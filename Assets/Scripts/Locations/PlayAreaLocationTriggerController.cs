namespace Assets.Scripts.Locations
{
    internal class PlayAreaLocationTriggerController : LocationTriggerController
    {
        private void Start()
        {
            LocationName = LocationType.PlayArea;
            MessageText = LocationMessgeText.PlayAreaText;
            FinishQuestText = LocationFinishQuestText.PlayAreaText;
            Bonus = Settings.PlayAreaBonus;
        }
    }
}
