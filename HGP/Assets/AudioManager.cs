using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "ClothingStore")
        {
            Play("Clothing Store Theme");
            Play("Clothing Store Ambience");
        }
        else if(scene.name == "Chris_Main_Menu")
        {
            Play("Main Menu Theme");
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        //Footsteps
        if (s.name == "Player_Footstep" && !s.source.isPlaying)
        {
            s.volume = UnityEngine.Random.Range(.7f, 1f);
            s.pitch = UnityEngine.Random.Range(.8f, 1.2f);
            s.source.Play();
            Debug.Log("Playing: " + name + ".");
        }
        
        s.source.Play();
        Debug.Log("Playing: " + name + ".");
        
       
        


    }

}
