using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Admin.PageSubscriberDashboard
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
