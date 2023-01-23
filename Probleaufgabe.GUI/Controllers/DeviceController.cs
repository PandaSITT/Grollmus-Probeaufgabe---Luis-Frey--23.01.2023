using Microsoft.AspNetCore.Mvc;
using Probleaufgabe.GUI.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Probleaufgabe.GUI.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(ILogger<DeviceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string jsonString = "{\"devices\":[{\"id\":\"1glmLrTZqf9YZleN\",\"name\":\"S7-150009\",\"deviceTypeId\":\"Beweis\",\"failsafe\":true,\"tempMin\":0,\"tempMax\":60,\"installationPosition\":\"horizontal\",\"insertInto19InchCabinet\":true,\"motionEnable\":true,\"siplusCatalog\":true,\"simaticCatalog\":true,\"rotationAxisNumber\":0,\"positionAxisNumber\":0},{\"id\":\"1glmLrTZqf9YZleN\",\"name\":\"S7-1500\",\"deviceTypeId\":\"S7_1500\",\"failsafe\":true,\"tempMin\":0,\"tempMax\":50,\"installationPosition\":\"horizontal\",\"insertInto19InchCabinet\":true,\"motionEnable\":true,\"siplusCatalog\":false,\"simaticCatalog\":true,\"rotationAxisNumber\":0,\"positionAxisNumber\":0,\"advancedEnvironmentalConditions\":false},{\"id\":\"9RLMugEpCVSeemZ5\",\"name\":\"ET 200SP\",\"deviceTypeId\":\"ET200_SP\",\"failsafe\":false,\"tempMin\":0,\"tempMax\":40,\"installationPosition\":\"horizontal\",\"insertInto19InchCabinet\":true,\"motionEnable\":true,\"siplusCatalog\":false,\"simaticCatalog\":true,\"rotationAxisNumber\":0,\"positionAxisNumber\":0,\"terminalElement\":true,\"advancedEnvironmentalConditions\":false},{\"id\":\"9RLMugEbCVSeemZ4\",\"name\":\"S7-300\",\"deviceTypeId\":\"S7_300\",\"failsafe\":true,\"tempMin\":0,\"tempMax\":40,\"installationPosition\":\"vertical\",\"insertInto19InchCabinet\":false,\"motionEnable\":false,\"siplusCatalog\":false,\"simaticCatalog\":false,\"rotationAxisNumber\":0,\"positionAxisNumber\":0,\"terminalElement\":true,\"advancedEnvironmentalConditions\":false}]}";

            JsonDevices myDeserializedClass = JsonConvert.DeserializeObject<JsonDevices>(jsonString);

            return View(myDeserializedClass.devices);
        }

        public IActionResult Details()
        {
            string jsonString = "{\"id\":\"1glmLrTZqf9YZleN\",\"name\":\"S7-150009\",\"deviceTypeId\":\"Beweis\",\"failsafe\":true,\"tempMin\":0,\"tempMax\":60,\"installationPosition\":\"horizontal\",\"insertInto19InchCabinet\":true,\"motionEnable\":true,\"siplusCatalog\":true,\"simaticCatalog\":true,\"rotationAxisNumber\":0,\"positionAxisNumber\":0}";

            Device myDeserializedClass = JsonConvert.DeserializeObject<Device>(jsonString);

            return View(myDeserializedClass);
        }
    }
}