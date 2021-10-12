CREATE PROCEDURE [dbo].[spGetFuncionario]
	@Mail VARCHAR(50),
	@Contraseña NVARCHAR(50)
AS
	SELECT f.[IdFuncionario]
			,f.[Mail]
			,f.[Contraseña]
	FROM [dbo].[Funcionarios] f
	WHERE (f.[Mail] = @Mail) AND
		(f.[Contraseña] = @Contraseña)
RETURN 0

