USE [master]
GO
/****** Object:  Database [SelectShop]    Script Date: 2024/4/11 下午 08:22:41 ******/
CREATE DATABASE [SelectShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SelectShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SelectShop.mdf' , SIZE = 81920KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SelectShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SelectShop_log.ldf' , SIZE = 147456KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SelectShop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SelectShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SelectShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SelectShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SelectShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SelectShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SelectShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [SelectShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SelectShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SelectShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SelectShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SelectShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SelectShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SelectShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SelectShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SelectShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SelectShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SelectShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SelectShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SelectShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SelectShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SelectShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SelectShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SelectShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SelectShop] SET RECOVERY FULL 
GO
ALTER DATABASE [SelectShop] SET  MULTI_USER 
GO
ALTER DATABASE [SelectShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SelectShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SelectShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SelectShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SelectShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SelectShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SelectShop', N'ON'
GO
ALTER DATABASE [SelectShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [SelectShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SelectShop]
GO
/****** Object:  Table [dbo].[Bags]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bags](
	[BagID] [int] IDENTITY(8,1) NOT NULL,
	[BagType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Picture] [nvarchar](max) NULL,
	[Price] [money] NULL,
	[Size] [nvarchar](200) NULL,
	[MaterialID] [int] NULL,
	[SuitableProductsID] [int] NULL,
	[PStlyeID] [int] NULL,
 CONSTRAINT [PK_Bags] PRIMARY KEY CLUSTERED 
(
	[BagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boxes]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boxes](
	[BoxID] [int] IDENTITY(14,1) NOT NULL,
	[BoxType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Picture] [nvarchar](max) NULL,
	[Price] [money] NULL,
	[Size] [nvarchar](200) NULL,
	[MaterialID] [int] NULL,
	[SuitableProductsID] [int] NULL,
	[PStlyeID] [int] NULL,
 CONSTRAINT [PK_Boxes] PRIMARY KEY CLUSTERED 
(
	[BoxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[CardID] [int] IDENTITY(6,1) NOT NULL,
	[CardType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Picture] [nvarchar](max) NULL,
	[Price] [money] NULL,
	[SuitableProductsID] [int] NULL,
	[PStlyeID] [int] NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[CardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftPackageStyle]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftPackageStyle](
	[PStlyeID] [int] IDENTITY(1,1) NOT NULL,
	[StyleName] [varchar](50) NOT NULL,
	[Picture] [varchar](max) NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_GiftPackageStyle] PRIMARY KEY CLUSTERED 
(
	[PStlyeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialColor]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialColor](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NOT NULL,
	[RGB] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_MaterialColor] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[packageMaterial]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[packageMaterial](
	[MaterialID] [int] IDENTITY(17,1) NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[ColorID] [int] NULL,
	[Description] [nvarchar](20) NULL,
 CONSTRAINT [PK_packageMaterial] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tActive]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tActive](
	[ActiveID] [int] IDENTITY(1,1) NOT NULL,
	[ActiveName] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Discount] [decimal](3, 2) NULL,
	[Description] [nvarchar](250) NULL,
	[ActiveImage] [varbinary](max) NULL,
 CONSTRAINT [PK_tActive] PRIMARY KEY CLUSTERED 
(
	[ActiveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tAgency]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tAgency](
	[AgencyID] [int] IDENTITY(0,1) NOT NULL,
	[AgencyName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[SupplierID] [int] NULL,
	[EnterpriseID] [int] NULL,
 CONSTRAINT [PK_tAgency] PRIMARY KEY CLUSTERED 
(
	[AgencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tAllPackage]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tAllPackage](
	[PackageID] [int] IDENTITY(1,1) NOT NULL,
	[PackName] [varchar](50) NULL,
	[Price] [money] NULL,
	[Picture] [varchar](max) NULL,
	[PackageStyleID] [int] NULL,
	[TypeID] [int] NULL,
	[MaterialID] [int] NULL,
 CONSTRAINT [PK_tAllPackage] PRIMARY KEY CLUSTERED 
(
	[PackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tAppraisal]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tAppraisal](
	[RankID] [int] IDENTITY(1,1) NOT NULL,
	[Rank] [nvarchar](50) NULL,
 CONSTRAINT [PK_tAppraisal] PRIMARY KEY CLUSTERED 
(
	[RankID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tCart]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NULL,
	[ProductID] [int] NULL,
	[Qty] [int] NULL,
	[Check] [bit] NULL,
 CONSTRAINT [PK_tCart] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tCategory]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
	[CategoryCName] [nvarchar](200) NULL,
 CONSTRAINT [PK_tCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tDepartment]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tDepartment](
	[DepID] [int] IDENTITY(1,1) NOT NULL,
	[DepName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tDistributor]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tDistributor](
	[DistributorID] [int] IDENTITY(0,1) NOT NULL,
	[DistributorName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[SupplierID] [int] NULL,
	[EnterpriseID] [int] NULL,
 CONSTRAINT [PK_tDistributor] PRIMARY KEY CLUSTERED 
(
	[DistributorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tEmployee]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tEmployee](
	[EmployeeID] [int] IDENTITY(9,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[Cellphone] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Birthday] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[E-mail] [nvarchar](50) NULL,
	[EmployeePhoto] [varbinary](max) NULL,
	[OnBoardDate] [nvarchar](50) NULL,
	[DepID] [int] NULL,
 CONSTRAINT [PK_tEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tEnterprise]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tEnterprise](
	[EnterpriseID] [int] IDENTITY(1,1) NOT NULL,
	[EnterpriseName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_tSupplier_1] PRIMARY KEY CLUSTERED 
(
	[EnterpriseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tEventLog]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tEventLog](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ProductID] [int] NULL,
	[EventDateTime] [nvarchar](50) NULL,
	[EventBrief] [nvarchar](150) NULL,
 CONSTRAINT [PK_EventLog] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tKeyword]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tKeyword](
	[ProductID] [int] NULL,
	[TagID] [int] NOT NULL,
	[Festival] [varchar](50) NULL,
	[Topic] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[Tag] [varchar](200) NOT NULL,
 CONSTRAINT [PK_tKeyword] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tLabel]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLabel](
	[LabelID] [int] IDENTITY(35,1) NOT NULL,
	[LabelName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Description] [nchar](250) NULL,
	[SupplierPhoto] [varbinary](max) NULL,
 CONSTRAINT [PK_tSupplier] PRIMARY KEY CLUSTERED 
(
	[LabelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMember]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMember](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[MemberName] [nvarchar](50) NULL,
	[Cellphone] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Birthday] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[E-mail] [nvarchar](50) NULL,
	[Points] [int] NULL,
	[VIP] [bit] NULL,
	[MemberPhoto] [varbinary](max) NULL,
	[Wallet] [money] NULL,
 CONSTRAINT [PK_tMember] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tOrder]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tOrder](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[GUI] [nvarchar](10) NULL,
	[OrderDate] [nvarchar](50) NULL,
	[MemberID] [int] NULL,
	[PackageWayID] [int] NULL,
	[StatusID] [int] NULL,
	[RecMemberID] [int] NULL,
	[Shipping] [int] NULL,
 CONSTRAINT [PK_tOrder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPackage]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPackage](
	[PackageWayID] [int] IDENTITY(1,1) NOT NULL,
	[PackageWay] [varchar](50) NULL,
 CONSTRAINT [PK_tPackage] PRIMARY KEY CLUSTERED 
(
	[PackageWayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPackageWayDetail]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPackageWayDetail](
	[PackageWayDetailID] [int] IDENTITY(1,1) NOT NULL,
	[PackageID] [int] NULL,
	[OrderID] [int] NULL,
	[PackQty] [int] NULL,
 CONSTRAINT [PK_tPackageWayDetail] PRIMARY KEY CLUSTERED 
(
	[PackageWayDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPay]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPay](
	[PayID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[PayTypeID] [int] NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_tPay] PRIMARY KEY CLUSTERED 
(
	[PayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPayType]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPayType](
	[PayTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PayKind] [nvarchar](50) NULL,
	[PayTypeNo] [int] NULL,
	[PayTypeName] [nvarchar](200) NULL,
	[PayTypeImagePath] [nvarchar](200) NULL,
 CONSTRAINT [PK_tPayType] PRIMARY KEY CLUSTERED 
(
	[PayTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProduct]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProduct](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](200) NULL,
	[Stocks] [int] NULL,
	[LabelID] [int] NULL,
	[SubCategoryID] [int] NULL,
	[ProductPhoto] [varbinary](max) NULL,
	[UnitPrice] [money] NULL,
	[Description] [nvarchar](250) NULL,
	[ActiveID] [int] NULL,
	[LaunchTime] [nvarchar](50) NULL,
	[Cost] [money] NULL,
 CONSTRAINT [PK_tProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPurchase]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPurchase](
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Qty] [int] NULL,
	[Memo] [nvarchar](250) NULL,
	[PurchaseID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tPurchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tReview]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tReview](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NULL,
	[ProductID] [int] NULL,
	[RankID] [int] NULL,
	[Comment] [nvarchar](250) NULL,
	[ReviewDate] [nvarchar](50) NULL,
	[PurchaseID] [int] NULL,
 CONSTRAINT [PK_tReview] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSales]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSales](
	[SalesID] [int] NOT NULL,
	[LabelID] [int] NULL,
	[AgencyID] [int] NULL,
	[DistribuatorID] [int] NULL,
 CONSTRAINT [PK_tSales] PRIMARY KEY CLUSTERED 
(
	[SalesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tStatus]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSubCategory]    Script Date: 2024/4/11 下午 08:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSubCategory](
	[SubCategoryID] [int] IDENTITY(17,1) NOT NULL,
	[SubCategoryName] [nvarchar](200) NULL,
	[SubCategoryCName] [nvarchar](200) NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_SubCategory1] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tPackageWayDetail] ADD  CONSTRAINT [DF_tPackageWayDetail_CardID]  DEFAULT ((0)) FOR [PackageID]
GO
ALTER TABLE [dbo].[tPackageWayDetail] ADD  CONSTRAINT [DF_tPackageWayDetail_PackQty]  DEFAULT ((1)) FOR [PackQty]
GO
ALTER TABLE [dbo].[Bags]  WITH CHECK ADD  CONSTRAINT [FK_Bags_GiftPackageStyle1] FOREIGN KEY([PStlyeID])
REFERENCES [dbo].[GiftPackageStyle] ([PStlyeID])
GO
ALTER TABLE [dbo].[Bags] CHECK CONSTRAINT [FK_Bags_GiftPackageStyle1]
GO
ALTER TABLE [dbo].[Bags]  WITH CHECK ADD  CONSTRAINT [FK_Bags_packageMaterial1] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[packageMaterial] ([MaterialID])
GO
ALTER TABLE [dbo].[Bags] CHECK CONSTRAINT [FK_Bags_packageMaterial1]
GO
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_Boxes_GiftPackageStyle1] FOREIGN KEY([PStlyeID])
REFERENCES [dbo].[GiftPackageStyle] ([PStlyeID])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_Boxes_GiftPackageStyle1]
GO
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_Boxes_packageMaterial1] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[packageMaterial] ([MaterialID])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_Boxes_packageMaterial1]
GO
ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_GiftPackageStyle1] FOREIGN KEY([PStlyeID])
REFERENCES [dbo].[GiftPackageStyle] ([PStlyeID])
GO
ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_GiftPackageStyle1]
GO
ALTER TABLE [dbo].[packageMaterial]  WITH CHECK ADD  CONSTRAINT [FK_packageMaterial_MaterialColor] FOREIGN KEY([ColorID])
REFERENCES [dbo].[MaterialColor] ([ColorID])
GO
ALTER TABLE [dbo].[packageMaterial] CHECK CONSTRAINT [FK_packageMaterial_MaterialColor]
GO
ALTER TABLE [dbo].[tAgency]  WITH CHECK ADD  CONSTRAINT [FK_tAgency_tEnterprise] FOREIGN KEY([EnterpriseID])
REFERENCES [dbo].[tEnterprise] ([EnterpriseID])
GO
ALTER TABLE [dbo].[tAgency] CHECK CONSTRAINT [FK_tAgency_tEnterprise]
GO
ALTER TABLE [dbo].[tAllPackage]  WITH CHECK ADD  CONSTRAINT [FK_tAllPackage_GiftPackageStyle1] FOREIGN KEY([PackageStyleID])
REFERENCES [dbo].[GiftPackageStyle] ([PStlyeID])
GO
ALTER TABLE [dbo].[tAllPackage] CHECK CONSTRAINT [FK_tAllPackage_GiftPackageStyle1]
GO
ALTER TABLE [dbo].[tAllPackage]  WITH CHECK ADD  CONSTRAINT [FK_tAllPackage_packageMaterial] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[packageMaterial] ([MaterialID])
GO
ALTER TABLE [dbo].[tAllPackage] CHECK CONSTRAINT [FK_tAllPackage_packageMaterial]
GO
ALTER TABLE [dbo].[tCart]  WITH CHECK ADD  CONSTRAINT [FK_tCart_tMember] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tMember] ([MemberID])
GO
ALTER TABLE [dbo].[tCart] CHECK CONSTRAINT [FK_tCart_tMember]
GO
ALTER TABLE [dbo].[tCart]  WITH CHECK ADD  CONSTRAINT [FK_tCart_tProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tProduct] ([ProductID])
GO
ALTER TABLE [dbo].[tCart] CHECK CONSTRAINT [FK_tCart_tProduct]
GO
ALTER TABLE [dbo].[tDistributor]  WITH CHECK ADD  CONSTRAINT [FK_tDistributor_tEnterprise] FOREIGN KEY([EnterpriseID])
REFERENCES [dbo].[tEnterprise] ([EnterpriseID])
GO
ALTER TABLE [dbo].[tDistributor] CHECK CONSTRAINT [FK_tDistributor_tEnterprise]
GO
ALTER TABLE [dbo].[tEmployee]  WITH NOCHECK ADD  CONSTRAINT [FK_tEmployee_Department] FOREIGN KEY([DepID])
REFERENCES [dbo].[tDepartment] ([DepID])
GO
ALTER TABLE [dbo].[tEmployee] NOCHECK CONSTRAINT [FK_tEmployee_Department]
GO
ALTER TABLE [dbo].[tEventLog]  WITH NOCHECK ADD  CONSTRAINT [FK_EventLog_tEmployee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tEmployee] ([EmployeeID])
GO
ALTER TABLE [dbo].[tEventLog] NOCHECK CONSTRAINT [FK_EventLog_tEmployee]
GO
ALTER TABLE [dbo].[tKeyword]  WITH CHECK ADD  CONSTRAINT [FK_tKeyword_tProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tProduct] ([ProductID])
GO
ALTER TABLE [dbo].[tKeyword] CHECK CONSTRAINT [FK_tKeyword_tProduct]
GO
ALTER TABLE [dbo].[tLabel]  WITH CHECK ADD  CONSTRAINT [FK_tLabel_tProduct] FOREIGN KEY([LabelID])
REFERENCES [dbo].[tProduct] ([ProductID])
GO
ALTER TABLE [dbo].[tLabel] CHECK CONSTRAINT [FK_tLabel_tProduct]
GO
ALTER TABLE [dbo].[tOrder]  WITH CHECK ADD  CONSTRAINT [FK_tOrder_tMember] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tMember] ([MemberID])
GO
ALTER TABLE [dbo].[tOrder] CHECK CONSTRAINT [FK_tOrder_tMember]
GO
ALTER TABLE [dbo].[tOrder]  WITH CHECK ADD  CONSTRAINT [FK_tOrder_tStatus] FOREIGN KEY([StatusID])
REFERENCES [dbo].[tStatus] ([StatusID])
GO
ALTER TABLE [dbo].[tOrder] CHECK CONSTRAINT [FK_tOrder_tStatus]
GO
ALTER TABLE [dbo].[tPackageWayDetail]  WITH CHECK ADD  CONSTRAINT [FK_tPackageWayDetail_tAllPackage] FOREIGN KEY([PackageID])
REFERENCES [dbo].[tAllPackage] ([PackageID])
GO
ALTER TABLE [dbo].[tPackageWayDetail] CHECK CONSTRAINT [FK_tPackageWayDetail_tAllPackage]
GO
ALTER TABLE [dbo].[tPackageWayDetail]  WITH CHECK ADD  CONSTRAINT [FK_tPackageWayDetail_tOrder] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tOrder] ([OrderID])
GO
ALTER TABLE [dbo].[tPackageWayDetail] CHECK CONSTRAINT [FK_tPackageWayDetail_tOrder]
GO
ALTER TABLE [dbo].[tPay]  WITH CHECK ADD  CONSTRAINT [FK_tPay_tOrder] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tOrder] ([OrderID])
GO
ALTER TABLE [dbo].[tPay] CHECK CONSTRAINT [FK_tPay_tOrder]
GO
ALTER TABLE [dbo].[tPay]  WITH CHECK ADD  CONSTRAINT [FK_tPay_tPayType] FOREIGN KEY([PayTypeID])
REFERENCES [dbo].[tPayType] ([PayTypeID])
GO
ALTER TABLE [dbo].[tPay] CHECK CONSTRAINT [FK_tPay_tPayType]
GO
ALTER TABLE [dbo].[tProduct]  WITH CHECK ADD  CONSTRAINT [FK_tProduct_tActive] FOREIGN KEY([ActiveID])
REFERENCES [dbo].[tActive] ([ActiveID])
GO
ALTER TABLE [dbo].[tProduct] CHECK CONSTRAINT [FK_tProduct_tActive]
GO
ALTER TABLE [dbo].[tProduct]  WITH CHECK ADD  CONSTRAINT [FK_tProduct_tSubCategory] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[tSubCategory] ([SubCategoryID])
GO
ALTER TABLE [dbo].[tProduct] CHECK CONSTRAINT [FK_tProduct_tSubCategory]
GO
ALTER TABLE [dbo].[tPurchase]  WITH CHECK ADD  CONSTRAINT [FK_tPurchase_tOrder] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tOrder] ([OrderID])
GO
ALTER TABLE [dbo].[tPurchase] CHECK CONSTRAINT [FK_tPurchase_tOrder]
GO
ALTER TABLE [dbo].[tPurchase]  WITH CHECK ADD  CONSTRAINT [FK_tPurchase_tProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tProduct] ([ProductID])
GO
ALTER TABLE [dbo].[tPurchase] CHECK CONSTRAINT [FK_tPurchase_tProduct]
GO
ALTER TABLE [dbo].[tReview]  WITH CHECK ADD  CONSTRAINT [FK_tReview_tAppraisal] FOREIGN KEY([RankID])
REFERENCES [dbo].[tAppraisal] ([RankID])
GO
ALTER TABLE [dbo].[tReview] CHECK CONSTRAINT [FK_tReview_tAppraisal]
GO
ALTER TABLE [dbo].[tReview]  WITH CHECK ADD  CONSTRAINT [FK_tReview_tMember] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tMember] ([MemberID])
GO
ALTER TABLE [dbo].[tReview] CHECK CONSTRAINT [FK_tReview_tMember]
GO
ALTER TABLE [dbo].[tReview]  WITH CHECK ADD  CONSTRAINT [FK_tReview_tProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tProduct] ([ProductID])
GO
ALTER TABLE [dbo].[tReview] CHECK CONSTRAINT [FK_tReview_tProduct]
GO
ALTER TABLE [dbo].[tReview]  WITH CHECK ADD  CONSTRAINT [FK_tReview_tPurchase] FOREIGN KEY([PurchaseID])
REFERENCES [dbo].[tPurchase] ([PurchaseID])
GO
ALTER TABLE [dbo].[tReview] CHECK CONSTRAINT [FK_tReview_tPurchase]
GO
ALTER TABLE [dbo].[tSales]  WITH CHECK ADD  CONSTRAINT [FK_tSales_tAgency] FOREIGN KEY([AgencyID])
REFERENCES [dbo].[tAgency] ([AgencyID])
GO
ALTER TABLE [dbo].[tSales] CHECK CONSTRAINT [FK_tSales_tAgency]
GO
ALTER TABLE [dbo].[tSales]  WITH CHECK ADD  CONSTRAINT [FK_tSales_tDistributor] FOREIGN KEY([DistribuatorID])
REFERENCES [dbo].[tDistributor] ([DistributorID])
GO
ALTER TABLE [dbo].[tSales] CHECK CONSTRAINT [FK_tSales_tDistributor]
GO
ALTER TABLE [dbo].[tSales]  WITH CHECK ADD  CONSTRAINT [FK_tSales_tLabel] FOREIGN KEY([LabelID])
REFERENCES [dbo].[tLabel] ([LabelID])
GO
ALTER TABLE [dbo].[tSales] CHECK CONSTRAINT [FK_tSales_tLabel]
GO
ALTER TABLE [dbo].[tSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_tSubCategory_tCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[tSubCategory] CHECK CONSTRAINT [FK_tSubCategory_tCategory]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tLabel', @level2type=N'COLUMN',@level2name=N'LabelID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原為供應商名稱、現改為品牌；為維持原有 Database Model 架構，表格名稱不更動' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tLabel', @level2type=N'COLUMN',@level2name=N'LabelName'
GO
USE [master]
GO
ALTER DATABASE [SelectShop] SET  READ_WRITE 
GO
