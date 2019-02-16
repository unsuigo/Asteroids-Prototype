using System;
using UnityEngine;
using SingletonT;


public class AudioManager : SingletonT<AudioManager>
{

    public Sound[] sounds;

    //Singleton will avoid second audioManager if we will change the scene
    


    void Start()
    {
       
        // if will reload scene
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
        
        PlayClip("BackGround");
    }


    public void PlayClip(string name)
    {
       Sound s =  Array.Find(sounds, sound => sound.name == name);

        //check if AudioClip exist
        if (s == null)
            return;

        s.source.Play();
        Debug.Log("Clip Playing");
    }

    public void StopClip(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    
}
