namespace PruebaTecnicaFymTechnology.Jwt
{
    public interface IJwt
    {
        public string GenerarToken(string Email, string UserName);
    }
}
