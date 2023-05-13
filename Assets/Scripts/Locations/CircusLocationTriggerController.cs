namespace Assets.Scripts.Locations
{
    internal class CircusLocationTriggerController : LocationTriggerController
    {
        private void Start()
        {
            LocationName = LocationType.Circus;
            MessageText = LocationMessgeText.CircusText;
            FinishQuestText = LocationFinishQuestText.CircusText;
            Bonus = Settings.CircusBonus;
        }
    }
}
