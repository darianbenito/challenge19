using System;
using System.IO;
using Challenge.Application.Users.Commands.AddUser;
using Challenge.Application.Users.Commands.DeleteUser;
using Challenge.Application.Users.Commands.UpdateUser;
using Challenge.Application.Users.Queries.GetAllUsers;
using Challenge.Application.Users.Queries.GetAllUsersPaginated;
using Challenge.Application.Users.Queries.GetUserByIdValue;
using Challenge.Persistence.Commons.NHibernate.Helpers;
using Challenge.Persistence.Users.Contracts;
using Challenge.Persistence.Users.NHibertante.Repositories;
using Unity;
using Unity.Injection;

namespace Challenge.Api
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<INHibernateHelper, NHibernateHelper>(new InjectionConstructor($@"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ChallengeDB.db")};Version=3;Journal Mode=Off;"));

            container.RegisterType<IUserRepository, UserNHibernateRepository>();

            container.RegisterType<IAddUserCommand, AddUserCommand>();
            container.RegisterType<IDeleteUserCommand, DeleteUserCommand>();
            container.RegisterType<IUpdateUserCommand, UpdateUserCommand>();

            container.RegisterType<IGetAllUsersQuery, GetAllUsersQuery>();
            container.RegisterType<IGetAllUsersPaginatedQuery, GetAllUsersPaginatedQuery>();
            container.RegisterType<IGetUserByIdValueQuery, GetUserByIdValueQuery>();
        }
    }
}