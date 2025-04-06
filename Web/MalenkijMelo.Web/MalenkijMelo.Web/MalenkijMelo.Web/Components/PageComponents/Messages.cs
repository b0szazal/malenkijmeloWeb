using BlazorBootstrap;
using MalenkijMelo.Share.Models;
using MudBlazor;

namespace MalenkijMelo.Web.Components.PageComponents
{
    public partial class Messages
    {
        private Collapse Collapse = default!;
        private List<Message>? messageStore;

        public string BadgeContent { get; set; } = "25";
        public string MessageToggleStyle { get; set; } = "width:15%; left: 80%;";
        public bool ChatShown { get; set; }= false;
        public string MessageToSend { get; set; } = "";

        protected override void OnInitialized()
        {
            messageStore = [];
            base.OnInitialized();
        }

        private async Task ToggleMessages()
        {
            await Collapse.ToggleAsync();
            if (MessageToggleStyle == "width:15%; left: 80%;" || MessageToggleStyle == "width:15%; left: 80%; top: 96%; animation: closeMessages 0.25s; animation-timing-function: ease-in;")
            {
                MessageToggleStyle = $"width:15%; left: 80%; top: 71%; animation: openMessages 0.25s; animation-timing-function: ease;" ;
            }
            else
            {
                MessageToggleStyle = $"width:15%; left: 80%; top: 96%; animation: closeMessages 0.25s; animation-timing-function: ease-in;";
            }
        }

        private void OpenChat()
        {
            ChatShown = true;
        }

        private void CloseChat()
        {
            ChatShown = false;
        }
    }
}
