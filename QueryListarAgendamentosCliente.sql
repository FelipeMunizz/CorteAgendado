select a.Id, 
concat(c.Nome, ' ', c.Sobrenome) as NomeCompleto, 
concat(ed.Logradouro,' - ', ed.Numero, isnull(complemento,'')) as Endereco, 
ed.Cidade, 
ed.UF,
ct.Telefone,
ct.Email,
concat(f.Nome, ' ',f.Sobrenome) Funcionario,
s.Nome as Servico,
CONVERT(varchar, a.DataHoraAgendamento, 105) + ' ' + CONVERT(varchar, a.DataHoraAgendamento, 108) as DiaHorario

from Agendamentos as a

inner join Clientes as c on a.ClienteId = c.Id
inner join Endereco as ed on c.EnderecoId = ed.Id
inner join Contato as ct on c.ContatoId = ct.Id
inner join Servicos as s on a.ServicoId = s.Id
inner join Funcionarios as f on a.FuncionarioId = f.Id

where c.Id = a.ClienteId