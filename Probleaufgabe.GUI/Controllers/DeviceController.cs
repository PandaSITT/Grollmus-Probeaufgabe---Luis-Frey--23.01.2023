using Microsoft.AspNetCore.Mvc;
using Probleaufgabe.GUI.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;

namespace Probleaufgabe.GUI.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> logger;

        private readonly HttpClient httpClient;

        public DeviceController(ILogger<DeviceController> logger, HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
            logger.LogInformation($"API BaseAdress: {httpClient.BaseAddress}");
            //TODO: BaseAdress entfernen wenn es geht
            this.httpClient.BaseAddress = new Uri("https://localhost:7090/api/");
        }

        public async Task<IActionResult> IndexAsync()
        {
            var devices = await httpClient.GetFromJsonAsync<List<Device>>("Device");

            return View(devices);
        }

        public async Task<IActionResult> Details(string id)
        {
            var device = await httpClient.GetFromJsonAsync<Device>($"Device/{id}");

            return View(device);
        }

        public async Task<IActionResult> DeleteDevice(string id)
        {
            var result = await httpClient.DeleteAsync($"Device/{id}");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Import()
        {

            return PartialView();
        }

        [HttpPost]
        public IActionResult Import(ImportFile fileObject)
        {
            var jsonAsString = new StringBuilder();
            using (var reader = new StreamReader(fileObject.JsonFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0) 
                {
                    jsonAsString.AppendLine(reader.ReadLine());
                }
            }
            
            //TODO: Import geht ned
            var result = httpClient.PostAsJsonAsync($"/Device/File", jsonAsString.ToString());

            return RedirectToAction("Index");
        }
    }
}