using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    /**
     * Awake is called when the script instance is being loaded.
     */
    public virtual void Awake()
    {
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }
    }

    /**
     * Plays a specific sound.
     */
    public void Play(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }
}
