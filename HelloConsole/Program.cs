using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelloConsole
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            try 
            {
                RunAsync().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
                Console.ReadLine();
            }
        }

        static async Task RunAsync()
        {
            try{
                IHelloWorld outputObject = null;

                client.BaseAddress = new Uri("http://localhost:62769");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string outText = await HelloStringRead();
                
                string outputType = ConfigurationManager.AppSettings["OutputTarget"].ToString();
                outputObject = OutputFactory.CreateObj(outputType);

                outputObject.SendMessage(outText);
                //Console.ReadLine();
              }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.InnerException);
                Console.ReadLine();
            }
        }

          

        static async Task<string> HelloStringRead()
        {
            string hello = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync("HelloWorldString");
                if (response.IsSuccessStatusCode)
                {
                    hello = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred reading string: " + e.Message);
                Console.ReadLine();
            }
            return hello;
        }
      
    }
}
