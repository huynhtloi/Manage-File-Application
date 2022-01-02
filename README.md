# Manage-File-Application
Ứng dụng cần quét hết đĩa cứng và đánh chỉ mục tên file, nội dung file (với những dạng file có nội dung là text như doc, pdf, txt) cho tìm kiếm theo tên, theo nội dung file một cách nhanh chóng, xoá file, mở file theo định dạng tương tứng (ví dụ mở file doc thì word sẽ mở nó lên). Thống kê file theo nhiều tiêu chí như: theo định dạng, theo thời gian, theo từ khoá.

# Feature/gui
- Quét hết đĩa cứng, quét file có text như: doc, pdf, txt, docx.
- Xóa file, sửa tên file (KeyDown: F2), mở file tương ứng loại file.
- Thống kê theo nhiều tiêu chí: tên, định dạng, path, thời gian, size, content.
- Responsive ứng dụng.
- Xem danh sách file theo nhiều kiểu view.
- Có thể tùy chỉnh độ rộng của listview, tree folder.
- btnBack, btnForward sử dụng stack.
- Load file vào listview bằng cách chọn folder trên tree folder hoặc gõ đường dẫn (Enter or bấm Go).
- Sắp xếp file theo A-Z, Z-A (chưa xếp được size file).
- Hiển thị số file được chọn, số file trong một folder.
