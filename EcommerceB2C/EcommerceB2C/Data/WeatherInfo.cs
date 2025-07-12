namespace EcommerceB2C.Data;

public class WeatherInfo
{
    public string Name { get; set; }
    public MainInfo Main { get; set; }

    public class MainInfo
    {
        public double Temp { get; set; }
        public int Humidity { get; set; } 
        public int Pressure { get; set; } 
    }
}
