using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpHeaderParser
{
    class Program
    {
        static readonly string responseFile = "HttpRequestHeader.txt";
        static readonly string requestFile = "HttpRequestHeader.txt";

        static void Main()
        {

            ParseRequest();
            ParseResponse();
            Console.ReadKey(true);
        }

        private static void ParseResponse()
        {
            Console.WriteLine("------Parsing Response------");
            var responseFileDict = HttpResponseParser.ParseResonse(responseFile);
            foreach (var item in responseFileDict)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

        }
        private static void ParseRequest()
        {

            Console.WriteLine("------Parsing Request------");
            var reqFileDict = HttpRequestParser.Parse(requestFile);

            foreach (var item in reqFileDict)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("##################################################################");
        }



        static void Test()
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://google.com");
            
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            // Displays all the headers present in the response received from the URI.
            Console.WriteLine("rnThe following headers were received in the response:");
            // Displays each header and it's key associated with the response.
            for (int i = 0; i < myHttpWebResponse.Headers.Count; ++i)
                Console.WriteLine("nHeader Name:{0}, Value :{1}", myHttpWebResponse.Headers.Keys[i], myHttpWebResponse.Headers[i]);
            // Releases the resources of the response.
            myHttpWebResponse.Close();
        }

    }
}
