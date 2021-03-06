USE [master]
GO
/****** Object:  Database [VehicleManagement]    Script Date: 23/02/2022 23:14:43 ******/
CREATE DATABASE [VehicleManagement]
GO
ALTER DATABASE [VehicleManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VehicleManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VehicleManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VehicleManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VehicleManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VehicleManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VehicleManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [VehicleManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VehicleManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VehicleManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VehicleManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VehicleManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VehicleManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VehicleManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VehicleManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VehicleManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VehicleManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VehicleManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VehicleManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VehicleManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VehicleManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VehicleManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VehicleManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VehicleManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VehicleManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [VehicleManagement] SET  MULTI_USER 
GO
ALTER DATABASE [VehicleManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VehicleManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VehicleManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VehicleManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VehicleManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VehicleManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'VehicleManagement', N'ON'
GO
ALTER DATABASE [VehicleManagement] SET QUERY_STORE = OFF
GO
USE [VehicleManagement]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Street] [nvarchar](250) NOT NULL,
	[City] [nvarchar](250) NOT NULL,
	[Cep] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[VehicleId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateWithdrawn] [datetime] NULL,
	[DateExpectedReturn] [datetime] NOT NULL,
	[DateReturn] [datetime] NULL,
	[DateExpectedWithdrawn] [datetime] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Cpf] [nvarchar](250) NULL,
	[Cnh] [nvarchar](250) NULL,
	[BirthDate] [datetime] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DenormalizedBooking]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DenormalizedBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ClientName] [nvarchar](250) NULL,
	[VehicleId] [int] NOT NULL,
	[VehicleModel] [nvarchar](250) NULL,
	[LicensePlate] [nvarchar](250) NULL,
	[BookingId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateWithdrawn] [datetime] NULL,
	[DateExpectedReturn] [datetime] NOT NULL,
	[DateReturn] [datetime] NULL,
	[Cpf] [nvarchar](250) NULL,
	[DateExpectedWithdrawn] [datetime] NULL,
 CONSTRAINT [PK_DenormalizedBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DenormalizedClient]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DenormalizedClient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Cpf] [nvarchar](250) NOT NULL,
	[Cnh] [nvarchar](250) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Street] [nvarchar](250) NULL,
	[City] [nvarchar](250) NULL,
	[Cep] [int] NULL,
 CONSTRAINT [PK_DenormalizedClient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DenormalizedVehicle]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DenormalizedVehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[LicensePlate] [nvarchar](250) NOT NULL,
	[ModelName] [nvarchar](250) NULL,
	[ModelManufacturer] [nvarchar](250) NULL,
	[StatusId] [int] NOT NULL,
	[StatusName] [nvarchar](250) NULL,
 CONSTRAINT [PK_DenormalizedVehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlate] [nvarchar](250) NOT NULL,
	[Status] [int] NOT NULL,
	[VehicleModelId] [int] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleManufacturer]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleManufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 23/02/2022 23:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleModel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[VehicleManufacturerId] [int] NOT NULL,
 CONSTRAINT [PK_VehicleModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[VehicleManufacturer] ON 

INSERT [dbo].[VehicleManufacturer] ([Id], [Name]) VALUES (1, N'FIAT')
INSERT [dbo].[VehicleManufacturer] ([Id], [Name]) VALUES (2, N'GM')
INSERT [dbo].[VehicleManufacturer] ([Id], [Name]) VALUES (3, N'VW')
INSERT [dbo].[VehicleManufacturer] ([Id], [Name]) VALUES (4, N'FORD')
INSERT [dbo].[VehicleManufacturer] ([Id], [Name]) VALUES (5, N'AUDI')
INSERT [dbo].[VehicleManufacturer] ([Id], [Name]) VALUES (6, N'MERCEDES')
INSERT [dbo].[VehicleManufacturer] ([Id], [Name]) VALUES (7, N'JEEP')
SET IDENTITY_INSERT [dbo].[VehicleManufacturer] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleModel] ON 

INSERT [dbo].[VehicleModel] ([Id], [Name], [VehicleManufacturerId]) VALUES (1, N'Palio', 1)
INSERT [dbo].[VehicleModel] ([Id], [Name], [VehicleManufacturerId]) VALUES (2, N'Punto', 1)
INSERT [dbo].[VehicleModel] ([Id], [Name], [VehicleManufacturerId]) VALUES (3, N'Onix', 2)
INSERT [dbo].[VehicleModel] ([Id], [Name], [VehicleManufacturerId]) VALUES (4, N'Up', 3)
INSERT [dbo].[VehicleModel] ([Id], [Name], [VehicleManufacturerId]) VALUES (5, N'Ka', 4)
INSERT [dbo].[VehicleModel] ([Id], [Name], [VehicleManufacturerId]) VALUES (6, N'Renegade', 7)
SET IDENTITY_INSERT [dbo].[VehicleModel] OFF
GO
USE [master]
GO
ALTER DATABASE [VehicleManagement] SET  READ_WRITE 
GO
