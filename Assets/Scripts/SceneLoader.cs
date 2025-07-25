using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load2ndScene()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    public void Load3rdScene()
    {
        SceneManager.LoadScene("ThirdLevel");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

}
