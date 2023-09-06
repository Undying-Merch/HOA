using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOA.Classes
{
    internal class DBConn
    {
        string url = "http://192.168.1.148";
        private string token = "ccb6515588dfcb51998acf33df8283a137001e2e";
        HttpClient client;


        public DBConn()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
        }

        private String[] jsonSplit(string json)
        {
            char split = '}';
            String[] splittedString = json.Split(split);
            splittedString = splittedString.SkipLast(1).ToArray();
            for (int i = 0; i < splittedString.Length; i++)
            {
                splittedString[i] = splittedString[i].TrimStart(',', '[');
                splittedString[i] = splittedString[i].TrimEnd(']');
                splittedString[i] = splittedString[i] + "}";
            }
            return splittedString;
        }

        public List<Regler> getAllRules()
        {
            List<Regler> rules = new List<Regler>();
            string json = client.GetStringAsync(url + ":8000/data/Rliste/").Result;
            string[] ruleStrings = jsonSplit(json);
            for (int i = 0;i < ruleStrings.Length;i++)
            {
                Regler regel = JsonSerializer.Deserialize<Regler>(ruleStrings[i]);
                rules.Add(regel);
            }
            return rules;
        }


        public void test()
        {
            string json = client.GetStringAsync(url + ":8000/data/Rliste/").Result;

        }

        public void poastTest(Beboer beboer)
        {
            var sJson = new StringContent(JsonSerializer.Serialize(beboer), Encoding.UTF8, "application/json");
            client.PostAsync(url + ":8000/data/Bcreate/", sJson);
        }
    }
}
