using Contracts.Notifications;
using iQuarc.AppBoot;
using iQuarc.SystemEx;
using Microsoft.Practices.ServiceLocation;

namespace Notifications
{
	[Service(typeof (INotificationService), Lifetime.Application)]
    public class NotificationService : INotificationService
    {
        private readonly IServiceLocator serviceLocator;
	    public NotificationService(IServiceLocator serviceLocator)
	    {
		    this.serviceLocator = serviceLocator;
	    }

	    public void NotifyNew<T>(T item)
        {
            var subscribers = serviceLocator.GetAllInstances<IStateChangeSubscriber<T>>();
            foreach (var subscriber in subscribers)
            {
                subscriber.NewItem(item);
            }
        }

		public void NotifyAlive<T>(T item)
		{
			var subscriber = serviceLocator.GetInstance<IAmAliveSubscriber<T>>();
			subscriber.AmAlive(item);
		}

		public void NotifyDeleted<T>(T item)
        {
            throw new System.NotImplementedException();
        }

	    public void NotifyChanged<T>(T item)
        {
            throw new System.NotImplementedException();
        }

	    public void NotifyStatusChange<T>(T item, Status newStatus, Status oldStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}