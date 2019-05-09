using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Domain.Users.Extensions
{
    public static class UserExtensions
    {
        public static void SetTheOldest(this IList<User> users)
        {
            if (users == null) throw new ArgumentNullException(nameof(users));
            if (users.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(users));

            User theOldestUser = users.First();

            for (var index = 1; index < users.Count; index++)
            {
                var currentUser = users[index];

                if (currentUser.BirthDate < theOldestUser.BirthDate)
                {
                    theOldestUser = currentUser;
                }
            }

            theOldestUser.IsTheOldest = true;
        }
    }
}