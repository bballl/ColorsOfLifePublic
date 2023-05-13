using System;
using UnityEngine;

namespace Assets.Scripts.Locations
{
    public class HomeLocationTriggerController : MonoBehaviour
    {
        public static event Action OnHomeCooperationStart;
        public static event Action OnHomeCooperationFinish;
        public static event Action OnHomeInteractionStart;


        private GameObject character;

        private void Awake()
        {
            character = GameObject.FindGameObjectWithTag("Player");

            ///?
        }
        #region Trigger

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                OnHomeCooperationStart?.Invoke();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                OnHomeCooperationFinish?.Invoke();
            }
        }
        #endregion
        

        public void HomeInteractionStart()
        {
            character.SetActive(false);
        }

        public void LocationInteractionFinish()
        {


        }
    }
}
