---
description: "Sinh code theo kiến trúc MVP + Layered + DI của dự án HieuThuoc"
mode: ask
---

Bạn là một lập trình viên C# WinForms, làm việc với kiến trúc MVP + Layered (Repository + Service) với DI.
Dựa trên mô tả dự án sau đây, hãy sinh code theo đúng chuẩn:
[MVP kết hợp Layered (Repository + Service) với DI:
•	Mô hình: MVP (View = WinForm, Presenter chứa UI logic)
•	Tách layer: UI (View/Presenter) → Services (Business) → Data / Repositories (DAL) → Domain (entities/DTOs)
•	Data Access: ADO.NET (SqlClient) hoặc Dapper
•	DI: Microsoft.Extensions.DependencyInjection
•	Logging: Serilog 
•	Config: app.config (lưu connectionString)
Lý do:
•	MVP phù hợp với WinForms, làm rõ việc test Presenter.
•	Layered/Repository giúp chứa logic kho/phân bổ (quan trọng) trong Service, tránh để UI xử lý logic.
•	Dễ mở rộng (ví dụ thêm API, WPF, Web sau này) vì business logic nằm riêng.
C# 7.8
.NET framework 4.7.2 (WinForms .NET), Visual Studio 2022+
DB: SQL Server  (đã tạo bảng sẵn trong SQL Server)
a. Cách tổ chức code và trách nhiệm:
Domain: chỉ chứa POCO entity (không tham chiếu UI/EF cụ thể. Gồm Medicine, Packaging, Batch, Purchase, PurchaseDetail, Sale, SaleDetail, Roles, Accounts).
Data (DAL):
•	Implement các IRepository bằng ADO.NET / Dapper.
•	Có SqlConnectionFactory / DbHelper để quản lý connection string và tạo SqlConnection.
•	Repositories chịu trách nhiệm mapping từ IDataReader -> entity hoặc sử dụng Dapper để map tự động.
•	Chứa sql/ scripts cho create & seed; mọi thay đổi schema thực hiện bằng script và lưu versioned trong sql/.
Services (BLL):
•	Chứa nghiệp vụ FEFO, validate, transaction logic (kêu DAL cập nhật).
•	Khi thực hiện bán: Service sẽ mở một SqlConnection + SqlTransaction, gọi repository để lấy batch theo FEFO (SELECT ... FOR UPDATE kiểu lock bằng UPDLOCK, ROWLOCK), cập nhật Batch.QuantityPills, chèn Sale, SaleDetail, SaleBatchAllocation, commmit/rollback.
UI (Views + Presenters): Forms implement IView interfaces; Presenter nhận event từ View, gọi Service, cập nhật View. Chỉ xử lý UI/event. Presenter không trực tiếp thao tác SQL.
Common: helper, constants, mapping (AutoMapper).
b. UI UX thiết kế (form chính)
•	MainForm: dashboard — cảnh báo near expiry, low stock (đỏ/vàng), search thuốc
•	BatchManagementForm: list lô theo thuốc, CRUD lô, nhập kho
•	PurchaseForm: tạo Purchase => tạo Batch(s)
•	SaleForm: dạng POS đơn giản — chọn thuốc, chọn số hộp/viên, tính tổng, click Sell
o	Khi Sell: gọi Presenter → Service → allocate FEFO → tạo Sale + SaleDetail + SaleBatchAllocation
o	Hiển thị popup nếu thiếu hàng
•	Reports: tồn kho theo thuốc (viên + quy đổi hộp), hàng sắp hết hạn
c. Quy ước lập trình & đặt tên
•	Class: PascalCase (e.g., InventoryService, BatchRepository)
•	Interface: I + PascalCase (e.g., IInventoryService)
•	Repository returns collections (IEnumerable<Batch> / List<Batch>)
•	DTO suffix: Dto (e.g., BatchDto)
•	Presenter suffix: Presenter (e.g., SalePresenter)
•	View interface: I{Name}View (e.g., ISaleView)
d. Cấu trúc thư mục hiện tại.
HieuThuoc
├─ src/
   ├─ HieuThuoc.Domain/            # Entities, Enums, DTOs
   │    └─ Entities/
   │         Medicine.cs
   │         Batch.cs
   │         Packaging.cs
   │    └─ DTOs/
   
   ├─ HieuThuoc.Data/              # Repositories, sql

   │    └─ Repositories/
   │    └─ sql/                    
 
   ├─ HieuThuoc.Services/          # Business logic (FEFO, allocation, reports)
   │    └─ Interfaces/
   │    └─ Implementations/
   │    └─ DTOs/                       # service layer DTOs
 
   ├─ HieuThuoc.UI/                 # WinForms app + Presenters
   │    └─ Forms/
   │         Form1.cs                 # Main form
   │    └─ Presenters/
   │    └─ Views/Interfaces/
   │    └─ Program.cs                  # DI bootstrap & Application.Run
   │    └─ app.config               # chứa cấu hình kết nối DB (connection string)
 
   └─ HieuThuoc.Common/             # Utilities, exceptions, constants, mapping, Helpers
        └─ MappingProfiles.cs (AutoMapper) #file này chưa có gì
        └─ Exceptions/
        └─ Helpers
 e. SQL server (các bảng):
-- Medicine: thông tin thuốc
CREATE TABLE Medicine (
  MedicineId    INT IDENTITY(1,1) PRIMARY KEY,
  MedicineCode  NVARCHAR(50) NOT NULL UNIQUE,   -- mã thuốc
  Name          NVARCHAR(255) NOT NULL,
  GenericName   NVARCHAR(255) NULL, --tên hoạt chất của thuốc (do WHO quy định)
  Manufacturer  NVARCHAR(255) NULL, --nhà sản xuất
  Unit          NVARCHAR(50) NOT NULL DEFAULT N'viên', -- unit cơ bản
  Description   NVARCHAR(MAX) NULL,
  ImageFile NVARCHAR(255) null
);
go
-- Packaging: kiểu đóng gói (ví dụ: Hộp 10 viên, Vỉ 4 viên...)
CREATE TABLE Packaging (
  PackagingId   INT IDENTITY(1,1) PRIMARY KEY,
  MedicineId    INT NOT NULL FOREIGN KEY REFERENCES Medicine(MedicineId),
  PackagingCode NVARCHAR(50) NOT NULL,   -- mã hộp (mã bao bì)
  Name          NVARCHAR(255) NULL,      -- ví dụ "Hộp 10 viên"
  PillsPerPack  INT NOT NULL,            -- số viên trong 1 pack/hộp
  PricePerPack DECIMAL(18,2) NULL,    -- giá bán 1 hộp
  PricePerPill DECIMAL(18,4) NULL,
  UNIQUE(MedicineId, PackagingCode)
);
go
CREATE TRIGGER trg_Packaging_CalcPrice
ON Packaging
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE p
	SET p.PricePerPack = ISNULL(i.PricePerPill,0) * i.PillsPerPack
    FROM Packaging p
    INNER JOIN inserted i ON p.PackagingId = i.PackagingId;
END;
go
-- Supplier: bên nhập thuốc
CREATE TABLE Supplier (
  SupplierId    INT IDENTITY(1,1) PRIMARY KEY,
  Name          NVARCHAR(255) NOT NULL,
  Phone         NVARCHAR(20) NULL,
  Address       NVARCHAR(MAX) NULL
);

-- Batch: mỗi lô nhập kho, lưu quantity tính theo "viên"
CREATE TABLE Batch (
  BatchId       INT IDENTITY(1,1) PRIMARY KEY,
  PackagingId    INT NULL FOREIGN KEY REFERENCES Packaging(PackagingId),
  BatchCode     NVARCHAR(100) NULL,      -- mã lô/lot
  ExpiryDate    DATE NOT NULL,
  QuantityPills INT NOT NULL CHECK (QuantityPills >= 0), -- tổng viên còn trong lô
  PurchasePrice DECIMAL(18,2) NOT NULL,  -- đơn giá tổng
  ReceivedPacks INT NULL,                 -- lưu số pack nhận ban đầu
  ReceivedLoosePills INT NULL,            -- nếu có viên lẻ
  CreatedAt     DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
go
CREATE TRIGGER trg_Batch_CalcQuantityAndPurchasePrice
ON Batch
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
go
-- Purchase + PurchaseDetail (liên kết tới Batch)
CREATE TABLE Purchase (
  PurchaseId    INT IDENTITY(1,1) PRIMARY KEY,
  SupplierId    INT FOREIGN KEY REFERENCES Supplier(SupplierId),
  PurchaseDate  DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  TotalAmount   DECIMAL(18,2) NOT NULL
);

CREATE TABLE PurchaseDetail (
  PurchaseDetailId INT IDENTITY(1,1) PRIMARY KEY,
  PurchaseId       INT NOT NULL FOREIGN KEY REFERENCES Purchase(PurchaseId),
  BatchId          INT NOT NULL FOREIGN KEY REFERENCES Batch(BatchId),
  QuantityPacks    INT NULL,
  QuantityPills    INT NOT NULL CHECK (QuantityPills > 0), --tổng viên của detail
  UnitPricePerPill DECIMAL(18,2) NOT NULL
);

-- Sale + SaleDetail (ghi đơn bán - đơn giản theo yêu cầu)
CREATE TABLE Sale (
  SaleId        INT IDENTITY(1,1) PRIMARY KEY,
  CustomerName  NVARCHAR(255) NULL,
  SaleDate      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  TotalAmount   DECIMAL(18,2) NOT NULL,
  SaleBy		int null FOREIGN KEY REFERENCES Accounts(AccID), --id của người bán
);

CREATE TABLE SaleDetail (
  SaleDetailId  INT IDENTITY(1,1) PRIMARY KEY,
  SaleId        INT NOT NULL FOREIGN KEY REFERENCES [Sale](SaleId),
  MedicineId   INT NULL FOREIGN KEY REFERENCES Medicine(MedicineId), --trường hợp nếu bán theo viên lẻ thì khi đó packageid null nên phải có medicineid
  PackagingId   INT NULL FOREIGN KEY REFERENCES Packaging(PackagingId), -- nếu bán theo pack
  QuantityPacks INT DEFAULT 0,    -- số hộp
  QuantityPills INT DEFAULT 0,    -- số viên lẻ
  UnitPrice     DECIMAL(18,2) NOT NULL,  -- giá bán per pill
);
go
ALTER TABLE SaleDetail
ADD CONSTRAINT CHK_SaleDetail_QtyNonNegative CHECK (QuantityPacks >= 0 AND QuantityPills >= 0);
go
-- ensure at least one > 0
ALTER TABLE SaleDetail
ADD CONSTRAINT CHK_SaleDetail_AtLeastOne CHECK (QuantityPacks > 0 OR QuantityPills > 0);
go
-- SaleBatchAllocation: để ghi rõ "lấy từ lô nào bao nhiêu viên" (quan trọng cho truy xuất & FEFO)
CREATE TABLE SaleBatchAllocation (
  AllocationId  INT IDENTITY(1,1) PRIMARY KEY,
  SaleId        INT NOT NULL FOREIGN KEY REFERENCES [Sale](SaleId),
  SaleDetailId  INT NOT NULL FOREIGN KEY REFERENCES SaleDetail(SaleDetailId),
  BatchId       INT NOT NULL FOREIGN KEY REFERENCES Batch(BatchId),
  AllocatedPills INT NOT NULL CHECK (AllocatedPills > 0) -- tổng viên thuốc bán
);
go
-- bảng Roles
CREATE TABLE Roles (
    RoleID			INT IDENTITY(1,1) PRIMARY KEY,
    RoleName		NVARCHAR(50) NOT NULL UNIQUE,	-- Tên quyền: Admin, QuanLy, NhanVien
    RoleDescription NVARCHAR(255) NULL				-- Mô tả quyền
);
--('Admin', N'Quyền cao nhất, quản lý toàn bộ hệ thống'),
--('QuanLy', N'Quản lý kho, bán hàng, báo cáo nhưng không tạo tài khoản'),
--('NhanVien', N'Nhập kho, bán hàng, xem báo cáo được phân quyền');
go
-- Account table
CREATE TABLE Accounts (
  AccId			INT IDENTITY(1,1) PRIMARY KEY,
  Username      NVARCHAR(50) NOT NULL UNIQUE,
  PasswordHash  NVARCHAR(255) NOT NULL,
  FullName		NVARCHAR(100) NOT NULL,
  email			nvarchar(50) null,
  SDT			nvarchar(10) null,
  RoleID		INT NOT NULL FOREIGN KEY REFERENCES Roles(RoleID), -- Liên kết tới bảng Roles
  CreatedBy		INT NULL FOREIGN KEY REFERENCES Accounts(AccID),  -- ID người tạo tài khoản
  CreatedAt		DATETIME DEFAULT GETDATE(),
  IsActive		BIT DEFAULT 1,										--1: đã kích hoạt, 0: chưa kích hoạt
  ImageFile NVARCHAR(255) null
);

f. Mục tiêu project:
Quản lý danh mục thuốc: tên, thành phần, hạn dùng, nhà cung cấp, số lô, giá mua/giá bán.

Quản lý kho: nhập kho, xuất kho (bán), tồn kho theo lô.

Bán hàng: tạo đơn bán, giảm tồn kho, in hóa đơn (nhân viên bán hàng, khách chỉ có thể xem các loại thuốc và
giá, khách không thể đăng nhập)

Cảnh báo thuốc gần hết hạn / tồn kho thấp.

Báo cáo doanh thu, lãi lỗ, tồn kho.
]

