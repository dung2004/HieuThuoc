USE [master]
GO

CREATE DATABASE [HieuThuoc]
GO

USE [HieuThuoc]
GO

CREATE TABLE [dbo].[Roles](
    [RoleID] [int] IDENTITY(1,1) NOT NULL,
    [RoleName] [nvarchar](50) NOT NULL,
    [RoleDescription] [nvarchar](255) NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Accounts](
    [AccId] [int] IDENTITY(1,1) NOT NULL,
    [Username] [nvarchar](50) NOT NULL,
    [PasswordHash] [nvarchar](255) NOT NULL,
    [FullName] [nvarchar](100) NOT NULL,
    [email] [nvarchar](50) NULL,
    [SDT] [nvarchar](10) NULL,
    [RoleID] [int] NOT NULL,
    [CreatedBy] [int] NULL,
    [CreatedAt] [datetime] NULL,
    [IsActive] [bit] NULL,
    [ImageFile] [nvarchar](255) NULL,
    PRIMARY KEY CLUSTERED ([AccId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Medicine](
    [MedicineId] [int] IDENTITY(1,1) NOT NULL,
    [MedicineCode] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](255) NOT NULL,
    [GenericName] [nvarchar](255) NULL,
    [Manufacturer] [nvarchar](255) NULL,
    [Unit] [nvarchar](50) NOT NULL,
    [Description] [nvarchar](max) NULL,
    [ImageFile] [nvarchar](255) NULL,
    PRIMARY KEY CLUSTERED ([MedicineId] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Packaging](
    [PackagingId] [int] IDENTITY(1,1) NOT NULL,
    [MedicineId] [int] NOT NULL,
    [PackagingCode] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](255) NULL,
    [PillsPerPack] [int] NOT NULL,
    [PricePerPack] [decimal](18, 2) NULL,
    [PricePerPill] [decimal](18, 4) NULL,
    PRIMARY KEY CLUSTERED ([PackagingId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Batch](
    [BatchId] [int] IDENTITY(1,1) NOT NULL,
    [BatchCode] [nvarchar](100) NULL,
    [ExpiryDate] [date] NOT NULL,
    [QuantityPills] [int] NOT NULL,
    [PurchasePrice] [decimal](18, 2) NOT NULL,
    [ReceivedPacks] [int] NULL,
    [ReceivedLoosePills] [int] NULL,
    [CreatedAt] [datetime2](7) NOT NULL,
    [PackagingId] [int] NULL,
    PRIMARY KEY CLUSTERED ([BatchId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Supplier](
    [SupplierId] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](255) NOT NULL,
    [Phone] [nvarchar](20) NULL,
    [Address] [nvarchar](max) NULL,
    PRIMARY KEY CLUSTERED ([SupplierId] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Purchase](
    [PurchaseId] [int] IDENTITY(1,1) NOT NULL,
    [SupplierId] [int] NULL,
    [PurchaseDate] [datetime2](7) NOT NULL,
    [TotalAmount] [decimal](18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PurchaseDetail](
    [PurchaseDetailId] [int] IDENTITY(1,1) NOT NULL,
    [PurchaseId] [int] NOT NULL,
    [BatchId] [int] NOT NULL,
    [QuantityPacks] [int] NULL,
    [QuantityPills] [int] NOT NULL,
    [UnitPricePerPill] [decimal](18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseDetailId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Sale](
    [SaleId] [int] IDENTITY(1,1) NOT NULL,
    [CustomerName] [nvarchar](255) NULL,
    [SaleDate] [datetime2](7) NOT NULL,
    [TotalAmount] [decimal](18, 2) NOT NULL,
    [SaleBy] [int] NULL,
    PRIMARY KEY CLUSTERED ([SaleId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SaleDetail](
    [SaleDetailId] [int] IDENTITY(1,1) NOT NULL,
    [SaleId] [int] NOT NULL,
    [PackagingId] [int] NULL,
    [QuantityPacks] [int] NULL,
    [QuantityPills] [int] NULL,
    [UnitPrice] [decimal](18, 2) NOT NULL,
    [MedicineId] [int] NULL,
    PRIMARY KEY CLUSTERED ([SaleDetailId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SaleBatchAllocation](
    [AllocationId] [int] IDENTITY(1,1) NOT NULL,
    [SaleId] [int] NOT NULL,
    [SaleDetailId] [int] NOT NULL,
    [BatchId] [int] NOT NULL,
    [AllocatedPills] [int] NOT NULL,
    PRIMARY KEY CLUSTERED ([AllocationId] ASC)
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription]) VALUES (1, N'Admin', N'Quyền cao nhất, quản lý toàn bộ hệ thống')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription]) VALUES (2, N'QuanLy', N'Quản lý kho, bán hàng, báo cáo nhưng không tạo tài khoản')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription]) VALUES (3, N'NhanVien', N'Nhập kho, bán hàng, xem báo cáo được phân quyền')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO

SET IDENTITY_INSERT [dbo].[Accounts] ON
INSERT [dbo].[Accounts] ([AccId], [Username], [PasswordHash], [FullName], [email], [SDT], [RoleID], [CreatedBy], [CreatedAt], [IsActive], [ImageFile]) VALUES (1, N'Phat', N'$2a$11$cfsI1I2nqJiTB/9WvLS7ru2hGKm05hlUXNOjjjJx/mIDnm6E6WjOO', N'Nguyễn Đình phát', N'phat@gmail.com', N'0123456789', 3, 2, CAST(N'2025-09-16T04:01:27.580' AS DateTime), 1, N'boy.png')
INSERT [dbo].[Accounts] ([AccId], [Username], [PasswordHash], [FullName], [email], [SDT], [RoleID], [CreatedBy], [CreatedAt], [IsActive], [ImageFile]) VALUES (2, N'Dung', N'$2a$11$cfsI1I2nqJiTB/9WvLS7ru2hGKm05hlUXNOjjjJx/mIDnm6E6WjOO', N'Admin System', N'admin@example.com', N'0123456789', 1, 2, CAST(N'2025-09-15T00:00:00.000' AS DateTime), 1, N'admin.jpg')
INSERT [dbo].[Accounts] ([AccId], [Username], [PasswordHash], [FullName], [email], [SDT], [RoleID], [CreatedBy], [CreatedAt], [IsActive], [ImageFile]) VALUES (3, N'Dong', N'$2a$11$cfsI1I2nqJiTB/9WvLS7ru2hGKm05hlUXNOjjjJx/mIDnm6E6WjOO', N'Quản Lý', N'quanly@example.com', N'0987654321', 2, 2, CAST(N'2025-09-17T00:00:00.000' AS DateTime), 1, N'man.png')
INSERT [dbo].[Accounts] ([AccId], [Username], [PasswordHash], [FullName], [email], [SDT], [RoleID], [CreatedBy], [CreatedAt], [IsActive], [ImageFile]) VALUES (4, N'nv1', N'$2a$11$cfsI1I2nqJiTB/9WvLS7ru2hGKm05hlUXNOjjjJx/mIDnm6E6WjOO', N'Nhân Viên 1', N'nv1@example.com', N'0912345678', 3, 2, CAST(N'2025-09-16T00:00:00.000' AS DateTime), 1, N'male.png')
INSERT [dbo].[Accounts] ([AccId], [Username], [PasswordHash], [FullName], [email], [SDT], [RoleID], [CreatedBy], [CreatedAt], [IsActive], [ImageFile]) VALUES (5, N'nv2', N'$2a$11$cfsI1I2nqJiTB/9WvLS7ru2hGKm05hlUXNOjjjJx/mIDnm6E6WjOO', N'Nhân Viên 2', N'nv2@example.com', N'0909123456', 3, 2, CAST(N'2025-09-16T00:00:00.000' AS DateTime), 1, N'woman.png')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO

SET IDENTITY_INSERT [dbo].[Medicine] ON
INSERT [dbo].[Medicine] ([MedicineId], [MedicineCode], [Name], [GenericName], [Manufacturer], [Unit], [Description], [ImageFile]) VALUES (1, N'M001', N'Paracetamol 500mg', N'Paracetamol', N'Pharma A', N'viên', N'Giảm đau, hạ sốt', N'paracetamol.png')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineCode], [Name], [GenericName], [Manufacturer], [Unit], [Description], [ImageFile]) VALUES (2, N'M002', N'Amoxicillin 500mg', N'Amoxicillin', N'Pharma B', N'viên', N'Kháng sinh penicillin', N'amoxicillin.png')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineCode], [Name], [GenericName], [Manufacturer], [Unit], [Description], [ImageFile]) VALUES (3, N'M003', N'Ibuprofen 200mg', N'Ibuprofen', N'Pharma C', N'viên', N'Giảm đau, chống viêm', N'ibuprofen.png')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineCode], [Name], [GenericName], [Manufacturer], [Unit], [Description], [ImageFile]) VALUES (4, N'M004', N'Cetirizine 10mg', N'Cetirizine', N'Pharma D', N'viên', N'Chống dị ứng', N'cetirizine.jpg')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineCode], [Name], [GenericName], [Manufacturer], [Unit], [Description], [ImageFile]) VALUES (5, N'M005', N'Omeprazole 20mg', N'Omeprazole', N'Pharma E', N'viên', N'Giảm tiết axit dạ dày. Điều trị loét dạ dày và tá tràng. Điều trị hội chứng Zollinger-Ellison', N'omeprazole.png')
SET IDENTITY_INSERT [dbo].[Medicine] OFF
GO

SET IDENTITY_INSERT [dbo].[Packaging] ON
INSERT [dbo].[Packaging] ([PackagingId], [MedicineId], [PackagingCode], [Name], [PillsPerPack], [PricePerPack], [PricePerPill]) VALUES (1, 1, N'PCK-M001-10', N'Hộp 10 viên', 10, CAST(90000.00 AS Decimal(18, 2)), CAST(9000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Packaging] ([PackagingId], [MedicineId], [PackagingCode], [Name], [PillsPerPack], [PricePerPack], [PricePerPill]) VALUES (2, 1, N'PCK-M001-20', N'Hộp 20 viên', 20, CAST(160000.00 AS Decimal(18, 2)), CAST(8000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Packaging] ([PackagingId], [MedicineId], [PackagingCode], [Name], [PillsPerPack], [PricePerPack], [PricePerPill]) VALUES (3, 2, N'PCK-M002-10', N'Hộp 10 viên', 10, CAST(100000.00 AS Decimal(18, 2)), CAST(10000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Packaging] ([PackagingId], [MedicineId], [PackagingCode], [Name], [PillsPerPack], [PricePerPack], [PricePerPill]) VALUES (4, 3, N'PCK-M003-10', N'Hộp 8 viên', 8, CAST(104000.00 AS Decimal(18, 2)), CAST(13000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Packaging] ([PackagingId], [MedicineId], [PackagingCode], [Name], [PillsPerPack], [PricePerPack], [PricePerPill]) VALUES (5, 4, N'PCK-M004-10', N'Hộp 10 viên', 10, CAST(110000.00 AS Decimal(18, 2)), CAST(11000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Packaging] ([PackagingId], [MedicineId], [PackagingCode], [Name], [PillsPerPack], [PricePerPack], [PricePerPill]) VALUES (6, 5, N'PCK-M005-14', N'Hộp 14 viên', 14, CAST(168000.00 AS Decimal(18, 2)), CAST(12000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Packaging] ([PackagingId], [MedicineId], [PackagingCode], [Name], [PillsPerPack], [PricePerPack], [PricePerPill]) VALUES (11, 1, N'PCK-M001-14', N'Hộp 14 viên', 14, CAST(196000.00 AS Decimal(18, 2)), CAST(14000.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[Packaging] OFF
GO

SET IDENTITY_INSERT [dbo].[Batch] ON
INSERT [dbo].[Batch] ([BatchId], [BatchCode], [ExpiryDate], [QuantityPills], [PurchasePrice], [ReceivedPacks], [ReceivedLoosePills], [CreatedAt], [PackagingId]) VALUES (1, N'B001', CAST(N'2026-12-31' AS Date), 344, CAST(3096000.00 AS Decimal(18, 2)), 30, 44, CAST(N'2025-09-15T21:12:45.1233333' AS DateTime2), 1)
INSERT [dbo].[Batch] ([BatchId], [BatchCode], [ExpiryDate], [QuantityPills], [PurchasePrice], [ReceivedPacks], [ReceivedLoosePills], [CreatedAt], [PackagingId]) VALUES (2, N'B002', CAST(N'2025-11-30' AS Date), 622, CAST(4976000.00 AS Decimal(18, 2)), 30, 22, CAST(N'2025-09-15T21:12:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Batch] ([BatchId], [BatchCode], [ExpiryDate], [QuantityPills], [PurchasePrice], [ReceivedPacks], [ReceivedLoosePills], [CreatedAt], [PackagingId]) VALUES (3, N'B003', CAST(N'2026-06-30' AS Date), 304, CAST(3040000.00 AS Decimal(18, 2)), 30, 4, CAST(N'2025-09-15T21:12:45.1233333' AS DateTime2), 3)
INSERT [dbo].[Batch] ([BatchId], [BatchCode], [ExpiryDate], [QuantityPills], [PurchasePrice], [ReceivedPacks], [ReceivedLoosePills], [CreatedAt], [PackagingId]) VALUES (4, N'B004', CAST(N'2025-09-26' AS Date), 241, CAST(3133000.00 AS Decimal(18, 2)), 30, 1, CAST(N'2025-09-15T00:02:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Batch] ([BatchId], [BatchCode], [ExpiryDate], [QuantityPills], [PurchasePrice], [ReceivedPacks], [ReceivedLoosePills], [CreatedAt], [PackagingId]) VALUES (5, N'B005', CAST(N'2027-03-31' AS Date), 423, CAST(4653000.00 AS Decimal(18, 2)), 30, 123, CAST(N'2025-09-15T21:12:45.1233333' AS DateTime2), 5)
INSERT [dbo].[Batch] ([BatchId], [BatchCode], [ExpiryDate], [QuantityPills], [PurchasePrice], [ReceivedPacks], [ReceivedLoosePills], [CreatedAt], [PackagingId]) VALUES (8, N'B014', CAST(N'2024-10-01' AS Date), 301, CAST(20000.00 AS Decimal(18, 2)), 20, 21, CAST(N'2025-09-22T01:28:31.4525686' AS DateTime2), 11)
SET IDENTITY_INSERT [dbo].[Batch] OFF
GO

SET IDENTITY_INSERT [dbo].[Supplier] ON
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Phone], [Address]) VALUES (1, N'Supplier A', N'0123456789', N'Số 1, Đường A, Hà Nội')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Phone], [Address]) VALUES (2, N'Supplier B', N'0987654321', N'Số 2, Đường Cộng Hòa, TP.HCM')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Phone], [Address]) VALUES (3, N'Supplier C', N'0912345678', N'Số 3, Đường C, Đà Nẵng')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Phone], [Address]) VALUES (4, N'Supplier D', N'0909123456', N'Số 4, Đường D, Cần Thơ')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Phone], [Address]) VALUES (5, N'Supplier E', N'0999888777', N'Số 5, Đường E, Hải Phòng')
INSERT [dbo].[Supplier] ([SupplierId], [Name], [Phone], [Address]) VALUES (6, N'Supplier Test', N'0123456789', N'số 17a, cộng hòa, hcm')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO

SET IDENTITY_INSERT [dbo].[Purchase] ON
INSERT [dbo].[Purchase] ([PurchaseId], [SupplierId], [PurchaseDate], [TotalAmount

]) VALUES (1, 1, CAST(N'2024-10-01T00:00:00.0000000' AS DateTime2), CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Purchase] ([PurchaseId], [SupplierId], [PurchaseDate], [TotalAmount]) VALUES (2, 2, CAST(N'2024-11-05T00:00:00.0000000' AS DateTime2), CAST(75000.00 AS Decimal(18, 2)))
INSERT [dbo].[Purchase] ([PurchaseId], [SupplierId], [PurchaseDate], [TotalAmount]) VALUES (3, 3, CAST(N'2024-12-10T20:30:00.0000000' AS DateTime2), CAST(96000.00 AS Decimal(18, 2)))
INSERT [dbo].[Purchase] ([PurchaseId], [SupplierId], [PurchaseDate], [TotalAmount]) VALUES (4, 4, CAST(N'2025-01-15T00:00:00.0000000' AS DateTime2), CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[Purchase] ([PurchaseId], [SupplierId], [PurchaseDate], [TotalAmount]) VALUES (5, 5, CAST(N'2025-02-20T02:00:00.0000000' AS DateTime2), CAST(84000.00 AS Decimal(18, 2)))
INSERT [dbo].[Purchase] ([PurchaseId], [SupplierId], [PurchaseDate], [TotalAmount]) VALUES (8, 6, CAST(N'2025-09-22T01:28:31.4233333' AS DateTime2), CAST(6020000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Purchase] OFF
GO

SET IDENTITY_INSERT [dbo].[PurchaseDetail] ON
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [BatchId], [QuantityPacks], [QuantityPills], [UnitPricePerPill]) VALUES (1, 1, 1, 100, 1000, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [BatchId], [QuantityPacks], [QuantityPills], [UnitPricePerPill]) VALUES (2, 2, 2, 50, 500, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [BatchId], [QuantityPacks], [QuantityPills], [UnitPricePerPill]) VALUES (3, 3, 3, 80, 804, CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [BatchId], [QuantityPacks], [QuantityPills], [UnitPricePerPill]) VALUES (4, 4, 4, 30, 300, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [BatchId], [QuantityPacks], [QuantityPills], [UnitPricePerPill]) VALUES (5, 5, 5, 30, 423, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [BatchId], [QuantityPacks], [QuantityPills], [UnitPricePerPill]) VALUES (6, 8, 8, 20, 301, CAST(20000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[PurchaseDetail] OFF
GO

SET IDENTITY_INSERT [dbo].[Sale] ON
INSERT [dbo].[Sale] ([SaleId], [CustomerName], [SaleDate], [TotalAmount], [SaleBy]) VALUES (6, N'Khách A', CAST(N'2025-03-01T00:00:00.0000000' AS DateTime2), CAST(150000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Sale] ([SaleId], [CustomerName], [SaleDate], [TotalAmount], [SaleBy]) VALUES (7, N'Khách B', CAST(N'2025-03-02T00:00:00.0000000' AS DateTime2), CAST(30000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Sale] ([SaleId], [CustomerName], [SaleDate], [TotalAmount], [SaleBy]) VALUES (8, N'Khách C', CAST(N'2025-03-03T00:00:00.0000000' AS DateTime2), CAST(60000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Sale] ([SaleId], [CustomerName], [SaleDate], [TotalAmount], [SaleBy]) VALUES (9, N'Khách D', CAST(N'2025-03-04T00:00:00.0000000' AS DateTime2), CAST(45000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Sale] ([SaleId], [CustomerName], [SaleDate], [TotalAmount], [SaleBy]) VALUES (10, N'Khách E', CAST(N'2025-03-05T00:00:00.0000000' AS DateTime2), CAST(56000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Sale] ([SaleId], [CustomerName], [SaleDate], [TotalAmount], [SaleBy]) VALUES (11, N'Tấn Dũng', CAST(N'2025-09-22T07:31:26.6853063' AS DateTime2), CAST(584000.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Sale] ([SaleId], [CustomerName], [SaleDate], [TotalAmount], [SaleBy]) VALUES (12, N'Khách E', CAST(N'2025-09-22T07:32:46.5230006' AS DateTime2), CAST(2200.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO

SET IDENTITY_INSERT [dbo].[SaleDetail] ON
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [PackagingId], [QuantityPacks], [QuantityPills], [UnitPrice], [MedicineId]) VALUES (6, 6, 1, 5, 0, CAST(120.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [PackagingId], [QuantityPacks], [QuantityPills], [UnitPrice], [MedicineId]) VALUES (7, 7, 5, 0, 5, CAST(90.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [PackagingId], [QuantityPacks], [QuantityPills], [UnitPrice], [MedicineId]) VALUES (8, 8, 4, 2, 0, CAST(140.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [PackagingId], [QuantityPacks], [QuantityPills], [UnitPrice], [MedicineId]) VALUES (9, 9, 3, 3, 0, CAST(160.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [PackagingId], [QuantityPacks], [QuantityPills], [UnitPrice], [MedicineId]) VALUES (10, 10, 6, 0, 10, CAST(220.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [PackagingId], [QuantityPacks], [QuantityPills], [UnitPrice], [MedicineId]) VALUES (11, 11, 2, 3, 13, CAST(8000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [PackagingId], [QuantityPacks], [QuantityPills], [UnitPrice], [MedicineId]) VALUES (12, 12, 6, 0, 10, CAST(220.00 AS Decimal(18, 2)), 5)
SET IDENTITY_INSERT [dbo].[SaleDetail] OFF
GO

SET IDENTITY_INSERT [dbo].[SaleBatchAllocation] ON
INSERT [dbo].[SaleBatchAllocation] ([AllocationId], [SaleId], [SaleDetailId], [BatchId], [AllocatedPills]) VALUES (1, 11, 11, 2, 73)
INSERT [dbo].[SaleBatchAllocation] ([AllocationId], [SaleId], [SaleDetailId], [BatchId], [AllocatedPills]) VALUES (2, 12, 12, 3, 10)
SET IDENTITY_INSERT [dbo].[SaleBatchAllocation] OFF
GO

ALTER TABLE [dbo].[Accounts] ADD UNIQUE NONCLUSTERED ([Username] ASC)
GO

ALTER TABLE [dbo].[Medicine] ADD UNIQUE NONCLUSTERED ([MedicineCode] ASC)
GO

ALTER TABLE [dbo].[Packaging] ADD UNIQUE NONCLUSTERED ([MedicineId] ASC, [PackagingCode] ASC)
GO

ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED ([RoleName] ASC)
GO

ALTER TABLE [dbo].[Accounts] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Accounts] ADD DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Batch] ADD DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Medicine] ADD DEFAULT (N'viên') FOR [Unit]
GO

ALTER TABLE [dbo].[Purchase] ADD DEFAULT (sysutcdatetime()) FOR [PurchaseDate]
GO

ALTER TABLE [dbo].[Sale] ADD DEFAULT (sysutcdatetime()) FOR [SaleDate]
GO

ALTER TABLE [dbo].[SaleDetail] ADD DEFAULT ((0)) FOR [QuantityPacks]
GO

ALTER TABLE [dbo].[SaleDetail] ADD DEFAULT ((0)) FOR [QuantityPills]
GO

ALTER TABLE [dbo].[Accounts] WITH CHECK ADD FOREIGN KEY([CreatedBy]) REFERENCES [dbo].[Accounts] ([AccId])
GO

ALTER TABLE [dbo].[Accounts] WITH CHECK ADD FOREIGN KEY([RoleID]) REFERENCES [dbo].[Roles] ([RoleID])
GO

ALTER TABLE [dbo].[Batch] WITH CHECK ADD FOREIGN KEY([PackagingId]) REFERENCES [dbo].[Packaging] ([PackagingId])
GO

ALTER TABLE [dbo].[Packaging] WITH CHECK ADD FOREIGN KEY([MedicineId]) REFERENCES [dbo].[Medicine] ([MedicineId])
GO

ALTER TABLE [dbo].[Purchase] WITH CHECK ADD FOREIGN KEY([SupplierId]) REFERENCES [dbo].[Supplier] ([SupplierId])
GO

ALTER TABLE [dbo].[PurchaseDetail] WITH CHECK ADD FOREIGN KEY([BatchId]) REFERENCES [dbo].[Batch] ([BatchId])
GO

ALTER TABLE [dbo].[PurchaseDetail] WITH CHECK ADD FOREIGN KEY([PurchaseId]) REFERENCES [dbo].[Purchase] ([PurchaseId])
GO

ALTER TABLE [dbo].[Sale] WITH CHECK ADD FOREIGN KEY([SaleBy]) REFERENCES [dbo].[Accounts] ([AccId])
GO

ALTER TABLE [dbo].[SaleBatchAllocation] WITH CHECK ADD FOREIGN KEY([BatchId]) REFERENCES [dbo].[Batch] ([BatchId])
GO

ALTER TABLE [dbo].[SaleBatchAllocation] WITH CHECK ADD FOREIGN KEY([SaleDetailId]) REFERENCES [dbo].[SaleDetail] ([SaleDetailId])
GO

ALTER TABLE [dbo].[SaleBatchAllocation] WITH CHECK ADD FOREIGN KEY([SaleId]) REFERENCES [dbo].[Sale] ([SaleId])
GO

ALTER TABLE [dbo].[SaleDetail] WITH CHECK ADD FOREIGN KEY([MedicineId]) REFERENCES [dbo].[Medicine] ([MedicineId])
GO

ALTER TABLE [dbo].[SaleDetail] WITH CHECK ADD FOREIGN KEY([PackagingId]) REFERENCES [dbo].[Packaging] ([PackagingId])
GO

ALTER TABLE [dbo].[SaleDetail] WITH CHECK ADD FOREIGN KEY([SaleId]) REFERENCES [dbo].[Sale] ([SaleId])
GO

ALTER TABLE [dbo].[Batch] WITH CHECK ADD CHECK (([QuantityPills]>=(0)))
GO

ALTER TABLE [dbo].[PurchaseDetail] WITH CHECK ADD CHECK (([QuantityPills]>(0)))
GO

ALTER TABLE [dbo].[SaleBatchAllocation] WITH CHECK ADD CHECK (([AllocatedPills]>(0)))
GO

ALTER TABLE [dbo].[SaleDetail] WITH CHECK ADD CONSTRAINT [CHK_SaleDetail_AtLeastOne] CHECK (([QuantityPacks]>(0) OR [QuantityPills]>(0)))
GO

ALTER TABLE [dbo].[SaleDetail] CHECK CONSTRAINT [CHK_SaleDetail_AtLeastOne]
GO

ALTER TABLE [dbo].[SaleDetail] WITH CHECK ADD CONSTRAINT [CHK_SaleDetail_QtyNonNegative] CHECK (([QuantityPacks]>=(0) AND [QuantityPills]>=(0)))
GO

ALTER TABLE [dbo].[SaleDetail] CHECK CONSTRAINT [CHK_SaleDetail_QtyNonNegative]
GO

CREATE TRIGGER [dbo].[trg_Batch_CalcQuantityAndPurchasePrice]
ON [dbo].[Batch]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE b
    SET
        b.QuantityPills = ISNULL(b.ReceivedLoosePills,0)
                        + (ISNULL(b.ReceivedPacks,0) * ISNULL(p.PillsPerPack,0)),
        b.PurchasePrice = (
            ISNULL(b.ReceivedLoosePills,0)
            + (ISNULL(b.ReceivedPacks,0) * ISNULL(p.PillsPerPack,0))
        ) * ISNULL(p.PricePerPill,0)
    FROM Batch b
    INNER JOIN inserted i ON b.BatchId = i.BatchId
    LEFT JOIN Packaging p ON b.PackagingId = p.PackagingId;
END;
GO

ALTER TABLE [dbo].[Batch] ENABLE TRIGGER [trg_Batch_CalcQuantityAndPurchasePrice]
GO

CREATE TRIGGER [dbo].[trg_Packaging_CalcPrice]
ON [dbo].[Packaging]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE p
    SET p.PricePerPack = ISNULL(i.PricePerPill,0) * i.PillsPerPack
    FROM Packaging p
    INNER JOIN inserted i ON p.PackagingId = i.PackagingId;
END;
GO

ALTER TABLE [dbo].[Packaging] ENABLE TRIGGER [trg_Packaging_CalcPrice]
GO