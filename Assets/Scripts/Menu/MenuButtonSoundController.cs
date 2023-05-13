using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MenuButtonSoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip mouseEnterSound;
        [SerializeField] private AudioClip mouseClickSound;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            
            ButtonMouseInteraction.OnMouseEnter += PlayMouseEnterSound;
            ButtonMouseInteraction.OnButtonClicked += PlayClickSound;
        }

        private void OnDestroy()
        {
            ButtonMouseInteraction.OnMouseEnter -= PlayMouseEnterSound;
            ButtonMouseInteraction.OnButtonClicked -= PlayClickSound;
        }

        private void PlayMouseEnterSound()
        {
            audioSource.PlayOneShot(mouseEnterSound);
        }

        private void PlayClickSound()
        {
            audioSource.PlayOneShot(mouseClickSound);
        }
    }
}
