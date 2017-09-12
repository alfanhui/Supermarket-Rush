using UnityEngine;
using System.Collections;

public class TrolleyModel : MonoBehaviour, InteractableObject {

    private float speed = 1f;
    private bool holding = false;

    private TrolleyController tc;
    private Transform previousParent;



    void Start() {
        tc = TrolleyController.Instance;
    }

    public void Activate() {
        tc.Activate();
    }

    public void Deactivate() {
        tc.Deactivate();
    }

    public void Move() {
        tc.Move();
    }


    public float Speed {
        get { return speed; }
    }

    public bool Holding {
        get { return holding; }
        set { holding = value; }
    }



 
}
