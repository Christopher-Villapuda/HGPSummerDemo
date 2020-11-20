using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHidingCutscene : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject introAnimVideoController;
    //public var VideoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        //turns 
        introAnimVideoController.SetActive(true);
        //turns off player
        thePlayer.SetActive(false);

        //idk if this works i've never used C# in unity before, but this is supposed to play the video once the collider is triggered
        //videoPlayer.Play();
        //this basically ends the cutscene and gives the player control again
        StartCoroutine(FinishCut());

    }

    IEnumerator FinishCut()
    {
        //feel free to change the seconds as needed, i set it to the same time as my animation
        yield return new WaitForSeconds(6);
        thePlayer.SetActive(true);
        //hidingVideoController.SetActive(false);

    }

    //video player code from the unity website
    //script code from Jimmy Vegas: https://www.youtube.com/watch?v=pru5sx_hqeE 
    //video player tutorial from Dapper Dino (excuse the hilariously cringey intro on that guy's vid lol): https://www.youtube.com/watch?v=OdVGyV3rTGs 
    //i have 

}
