using System;
using System.IO;
using System.Web.Http;
using Challenge.Api.Repositories.NHibernate;
using Challenge.Api.Repositories.NHibernate.Helpers;
using Challenge.Api.Seed;

namespace Challenge.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            SeedData seedData = new SeedData();
            seedData.Initialize(
                new UserNHibernateRepository(new NHibernateHelper($@"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ChallengeDB.db")};Version=3;Journal Mode=Off;")));
        }
    }
}
