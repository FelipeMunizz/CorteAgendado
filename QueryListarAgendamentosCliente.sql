select * from Agendamentos as a

inner join Clientes as c on a.ClienteId = c.Id
inner join Endereco as ed on c.EnderecoId = ed.Id