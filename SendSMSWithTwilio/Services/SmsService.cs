



namespace SendSMSWithTwilio.Services
{
    public class SmsService : ISmsService
    {
        private readonly TwilioSettings _twilio;

        public SmsService(IOptions<TwilioSettings> twilio)
        {
            _twilio = twilio.Value;
        }

        public MessageResource sendSms(string mobileNumber, string message)
        {
            //intialize connection with twilio
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

            //send message
            var result = MessageResource.Create(
                  body: message,
                  from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
                  to: mobileNumber
              );

            return result;
        }
    }
}
