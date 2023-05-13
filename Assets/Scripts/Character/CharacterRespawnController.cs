using Assets.Scripts.Mafias;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
    public class CharacterRespawnController : MonoBehaviour 
    {
        public static event Action<bool> OnCharacterStop;
        public static event Action<string> OnJournalMessge;

        [SerializeField] private Transform characterTransform;
        [SerializeField] private Transform characterRespawnPoint;
        [SerializeField] private Image darkScreenImage;

        private string text = "Мафиози подстрелили меня... Теперь не только грустно, но и больно. " +
            "Нужно двигаться дальше, скрепя сердцем...";
        
        private void Awake()
        {
            darkScreenImage.gameObject.SetActive(false);
            AIController.OnСharacterСontact += DarkScreen;
        }

        private void OnDestroy()
        {
            AIController.OnСharacterСontact -= DarkScreen;
        }

        private void Respawn()
        {
            characterTransform.position = characterRespawnPoint.position;
        }

        private void DarkScreen()
        {
            OnCharacterStop.Invoke(true);
            darkScreenImage.gameObject.SetActive(true);
            
            float duration = 3f;

            var sequence = DOTween.Sequence();

            sequence.Append(darkScreenImage.DOFade(1, duration))
                .AppendCallback(() => Respawn())
                .Append(darkScreenImage.DOFade(0, duration))
                .AppendCallback(() => OnCharacterStop.Invoke(false))
                .AppendCallback(() => OnJournalMessge(text))
                .AppendCallback(() => darkScreenImage.gameObject.SetActive(false))
                .SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }
    }
}
