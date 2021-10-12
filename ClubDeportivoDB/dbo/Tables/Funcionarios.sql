CREATE TABLE [dbo].[Funcionarios] (
    [IdFuncionario] INT           IDENTITY (1, 1) NOT NULL,
    [Mail]          NVARCHAR (50) NOT NULL,
    [Contraseña]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Funcionarios_IdFuncionario] PRIMARY KEY CLUSTERED ([IdFuncionario] ASC),
    CONSTRAINT [UK_Funcionarios_Mail] UNIQUE ([Mail])
);

