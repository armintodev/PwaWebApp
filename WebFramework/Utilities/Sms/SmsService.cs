using System.Threading.Tasks;
using Kavenegar;
using Kavenegar.Models.Enums;

namespace WebFramework.Utilities.Sms
{
    public class SmsService : ISmsService
    {
        public async Task<OperationResult> Send(string receptor, string message)
        {
            var sender = "1000596446";
            var api = new KavenegarApi("646E526A32384D727949783262687051702B4539787749746B386C73396631356E4C4E596242644A7251553D");
            var result = api.Send(sender, receptor, message);
            var status = api.Status(result.Messageid.ToString());
            if (status.Status is MessageStatus.Canceled)
                return new OperationResult(false, "ارسال لغو شده است");

            if (status.Status is MessageStatus.Undelivered)
                return new OperationResult(false, "پیام ارسال نشد");

            return new OperationResult(message: "پیام با موفقیت ارسال شد");
        }
    }
}