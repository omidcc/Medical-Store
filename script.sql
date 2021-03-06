USE [master]
GO
/****** Object:  Database [MedicalStoreDB]    Script Date: 12/1/2015 1:03:39 PM ******/
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
/****** Object:  Table [dbo].[Company]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customermaster]    Script Date: 12/1/2015 1:03:39 PM ******/
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
/****** Object:  Table [dbo].[Info]    Script Date: 12/1/2015 1:03:39 PM ******/
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
/****** Object:  Table [dbo].[Itemmaster]    Script Date: 12/1/2015 1:03:39 PM ******/
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
/****** Object:  Table [dbo].[Purchase]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchase](
	[Bill-No] [varchar](50) NULL,
	[Date] [nvarchar](max) NULL,
	[Party-Name] [nvarchar](50) NULL,
	[Sr_No] [nvarchar](50) NULL,
	[Company-Name] [nvarchar](50) NULL,
	[Model-Id] [nvarchar](50) NULL,
	[Prize] [nvarchar](50) NULL,
	[Vat] [nvarchar](50) NULL,
	[Qty] [nvarchar](50) NULL,
	[Total-vat] [nvarchar](50) NULL,
	[Total-Prize] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purchase-Final]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchase-Final](
	[Bill-No] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Party-Name] [nvarchar](50) NULL,
	[Total-Net-AMT] [varchar](50) NULL,
	[Total-Vat-AMT] [varchar](50) NULL,
	[Total-AMT] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Bill-No] [decimal](18, 0) NOT NULL,
	[Date] [datetime] NULL,
	[Party-Name] [nvarchar](50) NULL,
	[Sr.No] [decimal](18, 0) NULL,
	[Company-Name] [nvarchar](50) NULL,
	[Model-Id] [nvarchar](50) NULL,
	[Prize] [decimal](18, 0) NULL,
	[Vat] [decimal](18, 0) NULL,
	[Qty] [decimal](18, 0) NOT NULL,
	[Total-vat] [decimal](18, 0) NULL,
	[Total-Prize] [decimal](18, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sales-Final]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales-Final](
	[Bill-No] [decimal](18, 0) NULL,
	[Date] [datetime] NULL,
	[Party-Name] [nvarchar](50) NULL,
	[Total-Net-AMT] [nvarchar](50) NULL,
	[Total-Vat-AMT] [nvarchar](50) NULL,
	[Total-AMT] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Company-Name] [nvarchar](50) NULL,
	[Item-id] [nvarchar](50) NOT NULL,
	[Sale-QTY] [decimal](18, 0) NULL,
	[Purchase-QTY] [decimal](18, 0) NULL,
	[Available-QTY] [decimal](18, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Suppliermaster]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Suppliermaster](
	[SupplierId] [varchar](50) NULL,
	[SupplierName] [nvarchar](max) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usermaster]    Script Date: 12/1/2015 1:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usermaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usermaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (3, N'Beximco')
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (5, N'Square')
SET IDENTITY_INSERT [dbo].[Company] OFF
INSERT [dbo].[Customermaster] ([CustomerId], [CustomerName], [Address], [City], [MobileNo], [PhoneNo]) VALUES (N'1', N'Jolil', N'Dhaka', N'Comilla', N'01647852147', N'02-5412783')
INSERT [dbo].[Info] ([Id], [PartyName], [Name], [Gender], [Age], [Address], [ContactNo], [MobileNo], [Email], [Remarks]) VALUES (N'1', N'Stock Party', N'Rezwan Ahmed', N'Male', N'26', N'Dhanmondi,Dhaka', N'02-5412781', N'01676451278', N'rezwan@gmail.com', N'A very good paarty')
INSERT [dbo].[Itemmaster] ([SerialNo], [CompanyName], [ItemId], [Price]) VALUES (N'1', N'Beximco', N'bx-1', N'100')
INSERT [dbo].[Itemmaster] ([SerialNo], [CompanyName], [ItemId], [Price]) VALUES (N'2', N'Beximco', N'bx-2', N'60')
INSERT [dbo].[Itemmaster] ([SerialNo], [CompanyName], [ItemId], [Price]) VALUES (N'2', N'Square', N'sq-1', N'200')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'1', N'30-11-2015', N'shibly', N'1', N'Square', N'sq-03', N'100', N'1', N'10', N'10', N'1010')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'2', N'30-11-2015', N'raju', N'2', N'Square', N'sq-03', N'500', N'2', N'10', N'100', N'5100')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'3', N'3-30-11-2015', N'new', N'3', N'Beximco', N'sq-03', N'100', N'11', N'100', N'1100', N'11100')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'4', N'1-12-2015', N'omi', N'1', N'Square', N'sq-03', N'1000', N'1', N'12', N'120', N'12120')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'4', N'1-12-2015', N'party', N'1', N'Beximco', N'bx-2', N'60', N'1', N'10', N'6', N'606')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'4', N'1-12-2015', N'party', N'3', N'Square', N'sq-1', N'200', N'1', N'10', N'20', N'2020')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'4', N'1-12-2015', N'raju', N'1', N'Beximco', N'bx-1', N'100', N'1', N'100', N'100', N'10100')
INSERT [dbo].[Purchase] ([Bill-No], [Date], [Party-Name], [Sr_No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (N'5', N'1-12-2015', N'', N'1', N'Beximco', N'bx-1', N'100', N'2', N'10', N'20', N'1020')
INSERT [dbo].[Purchase-Final] ([Bill-No], [Date], [Party-Name], [Total-Net-AMT], [Total-Vat-AMT], [Total-AMT]) VALUES (N'1', N'30-11-2015', N'shibly', N'100', N'10', N'110')
INSERT [dbo].[Purchase-Final] ([Bill-No], [Date], [Party-Name], [Total-Net-AMT], [Total-Vat-AMT], [Total-AMT]) VALUES (N'2', N'30-11-2015', N'shibly', N'120', N'10', N'130')
INSERT [dbo].[Purchase-Final] ([Bill-No], [Date], [Party-Name], [Total-Net-AMT], [Total-Vat-AMT], [Total-AMT]) VALUES (N'3', N'3-30-11-2015', N'new', N'10000', N'1100', N'11100')
INSERT [dbo].[Purchase-Final] ([Bill-No], [Date], [Party-Name], [Total-Net-AMT], [Total-Vat-AMT], [Total-AMT]) VALUES (N'4', N'1-12-2015', N'raju', N'24600', N'246', N'24846')
INSERT [dbo].[Purchase-Final] ([Bill-No], [Date], [Party-Name], [Total-Net-AMT], [Total-Vat-AMT], [Total-AMT]) VALUES (N'5', N'1-12-2015', N'', N'1000', N'20', N'1020')
INSERT [dbo].[Sales] ([Bill-No], [Date], [Party-Name], [Sr.No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (CAST(1 AS Decimal(18, 0)), CAST(0x0000A41E00000000 AS DateTime), N'new', CAST(1 AS Decimal(18, 0)), N'Beximco', N'bx-2', CAST(60 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), CAST(303 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([Bill-No], [Date], [Party-Name], [Sr.No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (CAST(1 AS Decimal(18, 0)), CAST(0x0000A41E00000000 AS DateTime), N'omi', CAST(1 AS Decimal(18, 0)), N'Beximco', N'bx-2', CAST(60 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(6 AS Decimal(18, 0)), CAST(606 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([Bill-No], [Date], [Party-Name], [Sr.No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (CAST(1 AS Decimal(18, 0)), CAST(0x0000A41E00000000 AS DateTime), N'omi', CAST(1 AS Decimal(18, 0)), N'Beximco', N'bx-1', CAST(100 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(1010 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([Bill-No], [Date], [Party-Name], [Sr.No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (CAST(2 AS Decimal(18, 0)), CAST(0x0000A41E00000000 AS DateTime), N'surid', CAST(1 AS Decimal(18, 0)), N'Beximco', N'bx-2', CAST(60 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(6 AS Decimal(18, 0)), CAST(606 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([Bill-No], [Date], [Party-Name], [Sr.No], [Company-Name], [Model-Id], [Prize], [Vat], [Qty], [Total-vat], [Total-Prize]) VALUES (CAST(2 AS Decimal(18, 0)), CAST(0x0000A41E00000000 AS DateTime), N'shibly', CAST(1 AS Decimal(18, 0)), N'Square', N'sq-1', CAST(200 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(1010 AS Decimal(18, 0)))
INSERT [dbo].[Sales-Final] ([Bill-No], [Date], [Party-Name], [Total-Net-AMT], [Total-Vat-AMT], [Total-AMT]) VALUES (CAST(1 AS Decimal(18, 0)), CAST(0x0000A41E00000000 AS DateTime), N'omi', N'1900', N'19', N'1919')
INSERT [dbo].[Sales-Final] ([Bill-No], [Date], [Party-Name], [Total-Net-AMT], [Total-Vat-AMT], [Total-AMT]) VALUES (CAST(2 AS Decimal(18, 0)), CAST(0x0000A41E00000000 AS DateTime), N'surid', N'600', N'6', N'606')
INSERT [dbo].[Stock] ([Company-Name], [Item-id], [Sale-QTY], [Purchase-QTY], [Available-QTY]) VALUES (N'Beximco', N'bx-1', CAST(120 AS Decimal(18, 0)), CAST(110 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[Stock] ([Company-Name], [Item-id], [Sale-QTY], [Purchase-QTY], [Available-QTY]) VALUES (N'Beximco', N'bx-2', CAST(35 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)))
INSERT [dbo].[Stock] ([Company-Name], [Item-id], [Sale-QTY], [Purchase-QTY], [Available-QTY]) VALUES (N'Square', N'sq-1', CAST(15 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)))
INSERT [dbo].[Suppliermaster] ([SupplierId], [SupplierName], [Address], [City], [MobileNo], [PhoneNo]) VALUES (N'1', N'Jahid', N'Dhanmondi', N'Comilla', N'01234567874', N'4125741')
SET IDENTITY_INSERT [dbo].[Usermaster] ON 

INSERT [dbo].[Usermaster] ([Id], [Username], [Password]) VALUES (2, N'dcc', N'dcc')
INSERT [dbo].[Usermaster] ([Id], [Username], [Password]) VALUES (3, N'surid', N'ximi')
SET IDENTITY_INSERT [dbo].[Usermaster] OFF
USE [master]
GO
ALTER DATABASE [MedicalStoreDB] SET  READ_WRITE 
GO
