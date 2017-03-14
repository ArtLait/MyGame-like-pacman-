﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MyWebGam.Models;
using MyWebGam.EF;
using MyWebGam.Server;
using Microsoft.AspNet.SignalR.Hubs;

namespace MyWebGam.Hubs
{
    public class ChatHub : Hub
    {
        UserRepository repo;

        private static List<UserForChat> Users = new List<UserForChat>();
        private static World world = new World();
        public ChatHub()
        {
            repo = new UserRepository();
        }
        public void moovedDown(int keycode)
        {            
            world.MooveDown(Context.ConnectionId, keycode);
        }
        public void moovedUp(int keycode)
        {
            world.MooveUp(Context.ConnectionId, keycode);
        }
        public void checkAuth()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var name = repo.GetUserWithEmail(Context.User.Identity.Name);
                if (name != null)
                {
                    Connect(name);
                }
            }
        }
        // Подключение нового пользователя  
        public void Connect(string userName)
        {
            string id = Context.ConnectionId;

            if (!Users.Any(x => x.ConnectionId == id))
            {

                Users.Add(new UserForChat { ConnectionId = id, Name = userName });
             
                Clients.Caller.onConnected(id, userName, Users);

                Clients.Caller.TakeUserName(userName);
               
                Clients.AllExcept(id).onNewUserConnected(id, userName);
                              
                world.AddPlayer(new UserSession(Clients.Caller, userName, Context.ConnectionId));
                
                if (Users.Count == 1)
                {
                    var idThread = Server.Server.CreateStream(world);
                }
             }
        }
        // Отправка сообщений
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name, Users);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}