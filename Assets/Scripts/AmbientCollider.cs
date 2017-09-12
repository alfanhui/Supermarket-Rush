using UnityEngine;
using System.Collections;

public class AmbientCollider : MonoBehaviour {

    bool toggle = false;
    public float changeRate = 0.004F;
    private GameObject sun;

    void Start() {
        sun = GameObject.FindGameObjectWithTag("Sun");
    }

    void OnTriggerEnter(Collider other){ //When object collides with this.gameObject's colider (*IsTriggered is true)
        if (other.tag == "Player") { //When the object is the Player object (*<ridigedbody>Iskinematic is true)
            if (IsInvoking("AmbeintChange")) { //If its already being invoked, cancel because the player has entered the boundary again.
                CancelInvoke("AmbeintChange"); //cancel existing invoke
                toggle = !toggle; //which the toggle 
            }
            InvokeRepeating("AmbeintChange", 0.5f, 0.07f); //Run Method 'AmbeintChange' after a 0.5f wait, and repeat that method every 0.1th of a second... FOREVER
        }
    }

    void AmbeintChange() {
        if (toggle) {//if true, then they are leaving the building
            //RenderSettings.ambientIntensity += changeRate; //increase by small amount
            sun.GetComponent<Light>().intensity += changeRate;
        }
        else {// else they are entering the building
            //RenderSettings.ambientIntensity -= changeRate;
            sun.GetComponent<Light>().intensity -= changeRate;
        }
        if (!toggle && sun.GetComponent<Light>().intensity <= 0.55f) { //If target has been reached then ..
                toggle = !toggle; //Switch toggle
                CancelInvoke("AmbeintChange"); //Cancel the invoke
                //RenderSettings.ambientIntensity = 0.05f; //Set the value to what you finally want it to be.
                sun.GetComponent<Light>().intensity = 0.55f;
            }
            else if (toggle && sun.GetComponent<Light>().intensity >= 0.81f) {
                toggle = !toggle;
                CancelInvoke("AmbeintChange");
                //RenderSettings.ambientIntensity = 0.43f;
                sun.GetComponent<Light>().intensity = 0.81f;
            }
    }


}
