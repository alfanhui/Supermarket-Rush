using UnityEngine;
using System.Collections;

public class LeftWindowFridgeController : MonoBehaviour, InteractableObject {

    private bool opened = false;

    public void Activate() {
            Debug.Log("left window active");
            if (!opened) {
                Debug.Log("left window animation active");
                transform.GetComponent<Animator>().Play("Left opening", -1, 0f);
            }
            else {
                Debug.Log("left window animation deactive");
                transform.GetComponent<Animator>().Play("Left closing", -1, 0f);
            }
            opened = !opened;
            PlayerController.Instance.pm.ItemHolding = null;
            PlayerController.Instance.pm.Holding = PlayerModel.holding.nothing;
    }

    public void Deactivate() {
        return;
    }

    public void Move() {
        return;
    }
}

