
using Microsoft.AspNetCore.Components;

namespace MalenkijMelo.Web.Components.Layout
{
    public partial class NavMenu
    {
        private int logoWidth = 2000 / 15;
        private int logoHeight = 914 / 15;

        [CascadingParameter(Name = "NavbarOpen")]
        public bool IsNavbarOpen { get; set; }
    }
}