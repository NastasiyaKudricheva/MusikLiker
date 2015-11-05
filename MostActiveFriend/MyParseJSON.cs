using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Windows.Forms;


namespace MostActiveFriend
{
    public class MyParseJSON
    {

        public static FriendList ParseFriendList(string jsonFriend)
        {
           
            JArray array = CreateArray(jsonFriend);
            JsonConvert.DeserializeObject<FriendResponse>(array.First().ToString());
            FriendList friendList;
            friendList = new FriendList();
            foreach (JObject content in array.Children<JObject>())
            {
                FriendResponse fr = new FriendResponse();
                string str = content.ToString();
                fr = JsonConvert.DeserializeObject<FriendResponse>(str);
                friendList.response.Add(JsonConvert.DeserializeObject<FriendResponse>(content.ToString()));

            }
            return friendList;
        }

        public static FriendWall ParseFriendWall(string jsonWall)
        {
            JArray array = CreateArray(jsonWall);
            FriendWall friendWall = new FriendWall();
            try
            {
                friendWall.count = Int16.Parse(array.First().ToString());
                foreach (JObject content in array.Children<JObject>())
                {

                    friendWall.postList.Add(JsonConvert.DeserializeObject<Post>(content.ToString()));
                }
            }
            catch(Exception exception)
            {

               // MessageBox.Show(exception.ToString());
                
            }
           return friendWall;
           
        }

        public static UserList ParseUser(string jsonUser)
        {

            JArray array = CreateArray(jsonUser);
           // var v = JsonConvert.DeserializeObject<User>(array.First().ToString());
            UserList userList = new UserList();

          foreach (JObject content in array.Children<JObject>())
            {
                userList.UserResponse.Add(JsonConvert.DeserializeObject<User>(content.ToString()));

            }
            return userList;
        }

        internal static JArray CreateArray(string json)
        {
            
            JArray array = (JArray)JObject.Parse(json)["response"];
            return array;
        }
    }
}
