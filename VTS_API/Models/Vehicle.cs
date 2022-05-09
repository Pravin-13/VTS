namespace VTS_API.Models
{
    public class Vehicle : CommonPropEntity
    {
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public short ManufacturingYear { get; set; }
        public string LoadCarryingCapacity { get; set; }
        public string MakeOfVehicle { get; set; }
        public string ModelNumber { get; set; }
        public string BodyType { get; set; }
        public string OrganisationName { get; set; }
        public int DeviceID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public Device Device { get; set; }
    }
}
