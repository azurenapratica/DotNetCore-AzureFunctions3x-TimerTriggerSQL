USE BaseProcessamento
GO

CREATE TABLE dbo.Log
(
    Id INT IDENTITY(1,1) NOT NULL,
    Horario DATETIME NOT NULL,
    Mensagem VARCHAR(1000) NOT NULL,
    CONSTRAINT PK_Log PRIMARY KEY(Id)
)