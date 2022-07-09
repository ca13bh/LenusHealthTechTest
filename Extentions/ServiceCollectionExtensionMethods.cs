namespace LenusHealthTechTest.Extentions
{
    using LenusHealthTechTest.Interfaces.Core;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ServiceCollectionExtensionMethods
    {
        public static void RegisterInterfaceImplementations(this IServiceCollection serviceCollection, Type interfaceType, ServiceLifetime serviceLifetime, IReflectionService reflectionService)
        {
            var implementationTypes = reflectionService.GetImplementationsOfGenericInterface(interfaceType);
            foreach (var type in implementationTypes)
            {
                foreach (var ti in type.GetInterfaces())
                {
                    switch (serviceLifetime)
                    {
                        case ServiceLifetime.Singleton:
                            serviceCollection.AddSingleton(ti, type);
                            break;
                        case ServiceLifetime.Scoped:
                            serviceCollection.AddScoped(ti, type);
                            break;
                        case ServiceLifetime.Transient:
                        default:
                            serviceCollection.AddTransient(ti, type);
                            break;
                    }
                }
            }
        }
    }
}
