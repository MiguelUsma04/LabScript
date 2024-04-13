using Microsoft.JSInterop;

namespace LabScript
{
    public class AlertService : IAsyncDisposable, IAlertService
    {
        readonly Lazy<Task<IJSObjectReference>> ijsObjectReference;

        public AlertService(IJSRuntime ijsRuntime)
        {
            this.ijsObjectReference = new Lazy<Task<IJSObjectReference>>(() =>
            ijsRuntime.InvokeAsync<IJSObjectReference>("import", "./Pages/Home.razor.js").AsTask());
        }

        public async ValueTask DisposeAsync()
        {
            if (ijsObjectReference.IsValueCreated)
            {
                IJSObjectReference moduleJs = await ijsObjectReference.Value;
                await moduleJs.DisposeAsync();
            }
        }
    }
}