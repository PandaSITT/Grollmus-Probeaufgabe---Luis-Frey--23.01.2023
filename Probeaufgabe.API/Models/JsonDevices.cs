namespace Probeaufgabe.API.Models
{
    public class JsonDevices
    {
        public JsonDevices(List<Device> devices)
        {
            this.devices = devices;
        }

        public List<Device> devices { get; set; }
    }
}
