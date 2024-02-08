namespace ProductBuyerMVC.BussinessLogic
{
    public interface INotify
    {
        string Notification(string userId, string message);
    }
}