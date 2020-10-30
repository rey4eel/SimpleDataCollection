using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataCollectionHandller
{
 
    public partial class JsonData
    {
        [JsonProperty("Setting", NullValueHandling = NullValueHandling.Ignore)]
        public Setting Setting { get; set; }
    }

    public partial class Setting
    {
        [JsonProperty("BasicSetting", NullValueHandling = NullValueHandling.Ignore)]
        public BasicSetting BasicSetting { get; set; }
    }

    public partial class BasicSetting
    {
        [JsonProperty("AOIGUIdata", NullValueHandling = NullValueHandling.Ignore)]
        public AoiguIdata AoiguIdata { get; set; }

        [JsonProperty("APIGUIdata", NullValueHandling = NullValueHandling.Ignore)]
        public ApiguIdata ApiguIdata { get; set; }

        [JsonProperty("DefaultMachineName", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultMachineName { get; set; }

        [JsonProperty("LogData", NullValueHandling = NullValueHandling.Ignore)]
        public string LogData { get; set; }

        [JsonProperty("ReviewGUIdata", NullValueHandling = NullValueHandling.Ignore)]
        public ReviewGuIdata ReviewGuIdata { get; set; }

        [JsonProperty("SPIGUIdata", NullValueHandling = NullValueHandling.Ignore)]
        public SpiguIdata SpiguIdata { get; set; }
    }

    public partial class AoiguIdata
    {
        [JsonProperty("ExportPathData", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExportPathData { get; set; }

        [JsonProperty("RegistryDataPath", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RegistryDataPath { get; set; }
    }

    public partial class ApiguIdata
    {
        [JsonProperty("ExportPathData", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExportPathData { get; set; }

        [JsonProperty("RegistryDataPath", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RegistryDataPath { get; set; }
    }

    public partial class ReviewGuIdata
    {
        [JsonProperty("ExportPathData", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExportPathData { get; set; }

        [JsonProperty("RegistryDataPath", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RegistryDataPath { get; set; }
    }

    public partial class SpiguIdata
    {
        [JsonProperty("ExportPathData", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExportPathData { get; set; }

        [JsonProperty("RegistryDataPath", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RegistryDataPath { get; set; }
    }
}
