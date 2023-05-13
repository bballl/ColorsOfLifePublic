using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject aboutAuthorsPanel;
        [SerializeField] private GameObject controlPanel;

        [SerializeField] private Button prologButton;
        [SerializeField] private Button gameButton;
        [SerializeField] private Button aboutAuthorsButton;
        [SerializeField] private Button controlButton; 
        [SerializeField] private Button exitButton;
        [SerializeField] private Button backButton;

        private void Awake()
        {
            aboutAuthorsPanel.SetActive(false);
            controlPanel.SetActive(false);
            backButton.gameObject.SetActive(false);

            prologButton.onClick.AddListener(() => Invoke(nameof(LoadPrologScene), 0.2f));
            gameButton.onClick.AddListener(() => LoadGameScene());
            controlButton.onClick.AddListener(() => OpenControlPanel());
            aboutAuthorsButton.onClick.AddListener(() => OpenAboutAuthorsPanel());
            exitButton.onClick.AddListener(() => Exit());
            backButton.onClick.AddListener(() => BackToMainMenu());
        }

        private void OpenAboutAuthorsPanel()
        {
            mainMenuPanel.SetActive(false);
            controlPanel.SetActive(false);
            aboutAuthorsPanel.SetActive(true);
            backButton.gameObject.SetActive(true);
        }

        private void BackToMainMenu()
        {
            aboutAuthorsPanel.SetActive(false);
            controlPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            backButton.gameObject.SetActive(false);
        }

        private void OpenControlPanel()
        {
            mainMenuPanel.SetActive(false);
            aboutAuthorsPanel.SetActive(false);
            controlPanel.SetActive(true);
            backButton.gameObject.SetActive(true);
        }
        
        private void LoadPrologScene()
        {
            SceneManager.LoadScene("MainMenuPrologue");
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }

        private void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
