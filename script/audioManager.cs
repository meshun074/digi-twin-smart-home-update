using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{
    public SoundClass[] sounds;
    void Awake()
    {
        foreach(SoundClass S in sounds)
        {
            S.source = gameObject.AddComponent<AudioSource>();
            S.source.clip = S.audioClip;
            S.source.volume = S.volume;
            S.source.pitch = S.pitch;
            S.source.mute = S.mute;
            S.source.loop = S.loop;
            S.source.spatialBlend = S.spatialBlend;
        }
    }
    public void playSound(string name)
    {
       SoundClass s= Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound name is not found for play");
            return;
        }
        s.source.Play();
    }
    public void stopSound(string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            Debug.Log("Sound name is not found for stop");
            return; }
        s.source.Stop();
    }
    public void pauseSound(string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound name is not found for pause");
            return;
        }
        s.source.Pause();
    }

    public void resumeSound(string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound name is not found for resume");
            return;
        }
        s.source.UnPause();
    }
    // Update is called once per frame


}
