USE [master]
GO
CREATE TABLE [dbo].[Reserva](
	[Id_Reserva] [int] IDENTITY(1,1) NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Id_Sala] [int] NOT NULL,
	[DescripcionReserva] [varchar](500) NOT NULL,
	[Fecha_Inicio] [datetime] NOT NULL,
	[Fecha_Fin] [datetime] NOT NULL,
	[Color_Reserva] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id_Reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Usuario]    Script Date: 30/3/2020 18:33:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Usuario](
	[Id_Rol_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Id_Rol] [int] NOT NULL,
 CONSTRAINT [PK_Rol_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_Rol_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 30/3/2020 18:33:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id_Rol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala_Reuniones]    Script Date: 30/3/2020 18:33:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala_Reuniones](
	[Id_Sala] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Sala] [varchar](200) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Sala_Reuniones] PRIMARY KEY CLUSTERED 
(
	[Id_Sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/3/2020 18:33:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nick_Name] [varchar](50) NOT NULL,
	[Nombre_Usuario] [varchar](100) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 
GO
INSERT [dbo].[Reserva] ([Id_Reserva], [Id_Usuario], [Id_Sala], [DescripcionReserva], [Fecha_Inicio], [Fecha_Fin], [Color_Reserva], [Estado]) VALUES (1, 2, 6, N'Entrega de prueba tecnica', CAST(N'2020-03-30T18:00:00.000' AS DateTime), CAST(N'2020-03-30T19:00:00.000' AS DateTime), N'rgb(25, 105, 44)', 1)
GO
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol_Usuario] ON 
GO
INSERT [dbo].[Rol_Usuario] ([Id_Rol_Usuario], [Id_Usuario], [Id_Rol]) VALUES (1, 3, 3)
GO
INSERT [dbo].[Rol_Usuario] ([Id_Rol_Usuario], [Id_Usuario], [Id_Rol]) VALUES (3, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Rol_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id_Rol], [NombreRol], [Estado]) VALUES (1, N'Administrador', 1)
GO
INSERT [dbo].[Roles] ([Id_Rol], [NombreRol], [Estado]) VALUES (3, N'Usuario Basico', 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Sala_Reuniones] ON 
GO
INSERT [dbo].[Sala_Reuniones] ([Id_Sala], [Nombre_Sala], [Descripcion], [Estado]) VALUES (6, N'Sala Principal', N'con proyector', 1)
GO
SET IDENTITY_INSERT [dbo].[Sala_Reuniones] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id_Usuario], [Nick_Name], [Nombre_Usuario], [Email], [Password], [Estado]) VALUES (2, N'Perdomo24', N'Roberto Perdomo', N'rperdomo32@gmail.com', N'AQAAAAEAACcQAAAAEHYuofKOZfqCas4no3mm1h3cCl0p7u4+pJhd84xWpfttguCpDGgjFpUAdC/q+Wc6mw==', 1)
GO
INSERT [dbo].[Usuario] ([Id_Usuario], [Nick_Name], [Nombre_Usuario], [Email], [Password], [Estado]) VALUES (3, N'Usuario1', N'Usuario Basico', N'rperdomo32@gmail.com', N'AQAAAAEAACcQAAAAELZoaonrUFA3iF+a0ml51W01EgPXOZs2EUNE5NAW4tODMAzD31hKWBmB/dmABy9ffg==', 1)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Sala_Reuniones] FOREIGN KEY([Id_Sala])
REFERENCES [dbo].[Sala_Reuniones] ([Id_Sala])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Sala_Reuniones]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO
ALTER TABLE [dbo].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Usuario_Roles] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Roles] ([Id_Rol])
GO
ALTER TABLE [dbo].[Rol_Usuario] CHECK CONSTRAINT [FK_Rol_Usuario_Roles]
GO
ALTER TABLE [dbo].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Usuario_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Rol_Usuario] CHECK CONSTRAINT [FK_Rol_Usuario_Usuario]
GO
USE [master]
GO
ALTER DATABASE [ReservaSalaReunionesDB] SET  READ_WRITE 
GO
