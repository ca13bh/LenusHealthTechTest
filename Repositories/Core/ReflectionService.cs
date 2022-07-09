namespace LenusHealthTechTest.Repositories.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System;
    using LenusHealthTechTest.Interfaces.Core;

    /// <summary>
    /// This class is used to provide a service to access reflection data.
    /// </summary>
    public class ReflectionService : IReflectionService
    {
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        public ReflectionService() { }

        /// <summary>
        /// This method is called to get all types that implement a specific open generic interface
        /// </summary>
        /// <param name="genericInterfaceType">The type of the generic interface</param>
        public List<Type> GetImplementationsOfGenericInterface(Type genericInterfaceType)
        {
            var assemblies = this.GetAssemblies().Where(a => !a.IsDynamic).ToList();
            return (from x in assemblies.SelectMany(a => a.GetTypes())
                    from z in x.GetInterfaces()
                    let y = x.BaseType
                    where
                    (y != null && y.IsGenericType &&
                    genericInterfaceType.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
                    (z.IsGenericType &&
                    genericInterfaceType.IsAssignableFrom(z.GetGenericTypeDefinition()))
                    select x).Where(t => t.IsClass && !t.IsAbstract).ToList();
        }

        private ICollection<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName != null && !a.FullName.StartsWith("Microsoft") && !a.FullName.StartsWith("System"))
                .ToList();
        }
    }
}
