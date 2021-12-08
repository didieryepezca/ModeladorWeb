USE [master]
GO
/****** Object:  Database [ModeladorWeb]    Script Date: 7/12/2021 22:28:14 ******/
CREATE DATABASE [ModeladorWeb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ModeladorWeb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ModeladorWeb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ModeladorWeb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ModeladorWeb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ModeladorWeb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ModeladorWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ModeladorWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ModeladorWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ModeladorWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ModeladorWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ModeladorWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ModeladorWeb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ModeladorWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ModeladorWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ModeladorWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ModeladorWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ModeladorWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ModeladorWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ModeladorWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ModeladorWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ModeladorWeb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ModeladorWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ModeladorWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ModeladorWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ModeladorWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ModeladorWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ModeladorWeb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ModeladorWeb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ModeladorWeb] SET RECOVERY FULL 
GO
ALTER DATABASE [ModeladorWeb] SET  MULTI_USER 
GO
ALTER DATABASE [ModeladorWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ModeladorWeb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ModeladorWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ModeladorWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ModeladorWeb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ModeladorWeb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ModeladorWeb', N'ON'
GO
ALTER DATABASE [ModeladorWeb] SET QUERY_STORE = OFF
GO
USE [ModeladorWeb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Apellidos] [nvarchar](max) NULL,
	[Nombres] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_NIVEL]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NIVEL](
	[NivelID] [int] IDENTITY(1,1) NOT NULL,
	[ParentNivelID] [int] NULL,
	[Identificador] [varchar](100) NULL,
	[Nombre] [varchar](200) NULL,
	[ProyectoId] [int] NULL,
	[FechaCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NivelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_NIVEL_COLUMN_TITLES]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NIVEL_COLUMN_TITLES](
	[TituloID] [int] IDENTITY(1,1) NOT NULL,
	[proyectoID] [int] NOT NULL,
	[titulo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TituloID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_NIVEL_INFO]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NIVEL_INFO](
	[InfoID] [int] IDENTITY(1,1) NOT NULL,
	[NivelID] [int] NOT NULL,
	[Informacion] [varchar](max) NULL,
	[Usuario] [varchar](40) NULL,
	[FechaIngreso] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[InfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PERMISOS]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PERMISOS](
	[PermisoID] [int] IDENTITY(1,1) NOT NULL,
	[ProyectoID] [int] NOT NULL,
	[UsuarioCreacionId] [varchar](37) NULL,
	[UsuarioCreacionName] [varchar](100) NULL,
	[Permiso] [varchar](6) NULL,
	[UsuarioConcedidoId] [varchar](37) NULL,
	[UsuarioConcedidoName] [varchar](100) NULL,
	[FechaPermisoCreado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PROYECTO]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PROYECTO](
	[ProyectoID] [int] IDENTITY(1,1) NOT NULL,
	[NombreProyecto] [varchar](300) NULL,
	[DescripcionProyecto] [varchar](max) NULL,
	[FechaCreado] [datetime] NOT NULL,
	[FechaUltimaEdicion] [datetime] NOT NULL,
	[PropietarioID] [varchar](37) NOT NULL,
	[PropietarioName] [varchar](80) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProyectoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TREE]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TREE](
	[title] [varchar](500) NULL,
	[lazy] [bit] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parentId] [int] NULL,
	[proyectoId] [int] NULL,
	[fechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TREE_STYLE]    Script Date: 7/12/2021 22:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TREE_STYLE](
	[StyleID] [int] IDENTITY(1,1) NOT NULL,
	[NivelID] [int] NOT NULL,
	[style] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[StyleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211115141218_BaseDatosCambios', N'3.1.21')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Apellidos], [Nombres]) VALUES (N'6c76e003-7d0d-4492-a5a8-b98f4c1fb6a5', N'juvi203@hotmail.com', N'JUVI203@HOTMAIL.COM', N'juvi203@hotmail.com', N'JUVI203@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAELF2oCbmQVWDuXvHUTN1o2RVrVngJgn+gorGuvaL7r6g13/v/e7jlgF7WYzQLYS3+w==', N'XLDNM3FXBXWOMJIHNK5UJZWQH3KB23N3', N'5c5fc18b-d95c-47f4-93ce-ae21ae8151dc', NULL, 0, 0, NULL, 1, 0, N'VELASQUEZ', N'JUAN')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Apellidos], [Nombres]) VALUES (N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'didieryepezca@gmail.com', N'DIDIERYEPEZCA@GMAIL.COM', N'didieryepezca@gmail.com', N'DIDIERYEPEZCA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMln2ymFgHfeV1aLxla2gruRsWqprNo2WAJCSe6gTDLOgSJalQQE3jXJFXmYx8avGw==', N'R6MXVUFPBW2GT3KX4H5X5J2GVU5O6MFG', N'adf611c9-077c-48bf-affb-fcf4ac4e311d', NULL, 0, 0, NULL, 1, 0, N'YEPEZ', N'DIDIER')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Apellidos], [Nombres]) VALUES (N'f6b2cde6-0621-4113-82cd-036724955241', N'jairoquiroz@gmail.com', N'JAIROQUIROZ@GMAIL.COM', N'jairoquiroz@gmail.com', N'JAIROQUIROZ@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOMeKuuDFE5UYlI7bGqwC/HEzHX8vCjcvz9Qvj/KNuPekFwO+L9Mv3CW+o1FwBLYYw==', N'Z4JOGUFQ2BNJLBEZRD7CWFCPCUJETHMN', N'f15f6eac-ae44-4774-b194-35da35efbae1', NULL, 0, 0, NULL, 1, 0, N'QUIROZ', N'JAIRO')
GO
SET IDENTITY_INSERT [dbo].[TB_NIVEL] ON 

INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (1, 0, N'7454859663', N'UNIVERSIDAD TECNOLOGICA DEL PERU S.A.C (UTP)', 0, CAST(N'2021-11-16T20:54:20.733' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (2, 1, N'CONTRATO N° 75455845515', N'Servicio de Acceso a Internet', 0, CAST(N'2021-11-16T20:54:20.743' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (3, 1, N'CONTRATO N° 954389583433', N'Servicio de Interconexión de Sedes', 0, CAST(N'2021-11-16T20:54:20.743' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (4, 1, N'CONTRATO N° 987428421341', N'Servicio de Acceso dedicado a internet e interconexión de sedes (Arequipa)', 0, CAST(N'2021-11-16T20:54:20.743' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (9, 4, N'Sede Principal', N'Av. Petit Thouars 116, Lima, Lima, Lima', 0, CAST(N'2021-11-16T20:54:20.747' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (10, 4, N'Sede Callao', N'Av. Elmer Faucett 1234, Lima, Callao', 0, CAST(N'2021-11-16T20:54:20.747' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (11, 9, N'Circuito 001', N'Prefactibilidad 001', 0, CAST(N'2021-11-18T15:35:19.917' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (12, 9, N'Circuito 002', N'Prefactibilidad 002', 0, CAST(N'2021-11-18T15:36:50.160' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (13, 11, N'1.1.0', N'Pre - factibilidad 001', 0, CAST(N'2021-11-18T15:38:40.373' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (14, 11, N'1.1.1', N'Servicio de Acceso dedicado a Internet', 0, CAST(N'2021-11-18T15:39:07.473' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (15, 11, N'1.1.2', N'Servicio de Interconexión de datos', 0, CAST(N'2021-11-18T15:39:30.820' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (16, 14, N'a.', N'Equipamiento', 0, CAST(N'2021-11-18T15:40:31.413' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (17, 14, N'b.', N'Direcciones', 0, CAST(N'2021-11-18T15:40:42.357' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (18, 14, N'c.', N'Ancho de Banda', 0, CAST(N'2021-11-18T15:40:55.303' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (19, 14, N'd.', N'Servicio Gestionado: Seguridad Avanzada 4.0', 0, CAST(N'2021-11-18T15:42:14.957' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (20, 14, N'e.', N'Servicio Gestionado: SD-WAN', 0, CAST(N'2021-11-18T15:42:42.627' AS DateTime))
INSERT [dbo].[TB_NIVEL] ([NivelID], [ParentNivelID], [Identificador], [Nombre], [ProyectoId], [FechaCreacion]) VALUES (21, 14, N'f.', N'Servicio Gestionado: Monitoreo Netflow', 0, CAST(N'2021-11-18T15:43:15.373' AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_NIVEL] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ON 

INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (1, 0, N'TITULO 1')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (2, 0, N'TITULO 2222')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (4, 0, N'titulo 3333')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (8, 1, N'titulo 111 cableado estructurado')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (9, 1, N'titulo 2222 cableado estruc')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (10, 1, N'titulo 333 cableado estructurado')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (11, 0, N'titulo 4444')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (12, 0, N'titulo 55')
SET IDENTITY_INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_NIVEL_INFO] ON 

INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (1, 1, N'10000', N'DIDIER YEPEZ', CAST(N'2021-12-07T10:12:05.577' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (2, 1, N'Descripcion 2 Nivel', N'DIDIER YEPEZ', CAST(N'2021-11-26T16:35:30.413' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (3, 2, N'Acceso a internet comentario 112', N'DIDIER YEPEZ', CAST(N'2021-11-26T11:26:04.513' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (4, 2, N'acceso a internet comentario 2', N'DIDIER YEPEZ', CAST(N'2021-11-26T10:59:25.807' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (5, 3, N'12323', N'DIDIER YEPEZ', CAST(N'2021-11-30T08:41:56.463' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (6, 3, N'SIS 12313213', N'DIDIER YEPEZ', CAST(N'2021-11-30T08:42:05.590' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (7, 4, N'111111', N'DIDIER YEPEZ', CAST(N'2021-11-30T08:46:36.017' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (8, 4, N'septima infor', N'DIDIER YEPEZ', CAST(N'2021-11-26T12:12:18.407' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (9, 9, N'Primer Info de Sede Principal', N'MASTER', CAST(N'2021-11-19T08:07:03.577' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (10, 9, N'Segunda Info de Sede Principal', N'MASTER', CAST(N'2021-11-19T08:07:03.587' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (11, 10, N'Primer Info de Sede Callao', N'MASTER', CAST(N'2021-11-19T09:06:56.413' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (12, 10, N'Segunda Info de Sede Callao', N'MASTER', CAST(N'2021-11-19T09:06:56.423' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (13, 11, N'Primer Info de Circuito 001', N'MASTER', CAST(N'2021-11-19T09:09:04.420' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (14, 11, N'Segunda Info de Circuito 001', N'MASTER', CAST(N'2021-11-19T09:09:04.430' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (15, 12, N'Primer Info de Circuito 002', N'MASTER', CAST(N'2021-11-19T09:09:18.350' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (16, 12, N'Segunda Info de Circuito 002', N'MASTER', CAST(N'2021-11-19T09:09:18.360' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (17, 13, N'descripcion de Pre - factibilidad 001', N'MASTER', CAST(N'2021-11-19T09:15:01.117' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (18, 13, N'descripcion de Pre - factibilidad 001', N'MASTER', CAST(N'2021-11-19T09:15:01.117' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (19, 14, N'descripcion de Servicio de Acceso dedicado a Internet', N'MASTER', CAST(N'2021-11-19T09:15:33.600' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (20, 14, N'descripcion de Servicio de Acceso dedicado a Internet', N'MASTER', CAST(N'2021-11-19T09:15:33.610' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (21, 15, N'Primer info de Servicio de Interconexión de datos', N'MASTER', CAST(N'2021-11-19T09:20:26.647' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (22, 15, N'Segunda info de Servicio de Interconexión de datos', N'MASTER', CAST(N'2021-11-19T09:20:26.657' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (23, 16, N'Primer info de Equipamiento', N'MASTER', CAST(N'2021-11-19T09:21:09.130' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (24, 16, N'Segunda info de Equipamiento', N'MASTER', CAST(N'2021-11-19T09:21:09.130' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (25, 17, N'Primer info de Direcciones', N'MASTER', CAST(N'2021-11-19T09:50:02.457' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (26, 17, N'Segunda info de Direcciones', N'MASTER', CAST(N'2021-11-19T09:50:02.467' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (27, 18, N'Primer info de Ancho de Banda', N'MASTER', CAST(N'2021-11-19T09:50:27.613' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (28, 18, N'Segunda info de Ancho de Banda', N'MASTER', CAST(N'2021-11-19T09:50:27.613' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (29, 19, N'Primer info de Servicio Gestionado: Seguridad Avanzada 4.0', N'MASTER', CAST(N'2021-11-19T09:51:06.520' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (30, 19, N'Segunda info de Servicio Gestionado: Seguridad Avanzada 4.0', N'MASTER', CAST(N'2021-11-19T09:51:06.530' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (31, 20, N'Primer info de Servicio Gestionado: SD-WAN', N'MASTER', CAST(N'2021-11-19T09:51:50.407' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (32, 20, N'Segunda info de Servicio Gestionado: SD-WAN', N'MASTER', CAST(N'2021-11-19T09:51:50.417' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (33, 21, N'Primer info de Servicio Gestionado: Monitoreo Netflow', N'MASTER', CAST(N'2021-11-19T09:52:08.490' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (34, 21, N'Segunda info de Servicio Gestionado: Monitoreo Netflow', N'MASTER', CAST(N'2021-11-19T09:52:08.490' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (35, 1, N'tercera', N'DIDIER YEPEZ', CAST(N'2021-11-26T10:40:18.027' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (36, 1, N'cuarta', N'DIDIER YEPEZ', CAST(N'2021-11-26T10:40:22.150' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (37, 1, N'quinta', N'DIDIER YEPEZ', CAST(N'2021-11-26T10:40:34.937' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (38, 1, N'sexta informacion', N'DIDIER YEPEZ', CAST(N'2021-11-26T10:41:03.063' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (40, 1, N'SEPTIMA INFORMACION', N'DIDIER YEPEZ', CAST(N'2021-11-26T12:19:09.763' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (41, 1, N'OCTAVA INFORMACION NODO 1', N'DIDIER YEPEZ', CAST(N'2021-11-26T12:19:34.700' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (42, 1, N'OCTAVA INFORMACION NODO 1 update', N'DIDIER YEPEZ', CAST(N'2021-11-26T12:21:22.483' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (43, 1, N'NOVENA INFO UPDT', N'DIDIER YEPEZ', CAST(N'2021-11-26T12:45:58.080' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (44, 1, N'DECIMA INFO UPD', N'DIDIER YEPEZ', CAST(N'2021-11-26T12:46:15.173' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (45, 1, N'ONCEAVA UPD', N'DIDIER YEPEZ', CAST(N'2021-11-26T12:58:19.940' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (46, 2, N'tercera caja nivel 2', N'DIDIER YEPEZ', CAST(N'2021-11-26T15:42:56.840' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (47, 2, N'cuarta caja', N'DIDIER YEPEZ', CAST(N'2021-11-26T15:43:32.047' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (48, 2, N'QUINTA CAJA DEL NIVEL 2 y contando', N'DIDIER YEPEZ', CAST(N'2021-11-26T15:46:04.373' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (49, 2, N'SEXTA CAJA DEL NIVEL 2 y contando', N'DIDIER YEPEZ', CAST(N'2021-11-26T15:47:49.913' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (50, 32, N'PrimeraA caja de empresa de cableado estructurado', N'DIDIER YEPEZ', CAST(N'2021-11-26T16:19:15.693' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (51, 32, N'SEGUNDA CAJA DEL CABLEADO ESTRUCTURADO', N'DIDIER YEPEZ', CAST(N'2021-11-26T16:19:40.053' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (52, 32, N'TERCERA CAJA DEL CABLEADO ESTRUCTURADO', N'DIDIER YEPEZ', CAST(N'2021-11-26T16:19:46.303' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (53, 32, N'CUARTAaaaa CAJA CABLEADO ESTRUCTURADO', N'DIDIER YEPEZ', CAST(N'2021-11-26T16:21:48.790' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (54, 32, N'quintaaaaa caja cableado', N'DIDIER YEPEZ', CAST(N'2021-11-26T16:22:08.710' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (55, 1, N'DOCEAVAAAA', N'DIDIER YEPEZ', CAST(N'2021-11-26T16:35:56.920' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (56, 1, N'TRECEABA', N'DIDIER YEPEZ', CAST(N'2021-11-30T08:42:20.630' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (57, 32, N'sexta box cableadoooo', N'DIDIER YEPEZ', CAST(N'2021-12-02T17:32:40.150' AS DateTime))
INSERT [dbo].[TB_NIVEL_INFO] ([InfoID], [NivelID], [Informacion], [Usuario], [FechaIngreso]) VALUES (58, 32, N'septima box cableadoooo', N'DIDIER YEPEZ', CAST(N'2021-12-02T17:32:51.117' AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_NIVEL_INFO] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_PERMISOS] ON 

INSERT [dbo].[TB_PERMISOS] ([PermisoID], [ProyectoID], [UsuarioCreacionId], [UsuarioCreacionName], [Permiso], [UsuarioConcedidoId], [UsuarioConcedidoName], [FechaPermisoCreado]) VALUES (3, 1, N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ', N'EDITOR', N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ', CAST(N'2021-11-17T12:35:42.373' AS DateTime))
INSERT [dbo].[TB_PERMISOS] ([PermisoID], [ProyectoID], [UsuarioCreacionId], [UsuarioCreacionName], [Permiso], [UsuarioConcedidoId], [UsuarioConcedidoName], [FechaPermisoCreado]) VALUES (4, 2, N'6c76e003-7d0d-4492-a5a8-b98f4c1fb6a5', N'JUAN VELASQUEZ', N'VIEWER', N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ', CAST(N'2021-11-17T12:35:42.383' AS DateTime))
INSERT [dbo].[TB_PERMISOS] ([PermisoID], [ProyectoID], [UsuarioCreacionId], [UsuarioCreacionName], [Permiso], [UsuarioConcedidoId], [UsuarioConcedidoName], [FechaPermisoCreado]) VALUES (5, 2, N'6c76e003-7d0d-4492-a5a8-b98f4c1fb6a5', N'JUAN VELASQUEZ', N'EDITOR', N'6c76e003-7d0d-4492-a5a8-b98f4c1fb6a5', N'JUAN VELASQUEZ', CAST(N'2021-11-17T12:37:49.107' AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_PERMISOS] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_PROYECTO] ON 

INSERT [dbo].[TB_PROYECTO] ([ProyectoID], [NombreProyecto], [DescripcionProyecto], [FechaCreado], [FechaUltimaEdicion], [PropietarioID], [PropietarioName]) VALUES (1, N'CABLEADO ESTRUCTURADO', N'Descripcion del proyecto de cableado estructurado', CAST(N'2021-11-17T12:32:58.157' AS DateTime), CAST(N'2021-11-19T17:40:23.193' AS DateTime), N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ')
INSERT [dbo].[TB_PROYECTO] ([ProyectoID], [NombreProyecto], [DescripcionProyecto], [FechaCreado], [FechaUltimaEdicion], [PropietarioID], [PropietarioName]) VALUES (2, N'PROYECTO INSTALACION DE INTERNET', N'ESTA ES LA DESCRIPCION DEL SEGUNDO PROYECTO', CAST(N'2021-11-17T12:32:58.167' AS DateTime), CAST(N'2021-11-17T12:32:58.167' AS DateTime), N'6c76e003-7d0d-4492-a5a8-b98f4c1fb6a5', N'JUAN VELASQUEZ')
SET IDENTITY_INSERT [dbo].[TB_PROYECTO] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_TREE] ON 

INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'7454859663 - UNIVERSIDAD TECNOLOGICA DEL PERU S.A.C (UTP)', 1, 1, 0, 0, CAST(N'2021-11-23T15:29:20.763' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO N° 75455845515 - Servicio de Acceso a Internet', 1, 2, 1, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO N° 95438958343 - Servicio de Interconexión de Sedes', 1, 3, 1, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO N° 98742842134 - Servicio de Acceso dedicado a internet e interconexión de sedes (Arequipa)', 1, 4, 1, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Sede Principal - Av. Petit Thouars 116, Lima, Lima, Lima', 1, 5, 4, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Sede Callao - Av. Elmer Faucett 1234, Lima, Callao', 1, 6, 4, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Circuito 001 - Prefactibilidad 001', 1, 7, 5, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Circuito 002 - Prefactibilidad 002', 1, 8, 5, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Pre-factibilidad - 001', 1, 9, 7, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Servicio Acceso dedicado a internet - 001', 1, 10, 7, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'a. Equipamiento', 1, 11, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'b. Direcciones', 1, 12, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'c. Ancho de Banda', 1, 13, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'd. Servicio Gestionado: Seguridad Avanzada 4.0', 1, 14, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'e. Servicio Gestionado: SD-WAN', 1, 15, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'f. Servicio Gestionado: Monitoreo Netflow', 1, 16, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'75825154 - EMPRESA DE PY CABLEADO ESTRUCTURADO', 1, 32, 0, 1, CAST(N'2021-11-24T10:00:05.413' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRAT 1 - Instalacion de Internet', 1, 53, 32, 1, CAST(N'2021-11-24T11:33:45.607' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'EMPRESA DE PY INSTALACION DE INTERNET', 1, 54, 0, 2, CAST(N'2021-11-24T12:18:51.557' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'PRIMER CONTRATO - INSTALACION DE INTERNET', 1, 55, 54, 2, CAST(N'2021-11-24T12:22:52.867' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'SEGUNDO CONTRATO', 1, 56, 54, 2, CAST(N'2021-11-24T12:27:31.117' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO 2', 1, 57, 32, 1, CAST(N'2021-11-24T12:27:54.807' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO NUMERO 3', 1, 61, 32, 1, CAST(N'2021-11-24T16:10:04.897' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO NRO 4', 1, 63, 32, 1, CAST(N'2021-11-25T11:10:57.513' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Sede Principal del contrato nro 4', 1, 64, 63, 1, CAST(N'2021-11-25T11:11:19.873' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO NRO 5', 1, 66, 32, 1, CAST(N'2021-12-03T09:51:38.427' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Sub contrato nro 5', 1, 67, 66, 1, CAST(N'2021-12-03T09:52:02.853' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO nro 6', 1, 68, 32, 1, CAST(N'2021-12-03T10:18:42.697' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO HIJO 6.1', 1, 69, 68, 1, CAST(N'2021-12-03T10:19:07.427' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'CONTRATO HIJO 6.2', 1, 70, 68, 1, CAST(N'2021-12-03T10:19:25.830' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'6.1.1', 1, 71, 69, 1, CAST(N'2021-12-03T10:19:35.207' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'6.1.2', 1, 72, 69, 1, CAST(N'2021-12-03T10:19:45.270' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'6.1.1.1', 1, 73, 71, 1, CAST(N'2021-12-03T10:19:56.443' AS DateTime))
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion]) VALUES (N'Nodo 6.1.3', 1, 74, 69, 1, CAST(N'2021-12-03T10:20:08.523' AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_TREE] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_TREE_STYLE] ON 

INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (17, 1, N'Lime')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (18, 1, N'Aqua')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (20, 1, N'true')
SET IDENTITY_INSERT [dbo].[TB_TREE_STYLE] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 7/12/2021 22:28:14 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/12/2021 22:28:14 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 7/12/2021 22:28:14 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 7/12/2021 22:28:14 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 7/12/2021 22:28:14 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 7/12/2021 22:28:14 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/12/2021 22:28:14 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[TB_PERMISOS]  WITH CHECK ADD FOREIGN KEY([ProyectoID])
REFERENCES [dbo].[TB_PROYECTO] ([ProyectoID])
GO
USE [master]
GO
ALTER DATABASE [ModeladorWeb] SET  READ_WRITE 
GO
