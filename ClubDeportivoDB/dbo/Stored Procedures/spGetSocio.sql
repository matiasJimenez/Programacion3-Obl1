CREATE PROCEDURE [dbo].[spGetSocio]
	@IdSocio INT
AS
	SELECT s.[IdSocio]
			,s.[NombreCompleto]
			,s.[Cedula]
			,s.[FechaNacimiento]
			,s.[Activo]
			,s.[FechaAlta]
	FROM [dbo].[Socios] s
	WHERE s.[IdSocio] = @IdSocio
RETURN 0
