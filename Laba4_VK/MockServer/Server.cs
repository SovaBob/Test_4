using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tests.Models;

namespace MockServer
{
   public class Server
    {
        private HttpListener _listener;

        private Task _task;
        public bool IsStart { get; private set; }
        public string LastRequest { get; private set; }

        public Server()
        {
            _listener = new HttpListener();
            IsStart = false;
            //установка адресов прослушки
            _listener.Prefixes.Add("http://localhost:8080/");
            _listener.Prefixes.Add("http://localhost:8080/test/");
        }

        public async void Start()
        {
            IsStart = true;
            _task = Task.Run(() => StartServer());
        }

        public void Stop()
        {
            IsStart = false;
            _listener.Stop();
        }

        private void StartServer()
        {
            _listener.Start();
            while (IsStart)
            {
                HttpListenerContext context = _listener.GetContext();
                HttpListenerRequest request = context.Request;
                
                HttpListenerResponse response = context.Response;
                
                ProcessRequest(request.Url.AbsolutePath, response);
            }
        }

        private void SendMessageToClient(object message, HttpListenerResponse response)
        {
            byte[] buffer = ConvertMessageToBytes(message);

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            
            output.Close();
        }

        private byte[] ConvertMessageToBytes(object message)
        {
            string json = JsonConvert.SerializeObject(message);
            return System.Text.Encoding.UTF8.GetBytes(json);
        } 
        
        private void ProcessRequest(string request, HttpListenerResponse response)
        {
            LastRequest = request;
            switch (request)
            {
                case "/test":
                    string text = "abcdefg";
                    SendMessageToClient(text, response);
                    break;
                case "/method/users/get/194599671":
                    User user = new User()
                    {
                        Id = "194599671",
                        FirstName = "Игорь",
                        LastName = "Малахов",
                        IsClosed = false
                    };
                    SendMessageToClient(user,response);
                    break;
                case "/method/groups/getById/167950306":
                    Group group = new Group()
                    {
                        Id = "167950306",
                        Name = "Игра Обзоров",
                        ScreenName = "igraobzorov",
                        IsClosed = false
                    };
                    SendMessageToClient(group,response);
                    break;
                case "/method/groups/get/194599671":
                    List<Group> groups = new List<Group>();
                    Group tgroup = new Group()
                    {
                        Id = "167950306",
                        Name = "Игра Обзоров",
                        ScreenName = "igraobzorov",
                        IsClosed = false
                    };
                    groups.Add(tgroup);
                    tgroup = new Group()
                    {
                        Id = "120978225",
                        Name = "ДИЧЬ",
                        ScreenName = "ultradich",
                        IsClosed = false
                    };
                    groups.Add(tgroup);
                    SendMessageToClient(groups,response);
                    break;

            }

        }
    }
}