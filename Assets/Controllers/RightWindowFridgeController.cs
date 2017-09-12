using UnityEngine;
using System.Collections;

public class RightWindowFridgeController : MonoBehaviour, InteractableObject {

    private bool opened = false;

    public void Activate() {
        if (!opened) {
            transform.GetComponent<Animator>().Play("Right opening", -1, 0f);
        }
        else {
            transform.GetComponent<Animator>().Play("Right closing", -1, 0f);
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

