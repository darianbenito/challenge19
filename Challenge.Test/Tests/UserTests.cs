using System;
using System.Collections.Generic;
using Challenge.Domain.Users;
using Challenge.Domain.Users.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Test.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void SetTheOldestExtensionMethod_ShouldSetTheOldestUserFromCollection()
        {
            var usersCollection = new List<User>
            {
                new User { Id = 1, BirthDate = new DateTime(1984,1,5)},
                new User { Id = 2, BirthDate = new DateTime(1983,8,19)},
                new User { Id = 3, BirthDate = new DateTime(1994,9,3)},
                new User { Id = 4, BirthDate = new DateTime(2000,12,1)},
                new User { Id = 5, BirthDate = new DateTime(1987,3,28)}
            };

            usersCollection.SetTheOldest();

            Assert.IsTrue(usersCollection.Exists(x => x.Id == 2 && x.IsTheOldest));
        }
    }
}