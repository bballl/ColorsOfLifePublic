using System;
using UnityEngine;
using Assets.Scripts.UI;
using Assets.Scripts.Locations;
using Assets.Scripts.Timers;

namespace Assets.Scripts.Animals
{
    public class AnimalFeedController : MonoBehaviour
    {
        public static event Action<float> OnGetBonus;

        [SerializeField] private AnimalProperties animalProperties;

        private int amountFood;
        private int CatBellyful;
        private int DogBellyful;

        // Количество еды с зоомагащина
        private int amountFoodFromPetShop;
        // Максимальное кол-во насыщения
        private int maxBellyful;
        // Шаг, с которым кормится животное за раз
        private int stepBellyful;
        // Чисто красок за кормление животных
        private float amountColorFromPets;
        private float timeHunger;

        private bool isCatHome;
        private bool isDogHome;

        private TimerM timerHungerCat;
        private TimerM timerHungerDog;

        public bool IsFoodEnough => (amountFood >= stepBellyful);
        public bool IsCatBellyful => (CatBellyful == maxBellyful);
        public bool IsDogBellyful => (DogBellyful == maxBellyful);
        public bool IsCatHome => isCatHome;
        public bool IsDogHome => isDogHome;

        private void Start()
        {
            SetProperties();
            InitTimers();

            ParkLocationTriggerController.OnAnimalFound += GetAnimal;
            HomeLocationDialogTriggerController.OnCharacterFeedAnimal += FeedAnimal;
            LocationTriggerController.OnLocationInteractionFinish += GetFood;
        }
        private void Update()
        {
            UpdateTimers();
            CheckHunger();
        }

        private void OnDestroy()
        {
            ParkLocationTriggerController.OnAnimalFound -= GetAnimal;
            HomeLocationDialogTriggerController.OnCharacterFeedAnimal -= FeedAnimal;
            LocationTriggerController.OnLocationInteractionFinish -= GetFood;
        }
        private void GetAnimal(AnimalType animalType)
        {
            switch (animalType)
            {
                case AnimalType.Cat:
                    isCatHome = true;
                    break;
                case AnimalType.Dog:
                    isDogHome = true;
                    break;
            }
        }

        private void CheckHunger()
        {
            if (timerHungerCat.IsFinished == true)
            {
                if (CatBellyful > 0)
                    CatBellyful--;
                timerHungerCat.Start(timeHunger);
            }
            if (timerHungerDog.IsFinished == true)
            {
                if (DogBellyful > 0)
                    DogBellyful--;
                timerHungerDog.Start(timeHunger);
            }
        }

        private void SetProperties()
        {
            amountFoodFromPetShop = animalProperties.AmountFoodFromPetShop;
            maxBellyful = animalProperties.MaxBellyful;
            stepBellyful = animalProperties.StepBellyful;
            amountColorFromPets = animalProperties.AmountColorFromPets;
            timeHunger = animalProperties.TimeHunger;
        }

        private void GetFood(LocationType locationType)
        {
            if (locationType == LocationType.PetShop)
            {
                amountFood += amountFoodFromPetShop;
            }
        }

        private void FeedAnimal(AnimalType animalType)
        {
            switch (animalType)
            {
                case AnimalType.Cat:
                    CatBellyful += stepBellyful;
                    amountFood--;
                    OnGetBonus?.Invoke(amountColorFromPets);
                    timerHungerCat.Start(timeHunger);
                    break;
                case AnimalType.Dog:
                    DogBellyful += stepBellyful;
                    amountFood--;
                    OnGetBonus?.Invoke(amountColorFromPets);
                    timerHungerDog.Start(timeHunger);
                    break;
            }
        }

        #region Timers
        private void InitTimers()
        {
            timerHungerCat = new TimerM(timeHunger);
            timerHungerDog = new TimerM(timeHunger);
        }

        private void UpdateTimers()
        {
            timerHungerCat.RemoveTime(Time.deltaTime);
            timerHungerDog.RemoveTime(Time.deltaTime);
        }
        #endregion

    }
}
