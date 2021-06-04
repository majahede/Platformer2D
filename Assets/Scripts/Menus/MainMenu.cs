using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour

{
    private SceneLoader sceneLoader;

    /**
     * Start is called before the first frame update.
     */
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /**
     * Starts a new game.
     */
    public void NewGame()
    {
        sceneLoader.LoadNextScene();
    }

    /**
     * Quits application.
     */
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            Application.Quit();
        #elif UNITY_WEBGL
            Application.OpenURL("https://play.unity.com/u/majhed-zt");
        #endif
    }
}
