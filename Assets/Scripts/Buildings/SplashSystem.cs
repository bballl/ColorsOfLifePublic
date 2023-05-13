using UnityEngine;
using Assets.Scripts.Locations;

namespace Assets.Scripts.Buildings
{
    class SplashSystem : MonoBehaviour
    {
        [SerializeField] private LocationType locationType;
        private ParticleSystem[] particles;

        public LocationType LocationType => locationType;

        private void Start()
        {
            particles = GetComponentsInChildren<ParticleSystem>();

            LocationTriggerController.OnColoring += Painting;

            foreach (ParticleSystem particle in particles)
            {
                particle.Stop();
            }
        }
        private void OnDestroy()
        {
            LocationTriggerController.OnColoring -= Painting;
        }

        private void Painting(LocationType loctype)
        {
            foreach (ParticleSystem particle in particles)
            {
                if (locationType == loctype)
                {
                    particle.Play();
                    var anim = particle.GetComponent<Animator>();
                    anim.enabled = true;
                    anim.SetBool("isPainting", true);
                }
            }
        }
    }
}
