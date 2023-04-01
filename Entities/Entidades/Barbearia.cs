namespace Entities.Entidades;

public class Barbearia : Base
{
    public int ContatoId { get; set; }
    public int EnderecoId { get; set; }
    public int ConfiguracaoId { get; set; }
    public int ServicoId { get; set; }
    public virtual Contato Contato { get; set; }
    public virtual Endereco Endereco { get; set; }
    public virtual Configuracao Configuracao { get; set; }
    public virtual Servico Servico { get; set; }
}
