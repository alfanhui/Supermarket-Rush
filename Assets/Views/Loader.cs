using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    //public InteractionController ic;
    //public PlayerController pc;
    public GameObject kiPreFab;

	// Use this for initialization
    void Awake (){
            //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        /*
        if (InteractionController.Instance == null)
            //Instantiate gameManager prefab
            ic = new InteractionController();
            
         
        
            //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
            if (PlayerController.Instance == null)
                //Instantiate SoundManager prefab
                Instantiate(pc);
        */
         if (KeyboardInput.Instance == null)
                //Instantiate SoundManager prefab
                Instantiate(kiPreFab);
           
     }
}