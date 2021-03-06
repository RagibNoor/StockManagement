USE [master]
GO
/****** Object:  Database [StockManagement]    Script Date: 8/29/2018 9:08:49 AM ******/
CREATE DATABASE [StockManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagement.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagement_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockManagement] SET  MULTI_USER 
GO
ALTER DATABASE [StockManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockManagement]
GO
/****** Object:  Table [dbo].[Category_tbl]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category_tbl](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category_tbl] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company_tbl]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company_tbl](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Company_tbl] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item_tbl]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item_tbl](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[Reorder] [int] NOT NULL,
 CONSTRAINT [PK_Item_tbl] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stockIn_tbl]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stockIn_tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[StockInquantity] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_stockIn_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stockOut_tbl]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stockOut_tbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Reason] [varchar](50) NOT NULL,
	[StockOutdate] [date] NOT NULL,
	[StockOutQuantity] [int] NOT NULL,
 CONSTRAINT [PK_stockOut_tbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_tbl]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_tbl](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ItemAllInfo]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemAllInfo]
AS
SELECT i.ItemID, i.ItemName, ca.CategoryId, ca.CategoryName, co.CompanyID, co.CompanyName, i.Reorder
FROM     dbo.Item_tbl AS i INNER JOIN
                  dbo.Category_tbl AS ca ON i.CategoryID = ca.CategoryId INNER JOIN
                  dbo.Company_tbl AS co ON i.CompanyID = co.CompanyID

GO
/****** Object:  View [dbo].[ItemStockOutView_tbl]    Script Date: 8/29/2018 9:08:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemStockOutView_tbl]
AS
SELECT dbo.Item_tbl.ItemName, dbo.stockOut_tbl.id, dbo.stockOut_tbl.ItemId, dbo.stockOut_tbl.Reason, dbo.stockOut_tbl.StockOutdate, dbo.stockOut_tbl.StockOutQuantity
FROM     dbo.Item_tbl INNER JOIN
                  dbo.stockOut_tbl ON dbo.Item_tbl.ItemID = dbo.stockOut_tbl.ItemId

GO
SET IDENTITY_INSERT [dbo].[Category_tbl] ON 

INSERT [dbo].[Category_tbl] ([CategoryId], [CategoryName]) VALUES (1, N'Drink')
INSERT [dbo].[Category_tbl] ([CategoryId], [CategoryName]) VALUES (2, N'Chips')
INSERT [dbo].[Category_tbl] ([CategoryId], [CategoryName]) VALUES (3, N'choklet')
INSERT [dbo].[Category_tbl] ([CategoryId], [CategoryName]) VALUES (4, N'biscuit')
INSERT [dbo].[Category_tbl] ([CategoryId], [CategoryName]) VALUES (5, N'''ra''')
INSERT [dbo].[Category_tbl] ([CategoryId], [CategoryName]) VALUES (6, N'a')
SET IDENTITY_INSERT [dbo].[Category_tbl] OFF
SET IDENTITY_INSERT [dbo].[Company_tbl] ON 

INSERT [dbo].[Company_tbl] ([CompanyID], [CompanyName]) VALUES (1, N'Pran')
INSERT [dbo].[Company_tbl] ([CompanyID], [CompanyName]) VALUES (2, N'RFL')
INSERT [dbo].[Company_tbl] ([CompanyID], [CompanyName]) VALUES (3, N'Bombay')
INSERT [dbo].[Company_tbl] ([CompanyID], [CompanyName]) VALUES (4, N'Akij')
INSERT [dbo].[Company_tbl] ([CompanyID], [CompanyName]) VALUES (5, N'@CompanyName')
INSERT [dbo].[Company_tbl] ([CompanyID], [CompanyName]) VALUES (6, N'''com''')
SET IDENTITY_INSERT [dbo].[Company_tbl] OFF
SET IDENTITY_INSERT [dbo].[Item_tbl] ON 

INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (1, N'mango', 1, 1, 0)
INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (2, N'pepsi', 1, 2, 0)
INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (3, N'potato', 2, 1, 0)
INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (4, N'alltime', 4, 1, 0)
INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (5, N'lichi', 1, 1, 0)
INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (6, N'Rfl Drink', 1, 2, 0)
INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (7, N'''item''', 1, 1, 0)
INSERT [dbo].[Item_tbl] ([ItemID], [ItemName], [CategoryID], [CompanyID], [Reorder]) VALUES (8, N'ring', 2, 3, 0)
SET IDENTITY_INSERT [dbo].[Item_tbl] OFF
SET IDENTITY_INSERT [dbo].[stockIn_tbl] ON 

INSERT [dbo].[stockIn_tbl] ([Id], [ItemId], [StockInquantity], [Date]) VALUES (1, 1, 4, CAST(0xD73D0B00 AS Date))
INSERT [dbo].[stockIn_tbl] ([Id], [ItemId], [StockInquantity], [Date]) VALUES (3, 1, 3, CAST(0x963E0B00 AS Date))
INSERT [dbo].[stockIn_tbl] ([Id], [ItemId], [StockInquantity], [Date]) VALUES (4, 3, 7, CAST(0x983E0B00 AS Date))
INSERT [dbo].[stockIn_tbl] ([Id], [ItemId], [StockInquantity], [Date]) VALUES (5, 1, 7, CAST(0xA53E0B00 AS Date))
INSERT [dbo].[stockIn_tbl] ([Id], [ItemId], [StockInquantity], [Date]) VALUES (6, 1, 14, CAST(0xA53E0B00 AS Date))
INSERT [dbo].[stockIn_tbl] ([Id], [ItemId], [StockInquantity], [Date]) VALUES (7, 2, 7, CAST(0xA53E0B00 AS Date))
INSERT [dbo].[stockIn_tbl] ([Id], [ItemId], [StockInquantity], [Date]) VALUES (8, 8, 20, CAST(0xA63E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[stockIn_tbl] OFF
SET IDENTITY_INSERT [dbo].[stockOut_tbl] ON 

INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (1, 1, N's', CAST(0x963E0B00 AS Date), 2)
INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (2, 1, N'l', CAST(0x963E0B00 AS Date), 1)
INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (3, 1, N's', CAST(0x983E0B00 AS Date), 1)
INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (4, 1, N's', CAST(0x993E0B00 AS Date), 3)
INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (5, 3, N's', CAST(0x993E0B00 AS Date), 1)
INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (6, 3, N's', CAST(0xA53E0B00 AS Date), 6)
INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (7, 1, N'd', CAST(0xA63E0B00 AS Date), 4)
INSERT [dbo].[stockOut_tbl] ([id], [ItemId], [Reason], [StockOutdate], [StockOutQuantity]) VALUES (8, 8, N's', CAST(0xA63E0B00 AS Date), 5)
SET IDENTITY_INSERT [dbo].[stockOut_tbl] OFF
SET IDENTITY_INSERT [dbo].[User_tbl] ON 

INSERT [dbo].[User_tbl] ([UserId], [UserName], [Password]) VALUES (1, N'1', N'1')
SET IDENTITY_INSERT [dbo].[User_tbl] OFF
ALTER TABLE [dbo].[Item_tbl] ADD  CONSTRAINT [DF_Item_tbl_Reorder]  DEFAULT ((0)) FOR [Reorder]
GO
ALTER TABLE [dbo].[Item_tbl]  WITH CHECK ADD  CONSTRAINT [FK_Item_tbl_Category_tbl] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category_tbl] ([CategoryId])
GO
ALTER TABLE [dbo].[Item_tbl] CHECK CONSTRAINT [FK_Item_tbl_Category_tbl]
GO
ALTER TABLE [dbo].[Item_tbl]  WITH CHECK ADD  CONSTRAINT [FK_Item_tbl_Company_tbl] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company_tbl] ([CompanyID])
GO
ALTER TABLE [dbo].[Item_tbl] CHECK CONSTRAINT [FK_Item_tbl_Company_tbl]
GO
ALTER TABLE [dbo].[stockIn_tbl]  WITH CHECK ADD  CONSTRAINT [FK_stockIn_tbl_Item_tbl] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item_tbl] ([ItemID])
GO
ALTER TABLE [dbo].[stockIn_tbl] CHECK CONSTRAINT [FK_stockIn_tbl_Item_tbl]
GO
ALTER TABLE [dbo].[stockOut_tbl]  WITH CHECK ADD  CONSTRAINT [FK_stockOut_tbl_Item_tbl] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item_tbl] ([ItemID])
GO
ALTER TABLE [dbo].[stockOut_tbl] CHECK CONSTRAINT [FK_stockOut_tbl_Item_tbl]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "i"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ca"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "co"
            Begin Extent = 
               Top = 294
               Left = 48
               Bottom = 413
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemAllInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemAllInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Item_tbl"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "stockOut_tbl"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemStockOutView_tbl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemStockOutView_tbl'
GO
USE [master]
GO
ALTER DATABASE [StockManagement] SET  READ_WRITE 
GO
