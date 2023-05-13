using UnityEngine;
using Assets.Scripts.Locations;

namespace Assets.Scripts.Buildings
{
    public class ClockTicking : MonoBehaviour
    {
        [SerializeField] private ClockProperties properties;

        private SplashSystem splashSystem;
        private LocationType locationType;
        private GameObject clockPrefab;
        private float aboveBuilding;
        private GameObject clock;
        private SpriteRenderer sprite;
        private float sizeSprite;

        private void Start()
        {
            SetProperties();

            splashSystem = GetComponent<SplashSystem>();
            locationType = splashSystem.LocationType;

            LocationTriggerController.OnLocationInteractionStart += StartTicking;
            LocationTriggerController.OnLocationInteractionFinish += FinishTicking;

            sprite = GetComponentInChildren<SpriteRenderer>();
            sizeSprite = sprite.size.y;            
        }

        private void OnDestroy()
        {
            LocationTriggerController.OnLocationInteractionStart -= StartTicking;
            LocationTriggerController.OnLocationInteractionFinish -= FinishTicking;
        }

        private void SetProperties()
        {
            clockPrefab = properties.ClockPrefab;
            aboveBuilding = properties.AboveBuilding;
        }

        private void StartTicking(LocationType locType)
        {
            if (locationType == locType)
            {
                clock = Instantiate(clockPrefab);
                clock.transform.position = new(transform.position.x, transform.position.y + (sizeSprite / 2) + aboveBuilding, transform.position.y);
            }
        }

        private void FinishTicking(LocationType locType)
        {
            if (locationType == locType)
            {
                if (clock)
                    Destroy(clock);
            }
        }
    }
}
