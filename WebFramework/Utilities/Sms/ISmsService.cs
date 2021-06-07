using System.Threading.Tasks;

namespace WebFramework.Utilities.Sms
{
    public interface ISmsService
    {
        Task<OperationResult> Send(string receptor, string message);
    }
}
