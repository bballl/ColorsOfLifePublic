using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PausePanelController : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            pauseButton.onClick.AddListener(() => OpenPausePanel());
            continueButton.onClick.AddListener(ContinueGame);
            exitButton.onClick.AddListener(ExitToMainMenu);

            pausePanel.SetActive(false);
        }

        private void OpenPausePanel()
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }

        private void ContinueGame()
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }

        private void ExitToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
