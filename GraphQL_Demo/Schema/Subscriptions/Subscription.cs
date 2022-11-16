using Domain;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL_Demo.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public Restaurant RestaurantCreated([EventMessage] Restaurant restaurant) => restaurant;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<Restaurant>> RestaurantUpdated(Guid restaurantId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{restaurantId}_{nameof(Subscription.RestaurantUpdated)}";

            return topicEventReceiver.SubscribeAsync<string, Restaurant>(topicName);
        }
    }
}
