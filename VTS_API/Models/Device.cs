namespace VTS_API.Models
{
    public class Device : CommonPropEntity
    {
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
