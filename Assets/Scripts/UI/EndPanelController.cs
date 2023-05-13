using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Pictures;

namespace Assets.Scripts.UI
{    public class EndPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject endPanel;
        [SerializeField] private Button menuButton;

        private void Start()
        {
            endPanel.SetActive(false);
            Picture.OnPictureFinished += StartEnd;
            menuButton.onClick.AddListener(ExitToMainMenu);
        }

        private void OnDestroy()
        {
            Picture.OnPictureFinished -= StartEnd;
            menuButton.onClick.RemoveListener(ExitToMainMenu);
        }

        private void StartEnd()
        {
            endPanel.SetActive(true);
        }

        private void ExitToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}

