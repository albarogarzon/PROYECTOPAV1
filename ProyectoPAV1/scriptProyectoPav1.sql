USE [PAVGarzonPassadore]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 10/10/2019 18:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfiles](
	[id_perfil] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[id_perfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Perfiles] ON
INSERT [dbo].[Perfiles] ([id_perfil], [nombre], [borrado]) VALUES (1, N'Administrador', 0)
INSERT [dbo].[Perfiles] ([id_perfil], [nombre], [borrado]) VALUES (2, N'Vendedor', 0)
INSERT [dbo].[Perfiles] ([id_perfil], [nombre], [borrado]) VALUES (3, N'Tester', 0)
SET IDENTITY_INSERT [dbo].[Perfiles] OFF
/****** Object:  Table [dbo].[Marcas]    Script Date: 10/10/2019 18:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marcas](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (1, N'Philips', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (2, N'Sony', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (3, N'Samsung', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (4, N'Siemens', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (5, N'Atma', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (6, N'Aura', 1)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (7, N'Aurora', 1)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (8, N'Aurora', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (9, N'ss', 1)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (10, N'ElectroLux', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (11, N'Moulinex', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (12, N'GAMA', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (13, N'Black & Decker', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (14, N'Surrey', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [borrado]) VALUES (15, N'Drean', 0)
SET IDENTITY_INSERT [dbo].[Marcas] OFF
/****** Object:  Table [dbo].[Facturas]    Script Date: 10/10/2019 18:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facturas](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[nro_factura] [int] NULL,
	[fecha] [date] NOT NULL,
	[id_usuario] [int] NULL,
	[nombreCliente] [varchar](50) NOT NULL,
	[subtotal] [decimal](18, 2) NOT NULL,
	[descuento] [decimal](18, 2) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Facturas] ON
INSERT [dbo].[Facturas] ([id_factura], [nro_factura], [fecha], [id_usuario], [nombreCliente], [subtotal], [descuento], [borrado]) VALUES (3, 0, CAST(0x32400B00 AS Date), 1, N'albaro', CAST(2760.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Facturas] ([id_factura], [nro_factura], [fecha], [id_usuario], [nombreCliente], [subtotal], [descuento], [borrado]) VALUES (4, 0, CAST(0x32400B00 AS Date), 1, N'norma', CAST(106000.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Facturas] OFF
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/10/2019 18:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_perfil] [int] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[estado] [varchar](10) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (1, 1, N'admin', N'123', N'admin@gmail.com', N'1', 0)
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (4, 3, N'usr2', N'1234', N'usr2@gmail.com', N'S', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (5, 2, N'testing', N'123', N'asd', N'S', 0)
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (6, 2, N'Albaro', N'123', N'albarogarzon@gmail.com', N'S', 0)
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (7, 2, N'Igna Passadore', N'123', N'ignacio@gmail.com', N'S', 0)
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (9, 3, N'test', N'123', N'testing', N'S', 0)
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (10, 3, N'Mañana', N'dd', N'gg', N'S', 1)
INSERT [dbo].[Usuarios] ([id_usuario], [id_perfil], [usuario], [password], [email], [estado], [borrado]) VALUES (11, 2, N'Tomas', N'123', N'tom@gmail.com', N'S', 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Productos]    Script Date: 10/10/2019 18:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[stock] [int] NOT NULL,
	[precioVenta] [int] NOT NULL,
	[marcaProducto] [int] NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (1, N'Heladera Electrolux', N'340 litros', 10, 1200, 10, 0)
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (2, N'Ventilador', N'Turbo', 5, 3000, 5, 0)
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (4, N'Smart TV', N'32 pulgadas', 10, 17000, 1, 0)
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (5, N'ventildor', N'test', 10, 120, 2, 1)
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (7, N'22', N'ss', 1, 1, 2, 1)
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (8, N'Lavarropas Drean', N'Automatico Eco Blanco', 5, 25000, 15, 0)
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (9, N'Aspiradora', N'1800W', 10, 7000, 1, 0)
INSERT [dbo].[Productos] ([id_producto], [nombre], [descripcion], [stock], [precioVenta], [marcaProducto], [borrado]) VALUES (10, N'Aire Acondicionado Split', N'Frio/Calor', 5, 47000, 14, 0)
SET IDENTITY_INSERT [dbo].[Productos] OFF
/****** Object:  Table [dbo].[FacturasDetalle]    Script Date: 10/10/2019 18:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturasDetalle](
	[id_factura_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_factura] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[precio_unitario] [decimal](18, 2) NOT NULL,
	[cantidad] [decimal](18, 0) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[id_factura_detalle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FacturasDetalle] ON
INSERT [dbo].[FacturasDetalle] ([id_factura_detalle], [id_factura], [id_producto], [precio_unitario], [cantidad], [borrado]) VALUES (5, 3, 1, CAST(1200.00 AS Decimal(18, 2)), CAST(2 AS Decimal(18, 0)), 0)
INSERT [dbo].[FacturasDetalle] ([id_factura_detalle], [id_factura], [id_producto], [precio_unitario], [cantidad], [borrado]) VALUES (6, 3, 5, CAST(120.00 AS Decimal(18, 2)), CAST(3 AS Decimal(18, 0)), 0)
INSERT [dbo].[FacturasDetalle] ([id_factura_detalle], [id_factura], [id_producto], [precio_unitario], [cantidad], [borrado]) VALUES (7, 4, 2, CAST(3000.00 AS Decimal(18, 2)), CAST(2 AS Decimal(18, 0)), 0)
INSERT [dbo].[FacturasDetalle] ([id_factura_detalle], [id_factura], [id_producto], [precio_unitario], [cantidad], [borrado]) VALUES (8, 4, 8, CAST(25000.00 AS Decimal(18, 2)), CAST(4 AS Decimal(18, 0)), 0)
SET IDENTITY_INSERT [dbo].[FacturasDetalle] OFF
/****** Object:  ForeignKey [FK__Productos__marca__3D5E1FD2]    Script Date: 10/10/2019 18:17:52 ******/
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK__Productos__marca__3D5E1FD2] FOREIGN KEY([marcaProducto])
REFERENCES [dbo].[Marcas] ([idMarca])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK__Productos__marca__3D5E1FD2]
GO
/****** Object:  ForeignKey [FK__DetalleFa__id_pr__0AD2A005]    Script Date: 10/10/2019 18:17:52 ******/
ALTER TABLE [dbo].[FacturasDetalle]  WITH CHECK ADD  CONSTRAINT [FK__DetalleFa__id_pr__0AD2A005] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[FacturasDetalle] CHECK CONSTRAINT [FK__DetalleFa__id_pr__0AD2A005]
GO
