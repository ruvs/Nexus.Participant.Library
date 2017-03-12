using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace Nexus.ParticipantLibrary.UnitTests.Helpers.MassTransit
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registration = null)
        {
            string _rabbitMqHostUri = ConfigHelper.GetAppSetting("RabbitMqHost");
            string _rabbitMqUser = ConfigHelper.GetAppSetting("RabbitMqUser");
            string _rabbitMqSignalRServiceQueue = ConfigHelper.GetAppSetting("SignalRNotificationServiceQueue");

            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(_rabbitMqHostUri), hst =>
                {
                    hst.Username(_rabbitMqUser);
                    hst.Password(_rabbitMqUser);
                });

            //cfg.ReceiveEndpoint(host, _rabbitMqSignalRServiceQueue, c => c.Consumer<ChannelEventConsumer>());

            registration?.Invoke(cfg, host);
            });
        }
    }
}
