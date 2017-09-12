using UnityEngine;
using System.Collections;

public class CheckoutPurchase : MonoBehaviour {

    private float thrust = 20f;
    private GameController gc;
    private GameObject other;

    void Start() {
        gc = GameController.Instance;
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent("ObjectModel")) {
            this.other = other.gameObject;
            other.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, thrust));
            gc.UpdateScore(other.GetComponent<ObjectModel>().price);
            Invoke("DeactivateObject", 1f);
        }

                
    }


    void DeactivateObject() {
        this.other.GetComponent<ObjectModel>().Purchased = true;
        this.other.GetComponent<Rigidbody>().isKinematic = true;
    }
}
