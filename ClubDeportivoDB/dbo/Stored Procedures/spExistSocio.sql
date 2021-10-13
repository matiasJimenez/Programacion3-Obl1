CREATE PROCEDURE [dbo].[spExistSocio]
	@Cedula NVARCHAR(50)
AS
	SELECT s.[IdSocio]
			,s.[NombreCompleto]
			,s.[Cedula]
			,s.[FechaNacimiento]
			,s.[Activo]
			,s.[FechaAlta]
	FROM [dbo].[Socios] s
	WHERE s.[Cedula] = @Cedula
RETURN 0
