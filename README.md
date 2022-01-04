# Manage-File-Application
Ứng dụng cần quét hết đĩa cứng và đánh chỉ mục tên file, nội dung file (với những dạng file có nội dung là text như doc, pdf, txt) cho tìm kiếm theo tên, theo nội dung file một cách nhanh chóng, xoá file, mở file theo định dạng tương tứng (ví dụ mở file doc thì word sẽ mở nó lên). Thống kê file theo nhiều tiêu chí như: theo định dạng, theo thời gian, theo từ khoá.

# Feature/gui
- Quét hết đĩa cứng, quét folder, file có text như: doc, pdf, txt, docx.
- Xóa, sửa tên (KeyDown: F2), copy, cut, paste file/folder; mở file tương ứng loại file; mở folder; new folder, new file txt.
- Thống kê theo nhiều tiêu chí: tên, định dạng, path, thời gian, size, content.
- Responsive ứng dụng.
- Xem danh sách file theo nhiều kiểu view.
- Có thể tùy chỉnh độ rộng của listview, tree folder.
- btn Back, btn Forward.
- Load file vào listview bằng cách chọn folder trên treeFolder/folder trong listView/gõ đường dẫn (Enter or bấm Go).
- Sắp xếp file theo A-Z, Z-A, ngày tháng (chưa xếp được size file).
- Hiển thị số file được chọn, số file trong một folder.
- Thêm contextMenu để thao tác refresh, thêm, xóa, sửa, thêm mới,...
- Search file với các nội dung: name, content, date created.
