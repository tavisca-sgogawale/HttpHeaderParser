using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpHeaderParser
{

    class HttpResponseParser
    {

        public static Dictionary<string, string> ParseResonse(string filename)
        {
            var responseElements = new Dictionary<string, string>();
            using (StreamReader file = new StreamReader(filename))
            {
                string line = file.ReadLine();
                string[] s = line.Split(new[] { ' ' }, 2);
                responseElements.Add("HttpAndVersion", s[0]);
                responseElements.Add("StatusCode", s[1]);

                while ((line = file.ReadLine()) != null)
                {

                    if (line.Contains(":"))
                    {
                        string[] sp = line.Split(new[] { ':' }, 2);
                        responseElements.Add(sp[0], sp[1]);
                    }
                    else
                    {
                        break;
                    }

                }

                string data = file.ReadToEnd();
                responseElements.Add("Payload", data);
                file.Close();

            }

            return responseElements;
        }



    }
}
