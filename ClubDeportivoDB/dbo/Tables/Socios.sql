CREATE TABLE [dbo].[Socios] (
    [IdSocio]         INT           IDENTITY (1, 1) NOT NULL,
    [Cedula]          NVARCHAR (50) NOT NULL,
    [NombreCompleto]  VARCHAR (50)  NOT NULL,
    [FechaNacimiento] DATE          NOT NULL,
    [FechaAlta]       DATE          NOT NULL,
    [Activo]          BIT           NOT NULL,
    CONSTRAINT [PK_Socio_IdSocio] PRIMARY KEY CLUSTERED ([IdSocio] ASC),
    CONSTRAINT [UK_Socio_Cedula] UNIQUE ([Cedula])
);

