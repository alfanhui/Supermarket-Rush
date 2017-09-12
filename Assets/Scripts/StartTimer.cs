using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour {

    private GameController gc;

    void Start() {
        gc = GameController.Instance;
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
            gc.EnteredBuilding();
    }
}
