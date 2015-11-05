using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace MostActiveFriend
{
    
    public partial class Form1 : Form
    {
        private string _accessToken;
        private int _userId;
        private int _max;
        private int _mostActiveFriendId;
        Form _answer;
        private int _appId;

        public Form1()
        {
           
            InitializeComponent();
            _accessToken = "";
            _appId = 5132923;
            webBrowser1.Navigate(String.Format("http://api.vkontakte.ru/oauth/authorize?client_id={0}&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=friends,audio&response_type=token", _appId.ToString()));
            _max = 0;
        }

        private  void button1_Click(object sender, EventArgs e)
        {
           
            FriendList friendList = MyParseJSON.ParseFriendList(VkChaterer.GetFriends(_userId));
            int count;
            
            foreach (FriendResponse response in friendList.response)
            {
             
               //Regex regex = new Regex("[0-9]+",RegexOptions.IgnoreCase|RegexOptions.Singleline);
               //Match match = regex.Match(VkChaterer.Get(String.Format("https://api.vk.com/method/audio.getCount?owner_id={0}&access_token={1}", response.user_id,_accessToken)));
               //string count = match.Value;
                count = VkChaterer.GetAudioCount(response.user_id,_accessToken);
            
               
               if (_max < count)
                {
                    _max = count;
                    _mostActiveFriendId = response.user_id;
                }

            }
            _answer = new Form2(_mostActiveFriendId, _max);
            _answer.Show();

        }
       
       private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token", StringComparison.Ordinal) != -1)
            {
                
                
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        _accessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        _userId = Convert.ToInt32(m.Groups["value"].Value);
                    }
                    // еще можно запомнить срок жизни access_token - expires_in,
                    // если нужно
                }
                button1.Visible = true;
               // System.Windows.Forms.MessageBox.Show(String.Format("Ключ доступа: {0}\nUserID: {1}", _accessToken, _userId));
            }
        }
        
   
   }
   
  

}
