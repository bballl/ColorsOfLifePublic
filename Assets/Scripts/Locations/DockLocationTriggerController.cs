namespace Assets.Scripts.Locations
{
    internal class DockLocationTriggerController : LocationTriggerController
    {
        private void Start()
        {
            LocationName = LocationType.Dock;
            MessageText = LocationMessgeText.DockText;
            FinishQuestText = LocationFinishQuestText.DockText;
            Bonus = Settings.PierBonus;
        }
    }
}
