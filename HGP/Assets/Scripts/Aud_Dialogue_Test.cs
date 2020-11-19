using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aud_Dialogue_Test : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource source;
    [SerializeField]
    AudioClip NPCSpeak;
    [SerializeField]
    AudioClip playerSpeak;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NPCDialogue()
    {
        source.clip = NPCSpeak;
        source.Play();
        Debug.Log("Played Npc Dialogue");
    }

    public void PlayerDialogue()
    {
        source.clip = playerSpeak;
        source.Play();
        Debug.Log("Playing Player speak");
    }
}
