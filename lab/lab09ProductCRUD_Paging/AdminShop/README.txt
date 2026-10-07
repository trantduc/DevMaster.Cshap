DMIN SHOP - ASP.NET CORE MVC / EF CORE CODE FIRST / SQL SERVER

1. Mở AdminShop.csproj bằng Visual Studio.
2. Nếu SQL Server của bạn không dùng Server=. thì sửa DefaultConnection trong appsettings.json.
   Ví dụ SQL Express: Server=.\SQLEXPRESS;Database=AdminShopDb;Trusted_Connection=True;TrustServerCertificate=True
3. Tools > NuGet Package Manager > Package Manager Console.
4. Chạy:
   Add-Migration InitialCreate
   Update-Database
5. F5 hoặc Ctrl+F5. HTTPS mặc định: https://localhost:7230

PHẠM VI:
- Product: CRUD đầy đủ, tìm kiếm theo tên, paging 5 dòng/trang, upload ảnh, Category.
- Category/Blog/Banner/Customer/Account/Orders: query danh sách.
- Code First tạo các bảng Category, Product, Blog, Banner, Account, Customer, Orders, OrderDetail.
- Có dữ liệu seed Category + Product để xem paging ngay.
