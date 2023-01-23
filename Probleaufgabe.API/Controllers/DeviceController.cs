using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Probleaufgabe.API.Models;

namespace Probleaufgabe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly DatabaseContext _databaseContext;

        public DeviceController(ILogger<DeviceController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }


        [HttpGet]
        public ActionResult<List<Device>> GetAll()
        {
            return Ok(_databaseContext.Devices);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Device> Get(string id)
        {
            var device = _databaseContext.Devices.FirstOrDefault(q => q.id == id);

            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        [HttpPut("{id}")]
        public ActionResult<Device> Update(string id, Device device)
        {
            device.id = id;

            Device m = _databaseContext.Devices.FirstOrDefault(q => q.id == id);

            if (m == null)
            {
                return BadRequest();
            }


            _databaseContext.Devices.Update(m);
            _databaseContext.SaveChanges();
            return Ok(m);
        }

        [HttpPost]
        public ActionResult Insert(Device device)
        {
            if (_databaseContext.Devices.Any(q => q.id == device.id))
            {
                return BadRequest("ID exestiert bereits");
            }
            _databaseContext.Devices.Add(device);
            _databaseContext.SaveChanges();
            return Ok(device);
        }

        [HttpPost]
        [Route("File")]
        public ActionResult InsertFile(JsonDevices jsonDevices)
        {
            foreach (var device in jsonDevices.devices)
            {
                //TODO: Error handeling
                IActionResult result = Insert(device);
            }

            return Ok(jsonDevices);
        }

        [HttpGet]
        [Route("File")]
        public JsonDevices GetFile()
        {
            return new JsonDevices(_databaseContext.Devices.ToList());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(string id)
        {
            Device m = _databaseContext.Devices.FirstOrDefault(q => q.id == id);
            if (m != null)
            {
                _databaseContext.Devices.Remove(m);
                _databaseContext.SaveChanges();
            }

            return Ok();
        }
    }
}