CREATE PROCEDURE [dbo].[spCreateUpdateSocio]
	@IdSocio INT,
	@NombreCompleto VARCHAR(50) = NULL,
	@Cedula NVARCHAR(50) = NULL,	
	@FechaNacimiento DATE = NULL, 
	@Activo BIT = NULL
AS
	IF @IdSocio IS NULL
	BEGIN 
		INSERT INTO [dbo].[Socios] ([NombreCompleto], [Cedula], [FechaNacimiento], [Activo], [FechaAlta])
		VALUES (@NombreCompleto, @Cedula, @FechaNacimiento, @Activo, GETDATE())
		SET @IdSocio = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Socios]
		SET [NombreCompleto] = @NombreCompleto
			,[FechaNacimiento] = @FechaNacimiento
			,[Activo] = @Activo
		WHERE IdSocio = @IdSocio
	END
	SELECT @IdSocio AS IdSocio
RETURN 0
