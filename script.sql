USE [master]
GO
/****** Object:  Database [MedicalStoreDB]    Script Date: 11/29/2015 1:10:35 AM ******/
CREATE DATABASE [MedicalStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MedicalStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MedicalStoreDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MedicalStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MedicalStoreDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MedicalStoreDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicalStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicalStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MedicalStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedicalStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedicalStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MedicalStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedicalStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MedicalStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [MedicalStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedicalStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedicalStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedicalStoreDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MedicalStoreDB', N'ON'
GO
USE [MedicalStoreDB]
GO
/****** Object:  Table [dbo].[Customermaster]    Script Date: 11/29/2015 1:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customermaster](
	[CustomerId] [nvarchar](max) NULL,
	[CustomerName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Info]    Script Date: 11/29/2015 1:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info](
	[Id] [nvarchar](50) NULL,
	[PartyName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Age] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Remarks] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Itemmaster]    Script Date: 11/29/2015 1:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itemmaster](
	[SerialNo] [nvarchar](max) NULL,
	[CompanyName] [nvarchar](max) NULL,
	[ItemId] [nvarchar](max) NULL,
	[Price] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Suppliermaster]    Script Date: 11/29/2015 1:10:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliermaster](
	[SupplierId] [nvarchar](max) NULL,
	[SupplierName] [nvarchar](max) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Info] ([Id], [PartyName], [Name], [Gender], [Age], [Address], [ContactNo], [MobileNo], [Email], [Remarks]) VALUES (N'1', N'Stock Party', N'Rezwan Ahmed', N'Male', N'25', N'Dhanmondi,Dhaka', N'02-5412781', N'01676451278', N'rezwan@gmail.com', N'A very good paarty')
INSERT [dbo].[Itemmaster] ([SerialNo], [CompanyName], [ItemId], [Price]) VALUES (N'1', N'', N'sq-01', N'600')
USE [master]
GO
ALTER DATABASE [MedicalStoreDB] SET  READ_WRITE 
GO
