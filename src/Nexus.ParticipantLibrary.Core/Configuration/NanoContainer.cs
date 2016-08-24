using System;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.Core.Configuration
{
    public class NanoContainer
    {
        private readonly IDictionary<Type, ContainerRegistration> registrations = new Dictionary<Type, ContainerRegistration>();

        public virtual ContainerRegistration Register<TService>(Func<NanoContainer, TService> resolve)
            where TService : class
        {
            var registration = new ContainerRegistration(c => (object)resolve(c));
            this.registrations[typeof(TService)] = registration;
            return registration;
        }

        public virtual ContainerRegistration Register<TService>(TService instance)
        {
            if (Equals(instance, null))
                throw new ArgumentNullException("instance", "InstanceCannotBeNull");

            if (!typeof(TService).IsValueType && !typeof(TService).IsInterface)
                throw new ArgumentException("TypeMustBeInterface", "instance");

            var registration = new ContainerRegistration(instance);
            this.registrations[typeof(TService)] = registration;
            return registration;
        }

        public virtual TService Resolve<TService>()
        {
            ContainerRegistration registration;
            if (registrations.TryGetValue(typeof(TService), out registration))
                return (TService)registration.Resolve(this);

            return default(TService);
        }
    }
}
