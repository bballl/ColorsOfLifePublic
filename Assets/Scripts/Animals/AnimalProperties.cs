using UnityEngine;

namespace Assets.Scripts.Animals
{
    [CreateAssetMenu]
    public class AnimalProperties : ScriptableObject
    {
        [SerializeField] private int amountFoodFromPetShop;
        [SerializeField] private int maxBellyful;
        [SerializeField] private int stepBellyful;
        [SerializeField] private float amountColorFromPets;
        [SerializeField] private float timeHunger;

        public int AmountFoodFromPetShop => amountFoodFromPetShop;
        public int MaxBellyful => maxBellyful;
        public int StepBellyful => stepBellyful;
        public float AmountColorFromPets => amountColorFromPets;
        public float TimeHunger => timeHunger;
    }
}
