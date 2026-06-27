
1. Tổng quan kiến trúc
Solution áp dụng mô hình 3 lớp (3-tier) theo tài liệu thực hành:

┌─────────────────────────────────────────────────────────────┐
│  CMS.Data          │  Lớp Dữ liệu (Entities, EF sau này)   │
├─────────────────────────────────────────────────────────────┤
│  CMS.Backend       │  Lớp xử lý (ASP.NET Core MVC + API)   │
├─────────────────────────────────────────────────────────────┤
│  cms.frontend      │  Lớp giao diện (ReactJS — Create React)│
└─────────────────────────────────────────────────────────────┘
Project	Công nghệ	Vai trò
CMS.Data	.NET 8 Class Library	Định nghĩa Entity, map CSDL, dùng chung cho Backend/API
CMS.Backend	ASP.NET Core 8 MVC	Trang Admin, Razor Views, Web API (kế hoạch)
cms.frontend	React 18 (CRA)	Giao diện người xem tin tức, gọi API Backend
2. Cấu trúc thư mục
Solution: HuynhTramCMS_Solution (gồm 3 project)

Project 1: CMS.Backend (Được chọn làm Startup Project - in đậm)

Connected Services

Dependencies

Properties

wwwroot

Controllers

Models

Views

appsettings.json

Program.cs

Project 2: CMS.Data

Project 3: cms.frontend
3. Chi tiết chức năng từng module
3.1. CMS.Data — Lớp dữ liệu
File Entity	Chức năng	Kiểu dữ liệu chính	Quan hệ
Category.cs	Danh mục tin tức CMS	int Id, string Name, string Description	1 → N Post
Post.cs	Bài viết tin tức	string Title, Content, ImageUrl, DateTime CreatedDate, int CategoryId	N → 1 Category
User.cs	Tài khoản quản trị Admin	string Username, PasswordHash, FullName, Role	Độc lập
CategoryProduct.cs	Danh mục sản phẩm (E-commerce)	[Required] string Name, string? Description	1 → N Product
Product.cs	Sản phẩm	decimal(18,2) Price, int StockQuantity, int CategoryProductId	N → 1 CategoryProduct
Customer.cs	Khách hàng	string Email, Password, thông tin liên hệ	1 → N Order
Order.cs	Đơn hàng	int Status (0/1/2), DateTime OrderDate	N → 1 Customer, 1 → N OrderDetail
OrderDetail.cs	Chi tiết đơn	int Quantity, decimal UnitPrice	N → 1 Order, N → 1 Product
Ghi chú: Buổi 1 dùng dữ liệu mẫu in-memory trong Controller. Buổi sau sẽ nối Entity Framework Core + SQL Server.

3.2. CMS.Backend — Lớp MVC Admin
Controller	Route MVC	Chức năng	View
HomeController	/	Trang Welcome, điều hướng	Views/Home/Index.cshtml
CategoryController	/Category	Hiển thị bảng danh mục mẫu (kiểm chứng reference CMS.Data)	Views/Category/Index.cshtml
PostController	/Post	Danh sách bài viết dạng Card (ảnh, tiêu đề, mô tả, nút Xem chi tiết)	Views/Post/Index.cshtml
UserController	/User	Quản lý thành viên: badge quyền, nút Sửa/Xóa (Challenge 2)	Views/User/Index.cshtml
Công nghệ Backend: ASP.NET Core 8, Razor Views, Bootstrap 5, Kestrel HTTPS.
dmin
3.3. cms.frontend — Lớp React
File	Chức năng
src/config/nhuCmsAuthorInfo.js	Hằng số SV, URL Backend, dữ liệu mẫu Category/Post
src/App.js	Trang chủ: thông tin đồ án + 2 bảng dữ liệu mẫu
src/App.css	Giao diện card, bảng, header
Công nghệ Frontend: React 18, Create React App, npm.

URL chạy: http://localhost:3000/

cd cms.frontend
npm install   # lần đầu
npm start
4. Hướng dẫn chạy dự án
Yêu cầu
.NET 8 SDK
Node.js LTS (cho React)
Visual Studio 2022 hoặc VS Code / Cursor
Backend (bắt buộc — Startup Project)
cd CMS.Backend
dotnet run --launch-profile https
Visual Studio: chuột phải CMS.Backend → Set as Startup Project → F5.

Nếu lỗi address already in use cổng 7150:

lsof -ti :7150 | xargs kill -9
Frontend (terminal riêng)
cd cms.frontend
npm start
5. Luồng dữ liệu buổi 1 (Demo)
CMS.Data (Entity Category, Post, User)
    ↓ Project Reference
CMS.Backend (Controller tạo List<> mẫu)
    ↓ return View(model)
Razor View (HTML + Bootstrap)
    ↓ trình duyệt
https://localhost:7150/Category | /Post | /User
React (localhost:3000) hiện dùng dữ liệu đồng bộ từ nhuCmsAuthorInfo.js; buổi sau gọi fetch tới Web API Backend.

6. Nội dung nhánh buoi1
Khởi tạo Solution NhuCMS (đổi từ ThaiCMS).
Project CMS.Data: 8 Entity + comment chuyên nghiệp.
Project CMS.Backend: MVC, Category/Post/User Controller + View theo tài liệu.
Project cms.frontend: Create React App, trang thông tin SV + dữ liệu mẫu.
Cấu hình HTTPS port 7150, .gitignore loại bin/, obj/, node_modules/.
7. Tác giả & bản quyền
Dương Đào Huỳnh Như — MSSV: 2122110580 — Cao đẳng Công thương
Đồ án môn Chuyên đề ASP.NET — Năm 2026.
