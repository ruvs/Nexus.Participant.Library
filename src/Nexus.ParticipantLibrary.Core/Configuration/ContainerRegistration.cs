using System;

namespace Nexus.ParticipantLibrary.Core.Configuration
{
    public class ContainerRegistration
    {
        private readonly Func<NanoContainer, object> resolve;
        private object instance;
        private bool instancePerCall;

        public ContainerRegistration(Func<NanoContainer, object> resolve)
        {
            this.resolve = resolve;
        }
        public ContainerRegistration(object instance)
        {
            this.instance = instance;
        }

        public virtual ContainerRegistration InstancePerCall()
        {
            instancePerCall = true;
            return this;
        }
        public virtual object Resolve(NanoContainer container)
        {
            if (instancePerCall)
            {
                return resolve(container);
            }

            if (instance != null)
                return instance;

            return instance = resolve(container);
        }
    }
}
