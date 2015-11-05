using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostActiveFriend
{
    public class FriendList
    {
        public List<FriendResponse> response { get; set; }

       public FriendList()
        {
            this.response = new List<FriendResponse>();
        }
    }
}
