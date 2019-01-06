using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{

    private const string SCREEN_TO_OPEN = "PlayScreen";

    public void LaunchPlayScreen()
    {
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}
