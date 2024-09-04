using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Twilio.Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly TwilioService _twilioService;

        public IndexModel(ILogger<IndexModel> logger, TwilioService twilioService)
        {
            _logger = logger;
            _twilioService = twilioService;
        }

        public void OnGet()
        {
            _twilioService.SendMessage("+923000477761", "Testing");
        }
    }
}
