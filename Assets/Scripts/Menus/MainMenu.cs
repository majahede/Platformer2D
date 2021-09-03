using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour

{
    protected SceneLoader sceneLoader;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public virtual void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /// <summary>
    /// Starts a new game.
    /// </summary>
    public void NewGame()
    {
        sceneLoader.LoadNextScene();
    }

    /// <summary>
    /// Quits application.
    /// </summary>
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
