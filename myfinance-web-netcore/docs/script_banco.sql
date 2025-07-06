
CREATE TABLE PlanoConta (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descricao NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(10) NOT NULL
);

CREATE TABLE Transacao (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Historico NVARCHAR(200),
    DataTransacao DATETIME NOT NULL,
    PlanoContaId INT NOT NULL,
    Valor DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (PlanoContaId) REFERENCES PlanoConta(Id)
);
