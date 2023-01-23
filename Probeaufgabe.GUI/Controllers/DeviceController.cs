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

        public PartialViewResult Import()
        {
            return PartialView("Import");
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

            //TODO: Macht asynchron wirklich sinn?
            var content = new StringContent(jsonAsString.ToString(), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("Device/File", content);

            return RedirectToAction("Index");
        }
    }
}