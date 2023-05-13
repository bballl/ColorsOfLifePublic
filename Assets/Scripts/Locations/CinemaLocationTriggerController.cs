namespace Assets.Scripts.Locations
{
    internal class CinemaLocationTriggerController : LocationTriggerController
    {
        private void Start()
        {
            LocationName = LocationType.Cinema;
            MessageText = LocationMessgeText.CinemaText;
            FinishQuestText = LocationFinishQuestText.CinemaText;
            Bonus = Settings.CinemaBonus;
        }
    }
}
