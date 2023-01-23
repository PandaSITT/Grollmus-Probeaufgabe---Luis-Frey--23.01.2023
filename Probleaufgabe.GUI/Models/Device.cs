using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Probleaufgabe.GUI.Models
{
    public class Device
    {
        public string id { get; set; }

        public string name { get; set; }

        public string deviceTypeId { get; set; }

        [Display(Name = "Failsafe")]
        public bool failsafe { get; set; }

        public int tempMin { get; set; }

        public int tempMax { get; set; }

        [Display(Name = "Einbauposion")]
        public string installationPosition { get; set; }

        [Display(Name = "Geeignet für 19'' Schrank")]
        public bool insertInto19InchCabinet { get; set; }

        public bool motionEnable { get; set; }

        public bool siplusCatalog { get; set; }

        public bool simaticCatalog { get; set; }

        public int rotationAxisNumber { get; set; }

        public int positionAxisNumber { get; set; }

        [Display(Name = "Erweiterte Umgebungsbedingungen")]
        public bool? advancedEnvironmentalConditions { get; set; }

        [Display(Name = "Teminal vorhanden")]
        public bool? terminalElement { get; set; }
    }
}
