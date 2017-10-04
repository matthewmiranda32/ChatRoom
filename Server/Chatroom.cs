using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Chatroom
    {
        private List<IUser> users = new List<IUser>();

        public void JoinConversation(IUser user)
        {
            users.Add(user);
            Console.WriteLine("{0} has joined the conversation.\n", user.Username);
        }

        public void LeaveConversation(IUser user)
        {
            users.Add(user);
            Console.WriteLine("{0} has left the conversation.\n", user.Username);
        }

        public void NotifyUsers()
        {
            foreach(IUser user in users)
            {
                user.Notify(user);
            }
        }
    }
}
