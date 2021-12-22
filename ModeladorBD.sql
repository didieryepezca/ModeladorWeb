USE [master]
GO
/****** Object:  Database [ModeladorWeb]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[TB_NIVEL]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[TB_NIVEL_COLUMN_TITLES]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[TB_NIVEL_INFO]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[TB_PERMISOS]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[TB_PROYECTO]    Script Date: 22/12/2021 14:01:58 ******/
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
/****** Object:  Table [dbo].[TB_TREE]    Script Date: 22/12/2021 14:01:58 ******/
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
	[descripcion] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TREE_STYLE]    Script Date: 22/12/2021 14:01:58 ******/
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
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (11, 0, N'titulo 4444')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (12, 0, N'titulo 55')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (163, 13, N'Titulo 1')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (164, 13, N'Titulo 2')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (165, 13, N'Titulo 3')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (166, 13, N'Titulo 4')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (167, 13, N'Titulo 5')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (168, 13, N'Titulo 6')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (169, 13, N'Titulo 7')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (170, 13, N'Titulo 8')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (171, 13, N'Titulo 9')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (172, 13, N'Titulo 10')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (173, 13, N'Titulo 11')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (174, 13, N'Titulo 12')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (175, 13, N'Titulo 13')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (176, 13, N'Titulo 14')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (177, 13, N'Titulo 15')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (178, 13, N'Titulo 16')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (179, 13, N'Titulo 17')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (180, 13, N'Titulo 18')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (181, 13, N'Titulo 19')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (182, 13, N'Titulo 20')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (183, 13, N'Titulo 21')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (184, 13, N'Titulo 22')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (185, 13, N'Titulo 23')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (186, 13, N'Titulo 24')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (187, 13, N'Titulo 25')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (188, 13, N'Titulo 26')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (189, 13, N'Titulo 27')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (190, 13, N'Titulo 28')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (191, 13, N'Titulo 29')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (192, 13, N'Titulo 30')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (193, 13, N'Titulo 31')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (194, 13, N'Titulo 32')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (195, 13, N'Titulo 33')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (196, 13, N'Titulo 34')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (197, 13, N'Titulo 35')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (198, 13, N'Titulo 36')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (199, 13, N'Titulo 37')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (200, 13, N'Titulo 38')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (201, 13, N'Titulo 39')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (202, 13, N'Titulo 40')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (203, 13, N'Titulo 41')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (204, 13, N'Titulo 42')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (205, 13, N'Titulo 43')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (206, 13, N'Titulo 44')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (207, 13, N'Titulo 45')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (208, 13, N'Titulo 46')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (209, 13, N'Titulo 47')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (210, 13, N'Titulo 48')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (211, 13, N'Titulo 49')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (212, 13, N'Titulo 50')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (213, 14, N'Titulo 1')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (214, 14, N'Titulo 2')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (215, 14, N'Titulo 3')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (216, 14, N'Titulo 4')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (217, 14, N'Titulo 5')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (218, 14, N'Titulo 6')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (219, 14, N'Titulo 7')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (220, 14, N'Titulo 8')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (221, 14, N'Titulo 9')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (222, 14, N'Titulo 10')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (223, 14, N'Titulo 11')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (224, 14, N'Titulo 12')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (225, 14, N'Titulo 13')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (226, 14, N'Titulo 14')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (227, 14, N'Titulo 15')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (228, 14, N'Titulo 16')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (229, 14, N'Titulo 17')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (230, 14, N'Titulo 18')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (231, 14, N'Titulo 19')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (232, 14, N'Titulo 20')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (233, 14, N'Titulo 21')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (234, 14, N'Titulo 22')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (235, 14, N'Titulo 23')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (236, 14, N'Titulo 24')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (237, 14, N'Titulo 25')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (238, 14, N'Titulo 26')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (239, 14, N'Titulo 27')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (240, 14, N'Titulo 28')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (241, 14, N'Titulo 29')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (242, 14, N'Titulo 30')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (243, 14, N'Titulo 31')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (244, 14, N'Titulo 32')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (245, 14, N'Titulo 33')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (246, 14, N'Titulo 34')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (247, 14, N'Titulo 35')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (248, 14, N'Titulo 36')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (249, 14, N'Titulo 37')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (250, 14, N'Titulo 38')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (251, 14, N'Titulo 39')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (252, 14, N'Titulo 40')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (253, 14, N'Titulo 41')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (254, 14, N'Titulo 42')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (255, 14, N'Titulo 43')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (256, 14, N'Titulo 44')
GO
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (257, 14, N'Titulo 45')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (258, 14, N'Titulo 46')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (259, 14, N'Titulo 47')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (260, 14, N'Titulo 48')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (261, 14, N'Titulo 49')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (262, 14, N'Titulo 50')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (313, 0, N'TITULO 6')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (314, 0, N'TITULO 7')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (315, 0, N'TITULO 8')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (316, 0, N'TITULO 9')
INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] ([TituloID], [proyectoID], [titulo]) VALUES (317, 0, N'TITULO 10')
SET IDENTITY_INSERT [dbo].[TB_NIVEL_COLUMN_TITLES] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_NIVEL_INFO] ON 

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
SET IDENTITY_INSERT [dbo].[TB_NIVEL_INFO] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_PERMISOS] ON 

INSERT [dbo].[TB_PERMISOS] ([PermisoID], [ProyectoID], [UsuarioCreacionId], [UsuarioCreacionName], [Permiso], [UsuarioConcedidoId], [UsuarioConcedidoName], [FechaPermisoCreado]) VALUES (17, 13, N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ', N'EDITOR', N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ', CAST(N'2021-12-10T13:23:09.350' AS DateTime))
INSERT [dbo].[TB_PERMISOS] ([PermisoID], [ProyectoID], [UsuarioCreacionId], [UsuarioCreacionName], [Permiso], [UsuarioConcedidoId], [UsuarioConcedidoName], [FechaPermisoCreado]) VALUES (18, 14, N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ', N'EDITOR', N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ', CAST(N'2021-12-16T11:04:06.633' AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_PERMISOS] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_PROYECTO] ON 

INSERT [dbo].[TB_PROYECTO] ([ProyectoID], [NombreProyecto], [DescripcionProyecto], [FechaCreado], [FechaUltimaEdicion], [PropietarioID], [PropietarioName]) VALUES (13, N'PROYECTO 1', N'Primer proyecto', CAST(N'2021-12-10T13:23:09.123' AS DateTime), CAST(N'2021-12-10T13:23:09.123' AS DateTime), N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ')
INSERT [dbo].[TB_PROYECTO] ([ProyectoID], [NombreProyecto], [DescripcionProyecto], [FechaCreado], [FechaUltimaEdicion], [PropietarioID], [PropietarioName]) VALUES (14, N'TEST 1', N'TEST 1', CAST(N'2021-12-16T11:04:06.380' AS DateTime), CAST(N'2021-12-16T11:04:06.380' AS DateTime), N'7440186e-29c7-4030-92a2-8aa0b357d92f', N'DIDIER YEPEZ')
SET IDENTITY_INSERT [dbo].[TB_PROYECTO] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_TREE] ON 

INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'7454859663 - UNIVERSIDAD TECNOLOGICA DEL PERU S.A.C (UTP)', 1, 1, 0, 0, CAST(N'2021-11-23T15:29:20.763' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'CONTRATO N° 75455845515 - Servicio de Acceso a Internet', 1, 2, 1, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'CONTRATO N° 95438958343 - Servicio de Interconexión de Sedes', 1, 3, 1, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'CONTRATO N° 98742842134 - Servicio de Acceso dedicado a internet e interconexión de sedes (Arequipa)', 1, 4, 1, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Sede Principal - Av. Petit Thouars 116, Lima, Lima, Lima', 1, 5, 4, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Sede Callao - Av. Elmer Faucett 1234, Lima, Callao', 1, 6, 3, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Circuito 001 - Prefactibilidad 001', 1, 7, 5, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Circuito 002 - Prefactibilidad 002', 1, 8, 5, 0, CAST(N'2021-11-23T15:29:20.773' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Pre-factibilidad - 001', 1, 9, 7, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Servicio Acceso dedicado a internet - 001', 1, 10, 7, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'a. Equipamiento', 1, 11, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'b. Direcciones', 1, 12, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'c. Ancho de Banda', 1, 13, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'd. Servicio Gestionado: Seguridad Avanzada 4.0', 1, 14, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'e. Servicio Gestionado: SD-WAN', 1, 15, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'f. Servicio Gestionado: Monitoreo Netflow', 1, 16, 10, 0, CAST(N'2021-11-23T15:29:20.777' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'PROYECTO 1', 1, 240, 0, 13, CAST(N'2021-12-10T13:23:09.360' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'MODELACION 1', 1, 241, 240, 13, CAST(N'2021-12-10T13:23:59.190' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'1. SEDE 1', 1, 247, 241, 13, CAST(N'2021-12-10T14:40:55.013' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'2. SEDE 2', 1, 248, 241, 13, CAST(N'2021-12-10T14:40:55.027' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'3. SEDE 3.2', 1, 249, 241, 13, CAST(N'2021-12-10T14:40:55.030' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Pre Factibilidad', 1, 250, 248, 13, CAST(N'2021-12-13T09:18:00.770' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Requisitos', 1, 251, 248, 13, CAST(N'2021-12-13T09:18:12.590' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'5. SEDE 4.2', 1, 252, 253, 13, CAST(N'2021-12-13T09:57:05.957' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'MODELACION 2', 1, 253, 240, 13, CAST(N'2021-12-13T09:57:19.723' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'MODELACION 3', 1, 254, 240, 13, CAST(N'2021-12-13T09:59:14.247' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'4. SEDE 4.2', 1, 255, 241, 13, CAST(N'2021-12-13T10:02:29.730' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'TEST 1', 1, 279, 0, 14, CAST(N'2021-12-16T11:04:06.647' AS DateTime), N'COMENTARIO CABECERA 1')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'1. MODELACION  1', 1, 286, 279, 14, CAST(N'2021-12-16T11:19:33.770' AS DateTime), N'comment 1')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'2. MODELACION  2', 1, 287, 279, 14, CAST(N'2021-12-16T11:19:33.773' AS DateTime), N'comment 2')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'1. Item 1', 1, 288, 286, 14, CAST(N'2021-12-16T11:21:22.127' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'2. Item 2', 1, 289, 286, 14, CAST(N'2021-12-16T11:21:22.337' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'3. Item 3', 1, 290, 286, 14, CAST(N'2021-12-16T11:21:22.340' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'4. Item 4', 1, 291, 286, 14, CAST(N'2021-12-16T11:21:22.340' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'5. Item 5', 1, 292, 286, 14, CAST(N'2021-12-16T11:21:22.343' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'6. Item 6', 1, 293, 286, 14, CAST(N'2021-12-16T11:21:22.343' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'7. Item 7', 1, 294, 286, 14, CAST(N'2021-12-16T11:21:22.347' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'8. Item 8', 1, 295, 286, 14, CAST(N'2021-12-16T11:21:22.347' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'9. Item 9', 1, 296, 286, 14, CAST(N'2021-12-16T11:21:22.347' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'10. Item 10', 1, 297, 286, 14, CAST(N'2021-12-16T11:21:22.350' AS DateTime), NULL)
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'3. MODELACION 3', 1, 421, 279, 14, CAST(N'2021-12-21T13:05:29.377' AS DateTime), N'comment 3')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'4. MODELACION 4.1.1', 1, 424, 279, 14, CAST(N'2021-12-21T13:07:30.390' AS DateTime), N'comentario del nodo 4.1')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'MOD 4.1.2.1', 1, 428, 424, 14, CAST(N'2021-12-21T14:18:43.087' AS DateTime), N'comentario 6')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'SUBHIJO 4.2', 1, 431, 424, 14, CAST(N'2021-12-21T19:27:45.640' AS DateTime), N'comentario de subhijo')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'5. SEDE PRINCIPAL', 1, 433, 279, 14, CAST(N'2021-12-22T10:31:28.190' AS DateTime), N'Av. Petit Thouars 116, ')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Coordenadas', 1, 434, 433, 14, CAST(N'2021-12-22T10:42:41.577' AS DateTime), N'116343432, 24323424')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Dirección', 1, 435, 433, 14, CAST(N'2021-12-22T10:43:20.690' AS DateTime), N'Av. Petit Thouars 116')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Distrito', 1, 436, 433, 14, CAST(N'2021-12-22T10:43:58.433' AS DateTime), N'Cercado de Lima')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Provincia', 1, 437, 433, 14, CAST(N'2021-12-22T10:44:06.490' AS DateTime), N'Lima')
INSERT [dbo].[TB_TREE] ([title], [lazy], [id], [parentId], [proyectoId], [fechaCreacion], [descripcion]) VALUES (N'Departamento', 1, 438, 433, 14, CAST(N'2021-12-22T10:44:24.827' AS DateTime), N'Lima')
SET IDENTITY_INSERT [dbo].[TB_TREE] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_TREE_STYLE] ON 

INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (20, 1, N'true')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (21, 240, N'bold')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (22, 240, N'bold')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (23, 240, N'true')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (24, 240, N'true')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (26, 280, N'bold')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (27, 280, N'true')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (28, 415, N'bold')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (29, 415, N'italic')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (30, 415, N'true')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (32, 279, N'bold')
INSERT [dbo].[TB_TREE_STYLE] ([StyleID], [NivelID], [style]) VALUES (33, 279, N'true')
SET IDENTITY_INSERT [dbo].[TB_TREE_STYLE] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 22/12/2021 14:01:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 22/12/2021 14:01:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 22/12/2021 14:01:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 22/12/2021 14:01:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 22/12/2021 14:01:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 22/12/2021 14:01:59 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 22/12/2021 14:01:59 ******/
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
