using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    string XML = "Hello, World! <Document><State>TX</State></Document> <Total> 45.6 </Total> Hello"; //"Hello, World! <Document><State>TX</State></Document> <Total> 45.6 </Total> <Cost_Centre>NZ</Cost_Centre>Hello"; 
                    var httpContent = new StringContent(XML, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://localhost:7071/api/cost", httpContent);
                }

            }).GetAwaiter().GetResult();

        }
    }
}
