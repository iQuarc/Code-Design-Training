using System.Collections.Generic;
using Contracts.Notifications;
using iQuarc.AppBoot;
using iQuarc.SystemEx;

namespace Notifications
{
    [Service(typeof(IAmAliveSubscriber<>))]
    class AmAliveSubscriber<T> : IAmAliveSubscriber<T>
    {
        readonly IEnumerable<IAmAliveSubscriber<T>> subscribers;

        public AmAliveSubscriber(IAmAliveSubscriber<T>[] subscribers)
        {
            this.subscribers = subscribers;
        }

        public void AmAlive(T item)
        {
            subscribers.ForEach(s => s.AmAlive(item));
        }
    }
}