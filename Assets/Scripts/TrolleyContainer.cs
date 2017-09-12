using UnityEngine;
using System.Collections;

public class TrolleyContainer : MonoBehaviour {

    private PlayerController pc;

    void Start() {
        pc = PlayerController.Instance;
    }
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent("ObjectModel") && pc.pm.Holding != PlayerModel.holding.carrying) {
            other.GetComponent<ObjectModel>().PreviousParent = other.transform.parent;
            other.transform.parent = this.transform.parent;
            other.transform.GetComponent<Rigidbody>().useGravity = false;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.GetComponent("ObjectModel") && other.transform.parent == this.transform.parent) {
            other.transform.parent = other.transform.GetComponent<ObjectModel>().PreviousParent;
            other.transform.GetComponent<Rigidbody>().useGravity = true;
            other.transform.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}
