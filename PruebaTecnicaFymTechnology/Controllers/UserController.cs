using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFymTechnology.Jwt;
using PruebaTecnicaFymTechnology.Models;
using PruebaTecnicaFymTechnology.Models.Dtos;
using PruebaTecnicaFymTechnology.Repository.IRepository;

namespace PruebaTecnicaFymTechnology.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IJwt _JWT;
        public UserController(IMapper mapper, IUserRepository userRepository, IJwt jwt)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _JWT = jwt;
        }

        // GET: api/<UserController>/get
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            var listUsers = _userRepository.GetUsers();
            var userDto = new List<UserDto>();

            foreach (var list in listUsers)
            {
                userDto.Add(_mapper.Map<UserDto>(list));
            }

            return Ok(userDto);
        }

        // GET api/<UserController>/details
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Details(int id)
        {
            var user = _userRepository.GetUser(id);

            if (user == null) return NotFound();

            var userDto = (_mapper.Map<UserDto>(user));
            
            return Ok(userDto);
        }

        // PATCH api/<UserController>/id
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Patch(int id, [FromBody] UserDto model)
        {
            if (!ModelState.IsValid || id != model.Id)
            {
                return BadRequest(ModelState);
            }

                // FALTA VALIDACIONES

            var user = _mapper.Map<User>(model);
   
            if (!_userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", $"Error al actualizar el usuario!. {user.Username}");
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("", new { Id = user.Id }, user);
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int id)
        {
            Boolean exist = _userRepository.ExistUser(id);

            if (!exist)
            {
                ModelState.AddModelError("", "El Usuario No Existe!.");
                return BadRequest(ModelState);
            }

            var user = _userRepository.GetUser(id);

            if (!_userRepository.DeleteUser(user))
            {
                ModelState.AddModelError("", $"Error al borrar la User!. {user.Username}");
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
