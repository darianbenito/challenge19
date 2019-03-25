using System;
using System.Collections.Generic;
using System.Net;
using Domain.Users;
using Newtonsoft.Json.Linq;
using Persistence.Users.Contracts;

namespace Persistence.Seed
{
    public class SeedData
    {
        public void Initialize(IUserRepository userRepository)
        {
            var users = new List<User>();

            var json = new WebClient().DownloadString("https://randomuser.me/api/?results=500");

            JToken token = JObject.Parse(json);

            foreach (var a in (JArray)token.SelectToken("results"))
            {
                var newUser = new User()
                {
                    IdValue = a["id"]["value"].Value<string>(),
                    Gender = a["gender"].Value<string>(),
                    Name = a["name"]["first"].Value<string>(),
                    Email = a["email"].Value<string>(),
                    BirthDate = a["dob"]["date"].Value<DateTime>(),
                    Uuid = a["login"]["uuid"].Value<string>(),
                    UserName = a["login"]["username"].Value<string>(),
                };

                var location = new Location()
                {
                    State = a["location"]["state"].Value<string>(),
                    Street = a["location"]["street"].Value<string>(),
                    City = a["location"]["city"].Value<string>(),
                    PostCode = a["location"]["postcode"].Value<string>(),
                    User = newUser
                };

                newUser.Location = location;

                users.Add(newUser);
            }

            userRepository.AddAll(users);
        }
    }
}
