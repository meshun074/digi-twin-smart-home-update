using UnityEngine;

[System.Serializable]
public class SoundClass 
{
    public string name;
    public AudioClip audioClip;
    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;
    public bool mute;
    public bool loop;
    [HideInInspector]
    public AudioSource source;

}
