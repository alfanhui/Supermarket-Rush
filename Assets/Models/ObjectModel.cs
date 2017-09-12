using UnityEngine;
using System.Collections;

public class ObjectModel : MonoBehaviour, InteractableObject {

    private Vector3 lastLocation;
    private float holdDistance = 1.5f;
    private bool holding = false;
    public float price = 0.00f;
    public float specialPrice = 0.00f;
    private bool deactivated = false;
    private Transform previousParent; 
    private ObjectController oc;

    void Start() {
        oc = ObjectController.Instance;
    }

    public void Activate() {
        if (!deactivated) {
            if (this.transform.parent.GetComponent("TrolleyModel")) {
                this.transform.parent = previousParent;
                this.transform.GetComponent<Rigidbody>().isKinematic = false;
                this.transform.GetComponent<Rigidbody>().useGravity = false;
            }
            oc.Activate();
        }
    }

    public void Deactivate() {
        oc.Deactivate();
    }

    public void Move() {
        if(!deactivated)
            oc.Move();
    }


    public Vector3 LastLocation {
        get { return lastLocation; }
        set { lastLocation = value; }
    }

    public float HoldDistance {
        get { return holdDistance; }
    }

    public bool Holding {
        get { return holding; }
        set { holding = value; }
    }

    public bool Purchased {
        get { return deactivated; }
        set { deactivated= value; }
    }

    public Transform PreviousParent {
        get { return previousParent; }
        set { previousParent = value; }
    }

}
