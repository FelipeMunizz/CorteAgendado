CREATE TABLE Barbearia 
(   
 IdBarbearia INT IDENTITY(1,1) PRIMARY KEY, 
 Nome varchar(60), 
); 

CREATE TABLE EnderecoBarbearia 
( 
 IdEnderecoBarbearia INT IDENTITY(1,1) PRIMARY KEY, 
 Logradouro varchar(200),  
 Numero		varchar(100),  
 Cidade		varchar(100),  
 UF			INT,  
 CEP		varchar(20),  
 IdBarbearia INT,  
); 

CREATE TABLE ContatoBarbearia 
( 
 IdContatoBarbearia INT IDENTITY(1,1) PRIMARY KEY, 
 Telefone	varchar(11),  
 Email		varchar(100),  
 IsWhatsApp bit,  
 IdBarbearia INT,  
); 

CREATE TABLE Configuracao 
( 
 IdConfiguracao INT IDENTITY(1,1) PRIMARY KEY, 
 HoraFechamento varchar(10),  
 HoraInicio varchar(10),  
 IdBarbearia INT,  
); 

CREATE TABLE Pessoa 
( 
 IdPessoa INT IDENTITY(1,1) PRIMARY KEY, 
 Nome varchar(60),  
 Sobrenome varchar(90),  
 IdBarbearia INT,  
); 

CREATE TABLE Funcionario 
( 
 IdFuncionario INT IDENTITY(1,1) PRIMARY KEY, 
 TipoDoc INT,
 Documento varchar(14),  
 IdPessoa INT,  
); 

CREATE TABLE Cliente 
( 
 IdCliente INT IDENTITY(1,1) PRIMARY KEY, 
 IdPessoa INT,  
); 

CREATE TABLE EnderecoPessoa 
( 
 IdEnderecoPessoa INT IDENTITY(1,1) PRIMARY KEY, 
 Logradouro varchar(200),  
 Numero		varchar(100),  
 Cidade		varchar(100),  
 UF			INT,    
 CEP		varchar(20),  
 IdPessoa INT,  
); 

CREATE TABLE ContatoPessoa 
( 
 IdContadoPessoa INT IDENTITY(1,1) PRIMARY KEY, 
 Email		varchar(11),  
 Telefone	varchar(100),
 IsWhatsApp bit,    
 IdPessoa INT,  
); 

CREATE TABLE Servicos 
( 
 IdServico INT IDENTITY(1,1) PRIMARY KEY, 
 Servico varchar(70),  
 Descricao varchar(255),  
 TempoExecucao varchar(40),  
 IdBarbearia INT,  
); 

CREATE TABLE Agendamento 
( 
 IdAgendamento INT IDENTITY(1,1) PRIMARY KEY, 
 DataHoraAgendamento Date,  
 IdServico INT,  
 IdFuncionario INT,  
 IdCliente INT
); 

ALTER TABLE EnderecoBarbearia ADD FOREIGN KEY	(IdBarbearia) REFERENCES Barbearia      (IdBarbearia)
ALTER TABLE ContatoBarbearia ADD FOREIGN KEY	(IdBarbearia) REFERENCES Barbearia      (IdBarbearia)
ALTER TABLE Configuracao ADD FOREIGN KEY		(IdBarbearia) REFERENCES Barbearia      (IdBarbearia)
ALTER TABLE Pessoa ADD FOREIGN KEY				(IdBarbearia) REFERENCES Barbearia      (IdBarbearia)
ALTER TABLE Servicos ADD FOREIGN KEY			(IdBarbearia) REFERENCES Barbearia      (IdBarbearia)
ALTER TABLE Funcionario ADD FOREIGN KEY			(IdPessoa) REFERENCES Pessoa	        (IdPessoa)
ALTER TABLE Cliente ADD FOREIGN KEY				(IdPessoa) REFERENCES Pessoa	        (IdPessoa)
ALTER TABLE EnderecoPessoa ADD FOREIGN KEY		(IdPessoa) REFERENCES Pessoa	        (IdPessoa)
ALTER TABLE ContatoPessoa ADD FOREIGN KEY		(IdPessoa) REFERENCES Pessoa	        (IdPessoa)
ALTER TABLE Agendamento ADD FOREIGN KEY			(IdServico) REFERENCES Servicos        (IdServico)
ALTER TABLE Agendamento ADD FOREIGN KEY			(IdFuncionario) REFERENCES Funcionario  (IdFuncionario)
ALTER TABLE Agendamento ADD FOREIGN KEY			(IdCliente) REFERENCES Cliente			(IdCliente)
