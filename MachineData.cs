using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;


namespace DataCollectionHandller
{
    class MachineData
    {
        internal enum MachineType
        {
            AOI,
            SPI,
            API,
            Review,
            NoKYmachine
        }

        public static string AOIpath { get; set; } = @"C:\KohYoung\AOI\AOIGUI.exe";
        public static string SPIpath { get; set; } = @"C:\KohYoung\KY-3030\KY-3030.exe";
        public static string ReviewPath { get; set; } = @"C:\KohYoung\Review\AOIReviewStation.exe";


        public static string GetMachineType()
        {
            try
            {
                if (File.Exists(AOIpath))
                    return MachineType.AOI.ToString();
                if (File.Exists(ReviewPath))
                    return MachineType.Review.ToString();
                else
                    return MachineType.SPI.ToString();
            }
            catch
            {
                return MachineType.NoKYmachine.ToString();
            }
        }

    }

}
