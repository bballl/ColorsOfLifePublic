namespace Assets.Scripts.Locations
{
    internal class PlanetariumLocationTriggerController : LocationTriggerController
    {
        private void Start()
        {
            LocationName = LocationType.Planetarium;
            MessageText = LocationMessgeText.PlanetariumText;
            FinishQuestText = LocationFinishQuestText.PlanetariumText;
            Bonus = Settings.PlanetariumBonus;
        }
    }
}
