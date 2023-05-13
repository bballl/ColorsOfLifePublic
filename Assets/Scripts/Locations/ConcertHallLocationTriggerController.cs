namespace Assets.Scripts.Locations
{
    internal class ConcertHallLocationTriggerController : LocationTriggerController
    {
        private void Start()
        {
            LocationName = LocationType.ConcertHall;
            MessageText = LocationMessgeText.ConcertHallText;
            FinishQuestText = LocationFinishQuestText.ConcertHallText;
            Bonus = Settings.ConcertHallBonus;
        }
    }
}
