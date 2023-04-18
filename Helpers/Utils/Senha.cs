using System.Security.Cryptography;
using System.Text;

namespace Helpers.Utils;

public static class Senha
{
    private static readonly Random random = new Random();

    private static readonly string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly string lowercase = "abcdefghijklmnopqrstuvwxyz";
    private static readonly string digits = "0123456789";
    private static readonly string specials = "!@#$%^&*()_+-=[]{}|;':\"<>,.?/~`";

    public static string GenerateRandomPassword(int length = 8)
    {
        StringBuilder passwordBuilder = new StringBuilder();

        passwordBuilder.Append(GetRandomChar(uppercase));
        passwordBuilder.Append(GetRandomChar(digits));
        passwordBuilder.Append(GetRandomChar(specials));

        for (int i = 3; i < length; i++)
        {
            string charSet = uppercase + lowercase + digits + specials;
            passwordBuilder.Append(GetRandomChar(charSet));
        }

        return new string(passwordBuilder.ToString().OrderBy(c => random.Next()).ToArray());
    }

    private static char GetRandomChar(string charSet)
    {
        int index = random.Next(charSet.Length);
        return charSet[index];
    }

    public static bool ValidaSenha(string senha)
    {
        if (senha.Length < 8) return false;

        if (!senha.Any(char.IsUpper)) return false;

        if (!senha.Any(char.IsDigit)) return false;

        if (!senha.Any(c => !char.IsLetterOrDigit(c))) return false;

        return true;
    }

    public static string CriptografarSenha(string senha)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
