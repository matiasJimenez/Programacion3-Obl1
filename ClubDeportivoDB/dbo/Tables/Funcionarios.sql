CREATE TABLE [dbo].[Funcionarios] (
    [IdFuncionario] INT           IDENTITY (1, 1) NOT NULL,
    [Mail]          NVARCHAR (50) NOT NULL,
    [Contraseña]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED ([IdFuncionario] ASC)
);

