namespace IdentityServer.API.Application.ViewModels.Common.Modals
{
    public class ConfirmationModalViewModel
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string TargetId { get; set; }
        public string Title { get; set; }
        public string NameButtonSave { get; set; }
        public string NameButtonClose { get; set; }
    }
}
