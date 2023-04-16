select 
	concat(p.Nome, ' ', p.Sobrenome) as NomeCompleto,
	CASE f.TipoDoc
		WHEN 1 THEN FORMAT(CONVERT(BIGINT, f.documento), '000\.000\.000\-00')
        WHEN 2 THEN 
				STUFF(
                STUFF(
                    STUFF(
                        FORMAT(CONVERT(BIGINT, f.documento), '00000000000000'),
                        3, 0, '.'
                    ),
                    7, 0, '/'
                ),
                12, 0, '-'
            )
        ELSE f.documento
    END AS Documento,
	case f.Cargo
		when 1 then 'Gerencia'
		when 2 then 'Barbeiro'
	end as Cargo,
	Concat(e.Logradouro, ' ', e.Numero, ' - ', e.Cidade) as Endereco

from Funcionario as f

inner join Pessoa as p on p.IdPessoa = f.IdPessoa
inner join ContatoPessoa as cp on cp.IdPessoa = p.IdPessoa
inner join EnderecoPessoa as e on e.IdPessoa = p.IdPessoa

