namespace Helpers.Utils;

public static class Utils
{
    public static string RemoverCaracteresCpf(string cpf)
    {
        if (string.IsNullOrEmpty(cpf)) return cpf;

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11)
            throw new ArgumentException("CPF inválido.");

        return cpf;
    }

    public static string RemoverCaracteresCnpj(string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj)) return cnpj;

        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        if (cnpj.Length != 14)
            throw new ArgumentException("CNPJ inválido.");

        return cnpj;
    }
}
