namespace IdentityServer.API.Settings.Views
{
    public static class LayoutSettings
    {
        public static string LAYOUT_DEFAULT = "_Layout";
        public static Dictionary<string, string> Layouts => new()
        {
            {"Auth", "_AuthLayout"}
        };

        public static string GetLayoutOrDefaultByControllerName(string controllerName)
        {
            var layout = Layouts.GetValueOrDefault(controllerName);
            if (string.IsNullOrEmpty(layout))
                return LAYOUT_DEFAULT;

            return layout;  
        }
    }
}
