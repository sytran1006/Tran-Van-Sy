# Xây dựng CSDL quản lí lớp học(app console)
## Yêu cầu:
* Vẽ diagram (https://draw.io/) trước khi thiết kế trên SQL
* Thiết kế CSDL với SQL Server
* Hoàn thành những câu hỏi truy vấn

## Thông tin cơ bản gồm:
* Thông tin sinh viên: Họ và tên, giới tính,ngày tháng năm sinh, email, số điện thoại, điểm, lớp học...
* Thông tin lớp : Mã lớp, tên lớp, giáo viên quản lý, thời gian bắt đầu, thời gian kết thúc..
* Thông tin giáo viên: Họ và tên, ngày tháng năm sinh, năm vào trường học, số điện thoại, địa chỉ email,...

## Thêm dữ liệu mẫu
1. Thêm dữ liệu mẫu với 1000 sinh viên
2. Thêm dữ liệu mẫu với 100 giáo viên
3. Thêm dữ liệu mẫu với 50 lớp

## Viết truy vấn SQL cho các phần
1. Thêm, sửa, xóa, tìm kiếm sinh viên
2. Thêm, sửa, xóa, tìm kiếm giáo viên
3. Thêm, sửa, xóa, tìm kiếm lớp
4. Lấy danh sách sinh viên, giáo viên, lớp
5. Đếm số lượng sinh viên theo từng lớp sinh viên
6. Thống kê top 10 sinh viên có điểm cao nhất trong lớp bất kì
7. Thống kê số học sinh nam trong mỗi lớp.
8. Lấy ra điểm trung bình của từng lớp.
9. Lấy ra danh sách các lớp mà giáo viên chủ nhiệm
10. Lấy ra giáo viên chủ nhiệm nhiều lớp nhất


## Nâng cao 
1. Thống kê 10 giáo viên khác nhau chủ nhiệm lớp có điểm trung bình cao nhất
2. Suy nghĩ về trường hợp có nhiều hàng trăm nghìn records trong bảng Student, Class, Teacher chúng ta cần tìm theo các trường:
* Student: giới tính
* Giáo viên: năm vào trường học
* Lớp: thời gian bắt đầu, thời gian kết thúc

### Lưu ý
1. Push file lệnh lên theo từng bài
2. Thử xóa 1 giáo viên, sinh viên bất kỳ, xóa lớp sinh viên
    * Có sự khác biệt gì khi xóa giáo viên và sinh viên?
    * Vấn đề gì sẽ xảy ra khi xóa?
    * Có cách nào giải quyết vấn đề đó?
3. Tìm hiểu về __primary key, foreign key, index, unique__
4. Những phần ... là những phần có thể mở rộng thêm thông tin
5. Không đặt tên các trường, tên bảng, database bằng Tiếng Việt


