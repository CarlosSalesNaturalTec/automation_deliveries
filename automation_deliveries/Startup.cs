using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace automation_deliveries
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
