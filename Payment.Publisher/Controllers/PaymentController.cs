using Microsoft.AspNetCore.Mvc;
using Payment.Models;
using Payment.Publisher;

namespace Payment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly RabbitMQService _rabbitMQService;

        public PaymentController()
        {
            _rabbitMQService = new RabbitMQService();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePayment payment)
        {
            _rabbitMQService.Publish(payment);
            return Accepted();
        }
    }
}


