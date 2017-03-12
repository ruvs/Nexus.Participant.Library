using MassTransit;
using System;
using System.Threading.Tasks;
using GreenPipes;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Nexus.ParticipantLibrary.Messages.Interfaces;

namespace Nexus.ParticipantLibrary.UnitTests.Helpers.MassTransit
{
    public class SpyPublishEndpoint : IPublishEndpoint
    {
        public IList<object> PublishedMessages = new List<object>();

        #region IPublishEndpoint

        public Task Publish<T>(T message, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            PublishedMessages.Add(message);
            return Task.FromResult(0);
        }

        public Task Publish<T>(T message, IPipe<PublishContext<T>> publishPipe, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            PublishedMessages.Add(message);
            return Task.FromResult(0);
        }

        public Task Publish<T>(T message, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            PublishedMessages.Add(message);
            return Task.FromResult(0);
        }

        public Task Publish(object message, CancellationToken cancellationToken = default(CancellationToken))
        {
            PublishedMessages.Add(message);
            return Task.FromResult(0);
        }

        public Task Publish(object message, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default(CancellationToken))
        {
            PublishedMessages.Add(message);
            return Task.FromResult(0);
        }

        public Task Publish(object message, Type messageType, CancellationToken cancellationToken = default(CancellationToken))
        {
            PublishedMessages.Add(message);
            return Task.FromResult(0);
        }

        public Task Publish(object message, Type messageType, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default(CancellationToken))
        {
            PublishedMessages.Add(message);
            return Task.FromResult(0);
        }

        public Task Publish<T>(object values, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            PublishedMessages.Add(values);
            return Task.FromResult(0);
        }

        public Task Publish<T>(object values, IPipe<PublishContext<T>> publishPipe, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            PublishedMessages.Add(values);
            return Task.FromResult(0);
        }

        public Task Publish<T>(object values, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            PublishedMessages.Add(values);
            return Task.FromResult(0);
        }

        public ConnectHandle ConnectPublishObserver(IPublishObserver observer)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void ClearMessages()
        {
            PublishedMessages.Clear();
        }

        public bool WasMessagePublished<T>()
        {
            return PublishedMessages.Any(msg => msg is T);
        }

        public T GetPublishedMessage<T>() where T : class, IAmAPublishableMessage
        {
            return PublishedMessages.FirstOrDefault(msg => msg is T) as T;
        }

        public IEnumerable<T> GetPublishedMessages<T>() where T : class, IAmAPublishableMessage
        {
            return (from msg in PublishedMessages
                    where msg is T
                    select msg as T).ToList();
        }
    }
}
