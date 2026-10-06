namespace ESP32.Kestrel.Webserver.Services;

public class CalibrationSettings
{
    public int RawMin { get; set; } = 150;     // ค่าดิบต่ำสุด (Zero Point)
    public int RawMax { get; set; } = 3950;    // ค่าดิบสูงสุด (Span Point)
    public double ScaleMin { get; set; } = 0.0;
    public double ScaleMax { get; set; } = 100.0;
    public string Unit { get; set; } = "%";
}

public class CalibrationService
{
    private CalibrationSettings _settings = new();
    private string _currentOledMessage = "READY";

    public CalibrationSettings Settings => _settings;
    public string CurrentOledMessage => _currentOledMessage;

    public void UpdateSettings(CalibrationSettings newSettings)
    {
        // ป้องกันข้อผิดพลาดการหารด้วยศูนย์
        if (newSettings.RawMax <= newSettings.RawMin)
        {
            throw new ArgumentException("RawMax ต้องมีค่ามากกว่า RawMin เสมอ!");
        }
        _settings = newSettings;
    }

    public void SetOledMessage(string msg)
    {
        // Zone 3 ของ OLED เริ่มวาดข้อความที่ X=42 ตัวละ 6 px และหยุดเมื่อ X > 122
        // จึงแสดงได้สูงสุด 14 ตัวอักษร ตัดที่ฝั่ง Server ให้ตรงกับที่จอแสดงจริง
        _currentOledMessage = msg.Length > 14 ? msg[..14] : msg;
    }

    public double Compute(int rawAdc)
    {
        // Clamp ค่าให้อยู่ในช่วงที่กำหนด ป้องกันสเกลทะลัก
        int clamped = Math.Clamp(rawAdc, _settings.RawMin, _settings.RawMax);
        return ((double)(clamped - _settings.RawMin) / (_settings.RawMax - _settings.RawMin)) 
               * (_settings.ScaleMax - _settings.ScaleMin) + _settings.ScaleMin;
    }
}
