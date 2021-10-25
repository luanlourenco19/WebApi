create database Locadora

create table Cliente (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Nome VARCHAR(40),
  CPF VARCHAR(40),
  DataNascimento DateTime,
  );


create table Filme (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Titulo VARCHAR(40),
  ClassificacaoIndicativa int,
  Lancamento TINYINT,
  );



create table Locacao (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Id_Cliente int,
  Id_Filme int,
  DataLocacao DateTime,
  DataDevolucao DateTime,

  CONSTRAINT FK_Locacao_Cliente FOREIGN KEY (Id_Cliente) REFERENCES Cliente (ID), 
  CONSTRAINT FK_Locacao_Filme FOREIGN KEY (Id_Filme) REFERENCES Filme (ID),
);