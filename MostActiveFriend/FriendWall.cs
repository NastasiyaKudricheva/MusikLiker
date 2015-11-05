using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostActiveFriend
{
    public class FriendWall
    {
        public List<Post> postList { get; set; }
        public int user_id { get; set; }
        public int count { get; set; }

        public FriendWall()
        {
            this.postList = new List<Post>();

        }
    }
}
