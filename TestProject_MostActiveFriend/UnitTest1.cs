using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MostActiveFriend;


namespace TestProject_MostActiveFriend
{
    /// <summary>
    /// Сводное описание для UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: добавьте здесь логику теста
            //
        }
        [TestMethod]
        public void TestParseUser()
        {
            string input = "{\"response\":[{\"uid\":1,\"first_name\":\"Павел\",\"last_name\":\"Дуров\"}]}";
           // {\"response":[{"uid":1,"first_name":"Павел","last_name":"Дуров"}]}
            UserList userListActual = MyParseJSON.ParseUser(input);
            UserList eList = new UserList();
            eList.UserResponse.Add(new User());
            eList.UserResponse[0].uid = 1;
            eList.UserResponse[0].first_name = "Павел";
            eList.UserResponse[0].last_name = "Дуров";
            Debug.Assert(userListActual != null, "userListActual != null");
            Assert.AreEqual(expected: eList.UserResponse[0].first_name, actual: userListActual.UserResponse[0].first_name);
            Assert.AreEqual(expected: eList.UserResponse[0].last_name, actual: userListActual.UserResponse[0].last_name);
            //
            // TODO: добавьте здесь логику теста
            //
        }


    }
}
