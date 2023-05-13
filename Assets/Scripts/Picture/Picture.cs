using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Character;
using Assets.Scripts.UI;

namespace Assets.Scripts.Pictures
{
    public class Picture : MonoBehaviour
    {
        public static event Action<float> OnPicturePainted;
        public static event Action NotEnoughtColors;
        public static event Action OnPictureFinished;
        public static event Action OnPaintingSoundPlay; //добавил Глеб

        [SerializeField] private PaintScaleController paintScaleController;
        [SerializeField] private Sprite[] pictures;
        [SerializeField] private PictureProperties pictureProperties;

        private Image image;
        private float indexImage;
        private float valueColor;
        private int fillingPercentage;

        private void Start()
        {
            image = GetComponent<Image>();
            SetProperties();

            HomeLocationDialogTriggerController.OnCharacterPaintPicture += PaintPicture;
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnPicturePainted?.Invoke(50);
            }
#endif
        }

        private void OnDestroy()
        {
            HomeLocationDialogTriggerController.OnCharacterPaintPicture -= PaintPicture;
        }

        private void SetProperties()
        {
            valueColor = pictureProperties.ValueColor;
            fillingPercentage = pictureProperties.FillingPercentage;
        }

        private void PaintPicture()
        {
            if (paintScaleController.PaintScaleValue < valueColor)
            {
                NotEnoughtColors?.Invoke();
                return;
            }

            if (indexImage < pictures.Length)
            {
                OnPicturePainted?.Invoke(-valueColor);

                //var paintScalePercentage = valueColor * 100 / paintScaleController.MaxPaintScaleValue;
                //var pictureScalePercentage = (pictures.Length - 1) * paintScalePercentage / 100;

                var pictureScalePercentage = fillingPercentage * (pictures.Length - 1) / 100;

                indexImage = indexImage + pictureScalePercentage;

                if (indexImage >= pictures.Length - 1)
                {
                    indexImage = pictures.Length - 1;
                    OnPictureFinished?.Invoke();
                }
                image.sprite = pictures[(int)indexImage];                
            }

            OnPaintingSoundPlay.Invoke();
        }

    }
}
