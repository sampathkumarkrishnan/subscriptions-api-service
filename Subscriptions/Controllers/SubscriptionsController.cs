using Microsoft.AspNetCore.Mvc;
using Subscriptions.Models;

namespace Subscriptions.Controllers
{
    /// <summary>
    /// Controller for managing subscription operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private static readonly List<SubscriptionDTO> _subscriptions = new();
        private static int _nextId = 1;

        /// <summary>
        /// Retrieves all subscriptions.
        /// </summary>
        /// <returns>A collection of all subscriptions.</returns>
        /// <response code="200">Returns the list of subscriptions.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionDTO>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<SubscriptionDTO>> GetAll()
        {
            return Ok(_subscriptions);
        }

        /// <summary>
        /// Retrieves a specific subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription.</param>
        /// <returns>The subscription with the specified identifier.</returns>
        /// <response code="200">Returns the requested subscription.</response>
        /// <response code="404">If the subscription is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubscriptionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubscriptionDTO> GetById(int id)
        {
            var subscription = _subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }
            return Ok(subscription);
        }

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="subscription">The subscription data to create.</param>
        /// <returns>The newly created subscription.</returns>
        /// <response code="201">Returns the newly created subscription.</response>
        /// <response code="400">If the subscription data is invalid.</response>
        [HttpPost]
        [ProducesResponseType(typeof(SubscriptionDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SubscriptionDTO> Create(SubscriptionDTO subscription)
        {
            subscription.Id = _nextId++;
            _subscriptions.Add(subscription);
            return CreatedAtAction(nameof(GetById), new { id = subscription.Id }, subscription);
        }

        /// <summary>
        /// Updates an existing subscription.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription to update.</param>
        /// <param name="subscription">The updated subscription data.</param>
        /// <returns>No content on successful update.</returns>
        /// <response code="204">If the subscription was successfully updated.</response>
        /// <response code="404">If the subscription is not found.</response>
        /// <response code="400">If the subscription data is invalid.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, SubscriptionDTO subscription)
        {
            var existingSubscription = _subscriptions.FirstOrDefault(s => s.Id == id);
            if (existingSubscription == null)
            {
                return NotFound();
            }

            existingSubscription.Name = subscription.Name;
            existingSubscription.Email = subscription.Email;
            existingSubscription.Plan = subscription.Plan;
            existingSubscription.StartDate = subscription.StartDate;
            existingSubscription.EndDate = subscription.EndDate;
            existingSubscription.IsActive = subscription.IsActive;

            return NoContent();
        }

        /// <summary>
        /// Deletes a subscription.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription to delete.</param>
        /// <returns>No content on successful deletion.</returns>
        /// <response code="204">If the subscription was successfully deleted.</response>
        /// <response code="404">If the subscription is not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var subscription = _subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            _subscriptions.Remove(subscription);
            return NoContent();
        }
    }
}

