using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tests.Client;
using Tests.Models;

namespace Tests.Repositories
{
    public class GroupRepositoryMock:IGroupRepository
    {
       
        private string accessToken =
            "9bafa781777fd8dd078a0bdbeb16bdc60a69e4726672b7698f7b4cf01dbf2d979eca022f6de38957074e1";

        private string url = "http://localhost:8080/method/";
        
        public Group GetById(string id)
        {
            string request = $"{url}groups/getById/{id}";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private Group Parse(string json)
        {
            return JsonConvert.DeserializeObject<Group>(json);
        }
        
        public List<Group> Get(string id, string count)
        {
            string request = $"{url}groups/get/{id}";
            WebClient webClient = new WebClient();
            
            string json = webClient.SendRequest(request, "GET");
            
            Group[] res = ParseList(json, count);
            List<Group> groups = new List<Group>();
            for (int i = 0; i < res.Length; i++)
                groups.Add(res[i]);
            return groups;
        }
        private Group[] ParseList(string json, string count)
        {
            return JsonConvert.DeserializeObject<Group[]>(json);
        }
    }
}