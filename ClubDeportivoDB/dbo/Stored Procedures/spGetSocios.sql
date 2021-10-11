CREATE PROCEDURE [dbo].[spGetSocios]
	@Cedula nvarchar(50) = null
AS
	SELECT 
		S.IdSocio,
		S.NombreCompleto,
		S.Cedula,
		S.FechaNacimiento,
		S.Activo,
		S.FechaAlta
	FROM dbo.[Socios] S
	WHERE (@Cedula = S.Cedula or @Cedula is null)
RETURN 0
