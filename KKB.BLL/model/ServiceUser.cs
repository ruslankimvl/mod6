using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace KKB.BLL.model
{
    public class ServiceUser
    {
        public bool Registration(User user, out string message)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase("KKB.db"))
                {
                    var users = db.GetCollection<User>("User");
                    users.Insert(user);
                }
                message = "Регистрация прошла успешно!";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        public User LogOn(string login,string password, out string message)
        {
            User user = null;
            using (LiteDatabase db = new LiteDatabase("KKB.db"))
            {
               
                var users = db.GetCollection<User>("User").FindAll();
                if (users.Any(a => a.login ==
                login && a.password == password))
                {
                    user = users.FirstOrDefault(a => a.login == login && a.password == password);
                    message = "ok";
                }
                else {
                    message = "Неправильный логин или пароль";
                }
            }
            return user;
        }
    }
}
