USE [WideWorldImporters]
GO
/****** Object:  Schema [Warehouse]    Script Date: 1/2/2020 3:52:37 PM ******/
CREATE SCHEMA [Warehouse]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/2/2020 3:52:37 PM ******/
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
/****** Object:  Table [dbo].[Log]    Script Date: 1/2/2020 3:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MachineName] [nvarchar](50) NOT NULL,
	[Logged] [datetime] NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Logger] [nvarchar](250) NULL,
	[Callsite] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockItems]    Script Date: 1/2/2020 3:52:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockItems](
	[StockItemID] [int] IDENTITY(1,1) NOT NULL,
	[StockItemName] [nvarchar](200) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[ColorID] [int] NULL,
	[UnitPackageID] [int] NOT NULL,
	[OuterPackageID] [int] NOT NULL,
	[Brand] [nvarchar](100) NULL,
	[Size] [nvarchar](40) NULL,
	[LeadTimeDays] [int] NOT NULL,
	[QuantityPerOuter] [int] NOT NULL,
	[IsChillerStock] [bit] NOT NULL,
	[Barcode] [nvarchar](100) NULL,
	[TaxRate] [decimal](18, 3) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[RecommendedRetailPrice] [decimal](18, 2) NULL,
	[TypicalWeightPerUnit] [decimal](18, 3) NOT NULL,
	[MarketingComments] [nvarchar](max) NULL,
	[InternalComments] [nvarchar](max) NULL,
	[CustomFields] [nvarchar](max) NULL,
	[Tags]  [nvarchar](max) NULL,
	[SearchDetails]  [nvarchar](max) NULL,
	[LastEditedBy] [int] NOT NULL,
	[ValidFrom] [datetime] NOT NULL,
	[ValidTo] [datetime] NOT NULL,
 CONSTRAINT [PK_StockItems] PRIMARY KEY CLUSTERED 
(
	[StockItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[StockItems] ON 

INSERT [dbo].[StockItems] ([StockItemID], [StockItemName], [SupplierID], [ColorID], [UnitPackageID], [OuterPackageID], [Brand], [Size], [LeadTimeDays], [QuantityPerOuter], [IsChillerStock], [Barcode], [TaxRate], [UnitPrice], [RecommendedRetailPrice], [TypicalWeightPerUnit], [MarketingComments], [InternalComments], [CustomFields], [LastEditedBy], [ValidFrom], [ValidTo]) VALUES (10, N'USB anime flash drive - Vegeta 2dba7afc-937b-4a75-a066-96ace6bf3cb8', 12, NULL, 7, 7, NULL, NULL, 14, 1, 0, NULL, CAST(15.000 AS Decimal(18, 3)), CAST(39.00 AS Decimal(18, 2)), CAST(47.84 AS Decimal(18, 2)), CAST(0.050 AS Decimal(18, 3)), NULL, NULL, N'{ "CountryOfManufacture": "Japan", "Tags": ["32GB","USB Powered"] }', 1, CAST(N'2019-08-23T00:00:00.000' AS DateTime), CAST(N'2024-08-23T00:00:00.000' AS DateTime))
INSERT [dbo].[StockItems] ([StockItemID], [StockItemName], [SupplierID], [ColorID], [UnitPackageID], [OuterPackageID], [Brand], [Size], [LeadTimeDays], [QuantityPerOuter], [IsChillerStock], [Barcode], [TaxRate], [UnitPrice], [RecommendedRetailPrice], [TypicalWeightPerUnit], [MarketingComments], [InternalComments], [CustomFields], [LastEditedBy], [ValidFrom], [ValidTo]) VALUES (11, N'USB anime flash drive - Vegeta 322bd0fd-1c60-46e4-8e4d-5b867bc17587', 12, NULL, 7, 7, NULL, NULL, 14, 1, 0, NULL, CAST(15.000 AS Decimal(18, 3)), CAST(32.00 AS Decimal(18, 2)), CAST(47.84 AS Decimal(18, 2)), CAST(0.050 AS Decimal(18, 3)), NULL, NULL, N'{ "CountryOfManufacture": "Japan", "Tags": ["32GB","USB Powered"] }', 1, CAST(N'2019-08-23T00:00:00.000' AS DateTime), CAST(N'2024-08-23T00:00:00.000' AS DateTime))
INSERT [dbo].[StockItems] ([StockItemID], [StockItemName], [SupplierID], [ColorID], [UnitPackageID], [OuterPackageID], [Brand], [Size], [LeadTimeDays], [QuantityPerOuter], [IsChillerStock], [Barcode], [TaxRate], [UnitPrice], [RecommendedRetailPrice], [TypicalWeightPerUnit], [MarketingComments], [InternalComments], [CustomFields], [LastEditedBy], [ValidFrom], [ValidTo]) VALUES (13, N'USB anime flash drive - Vegeta b53f80c7-64ec-4552-a72e-639bb34c92aa', 12, NULL, 7, 7, NULL, NULL, 14, 1, 0, NULL, CAST(15.000 AS Decimal(18, 3)), CAST(32.00 AS Decimal(18, 2)), CAST(47.84 AS Decimal(18, 2)), CAST(0.050 AS Decimal(18, 3)), NULL, NULL, N'{ "CountryOfManufacture": "Japan", "Tags": ["32GB","USB Powered"] }', 1, CAST(N'2019-08-26T00:00:00.000' AS DateTime), CAST(N'2024-08-26T00:00:00.000' AS DateTime))
INSERT [dbo].[StockItems] ([StockItemID], [StockItemName], [SupplierID], [ColorID], [UnitPackageID], [OuterPackageID], [Brand], [Size], [LeadTimeDays], [QuantityPerOuter], [IsChillerStock], [Barcode], [TaxRate], [UnitPrice], [RecommendedRetailPrice], [TypicalWeightPerUnit], [MarketingComments], [InternalComments], [CustomFields], [LastEditedBy], [ValidFrom], [ValidTo]) VALUES (15, N'USB anime flash drive - Vegeta 254bc2d4-b993-41e5-926f-4f5b0d05b2de', 12, NULL, 7, 7, NULL, NULL, 14, 1, 0, NULL, CAST(15.000 AS Decimal(18, 3)), CAST(32.00 AS Decimal(18, 2)), CAST(47.84 AS Decimal(18, 2)), CAST(0.050 AS Decimal(18, 3)), NULL, NULL, N'{ "CountryOfManufacture": "Japan", "Tags": ["32GB","USB Powered"] }', 1, CAST(N'2019-09-17T00:00:00.000' AS DateTime), CAST(N'2024-09-17T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[StockItems] OFF
/****** Object:  StoredProcedure [dbo].[NLog_AddEntry_p]    Script Date: 1/2/2020 3:52:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NLog_AddEntry_p] (
  @machineName nvarchar(200),
  @logged datetime,
  @level varchar(5),
  @message nvarchar(max),
  @logger nvarchar(300),
  @properties nvarchar(max),
  @callsite nvarchar(300),
  @exception nvarchar(max)
) AS
BEGIN
  INSERT INTO [dbo].[NLog] (
    [MachineName],
    [Logged],
    [Level],
    [Message],
    [Logger],
    [Properties],
    [Callsite],
    [Exception]
  ) VALUES (
    @machineName,
    @logged,
    @level,
    @message,
    @logger,
    @properties,
    @callsite,
    @exception
  );
END
GO
