using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Twilio.Test
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _twilioPhoneNumber;

        public TwilioService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSID"];
            _authToken = configuration["Twilio:AuthToken"];
            _twilioPhoneNumber = configuration["Twilio:PhoneNumber"];
        }

        public void SendMessage(string toPhoneNumber, string message)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(toPhoneNumber))
            {
                From = new PhoneNumber(_twilioPhoneNumber),
                Body = message
            };

            var msg = MessageResource.Create(messageOptions);
            Console.WriteLine($"Message sent: SID {msg.Sid}");
        }
    }
}
