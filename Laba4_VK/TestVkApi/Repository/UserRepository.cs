using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tests.Models;
using Tests.Client;

namespace Tests.Repositories
{
    public class UsersRepository: IUsersRepository
    {

        private string accessToken =
            "920811adb09e37012c2875f919c58166c0b7082f96d23f57cb4be00c57672957f106fd260f20ff375d119";

        private string url = "https://api.vk.com/method/";
        
        public User GetUserById(string id)
        {
            string request = $"{url}users.get?user_ids={id}&access_token={accessToken}&v=5.103";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            JObject userJObject = JObject.Parse(json);
            JToken userInfo = userJObject["response"][0];
            User user = new User();
            user.Id = userInfo["id"].ToString();
            user.FirstName = userInfo["first_name"].ToString();
            user.LastName = userInfo["last_name"].ToString();
            user.IsClosed = (bool)userInfo["is_closed"];
            return user;
        }
    }
}