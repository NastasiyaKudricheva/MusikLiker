using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostActiveFriend
{
    public class FriendResponse
    {


        public int uid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int can_see_all_posts { get; set; }
        public int online { get; set; }
        public int user_id { get; set; }
        public List<int> lists { get; set; }
        public string deactivated { get; set; }

       
    }
   
}
