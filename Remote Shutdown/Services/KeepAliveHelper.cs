using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Remote_Shutdown.Services
{
    public class KeepAliveHelper
    {
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static void KeepAlive()
        {
            // Default values
            var host = "localhost";
            var port = "5555";
            var url = "keepalive";
            string fullRequestPath = $"http://{host}:{port}/{url}";

            WebRequest request = WebRequest.Create(fullRequestPath);

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            // Recovers the HTML content
            using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine($"Keep-Alive @ {fullRequestPath} : {response.StatusDescription}");
        }

    }
}
