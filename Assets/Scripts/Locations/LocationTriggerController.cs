using Assets.Scripts.Mafias;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Locations
{
    public class LocationTriggerController : MonoBehaviour
    {
        public static event Action<LocationTriggerController, string> OnCooperationStart;
        public static event Action OnCooperationFinish;
        public static event Action<string> OnQuestCompleted;
        public static event Action<float> OnGetBonus;
        public static event Action<LocationType> OnColoring;
        
        //события для приглушения основной музыки
        public static event Action<LocationType> OnLocationInteractionStart;
        public static event Action<LocationType> OnLocationInteractionFinish;

        [SerializeField] protected LocationSettings Settings;
        protected float Bonus;
        protected string MessageText; //текст для диалогового окна
        protected string FinishQuestText; //текст окончания квеста, попадает в дневник
        protected LocationType LocationName; //?

        private GameObject character;
        private bool isLocationActive;
        private float updateTime;
        private bool isColored;


        private void Awake()
        {
            character = GameObject.FindGameObjectWithTag("Player");
            isLocationActive = true;
            updateTime = Settings.UpdateTime;
            AIController.OnСharacterСontact += LoseColor;
        }
        private void OnDestroy()
        {
            AIController.OnСharacterСontact -= LoseColor;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && isLocationActive)
            {
                OnCooperationStart.Invoke(this, MessageText);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                OnCooperationFinish.Invoke();
            }
        }

        public void LocationInteractionStart()
        {
            character.SetActive(false);
            Invoke(nameof(LocationInteractionFinish), 5f);
            OnLocationInteractionStart.Invoke(LocationName);
        }

        public virtual void LocationInteractionFinish()
        {
            isLocationActive = false;
            Invoke(nameof(ActivateLocation), updateTime);

            if (isColored == false && GetRandomValue())
            {
                OnColoring?.Invoke(LocationName);
                isColored= true;
            }
            
            character.SetActive(true);
            
            OnLocationInteractionFinish.Invoke(LocationName);
            OnGetBonus.Invoke(Bonus);
            OnQuestCompleted.Invoke(FinishQuestText);
        }

        private void ActivateLocation()
        {
            isLocationActive = true;
        }

        private bool GetRandomValue()
        {
            var value = UnityEngine.Random.Range(1, 3);

            Debug.Log($"LocationTriggerController.GetRandomValue() = {value}");
            
            if (value == 1)
                return true;
            else
                return false;
        }

        private void LoseColor()
        {
            isColored = false;
        }
    }
}
