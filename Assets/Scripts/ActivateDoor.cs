using UnityEngine;
using System.Collections;

public class ActivateDoor : MonoBehaviour {

    private Transform leftDoor;
    private Transform rightDoor;

    void Start() {
        leftDoor = transform.FindChild("DoorLeft");
        rightDoor = transform.FindChild("DoorRight");
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (leftDoor.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash("OpenLeft")) {
                leftDoor.GetComponent<Animator>().Play("OpeningLeft", -1, 0f);
                rightDoor.GetComponent<Animator>().Play("OpeningRight", -1, 0f);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            if (leftDoor.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash("CloseLeft")) {
                leftDoor.GetComponent<Animator>().Play("ClosingLeft", -1, 0f);
                rightDoor.GetComponent<Animator>().Play("ClosingRight", -1, 0f);
            }
        }
    }
}
