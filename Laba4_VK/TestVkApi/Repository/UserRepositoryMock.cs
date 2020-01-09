using Newtonsoft.Json;
using Tests.Client;
using Tests.Models;

namespace Tests.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        private string accessToken =
            "9bafa781777fd8dd078a0bdbeb16bdc60a69e4726672b7698f7b4cf01dbf2d979eca022f6de38957074e1";

        private string url = "http://localhost:8080/method/";
        
        public User GetUserById(string id)
        {
            string request = $"{url}users/get/{id}";
            WebClient webClient = new WebClient();
            string json = webClient.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}