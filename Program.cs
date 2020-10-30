using System;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace DataCollectionHandller
{
    class Program
    {
        public static string MachineType { get; set; }


        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Checking the setting");
                string settingPath = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "DataHandler.json");

                JsonData settingData = JsonConvert.DeserializeObject<JsonData>(settingPath);

                Console.WriteLine($"Machine type is{MachineData.GetMachineType()}");

                switch (MachineData.GetMachineType())
                {
                    case "AOI": ExportAOImachine(settingData); break;
                    case "SPI": ExportSPImachine(settingData); break;
                    case "Review": ExportReviewmachine(settingData); break;
                    case "NoKYmachine": ExportNoKYmachine(); break;

                }
                Console.WriteLine("Complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


            Console.ReadLine();
        }
        private static void ExportAOImachine(JsonData settingData)
        {
            DataCollectionHandler dataHandler = new DataCollectionHandler(
                settingData.Setting.BasicSetting.AoiguIdata.ExportPathData,
                settingData.Setting.BasicSetting.AoiguIdata.RegistryDataPath, "AOI");

            dataHandler.ExportGuiData();
            dataHandler.ExportRegistryData();
        }
        private static void ExportSPImachine(JsonData settingData)
        {
            DataCollectionHandler dataHandler = new DataCollectionHandler(
                settingData.Setting.BasicSetting.SpiguIdata.ExportPathData,
                settingData.Setting.BasicSetting.SpiguIdata.RegistryDataPath, "SPI");

            dataHandler.ExportGuiData();
            dataHandler.ExportRegistryData();
        }
        private static void ExportReviewmachine(JsonData settingData)
        {
            DataCollectionHandler dataHandler = new DataCollectionHandler(
                settingData.Setting.BasicSetting.ReviewGuIdata.ExportPathData,
                settingData.Setting.BasicSetting.ReviewGuIdata.RegistryDataPath, "Review");

            dataHandler.ExportGuiData();
            dataHandler.ExportRegistryData();
        }
        private static void ExportNoKYmachine()
        {
            Console.WriteLine("Machine type not detected");
        }
    }
}
