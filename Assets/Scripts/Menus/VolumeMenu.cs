using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    /// <summary>
    /// Sets volume.
    /// </summary>
    /// <param name="volume">The volume.</param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
