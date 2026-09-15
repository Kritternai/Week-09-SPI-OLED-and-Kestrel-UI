# การส่งงานสัปดาห์ที่ 9: SPI OLED Display & Edge Kestrel UI

* **รหัสนักศึกษา:** 67030011
* **Git Branch:** `HW-67030011`

---

## สารบัญงานและรายงานผลการทดลอง

1. **รายงานผลการทดลอง Lab 9.2:**
   - [07-Labsheet-09-2-Kestrel-Calibration-and-Display-API.md](07-Labsheet-09-2-Kestrel-Calibration-and-Display-API.md)
   - รายละเอียด: การพัฒนาเอนจินปรับเทียบเซนเซอร์ Two-Point Linear Calibration และ REST Minimal API บน Kestrel Web Server พร้อมผลการตรวจสอบเชิงนิติวิทยาศาสตร์เครือข่าย (cURL Forensics & Fault Injection)

2. **โฟลเดอร์ซอร์สโค้ดโปรเจกต์:**
   - [ESP32.Kestrel.Webserver/](ESP32.Kestrel.Webserver/)
     - [Program.cs](ESP32.Kestrel.Webserver/Program.cs)
     - [Services/CalibrationService.cs](ESP32.Kestrel.Webserver/Services/CalibrationService.cs)
     - [Services/DisplayMessageRequest.cs](ESP32.Kestrel.Webserver/Services/DisplayMessageRequest.cs)

3. **โฟลเดอร์รูปภาพผลลัพธ์การทดลอง:**
   - [Images/](Images/)
     - `lab9-2-activity-2-0-server-bringup.png` (การคอมไพล์และรันเซิร์ฟเวอร์ Kestrel)
     - `lab9-2-activity-2-1-calibration-service-build.png` (ไฟล์โมเดล Services และผล Build)
     - `lab9-2-forensic-2-1-curl-endpoints.png` (ผลการยิง cURL ทดสอบทั้ง 3 Endpoints)
     - `lab9-2-forensic-2-2-fault-injection.png` (ผลการทดสอบ Fault Injection 400 Bad Request / 415)
