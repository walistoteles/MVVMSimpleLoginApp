using MVVMSimpleLoginApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSimpleLoginApp.Services
{
    class LoginService
    {


        public async Task<bool> Login(string password,string username)
        {
            List<User> users = new List<User>();

            string x = await Xamarin.Essentials.SecureStorage.GetAsync("users");
            if(x != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(x);
                for (int i = 0; i < users.Count; i++)
                {
                    if(password == users[i].Password && username == users[i].Username)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }

            return false;
        }


        public async void Register(string password,string username)
        {

            User user = new User();
            List<User> users = new List<User>();

            user.Username = username;
            user.Password = password;

            

            string x = await Xamarin.Essentials.SecureStorage.GetAsync("users");
            if(x != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(x);

                users.Add(user);
                string y = JsonConvert.SerializeObject(users);

                Xamarin.Essentials.SecureStorage.Remove("users");
                await Xamarin.Essentials.SecureStorage.SetAsync("users", y);
            }
            else
            {
                users.Add(user);
                string y = JsonConvert.SerializeObject(users);
                await Xamarin.Essentials.SecureStorage.SetAsync("users", y);

            }
        }
    }
}
