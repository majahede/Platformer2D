using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour

{
    public SceneLoader sceneLoader;

    public void NewGame()
    {
        sceneLoader.LoadNextScene();
    }

    public void ResumeGame()
    {
       // sceneLoader.LoadNextScene();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
