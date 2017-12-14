using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVCAuth.Models
{
    public class LoginUser
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
    }

    static class ManageUsers 
    {
        private static Dictionary<String, LoginUser> users;

        static ManageUsers()
        {
            users = new Dictionary<String, LoginUser>();
            RegisterUser(new LoginUser() { Username = "titi@toto.com", Password = "Titi123+" });
            RegisterUser(new LoginUser() { Username = "tete@toto.com", Password = "Tete123+" });
            RegisterUser(new LoginUser() { Username = "toto@toto.com", Password = "Toto123+" });
            RegisterUser(new LoginUser() { Username = "tutu@toto.com", Password = "Tutu123+" });
            
          
            foreach (var u in users)
            {
                try
                {
                    Roles.RemoveUserFromRole(u.Value.Username, "users");
                }
                catch { }
                try
                {
                    Roles.RemoveUserFromRole(u.Value.Username, "admins");
                }
                catch { }

                Membership.DeleteUser(u.Value.Username);
            }
            Roles.DeleteRole("users");
            Roles.DeleteRole("admins");
            if (!Roles.RoleExists("users"))
            {
                Roles.CreateRole("users");  
            }

            if (!Roles.RoleExists("admins"))
            {
                Roles.CreateRole("admins");
            }
            
            
            foreach (var u in users)
            {
                if (Membership.FindUsersByName(u.Value.Username).Count <= 0)
                {
                    MembershipUser user = Membership.CreateUser(u.Value.Username,
                        u.Value.Password, u.Value.Username);
                    if (u.Value.Username == "titi@toto.com" || u.Value.Username == "tutu@toto.com")
                    {
                        Roles.AddUserToRole(u.Value.Username, "admins");
                    }
                    Roles.AddUserToRole(u.Value.Username, "users");
                }
            }
        }

        public static String RegisterUser(LoginUser user)
        {
        users.Add(user.Username, user);
        return user.Username;
        }

        public static String DeleteUser(LoginUser user)
        {
            users.Remove(user.Username);
            return user.Username;
        }

        public static  LoginUser getUserByName(String username)
        {
            return users[username];
        }

        public static List<LoginUser>  getUsers()
        {
            return users.Values.ToList();
        }

    }
}