using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ChatroomUsers : IUser
    {
        private string userName;

        public string Username
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public ChatroomUsers(string userName)
        {
            this.userName = userName;
        }

        public void Notify(IUser user)
        {
            Console.WriteLine("{0} is online. ", user.Username);
        }

        }
}

