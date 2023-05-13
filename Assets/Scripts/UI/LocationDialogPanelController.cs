using Assets.Scripts.Locations;
using Assets.Scripts.Test;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LocationDialogPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject locationDialogPanel;
        //[SerializeField] private TMP_Text dialogText;
        [SerializeField] private Text dialogText;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;

        private LocationTriggerController currentLocation;

        private void Awake()
        {
            locationDialogPanel.SetActive(false);

            okButton.onClick.AddListener(LocationInteractionActivate);
            cancelButton.onClick.AddListener(ClosePanel);

            LocationTriggerController.OnCooperationStart += OpenPanel;
            LocationTriggerController.OnCooperationFinish += ClosePanel;
        }

        private void OnDestroy()
        {
            LocationTriggerController.OnCooperationStart -= OpenPanel;
            LocationTriggerController.OnCooperationFinish -= ClosePanel;
        }

        private void OpenPanel(LocationTriggerController location, string text)
        {
            Time.timeScale = 0f;
            locationDialogPanel.SetActive(true);

            currentLocation = location;
            dialogText.text = text;
        }

        private void ClosePanel()
        {
            Time.timeScale = 1f;
            locationDialogPanel.SetActive(false);
        }

        private void LocationInteractionActivate()
        {
            Time.timeScale = 1f;
            currentLocation.LocationInteractionStart();
        }

        


    }
}
