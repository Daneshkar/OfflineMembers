using System;
using MiddlewareTest.Models;

namespace MiddlewareTest.Data
{
    public class DataBase
    {
        public DataBase()
        {
            Users.Add(new User() {Name="u1", CurrentMoney=20 });
        }
        public static List<User> Users { get; set; } = new List<User>();
        public User GetUser()
        {
            return Users[0];
        }

    }
}
