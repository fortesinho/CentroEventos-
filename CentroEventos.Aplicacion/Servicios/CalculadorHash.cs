using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion.Servicios;

public static class CalculadorHash
{
    public static string CalcularSha256(string contraseña)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(contraseña);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}