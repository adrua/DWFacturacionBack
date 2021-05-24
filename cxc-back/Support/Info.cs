using Microsoft.OpenApi.Models;
namespace Cxc_back.Support
{
    public class Info : OpenApiInfo
    {
        public new string Title { get; set; }

        public new string Version { get; set; }
    }
}
