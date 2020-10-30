using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DataCollectionHandller
{
    public delegate void Notify();

    class DataCollectionHandler
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool IsWow64Process(IntPtr hProcess, out bool Wow64Process);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool Wow64DisableWow64FsRedirection(out IntPtr OldValue);

        private List<string> dataPath;
        private List<string> registryPath;
        private string currentDateTime = DateTime.Now.ToString("MMddyyyyHHmmss");
        private string backupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public List<string> DataPath
        {
            get { return dataPath; }
            set { dataPath = value; }
        }
        public List<string> RegistryPath
        {
            get { return registryPath; }
            set { registryPath = value; }
        }
        public string CurrentDateTime
        {
            get { return currentDateTime; }
            set { currentDateTime = value; }
        }
        public string BackupPath
        {
            get { return backupPath; }
            set { backupPath = value; }
        }


        public DataCollectionHandler(List<string> dataPath, List<string> registryPath,string machineType)
        {
            DataPath = dataPath;
            RegistryPath = registryPath;
            Directory.CreateDirectory(BackupPath + "\\" + machineType + "_" + CurrentDateTime + "_" + Environment.MachineName);
            backupPath += "\\" + machineType + "_" + CurrentDateTime + "_" + Environment.MachineName;
        }
        internal void ExportRegistryData()
        {

            bool bWow64 = false;
            IsWow64Process(Process.GetCurrentProcess().Handle, out bWow64);
            if (bWow64)
            {
                IntPtr OldValue = IntPtr.Zero;
                bool bRet = Wow64DisableWow64FsRedirection(out OldValue);
            }
            string sFile = backupPath + "\\";

            foreach(string sKey in RegistryPath)
            {
                using (Process process = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    psi.FileName = "reg";
                    psi.Arguments = "export " + "" + sKey.Replace("/","\\") + "" + " " + "" + sFile + sKey.Split('/').Last() + ".reg" + "";
                    psi.RedirectStandardOutput = true;
                    psi.UseShellExecute = false;
                    process.StartInfo = psi;
                    process.Start();
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string sResult = reader.ReadToEnd();
                        Console.Write(sResult);
                    }
                }
            }
        }
        internal void ExportMachineData()
        {

        }
        internal void ExportGuiData()
        {
            foreach (string dataPath in DataPath)
            {
                File.Copy(dataPath.Replace("/","\\"), BackupPath + "\\" + dataPath.Split('/').Last());
                Console.WriteLine($"Moving the file into {BackupPath + "\\" + dataPath.Split('/').Last()}");
            }
        }
    }
}
