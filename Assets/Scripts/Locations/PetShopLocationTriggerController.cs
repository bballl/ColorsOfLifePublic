namespace Assets.Scripts.Locations
{
    internal class PetShopLocationTriggerController : LocationTriggerController
    {
        private void Start()
        {
            LocationName = LocationType.PetShop;
            MessageText = LocationMessgeText.PetShopText;
            FinishQuestText = LocationFinishQuestText.PetShopText;
            Bonus = Settings.PetShopBonus;
        }
    }
}
