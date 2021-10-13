CREATE PROCEDURE [dbo].[spExistFuncionario]
	@Mail VARCHAR(50)
AS
	SELECT f.[IdFuncionario]
			,f.[Mail]
			,f.[Contraseña]
	FROM [dbo].[Funcionarios] f
	WHERE (f.[Mail] = @Mail)
RETURN 0
