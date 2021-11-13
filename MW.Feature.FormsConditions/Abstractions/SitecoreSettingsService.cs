namespace MW.Feature.FormConditions.Abstractions
{
    public class SitecoreSettingsService : ISettingsService
    {
        public string GetSetting(string name)
        {
            return Sitecore.Configuration.Settings.GetSetting(name);
        }
    }
}
