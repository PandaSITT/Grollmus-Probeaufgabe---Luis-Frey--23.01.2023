using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Probleaufgabe.API.Models
{
    public class Device
    {
        //TODO: string laut swagger nullable????
        public string id { get; set; }

        public string name { get; set; }

        public string deviceTypeId { get; set; }

        public bool failsafe { get; set; }

        public int tempMin { get; set; }

        public int tempMax { get; set; }

        public string installationPosition { get; set; }

        public bool insertInto19InchCabinet { get; set; }

        public bool motionEnable { get; set; }

        public bool siplusCatalog { get; set; }

        public bool simaticCatalog { get; set; }

        public int rotationAxisNumber { get; set; }

        public int positionAxisNumber { get; set; }

        public bool? advancedEnvironmentalConditions { get; set; }

        public bool? terminalElement { get; set; }
    }
}
