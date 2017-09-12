using UnityEngine;
using System.Collections;

public class NearCheckout : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            transform.GetChild(0).GetComponent<CheckoutBelt>().ToggleRoll();
        }
    }

}
