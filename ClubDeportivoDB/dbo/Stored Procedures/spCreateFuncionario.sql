CREATE PROCEDURE [dbo].[spCreateFuncionario]
	@IdFuncionario INT = NULL,
	@Mail NVARCHAR(50),
	@Contraseña NVARCHAR(50)
AS
	BEGIN 
		INSERT INTO [dbo].[Funcionarios] ([Mail], [Contraseña])
		VALUES (@Mail, @Contraseña)
		SET @IdFuncionario = SCOPE_IDENTITY();
	END
RETURN 0
