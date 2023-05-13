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
            //TO DO: ���� ���� ����� ����� ����������� ����������, ���������� �������� �������� ������
        }
        public void OnGameContinue()
        {
            SceneManager.LoadScene(mainMenuIndex);
            Debug.Log("The scene call index is not specified. Button: ContinueGameButton");
            //TO DO: ���� ���� ����� ����� ����������� ����������, ���������� ��������� ����������
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
