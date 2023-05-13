using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu
{
    public class ButtonMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
    {
        public static event Action OnMouseEnter;
        public static event Action OnButtonClicked;

        [SerializeField] private GameObject frame;

        private void Awake()
        {
            frame?.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            frame?.SetActive(true);
            OnMouseEnter.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            frame?.SetActive(false);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonClicked.Invoke();
        }
    }
}
