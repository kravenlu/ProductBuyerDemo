using System.Diagnostics;

namespace ProductBuyerMVC.BussinessLogic
{
    public class NotifyToPage : INotify
    {
        public string Notification(string userId, string message)
        {
            Debug.WriteLine($"Sending message... {userId} - {message}");
            
            return "Sending message..." + userId + " - " + message;
        }

    }
}
