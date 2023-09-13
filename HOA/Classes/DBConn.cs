using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public int getUserId(string userName)
        {
            string json = client.GetStringAsync(url + ":8000/data/Bliste/").Result;
            string[] bList = jsonSplit(json);
            for(int i = 0; i < bList.Length; i++)
            {
                Beboer beboer = JsonSerializer.Deserialize<Beboer>(bList[i]);
                if (beboer.brugernavn == userName)
                {
                    return beboer.id;
                }
            }
            return 0;

        }

        public bool passwordCheck(Beboer beboer)
        {
            var sJson = new StringContent(JsonSerializer.Serialize(beboer), Encoding.UTF8, "application/json");
            var response = client.PostAsync(url + ":8000/data/password/", sJson);
            bool boolResp = Boolean.Parse(response.Result.Content.ReadAsStringAsync().Result);
            return boolResp;
        }

        public bool postAnmeldese(int pplId,decimal lattitude,decimal longitude,int regelId,string image)
        {

            //var sJson = new StringContent(JsonSerializer.Serialize(anmeldelse), Encoding.UTF8, "application/json");
            //var response = client.PostAsync(url + ":8000/data/Acreate/", sJson);
            using (var multupartFomrContent = new MultipartFormDataContent())
            {
                multupartFomrContent.Add(new StringContent(pplId.ToString()), name: "andmelder_id");
                multupartFomrContent.Add(new StringContent(lattitude.ToString()), name: "lattitude");
                multupartFomrContent.Add(new StringContent(longitude.ToString()), name: "longtitude");
                multupartFomrContent.Add(new StringContent(regelId.ToString()), name: "regel_id");

                var fileStreamContent = new StreamContent(File.OpenRead(image));
                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                multupartFomrContent.Add(fileStreamContent, name: "photo", fileName: "anmeld.jpeg");

                //var sJson = new StringContent(JsonSerializer.Serialize(multupartFomrContent), Encoding.UTF8, "application/json");
                var response = client.PostAsync(url + ":8000/data/Acreate/", multupartFomrContent);
                return response.Result.IsSuccessStatusCode;
                
            }
        }
        
        
    }
}
