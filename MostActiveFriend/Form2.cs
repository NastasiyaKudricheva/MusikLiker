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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;



namespace MostActiveFriend
{
    public partial class Form2 : Form
    {
        public Form2(int userId, int postsValue)
        {
            InitializeComponent();
         
            UserList userList = MyParseJSON.ParseUser(VkChaterer.GetUser(userId));
          
            textBox1.Text = userList.UserResponse[0].first_name;
            textBox2.Text = userList.UserResponse[0].last_name;
            textBox3.Text = postsValue.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
       

    }
}
