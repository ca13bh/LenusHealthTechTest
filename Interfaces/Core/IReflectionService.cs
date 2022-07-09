namespace LenusHealthTechTest.Interfaces.Core
{
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// This interface defines the reflection service.
    /// </summary>
    public interface IReflectionService
    {
        /// <summary>
        /// This method is called to get all types that implement a specific open generic interface
        /// </summary>
        /// <param name="genericInterfaceType">The type of the generic interface</param>
        List<Type> GetImplementationsOfGenericInterface(Type genericInterfaceType);
    }
}