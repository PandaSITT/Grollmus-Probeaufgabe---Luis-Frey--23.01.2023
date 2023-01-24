using Microsoft.AspNetCore.Mvc;
using Probeaufgabe.GUI.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace Probeaufgabe.GUI.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> logger;

        private readonly HttpClient httpClient;

        public DeviceController(ILogger<DeviceController> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClient = httpClientFactory.CreateClient("ApiClient");
            logger.LogInformation($"API BaseAdress: {httpClient.BaseAddress}");
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

        [HttpGet]
        public IActionResult Import()
        {
            return PartialView("_Import");
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

            var content = new StringContent(jsonAsString.ToString(), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("Device/File", content);

            return RedirectToAction("Index");
        }
    }
}