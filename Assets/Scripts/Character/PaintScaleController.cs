using Assets.Scripts.Locations;
using Assets.Scripts.Pictures;
using Assets.Scripts.Animals;
using Assets.Scripts.Mafias;
using System;
using UnityEngine;

namespace Assets.Scripts.Character
{
    internal class PaintScaleController : MonoBehaviour
    {
        public static event Action<float, float> OnUpdatePaintScaleView;
        
        private float minValue = 0;
        private float maxValue = 100;
        private float currentValue;

        public float PaintScaleValue => currentValue; //?
        public float MaxPaintScaleValue => maxValue;

        private void Awake()
        {
            LocationTriggerController.OnGetBonus += UpdateScaleValue;
            Picture.OnPicturePainted += UpdateScaleValue;
            AnimalFeedController.OnGetBonus += UpdateScaleValue;
            AIController.OnСharacterСontact += LoseColor;
        }

        private void Start()
        {
            OnUpdatePaintScaleView.Invoke(currentValue, maxValue);
        }

        private void OnDestroy()
        {
            LocationTriggerController.OnGetBonus -= UpdateScaleValue;
            Picture.OnPicturePainted -= UpdateScaleValue;
            AnimalFeedController.OnGetBonus -= UpdateScaleValue;
            AIController.OnСharacterСontact -= LoseColor;
        }

        public void UpdateScaleValue(float value)
        {
            currentValue += value;
            if (currentValue > maxValue)
                currentValue = maxValue;

            OnUpdatePaintScaleView.Invoke(currentValue, maxValue);
            
            Debug.Log($"Шкала красок получила + {value} процентов");
            Debug.Log($"Текущее значение шкалы = {currentValue} процентов");
        }

        private void LoseColor()
        {
            currentValue = 0;
            OnUpdatePaintScaleView.Invoke(currentValue, maxValue);
            Debug.Log($"Вы потеряли все краски.");
        }
    }
}
