using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour {

    AudioSource[] monstersteps;
    AudioSource step1;
    AudioSource step2;
    //AudioSource step3;
    //AudioSource step4;
    //AudioSource step5;
    //AudioSource step6;


    void Start () {
        monstersteps = GetComponents<AudioSource>();
        step1 = monstersteps[0];
        step2 = monstersteps[1];
       // step3 = monstersteps[2];
        //step4 = monstersteps[3];
        //step5 = monstersteps[4];
        //step6 = monstersteps[5];
    }
	
	
   public void playSounds() {
        step1.Play();
        step2.PlayDelayed(2);
      //  step3.Play();
       // step4.Play();
    }
}
