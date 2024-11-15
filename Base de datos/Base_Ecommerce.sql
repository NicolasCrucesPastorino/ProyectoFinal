create DATABASE PruebaConNico

-- Tablas existentes

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[Precio] [money] NULL,
	[Stock] [int] NULL,
	[IdUsuario] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ARTICULOS] ADD  CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ARTICULOS]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO

CREATE TABLE [dbo].[CATEGORIAS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CATEGORIAS] ADD CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IMAGENES](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [IdArticulo] [int] NOT NULL,
    [ImagenUrl] [varchar](1000) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IMAGENES] ADD CONSTRAINT [PK_IMAGENES] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IMAGENES] WITH CHECK ADD CONSTRAINT [FK_IMAGENES_ARTICULOS] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[ARTICULOS] ([Id])
GO

ALTER TABLE [dbo].[IMAGENES] CHECK CONSTRAINT [FK_IMAGENES_ARTICULOS]
GO

CREATE TABLE [dbo].[MARCAS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MARCAS] ADD CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- Nuevas tablas

CREATE TABLE [dbo].[Rol](
    [idRol] [int] IDENTITY(1,1) NOT NULL,
    [Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Rol] ADD CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
    [idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TipoDocumentoVenta](
    [idTipoDocumentoVenta] [int] IDENTITY(1,1) NOT NULL,
    [Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TipoDocumentoVenta] ADD CONSTRAINT [PK_TipoDocumentoVenta] PRIMARY KEY CLUSTERED 
(
    [idTipoDocumentoVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[correo] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[idRol] [int] NULL,
	[urlFoto] [varchar](500) NULL,
	[nombreFoto] [varchar](100) NULL,
	[clave] [varchar](100) NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario] ADD PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO

--
CREATE TABLE [dbo].[Venta](
    [idVenta] [int] IDENTITY(1,1) NOT NULL,
    [numeroVenta] [varchar](6) NULL,
    [idTipoDocumentoVenta] [int] NULL,
    [idUsuario] [int] NULL,
    [documentoCliente] [varchar](10) NULL,
    [nombreCliente] [varchar](20) NULL,
    [subTotal] [decimal](10, 2) NULL,
    [impuestoTotal] [decimal](10, 2) NULL,
    [Total] [decimal](10, 2) NULL,
    [fechaRegistro] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Venta] ADD PRIMARY KEY CLUSTERED 
(
    [idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Venta] ADD DEFAULT (getdate()) FOR [fechaRegistro]
GO

ALTER TABLE [dbo].[Venta] WITH CHECK ADD FOREIGN KEY([idTipoDocumentoVenta])
REFERENCES [dbo].[TipoDocumentoVenta] ([idTipoDocumentoVenta])
GO

ALTER TABLE [dbo].[Venta] WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO

CREATE TABLE [dbo].[DetalleVenta](
    [idDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
    [idVenta] [int] NULL,
    [idProducto] [int] NULL,
    [marcaProducto] [varchar](100) NULL,
    [descripcionProducto] [varchar](100) NULL,
    [categoriaProducto] [varchar](100) NULL,
    [cantidad] [int] NULL,
    [precio] [decimal](10, 2) NULL,
    [total] [decimal](10, 2) NULL
) ON [PRIMARY]
GO

GO

ALTER TABLE [dbo].[DetalleVenta] ADD PRIMARY KEY CLUSTERED 
(
    [idDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DetalleVenta] WITH CHECK ADD CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY([idVenta])
REFERENCES [dbo].[Venta] ([idVenta])
GO

-- Relación con la tabla Articulos (si idProducto es parte de la tabla Articulos)
ALTER TABLE [dbo].[DetalleVenta] WITH CHECK ADD CONSTRAINT [FK_DetalleVenta_Articulos] FOREIGN KEY([idProducto])
REFERENCES [dbo].[ARTICULOS] ([Id])
GO
