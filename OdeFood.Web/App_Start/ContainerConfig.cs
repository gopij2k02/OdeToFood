using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeFood.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly); // For MVC registration
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);//For API registration

            //Configuration to use InMemoryRes data
            //builder.RegisterType<InMemoryRestaurantData>()
            //    .As<IRestaurantData>()
            //    .SingleInstance();

            // Only changes here for Depedency Injection to use the SQL DB Restaturant data
            builder.RegisterType<SqlDbRestaurantData>()
                .As<IRestaurantData>()
                .InstancePerRequest(); // create instance per request opposite of singleinstance
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //FOR WEB API autofac webapi nuget
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}