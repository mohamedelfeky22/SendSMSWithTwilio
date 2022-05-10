

namespace SendSMSWithTwilio.Services
{
    public interface ISmsService
    {
        MessageResource sendSms(string mobileNumber, string message);
    }
}
