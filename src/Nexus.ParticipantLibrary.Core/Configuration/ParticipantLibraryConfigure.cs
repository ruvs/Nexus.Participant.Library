using MassTransit;
using Nexus.ParticipantLibrary.Core.Library;

namespace Nexus.ParticipantLibrary.Core.Configuration
{
    public class ParticipantLibraryConfigure
    {
        private readonly ParticipantLibraryConfigure inner;
        private readonly NanoContainer container;

        protected ParticipantLibraryConfigure(ParticipantLibraryConfigure inner)
        {
            this.inner = inner;
        }

        protected ParticipantLibraryConfigure(NanoContainer container)
        {
            this.container = container;
        }

        protected NanoContainer Container
        {
            get { return container ?? inner.Container; }
        }

        public static ParticipantLibraryConfigure Init()
        {
            var container = new NanoContainer();
            container.Register(Build);

            return new ParticipantLibraryConfigure(container);
        }

        public ParticipantLibraryConfigure With<T>(T instance) where T : class
        {
            Container.Register(instance);
            return this;
        }


        private static IAmAParticipantLibrary Build(NanoContainer context)
        {
            var handler = new ParticipantItemLibrary(context.Resolve<IWriteToParticipantLibrary>(),
                context.Resolve<IReadFromParticipantLibrary>(), context.Resolve<IPublishEndpoint>());
            return handler;
        }

        public virtual IAmAParticipantLibrary Build()
        {
            if (inner != null)
                return inner.Build();
            //ValidateThatClaimsPrincipalResolverIsConfigured();
            ValidateThatWriterIsConfigured();
            ValidateThatReaderIsConfigured();
            ValidateThatBusIsConfigured();
            return Container.Resolve<IAmAParticipantLibrary>();
        }

        private void ValidateThatWriterIsConfigured()
        {
            if (container.Resolve<IWriteToParticipantLibrary>() == null)
            {
                throw new ParticipantLibraryConfigurationException("You must first register an IWriteToParticipantLibrary");
            }
        }

        private void ValidateThatReaderIsConfigured()
        {
            if (container.Resolve<IReadFromParticipantLibrary>() == null)
            {
                throw new ParticipantLibraryConfigurationException("You must first register an IReadFromParticipantLibrary");
            }
        }

        private void ValidateThatBusIsConfigured()
        {
            if (container.Resolve<IBus>() == null)
            {
                throw new ParticipantLibraryConfigurationException("You must first register an IBus");
            }
        }

        //private void ValidateThatClaimsPrincipalResolverIsConfigured()
        //{
        //    if (container.Resolve<IResolveClaimsPrincipal>() == null)
        //    {
        //        throw new CatalogConfigurationException("You must first register an IResolveClaimsPrincipal");
        //    }
        //}
    }
}