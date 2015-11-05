using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostActiveFriend
{
    public class UserList
    {
        public List<User> UserResponse { get; set; }

        public UserList()
        {
            this.UserResponse = new List<User>();
        }
    }
}
