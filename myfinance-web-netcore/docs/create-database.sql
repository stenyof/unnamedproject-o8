-- Criação do banco de dados (caso ainda não exista)
CREATE DATABASE MyFinanceWeb;
GO

USE MyFinanceWeb;
GO

-- Criação da tabela PlanoConta
CREATE TABLE PlanoConta (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(20) NOT NULL,
    Descricao NVARCHAR(200) NULL
);
GO

-- Criação da tabela Transacao
CREATE TABLE Transacao (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Historico NVARCHAR(255) NULL,
    DataTransacao DATE NOT NULL,
    Valor DECIMAL(18,2) NOT NULL,
    PlanoContaId INT NOT NULL,
    FOREIGN KEY (PlanoContaId) REFERENCES PlanoConta(Id)
);
GO