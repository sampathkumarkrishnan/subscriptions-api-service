namespace Subscriptions.Models
{
    /// <summary>
    /// Represents a subscription data transfer object.
    /// </summary>
    public class SubscriptionDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the subscription.
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the subscriber.
        /// </summary>
        /// <example>John Doe</example>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the subscriber.
        /// </summary>
        /// <example>john.doe@example.com</example>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the subscription plan type.
        /// </summary>
        /// <example>Premium</example>
        public string Plan { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the start date of the subscription.
        /// </summary>
        /// <example>2024-01-01T00:00:00Z</example>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the subscription. Null if the subscription has no end date.
        /// </summary>
        /// <example>2024-12-31T23:59:59Z</example>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription is currently active.
        /// </summary>
        /// <example>true</example>
        public bool IsActive { get; set; }
    }
}
