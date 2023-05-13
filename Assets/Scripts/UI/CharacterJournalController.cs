using Assets.Scripts.Character;
using Assets.Scripts.Locations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    internal class CharacterJournalController : MonoBehaviour
    {
        [SerializeField] private Text topText;
        [SerializeField] private Text bottomText;
        [SerializeField] private ParticleSystem newEntryParticleSystem;

        

        private void Awake()
        {
            LocationTriggerController.OnQuestCompleted += NewEntry;
            CharacterRespawnController.OnJournalMessge += NewEntry;
            Assets.Scripts.Locations.MemoryTrigger.Mem += NewEntry;
            topText.text = "Я решил завести дневник.\nБуду здесь записывать что-нибудь, пока даже не знаю что...";
        }

        private void OnDestroy()
        {
            LocationTriggerController.OnQuestCompleted -= NewEntry;
        }

        private void NewEntry(string text)
        {
            newEntryParticleSystem.Play();
            bottomText.text = topText.text;
            topText.text = text;
        }
    }
}
