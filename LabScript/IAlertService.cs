namespace LabScript
{
    public interface IAlertService
    {
        Task CallJsAlertFunction();
        ValueTask DisposeAsync();
    }
}