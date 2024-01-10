using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFymTechnology.Jwt;
using PruebaTecnicaFymTechnology.Models;
using PruebaTecnicaFymTechnology.Models.Dtos;
using PruebaTecnicaFymTechnology.Repository;
using PruebaTecnicaFymTechnology.Repository.IRepository;

namespace PruebaTecnicaFymTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IJwt _JWT;

        public AuthController(IMapper mapper, IUserRepository userRepository, IRoleRepository roleRepository, IJwt jwt)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _JWT = jwt;
        }


        // POST api/<AuthController>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult register([FromBody] UserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Boolean Exist = _userRepository.ExistUser(model.Username);

            if (Exist)
            {
                ModelState.AddModelError("message", "El Usuario Ya Existe!.");
                return BadRequest(ModelState);
            }

            var role = _roleRepository.GetRol("Client");

            var user = _mapper.Map<User>(model);

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            if (!_userRepository.CreateUser(user))
            {
                ModelState.AddModelError("message", $"Error al guardar el usuario!. {user.Username}");
                return BadRequest(ModelState);
            }

            _roleRepository.CreateRoleUser(new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            return Ok();

        }


        // POST api/<AuthController>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoginDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Boolean Exist = _userRepository.ExistUser(model.Username);

            if (!Exist)
            {
                ModelState.AddModelError("", "El Usuario No Existe!.");
                return BadRequest(ModelState);
            }

            var user = _userRepository.GetUser(model.Username);

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

            if (!isPasswordCorrect)
            {
                ModelState.AddModelError("", "La contraseña ingresada No es Correcta.");
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("", new { }, new { token = _JWT.GenerarToken(user.Email, user.Username) });
        }
    }
}
