using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Tests.Client;
using Tests.Models;

namespace Tests.Repositories
{
    public class GroupRepository:IGroupRepository
    {
        private string accessToken =
            "9bafa781777fd8dd078a0bdbeb16bdc60a69e4726672b7698f7b4cf01dbf2d979eca022f6de38957074e1";

        private string url = "https://api.vk.com/method/";


        public Group GetById(string id)
        {
            string request = $"{url}groups.getById?group_id={id}&access_token={accessToken}&v=5.103";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }
        
        private Group Parse(string json)
        {
            JObject groupJObject = JObject.Parse(json);
            JToken groupInfo = groupJObject["response"][0];
            Group group = new Group();
            group.Id = groupInfo["id"].ToString();
            group.Name = groupInfo["name"].ToString();
            group.ScreenName = groupInfo["screen_name"].ToString();
            group.IsClosed = (bool)groupInfo["is_closed"];
            return group;
            
        }
        
        public List<Group> Get(string id, string count)
        {
            
            string request = $"{url}groups.get?user_id={id}&count={count}&extended={"1"}&access_token={accessToken}&v=5.103";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return ParseList(json);
        }
        
        private List<Group> ParseList(string json)
        {
            JObject groupJObject = JObject.Parse(json);
            JToken groupInfo = groupJObject["response"]["items"];
            List<Group> groups = new List<Group>();

            for (int i = 0; i < groupInfo.Count(); i++)
            {
                Group group = new Group();
                group.Id = groupInfo[i]["id"].ToString();
                group.Name = groupInfo[i]["name"].ToString();
                group.ScreenName = groupInfo[i]["screen_name"].ToString();
                group.IsClosed = (bool)groupInfo[i]["is_closed"];
                groups.Add(group);
            }
            return groups;
            
        }
    }
}