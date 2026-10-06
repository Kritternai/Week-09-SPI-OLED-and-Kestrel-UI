# การส่งงานสัปดาห์ที่ 9: SPI OLED Display & Edge Kestrel UI

* **รหัสนักศึกษา:** 67030011
* **Git Branch:** `HW-67030011`

---

## สารบัญงานและรายงานผลการทดลอง

### 1. รายงานผลการทดลอง Lab 9.1 (Deconstructed SPI OLED Bringup)
- [06-Labsheet-09-1-SPI-OLED-Deconstructed-Bringup.md](06-Labsheet-09-1-SPI-OLED-Deconstructed-Bringup.md)
- **รายละเอียด:** การพัฒนาตัวขับจอภาพ SSD1306 แบบ 4-wire SPI จากระดับพื้นฐาน (Deconstructed Bring-up) ด้วย ESP-IDF v6.0.2, การทำ Bitwise Canvas บน 1KB Framebuffer, การสร้างตัวอักษรจาก `font5x7.h` แสดงข้อความ "HELLO WORLD" และรหัสนักศึกษา "ID: 67030011"
- **การตรวจสอบเชิงนิติวิทยาศาสตร์ (Forensics):**
  - Forensic Visual Observation Challenge: การวิเคราะห์จอแสดงผลกลับหัว 180 องศา และแถบสีเหลืองอยู่ด้านล่าง
  - Hex Dump Memory Inspection & Bit-to-Pixel Reconstruction ของตัวอักษร 'H'
  - ตอบคำถามท้ายการทดลองครบถ้วนทั้ง 3 ข้อ

### 2. รายงานผลการทดลอง Lab 9.2 (Kestrel Calibration & Display API)
- [07-Labsheet-09-2-Kestrel-Calibration-and-Display-API.md](07-Labsheet-09-2-Kestrel-Calibration-and-Display-API.md)
- **รายละเอียด:** การพัฒนาเอนจินปรับเทียบเซนเซอร์ Two-Point Linear Calibration และ REST Minimal API บน Kestrel Web Server (.NET 9.0)
- **การตรวจสอบเชิงนิติวิทยาศาสตร์เครือข่าย (Network Forensics):**
  - ทดสอบ cURL ทั้ง 3 Endpoints (`GET /api/telemetry`, `POST /api/potentiometer/calibrate`, `POST /api/oled/message`)
  - Fault Injection Testing (400 Bad Request เมื่อส่ง Slope <= 0 และ 415 Unsupported Media Type)
  - ตอบคำถามท้ายการทดลองครบถ้วนทั้ง 3 ข้อ

---

## รายการซอร์สโค้ดโปรเจกต์ (Source Code)

1. **โปรเจกต์ Lab 9.1 (ESP-IDF C Project):**
   - [Lab9-1_OLED_BringUp/](Lab9-1_OLED_BringUp/)
     - [main/Lab9-1_OLED_BringUp.c](Lab9-1_OLED_BringUp/main/Lab9-1_OLED_BringUp.c) (เฟิร์มแวร์ C ฉบับสมบูรณ์)
     - [main/font5x7.h](Lab9-1_OLED_BringUp/main/font5x7.h) (ตารางฟอนต์ Matrix 5x7)
     - [main/CMakeLists.txt](Lab9-1_OLED_BringUp/main/CMakeLists.txt)
     - [CMakeLists.txt](Lab9-1_OLED_BringUp/CMakeLists.txt)

2. **โปรเจกต์ Lab 9.2 (.NET Kestrel Webserver Project):**
   - [ESP32.Kestrel.Webserver/](ESP32.Kestrel.Webserver/)
     - [Program.cs](ESP32.Kestrel.Webserver/Program.cs)
     - [Services/CalibrationService.cs](ESP32.Kestrel.Webserver/Services/CalibrationService.cs)
     - [Services/DisplayMessageRequest.cs](ESP32.Kestrel.Webserver/Services/DisplayMessageRequest.cs)
     - [ESP32.Kestrel.Webserver.csproj](ESP32.Kestrel.Webserver/ESP32.Kestrel.Webserver.csproj)

---

## รูปภาพหลักฐานผลการทดลอง (Images Artifacts)

- [Images/](Images/)
  - `lab9-1-activity-1-0-create-and-build.png` (การสร้างโปรเจกต์และคอมไพล์ ESP-IDF บน Terminal)
  - `lab9-1-hardware-hello-world.jpg` (ภาพถ่ายฮาร์ดแวร์จริง ESP32 + 0.96" SPI OLED แสดง HELLO WORLD และ ID: 67030011)
  - `lab9-1-forensic-1-1-hexdump.png` (ภาพ Serial Monitor แสดงผล Hex Dump 16 ไบต์ของ Framebuffer Page 0)
  - `lab9-2-activity-2-0-server-bringup.png` (การคอมไพล์และรันเซิร์ฟเวอร์ Kestrel)
  - `lab9-2-activity-2-1-calibration-service-build.png` (ไฟล์โมเดล Services และผล Build)
  - `lab9-2-activity-2-2-routes-build.png` (การผูก Minimal API Routes และผล Build สำเร็จ)
  - `lab9-2-forensic-2-1-curl-endpoints.png` (ผลการยิง cURL ทดสอบทั้ง 3 Endpoints)
  - `lab9-2-forensic-2-2-fault-injection.png` (ผลการทดสอบ Fault Injection 400 Bad Request / 415)
