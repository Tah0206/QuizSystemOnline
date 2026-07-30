# 🎓 Online Quiz System (Hệ thống thi trắc nghiệm trực tuyến)

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-purple)
![Bootstrap](https://img.shields.io/badge/Frontend-Bootstrap%205-blue)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![License](https://img.shields.io/badge/License-MIT-green)

> **Mô tả:** Dự án Website quản lý và tổ chức thi trắc nghiệm trực tuyến được xây dựng dựa trên nền tảng **ASP.NET Core (Razor Pages)**. Đây là đồ án môn học chuyên ngành Công nghệ Phần mềm tại Trường Đại học Ngoại ngữ - Tin học TP.HCM (HUFLIT).

---

## 📸 Demo Giao diện (Screenshots)
| Trang Chủ | Trang Quản trị |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/ef8022db-368a-4935-9e2b-75a28198df07" alt="Home Page" width="400"/> | <img src="https://github.com/user-attachments/assets/5be57ceb-5d5f-4245-bdad-d835896a7aeb" alt="Quiz Page" width="400"/> |
| Trang Làm bài | Trang Kết quả |
| <img src="https://github.com/user-attachments/assets/1651a183-597b-4a67-8ba6-b9387e5657f1" alt="Ex Page" width="400"/> | <img src="https://github.com/user-attachments/assets/5e2c6656-33a4-4ab0-9651-2d27c53c8e8f" alt="Result Page" width="400"/> |

## 🛠 Công nghệ & Kỹ thuật (Tech Stack)

### Backend
* **Framework:** ASP.NET Core 8.0 (Razor Pages) - *Kiến trúc Page-based gọn nhẹ, hiệu năng cao.*
* **ORM:** Entity Framework Core (Code First) - *Quản lý dữ liệu và Migrations.*
* **Authentication:** ASP.NET Core Identity - *Bảo mật, phân quyền Admin/Student.*

### Frontend
* **Interface:** HTML5, CSS3, Bootstrap 5 (Responsive Design).
* **Scripting:** JavaScript (ES6), jQuery.
* **Logic:** Xử lý đếm ngược thời gian (Countdown Timer) và Auto-submit phía Client.

### Database & Tools
* **Database:** SQL Server.
* **IDE:** Visual Studio 2022.
* **Version Control:** Git & GitHub.

---

## ✨ Tính năng chi tiết (Key Features)

### 👨‍💻 Phân hệ Quản trị (Admin / Giảng viên)
- [x] **Dashboard:** Xem thống kê tổng quan (số lượng sinh viên, đề thi, kết quả).
- [x] **Quản lý Môn học:** CRUD (Thêm/Sửa/Xóa) các môn học.
- [x] **Quản lý Ngân hàng câu hỏi:** - Thêm câu hỏi mới với nhiều lựa chọn đáp án.
    - Đánh dấu đáp án đúng.
    - Phân loại câu hỏi theo độ khó (Dễ/Trung bình/Khó).
- [x] **Quản lý Đề thi (Exam):**
    - Tạo đề thi thủ công hoặc **Random** (lấy ngẫu nhiên câu hỏi từ ngân hàng).
    - Xáo trộn câu trả lời trong đề thi
    - Cài đặt thời gian làm bài.
- [x] **Quản lý Kết quả:** Xem bảng điểm chi tiết của từng sinh viên.

### 👨‍🎓 Phân hệ Sinh viên (User)
- [x] **Đăng ký/Đăng nhập:** Bảo mật thông tin cá nhân.
- [x] **Danh sách đề thi:** Xem các kỳ thi đang mở.
- [x] **Làm bài thi (Real-time):**
    - Giao diện làm bài tập trung, dễ nhìn.
    - **Countdown Timer:** Đồng hồ đếm ngược thời gian thực (chống gian lận thời gian).
    - Tự động chuyển câu hỏi.
- [x] **Nộp bài & Chấm điểm:**
    - Nút "Nộp bài" sớm.
    - **Auto-submit:** Hệ thống tự động thu bài khi hết giờ.
    - Hiển thị điểm số và đáp án đúng/sai ngay lập tức (hoặc ẩn tùy cấu hình).

---

## 🗂 Cấu trúc Cơ sở dữ liệu (Database Schema)
Hệ thống bao gồm các thực thể (Entities) chính:
* `ApplicationUser`: Mở rộng từ IdentityUser (lưu thông tin Sinh viên/Giảng viên).
* `Subject`: Lưu thông tin môn học.
* `Question`: Lưu nội dung câu hỏi, độ khó, môn học tương ứng.
* `Exam`: Lưu thông tin đề thi, thời gian, mã đề.
* `ExamResult`: Lưu kết quả thi, điểm số, ngày giờ nộp bài của sinh viên.

---

## ⚙️ Hướng dẫn cài đặt & Chạy (Installation Guide)

Để chạy dự án này trên máy cục bộ (Localhost), vui lòng làm theo các bước sau:

### Bước 1: Clone dự án
Mở Git Bash hoặc Terminal và chạy lệnh:
```bash
git clone https://github.com/Tah0206/QuizSystemOnline.git
```
### Bước 2: Thiết lập Database

#### Phục hồi file `.BAK` vào SQL Server

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối tới server của bạn
3. Chuột phải vào **Databases > Restore Database…**
4. Chọn **Device** và trỏ đến file `QLKhachSan.BAK` có trong project
5. Nhấn **OK** để phục hồi database
6. Sau khi hoàn tất bạn sẽ có database sẵn sàng để sử dụng

> Việc restore file .BAK sẽ tạo ra database với đầy đủ bảng dữ liệu cần thiết cho website hoạt động bình thường.


### Bước 3: Cấu hình Database
Mở file `appsettings.json.`

Tìm phần ConnectionStrings. Thay đổi Server Name thành tên Server của bạn:

```json

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=OnlineQuizDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

### Bước 4: Cập nhật Cơ sở dữ liệu (Migrations)
Mở dự án bằng Visual Studio 2022.

Vào menu: `Tools > NuGet Package Manager > Package Manager Console.`

Chạy lệnh sau để khởi tạo Database:

```PowerShell
Update-Database
```

### Bước 5: Khởi chạy
Nhấn tổ hợp phím **F5** hoặc nút ▶ Run trên thanh công cụ.

Trình duyệt sẽ mở ra trang chủ.

* Tài khoản Admin mặc định: Admin / 123

## 🗺 Lộ trình phát triển (Roadmap)
* Thêm tính năng Import câu hỏi từ file Excel.

* Xuất bảng điểm ra file PDF/Excel.

* Thêm dạng câu hỏi "Điền vào chỗ trống".

* Tối ưu giao diện Mobile

## 📞 Liên hệ (Contact)
Nếu bạn thấy dự án này thú vị hoặc muốn trao đổi thêm về kỹ thuật, hãy liên hệ vào trang profile mình
