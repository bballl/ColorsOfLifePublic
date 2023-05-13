using Assets.Scripts.Locations;
using UnityEngine;

namespace Assets.Scripts.Animals
{
    public class AnimalsInteractionController : MonoBehaviour
    {
        [SerializeField] private GameObject catPrefab;
        [SerializeField] private GameObject dogPrefab;
        
        private Animal cat;
        private Animal dog;

        private void Awake()
        {
            ParkLocationTriggerController.OnAnimalFound += GetAnimal;

            dogPrefab.SetActive(false);
            catPrefab.SetActive(false);
        }

        private void OnDestroy()
        {
            ParkLocationTriggerController.OnAnimalFound -= GetAnimal;
        }

        private void GetAnimal(AnimalType animal)
        {
            if (animal == AnimalType.Cat)
            {
                cat.InHome = true;
                catPrefab.SetActive(true);
            }

            if (animal == AnimalType.Dog)
            {
                dog.InHome = true;
                dogPrefab.SetActive(true);
            }
        }
    }
}
