USE [master]
GO
/****** Object:  Database [MiDoc]    Script Date: 24/05/2021 10:50:43 ******/
CREATE DATABASE [MiDoc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MiDoc', FILENAME = N'D:\rdsdbdata\DATA\MiDoc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'MiDoc_log', FILENAME = N'D:\rdsdbdata\DATA\MiDoc_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MiDoc] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiDoc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MiDoc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MiDoc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MiDoc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MiDoc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MiDoc] SET ARITHABORT OFF 
GO
ALTER DATABASE [MiDoc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MiDoc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MiDoc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MiDoc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MiDoc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MiDoc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MiDoc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MiDoc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MiDoc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MiDoc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MiDoc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MiDoc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MiDoc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MiDoc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MiDoc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MiDoc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MiDoc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MiDoc] SET RECOVERY FULL 
GO
ALTER DATABASE [MiDoc] SET  MULTI_USER 
GO
ALTER DATABASE [MiDoc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MiDoc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MiDoc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MiDoc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MiDoc] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MiDoc] SET QUERY_STORE = OFF
GO
USE [MiDoc]
GO
/****** Object:  User [adrua]    Script Date: 24/05/2021 10:50:48 ******/
CREATE USER [adrua] FOR LOGIN [adrua] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [adrua]
GO
/****** Object:  Schema [CNT]    Script Date: 24/05/2021 10:50:49 ******/
CREATE SCHEMA [CNT]
GO
/****** Object:  Schema [inv]    Script Date: 24/05/2021 10:50:49 ******/
CREATE SCHEMA [inv]
GO
/****** Object:  Table [CNT].[Bancos]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CNT].[Bancos](
	[BancoId] [int] IDENTITY(1,1) NOT NULL,
	[BancoNombre] [nvarchar](22) NULL,
	[BancoLongitud] [int] NOT NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fecha_Impresion] [datetime2](7) NULL,
	[Fecha_Reimpresion] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_Bancos] PRIMARY KEY CLUSTERED 
(
	[BancoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CNT].[Ciudades]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CNT].[Ciudades](
	[CiudadDepartamentoId] [int] NOT NULL,
	[Ciudadid] [int] NOT NULL,
	[CntComp] [nvarchar](max) NULL,
	[CiudadCodigoPoblado] [decimal](8, 0) NOT NULL,
	[CiudadNombreDepartamento] [nvarchar](60) NULL,
	[CiudadNombreCiudad] [nvarchar](68) NULL,
	[CiudadNombrePoblado] [nvarchar](68) NULL,
	[CiudadTipoMunicipio] [nvarchar](5) NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fecha_Impresion] [datetime2](7) NULL,
	[Fecha_Reimpresion] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[CiudadDepartamentoId] ASC,
	[Ciudadid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CNT].[Clientes]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CNT].[Clientes](
	[ClienteId] [decimal](6, 0) NOT NULL,
	[ClienteClasificacion] [int] NOT NULL,
	[ClienteTipoID] [int] NOT NULL,
	[ClienteNit] [nvarchar](20) NULL,
	[CodigoCiiuId] [nvarchar](6) NULL,
	[ClienteEstado] [int] NOT NULL,
	[ClienteRazonSocial] [nvarchar](111) NULL,
	[ClienteDireccion] [nvarchar](90) NULL,
	[CiudadDepartamentoId] [int] NOT NULL,
	[Ciudadid] [int] NOT NULL,
	[CntComp] [nvarchar](max) NULL,
	[ClienteTelefono] [nvarchar](20) NULL,
	[ClienteCelular] [nvarchar](24) NULL,
	[ClienteEmail] [nvarchar](150) NULL,
	[ClienteContacto] [nvarchar](36) NULL,
	[ClienteTelefonoContacto] [nvarchar](20) NULL,
	[ClienteEmailContacto] [nvarchar](150) NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fecha_Impresion] [datetime2](7) NULL,
	[Fecha_Reimpresion] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CNT].[CodigosCiiu]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CNT].[CodigosCiiu](
	[CodigoCiiuId] [nvarchar](6) NOT NULL,
	[CodigoCiiuDescripcion] [nvarchar](246) NULL,
	[CodigoCiiuclase] [bit] NOT NULL,
	[CodigoCiiugrupo] [bit] NOT NULL,
	[CodigoCiiudivision] [bit] NOT NULL,
	[CodigoCiiuBloqueo] [bit] NOT NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fecha_Impresion] [datetime2](7) NULL,
	[Fecha_Reimpresion] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_CodigosCiiu] PRIMARY KEY CLUSTERED 
(
	[CodigoCiiuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CNT].[FacturaMovimientos]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CNT].[FacturaMovimientos](
	[FacturaId] [int] NOT NULL,
	[FacturaSerie] [int] NOT NULL,
	[ProductoLinea] [nvarchar](8) NOT NULL,
	[CntComp] [nvarchar](max) NULL,
	[FacturaMovimientoCantidad] [decimal](4, 2) NOT NULL,
	[FacturaMovimientoValorUnidad] [decimal](18, 2) NOT NULL,
	[FacturaMovimientoTotal] [decimal](18, 2) NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_FacturaMovimientos] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC,
	[FacturaSerie] ASC,
	[ProductoLinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CNT].[Facturas]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CNT].[Facturas](
	[FacturaId] [int] NOT NULL,
	[FacturaSerie] [int] NOT NULL,
	[CntComp] [nvarchar](max) NULL,
	[FacturaFecha] [datetime2](7) NOT NULL,
	[ClienteId] [decimal](6, 0) NOT NULL,
	[FacturaValor] [decimal](18, 2) NULL,
	[FacturaValorNoGravado] [decimal](18, 2) NOT NULL,
	[FacturaImpuestos] [decimal](18, 2) NULL,
	[FacturaTotal] [decimal](18, 2) NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fecha_Impresion] [datetime2](7) NULL,
	[Fecha_Reimpresion] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC,
	[FacturaSerie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/05/2021 10:50:49 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 24/05/2021 10:50:49 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 24/05/2021 10:50:49 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 24/05/2021 10:50:49 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 24/05/2021 10:50:49 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 24/05/2021 10:50:49 ******/
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceCodes]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceCodes](
	[UserCode] [nvarchar](200) NOT NULL,
	[DeviceCode] [nvarchar](200) NOT NULL,
	[SubjectId] [nvarchar](200) NULL,
	[ClientId] [nvarchar](200) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[Expiration] [datetime2](7) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DeviceCodes] PRIMARY KEY CLUSTERED 
(
	[UserCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersistedGrants]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersistedGrants](
	[Key] [nvarchar](200) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[SubjectId] [nvarchar](200) NULL,
	[ClientId] [nvarchar](200) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[Expiration] [datetime2](7) NULL,
	[Data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PersistedGrants] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [inv].[Productos]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [inv].[Productos](
	[ProductoLinea] [nvarchar](8) NOT NULL,
	[ProductoDescripcion] [nvarchar](75) NULL,
	[ProductoSaldo] [decimal](6, 2) NULL,
	[ProductoCosto] [decimal](18, 2) NULL,
	[ProductoPrecio] [decimal](18, 2) NOT NULL,
	[Productoiva] [decimal](8, 4) NOT NULL,
	[ProductoUnidad] [int] NOT NULL,
	[ProductoCodigoBarra] [nvarchar](15) NULL,
	[ProductoCantidadMinima] [decimal](6, 2) NOT NULL,
	[ProductoCantidadMaxima] [decimal](6, 2) NOT NULL,
	[ProductoUbicacion] [nvarchar](10) NULL,
	[ProductoTipo] [int] NOT NULL,
	[ProductoControlSaldo] [bit] NOT NULL,
	[ProductoObservaciones] [nvarchar](max) NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fecha_Impresion] [datetime2](7) NULL,
	[Fecha_Reimpresion] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ProductoLinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [inv].[Saldos]    Script Date: 24/05/2021 10:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [inv].[Saldos](
	[ProductoLinea] [nvarchar](8) NOT NULL,
	[PeriodoDescripcionx] [nvarchar](15) NOT NULL,
	[invComp] [nvarchar](max) NULL,
	[InvSaldosCantidad] [decimal](6, 2) NOT NULL,
	[InvSaldosValor] [decimal](6, 2) NOT NULL,
	[InvSaldosTotal] [decimal](7, 2) NULL,
	[InvSaldosValorPromedio] [decimal](6, 2) NULL,
	[InvSaldosUltimoValor] [decimal](6, 2) NULL,
	[InvSaldosMaximoValor] [decimal](6, 2) NULL,
	[Fecha_Computador] [datetime2](7) NULL,
	[Fuente] [nvarchar](32) NULL,
	[FuenteImport] [nvarchar](32) NULL,
	[Proceso] [int] NULL,
	[Usuario] [nvarchar](255) NULL,
 CONSTRAINT [PK_Saldos] PRIMARY KEY CLUSTERED 
(
	[ProductoLinea] ASC,
	[PeriodoDescripcionx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Clientes_CiudadDepartamentoId_Ciudadid]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_Clientes_CiudadDepartamentoId_Ciudadid] ON [CNT].[Clientes]
(
	[CiudadDepartamentoId] ASC,
	[Ciudadid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Clientes_CodigoCiiuId]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_Clientes_CodigoCiiuId] ON [CNT].[Clientes]
(
	[CodigoCiiuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FacturaMovimientos_ProductoLinea]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_FacturaMovimientos_ProductoLinea] ON [CNT].[FacturaMovimientos]
(
	[ProductoLinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Facturas_ClienteId]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_Facturas_ClienteId] ON [CNT].[Facturas]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 24/05/2021 10:50:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 24/05/2021 10:50:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DeviceCodes_DeviceCode]    Script Date: 24/05/2021 10:50:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DeviceCodes_DeviceCode] ON [dbo].[DeviceCodes]
(
	[DeviceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DeviceCodes_Expiration]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_DeviceCodes_Expiration] ON [dbo].[DeviceCodes]
(
	[Expiration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersistedGrants_Expiration]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_Expiration] ON [dbo].[PersistedGrants]
(
	[Expiration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PersistedGrants_SubjectId_ClientId_Type]    Script Date: 24/05/2021 10:50:49 ******/
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [dbo].[PersistedGrants]
(
	[SubjectId] ASC,
	[ClientId] ASC,
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [CNT].[Bancos] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [CNT].[Bancos] ADD  DEFAULT (N'CP3121') FOR [Fuente]
GO
ALTER TABLE [CNT].[Bancos] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [CNT].[Ciudades] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [CNT].[Ciudades] ADD  DEFAULT (N'CP3110') FOR [Fuente]
GO
ALTER TABLE [CNT].[Ciudades] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [CNT].[Clientes] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [CNT].[Clientes] ADD  DEFAULT (N'CP3024') FOR [Fuente]
GO
ALTER TABLE [CNT].[Clientes] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [CNT].[CodigosCiiu] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [CNT].[CodigosCiiu] ADD  DEFAULT (N'CP3000') FOR [Fuente]
GO
ALTER TABLE [CNT].[CodigosCiiu] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [CNT].[FacturaMovimientos] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [CNT].[FacturaMovimientos] ADD  DEFAULT (N'CP4123') FOR [Fuente]
GO
ALTER TABLE [CNT].[FacturaMovimientos] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [CNT].[Facturas] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [CNT].[Facturas] ADD  DEFAULT (N'CP4123') FOR [Fuente]
GO
ALTER TABLE [CNT].[Facturas] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [inv].[Productos] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [inv].[Productos] ADD  DEFAULT (N'CP4124') FOR [Fuente]
GO
ALTER TABLE [inv].[Productos] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [inv].[Saldos] ADD  DEFAULT (getdate()) FOR [Fecha_Computador]
GO
ALTER TABLE [inv].[Saldos] ADD  DEFAULT (N'CP4124') FOR [Fuente]
GO
ALTER TABLE [inv].[Saldos] ADD  DEFAULT (user_name()) FOR [Usuario]
GO
ALTER TABLE [CNT].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Ciudades_CiudadDepartamentoId_Ciudadid] FOREIGN KEY([CiudadDepartamentoId], [Ciudadid])
REFERENCES [CNT].[Ciudades] ([CiudadDepartamentoId], [Ciudadid])
GO
ALTER TABLE [CNT].[Clientes] CHECK CONSTRAINT [FK_Clientes_Ciudades_CiudadDepartamentoId_Ciudadid]
GO
ALTER TABLE [CNT].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_CodigosCiiu_CodigoCiiuId] FOREIGN KEY([CodigoCiiuId])
REFERENCES [CNT].[CodigosCiiu] ([CodigoCiiuId])
GO
ALTER TABLE [CNT].[Clientes] CHECK CONSTRAINT [FK_Clientes_CodigosCiiu_CodigoCiiuId]
GO
ALTER TABLE [CNT].[FacturaMovimientos]  WITH CHECK ADD  CONSTRAINT [FK_FacturaMovimientos_Facturas_FacturaId_FacturaSerie] FOREIGN KEY([FacturaId], [FacturaSerie])
REFERENCES [CNT].[Facturas] ([FacturaId], [FacturaSerie])
ON DELETE CASCADE
GO
ALTER TABLE [CNT].[FacturaMovimientos] CHECK CONSTRAINT [FK_FacturaMovimientos_Facturas_FacturaId_FacturaSerie]
GO
ALTER TABLE [CNT].[FacturaMovimientos]  WITH CHECK ADD  CONSTRAINT [FK_FacturaMovimientos_Productos_ProductoLinea] FOREIGN KEY([ProductoLinea])
REFERENCES [inv].[Productos] ([ProductoLinea])
GO
ALTER TABLE [CNT].[FacturaMovimientos] CHECK CONSTRAINT [FK_FacturaMovimientos_Productos_ProductoLinea]
GO
ALTER TABLE [CNT].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [CNT].[Clientes] ([ClienteId])
GO
ALTER TABLE [CNT].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes_ClienteId]
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
ALTER TABLE [inv].[Saldos]  WITH CHECK ADD  CONSTRAINT [FK_Saldos_Productos_ProductoLinea] FOREIGN KEY([ProductoLinea])
REFERENCES [inv].[Productos] ([ProductoLinea])
ON DELETE CASCADE
GO
ALTER TABLE [inv].[Saldos] CHECK CONSTRAINT [FK_Saldos_Productos_ProductoLinea]
GO
USE [master]
GO
ALTER DATABASE [MiDoc] SET  READ_WRITE 
GO
