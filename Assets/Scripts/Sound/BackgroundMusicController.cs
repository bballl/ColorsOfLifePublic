using Assets.Scripts.Locations;
using Assets.Scripts.Mafias;
using Assets.Scripts.Pictures;
using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class BackgroundMusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource backMusicAudioSource;
        [SerializeField] private AudioSource locationAudioSource;
        
        [SerializeField] private AudioClip homeClip;
        [SerializeField] private AudioClip cinemaClip;
        [SerializeField] private AudioClip circusClip;
        [SerializeField] private AudioClip playgroundClip;
        [SerializeField] private AudioClip parkClip;
        [SerializeField] private AudioClip petShopClip;
        [SerializeField] private AudioClip planetariumClip;
        [SerializeField] private AudioClip concertHallClip;
        [SerializeField] private AudioClip dockClip;
        [SerializeField] private AudioClip shotClip;
        [SerializeField] private AudioClip colourClip;
        [SerializeField] private AudioClip paintingClip;
        
        private float lowSound = 0.2f;
        private float standartSound = 1f;

        private void Awake()
        {
            LocationTriggerController.OnLocationInteractionStart += FadingMusic;
            LocationTriggerController.OnLocationInteractionStart += PlayLocationClip;
            LocationTriggerController.OnLocationInteractionFinish += StandartVolume;
            AIController.OnСharacterСontact += PlayShotSound;
            LocationTriggerController.OnColoring += PlayColoringSound;
            Picture.OnPaintingSoundPlay += PlayPaintingSound;
        }

        private void OnDestroy()
        {
            LocationTriggerController.OnLocationInteractionStart -= FadingMusic;
            LocationTriggerController.OnLocationInteractionStart -= PlayLocationClip;
            LocationTriggerController.OnLocationInteractionFinish -= StandartVolume;
            AIController.OnСharacterСontact -= PlayShotSound;
            LocationTriggerController.OnColoring -= PlayColoringSound;
            Picture.OnPaintingSoundPlay += PlayPaintingSound;
        }

        private void FadingMusic(LocationType locationType)
        {
            backMusicAudioSource.volume = lowSound;
        }

        private void StandartVolume(LocationType locationType)
        {
            backMusicAudioSource.volume = standartSound;
        }

        private void PlayShotSound()
        {
            locationAudioSource.PlayOneShot(shotClip);
        }

        private void PlayColoringSound(LocationType locationType)
        {
            locationAudioSource.PlayOneShot(colourClip);
        }

        private void PlayPaintingSound()
        {
            locationAudioSource.PlayOneShot(paintingClip);
        }

        private void PlayLocationClip(LocationType locationType)
        {
            switch(locationType)
            {
                case LocationType.Cinema:
                    locationAudioSource.PlayOneShot(cinemaClip);
                    break;

                case LocationType.Circus:
                    locationAudioSource.PlayOneShot(circusClip);
                    break;

                case LocationType.PlayArea:
                    locationAudioSource.PlayOneShot(playgroundClip);
                    break;

                case LocationType.Park:
                    locationAudioSource.PlayOneShot(parkClip);
                    break;

                case LocationType.PetShop:
                    locationAudioSource.PlayOneShot(petShopClip);
                    break;

                case LocationType.Planetarium:
                    locationAudioSource.PlayOneShot(planetariumClip);
                    break;

                case LocationType.ConcertHall:
                    locationAudioSource.PlayOneShot(concertHallClip);
                    break;

                case LocationType.Dock:
                    locationAudioSource.PlayOneShot(dockClip);
                    break;
            }
        }


    }
}
