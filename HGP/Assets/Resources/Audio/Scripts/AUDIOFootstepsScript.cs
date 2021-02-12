using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIOFootstepsScript : MonoBehaviour
{
    

    

    public void FootSteps()
    {
       FindObjectOfType<AudioManager>().Play("Player_Footstep");
        
    }
}
