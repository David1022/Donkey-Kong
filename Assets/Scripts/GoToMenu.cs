using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour {

    private const string SCREEN_TO_OPEN = "StartScreen";

    public void LaunchMenuScreen()
    {
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}
