using Cargo_Transportation.DBProvider;
using Cargo_Transportation.DIHelpers;
using Cargo_Transportation.Enums;
using Cargo_Transportation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cargo_Transportation.Check
{
    public static class                 LoginRegisterCheck
    {
        public static bool              CheckLogin(string login)
        {
            if (login.Length < 5 || login.Length > 20)
                return (false);
            return (true);
        }
        public static AplicationUser    Which_User(string login, string password)
        {
            foreach (var user in IoC.Application_Work.All_Users)
            {
                if (user.Login.Equals(login))
                {
                    IoC.Application_Work.Current_User = user;
                    if (user is Client && user.Parol == password)
                        return (AplicationUser.User);
                    else if (user is Employee && (user as Employee).Position == "Dispatcher" && user.Parol == password)
                        return (AplicationUser.Dispatcher);
                    else if (user is Employee && (user as Employee).Position == "Driver" && user.Parol == password)
                        return (AplicationUser.Driver);
                    else if (user is Employee && (user as Employee).Position == "Administrator" && user.Parol == password)
                        return (AplicationUser.Admin);
                }
            }
            IoC.Application_Work.Current_User = null;
            return (AplicationUser.None);
        }
    }
}
