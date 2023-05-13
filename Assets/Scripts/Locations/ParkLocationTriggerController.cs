using Assets.Scripts.Animals;
using System;
using UnityEngine;

namespace Assets.Scripts.Locations
{
    internal class ParkLocationTriggerController : LocationTriggerController
    {
        public static event Action<AnimalType> OnAnimalFound;

        private bool isCatFound;
        private bool isDogFound;
        
        private string catMessage = "Гуляя в парке, я нашел потерянную кошечку и взял ее к себе. " +
            "Теперь я должен не забывать ее кормить.";
        private string dogMessage = "В парке я нашел потерявшуюся собаку и взял ее домой. У меня как раз есть будка для нее.";
        

        private void Start()
        {
            LocationName = LocationType.Park;
            MessageText = LocationMessgeText.ParkText;
            FinishQuestText = catMessage;
            Bonus = Settings.ParkBonus;
        }

        public override void LocationInteractionFinish()
        {
            base.LocationInteractionFinish();
            FindAnimal();
        }

        private void FindAnimal()
        {
            if (isCatFound == false)
            {
                OnAnimalFound?.Invoke(AnimalType.Cat);
                FinishQuestText = dogMessage;
                isCatFound = true;
                return;
            }

            if (isDogFound == false)
            {
                OnAnimalFound?.Invoke(AnimalType.Dog);
                FinishQuestText = LocationFinishQuestText.ParkText;
                isDogFound = true;
            }
        }
    }
}
