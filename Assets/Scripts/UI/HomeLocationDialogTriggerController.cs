using Assets.Scripts.Locations;
using Assets.Scripts.Pictures;
using Assets.Scripts.Character;
using Assets.Scripts.Animals;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HomeLocationDialogTriggerController : MonoBehaviour
    {
        public static event Action OnCharacterCameHome;
        public static event Action OnCharacterPaintPicture;
        public static event Action<AnimalType> OnCharacterFeedAnimal;

        [Header("locationDialogPanel")]
        [SerializeField] private GameObject locationDialogPanel;
        //[SerializeField] private TMP_Text dialogText;
        [SerializeField] private Text dialogText;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;


        [Header("homePanel")]
        [SerializeField] private GameObject homePanel;
        //[SerializeField] private TMP_Text errorText;
        [SerializeField] private Text errorText;
        [SerializeField] private Button paintButton;
        [SerializeField] private Button feedCatButton;
        [SerializeField] private Button feedDogButton;
        [SerializeField] private Button exitButton;

        [Header("FeedController")]
        [SerializeField] private AnimalFeedController animalFeedController;

        private string startText = "Вы подошли к своему дому.\nВ нем все так напоминает об Эмили...\n\nВойдете?";
        private string errorColor = "Недостаточно красок.";
        private string errorFood = "Недостаточно еды.";
        private string errorCatFood = "Кот сыт.";
        private string errorDogFood = "Собата сытa.";
        private string errorCat = "У вас нет кота.";
        private string errorDog = "У вас нет собаки.";

        private void Awake()
        {
            HomeLocationTriggerController.OnHomeCooperationStart += OpenPanel;
            Picture.NotEnoughtColors += NotEnoughtColor;


            locationDialogPanel.SetActive(false);
            homePanel.SetActive(false);

            okButton.onClick.AddListener(HomeInteractionActivate); //(OnCharacterCameHome.Invoke);
            cancelButton.onClick.AddListener(ClosePanel);
            paintButton.onClick.AddListener(PaintPicture);
            feedCatButton.onClick.AddListener(FeedCat);
            feedDogButton.onClick.AddListener(FeedDog);
            exitButton.onClick.AddListener(ExitHome);     
        }

        private void OnDestroy()
        {
            HomeLocationTriggerController.OnHomeCooperationStart -= OpenPanel;
            Picture.NotEnoughtColors -= NotEnoughtColor;

            okButton.onClick.RemoveListener(HomeInteractionActivate); //(OnCharacterCameHome.Invoke);
            cancelButton.onClick.RemoveListener(ClosePanel);
            paintButton.onClick.RemoveListener(PaintPicture);
            feedCatButton.onClick.RemoveListener(FeedCat);
            feedDogButton.onClick.RemoveListener(FeedDog);
            exitButton.onClick.RemoveListener(ExitHome);
        }

        private void OpenPanel()
        {
            Time.timeScale = 0f;
            locationDialogPanel.SetActive(true);

            dialogText.text = startText;
        }

        private void ClosePanel()
        {
            Time.timeScale = 1f;
            locationDialogPanel.SetActive(false);
        }

        private void PaintPicture()
        {
            OnCharacterPaintPicture?.Invoke();
        }
        private void NotEnoughtColor()
        {
            errorText.text = errorColor;
        }

        private void FeedCat()
        {
            if (animalFeedController.IsCatHome == true)
            {
                if (animalFeedController.IsFoodEnough == true)
                {
                    if (animalFeedController.IsCatBellyful == false)
                        OnCharacterFeedAnimal?.Invoke(AnimalType.Cat);
                    else
                        errorText.text = errorCatFood;
                }
                else
                    errorText.text = errorFood;
            }
            else
                errorText.text = errorCat;            
        }

        private void FeedDog()
        {
            if (animalFeedController.IsDogHome == true)
            {
                if (animalFeedController.IsFoodEnough == true)
                {
                    if (animalFeedController.IsDogBellyful == false)
                        OnCharacterFeedAnimal?.Invoke(AnimalType.Dog);
                    else
                        errorText.text = errorDogFood;
                }
                else
                    errorText.text = errorFood;
            }
            else
                errorText.text = errorDog;                
        }

        private void ExitHome()
        {
            Time.timeScale = 1f;
            homePanel.SetActive(false);
        }

        private void HomeInteractionActivate()
        {
            locationDialogPanel.SetActive(false);
            homePanel.SetActive(true);
            errorText.text = "";
        }

    }
}
