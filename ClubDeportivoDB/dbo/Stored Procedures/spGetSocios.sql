CREATE PROCEDURE [dbo].[spGetSocios]
	@Cedula nvarchar(50) = null
AS
	SELECT 
		s.IdSocio,
		s.NombreCompleto,
		s.Cedula,
		s.FechaNacimiento,
		s.Activo,
		s.FechaAlta
	FROM dbo.[Socios] s
	WHERE (@Cedula = s.Cedula or @Cedula is null)
RETURN 0
