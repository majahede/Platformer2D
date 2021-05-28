using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour

{
    protected SceneLoader sceneLoader;

    public virtual void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void NewGame()
    {
        sceneLoader.LoadNextScene();
    }

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
