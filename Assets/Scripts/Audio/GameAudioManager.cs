using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioManager : AudioManager
{

    public static GameAudioManager Instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public override void Awake()
    {
        base.Awake();

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        Play("Theme");
    }

}
