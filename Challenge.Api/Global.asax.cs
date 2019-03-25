using System;
using System.IO;
using System.Web.Http;
using Persistence.Commons.NHibernate.Helpers;
using Persistence.Seed;
using Persistence.Users.NHibertante.Repositories;

namespace Challenge.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var seedData = new SeedData();
            seedData.Initialize(
                new UserNHibernateRepository(new NHibernateHelper($@"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ChallengeDB.db")};Version=3;Journal Mode=Off;")));
        }
    }
}
