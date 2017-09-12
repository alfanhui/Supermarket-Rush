using UnityEngine;
using System.Collections;

public class InteractionView : MonoBehaviour {

    private PlayerController pc;
    private InteractionController ic;
    private TrolleyController tc;

    void Awake() {
        
    }

	// Use this for initialization
	void Start () {
        pc = PlayerController.Instance;
        ic = InteractionController.Instance;
        tc = TrolleyController.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (pc.pm.Holding == PlayerModel.holding.carrying) { //Move any item that your holding
            pc.pm.ItemHolding.GetComponent<InteractableObject>().Move();
        }
        ic.UpdatePositions();
        ic.RaycastHit();
        ic.UpdateCursor();
	}

    void FixedUpdate() {
        if (pc.pm.Holding == PlayerModel.holding.carrying) 
            if(pc.pm.ItemHolding.GetComponent("TrolleyModel")){
                tc.Move2();
                tc.MoveRotate();
            }
        
    }
}
