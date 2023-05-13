using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        private readonly int mainMenuIndex = 1;
        public void OnNewGameStart()
        {
            SceneManager.LoadScene(mainMenuIndex);
            Debug.Log("The scene call index is not specified. Button: NewGameButton");
            //TO DO: ≈сли игра будет иметь возможность сохранени€, необходимо добавить удаление данных
        }
        public void OnGameContinue()
        {
            SceneManager.LoadScene(mainMenuIndex);
            Debug.Log("The scene call index is not specified. Button: ContinueGameButton");
            //TO DO: ≈сли игра будет иметь возможность сохранени€, необходимо загружать сохранение
        }

        public void OnSettingCall()
        {
            SceneManager.LoadScene(mainMenuIndex);
            Debug.Log("The scene call index is not specified. Button: SettingsButton");
        }

        public void OnAuthorsCall()
        {
            SceneManager.LoadScene(mainMenuIndex);
            Debug.Log("The scene call index is not specified. Button: AuthorsButton");
        }

        public void OnApplicationQuit()
        {
            Application.Quit();
        }

        public void OnPrologue()
        {
            SceneManager.LoadScene("MainMenuPrologue");
        }
    }
}
