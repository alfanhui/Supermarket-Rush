using UnityEngine;
using System.Collections;

public class InteractionController : Singleton<InteractionController> {

     public InteractionModel im;
     private RaycastHit hitInfo;
     private PlayerController pc;
     private KeyboardInput ki;

     void Start() {
         pc = PlayerController.Instance;
         ki = KeyboardInput.Instance;
         im = GameObject.FindWithTag("Model").GetComponent<InteractionModel>();
     }

     public void UpdatePositions() {
        im.HeadPosition = Camera.main.transform.position;
        im.GazeDirection = Camera.main.transform.forward;
     }

     public void RaycastHit(){
         if (Physics.Raycast(im.HeadPosition, im.GazeDirection, out hitInfo, im.MaxDistance)) {
             im.HitInfo = hitInfo;
             switch ((int)pc.pm.Holding) {
                 case 0: //nothing
                     CursorChange(0);
                     if (im.HitInfo.transform.GetComponent("InteractableObject") || im.HitInfo.collider.GetComponent("InteractableObject"))
                        CursorChange(1);
                     //Check if action is pressed
                     if (ki.MousePress_0) {
                         //Debug.Log("Button pressed");
                         //Debug.Log(im.HitInfo.transform.name);
                         //Debug.Log(im.HitInfo.collider.name);
                         if (im.HitInfo.transform.GetComponent("InteractableObject")) {
                             CursorChange(2);
                             pc.pm.ItemHolding = im.HitInfo.transform.transform; //added collider
                             pc.pm.Holding = PlayerModel.holding.carrying;
                             im.HitInfo.transform.GetComponent<InteractableObject>().Activate(); //changed transform to collider
                         }
                         else if (im.HitInfo.collider.GetComponent("InteractableObject")) {
                             CursorChange(2);
                             pc.pm.ItemHolding = im.HitInfo.collider.transform; //added collider
                             pc.pm.Holding = PlayerModel.holding.carrying;
                             im.HitInfo.collider.GetComponent<InteractableObject>().Activate(); //changed transform to collider
                         }
                     }
                     break;
                 case 1:
                     //Check if they want to drop or throw
                     if (ki.MousePress_1) {
                         CursorChange(3);
                         pc.pm.ItemHolding.GetComponent<InteractableObject>().Deactivate();
                         pc.pm.ItemHolding = null;
                         pc.pm.Holding = PlayerModel.holding.nothing;
                         CursorChange(0);
                     }
                     else if (ki.MousePress_0) {
                         CursorChange(4);
                         pc.pm.ItemHolding.GetComponent<InteractableObject>().Deactivate();
                         pc.pm.ItemHolding = null;
                         pc.pm.Holding = PlayerModel.holding.nothing;
                         CursorChange(0);
                     }
                     break;
                 default:
                     CursorChange(0);
                     break;

             }
         }
         else {
             switch ((int)pc.pm.Holding) {
                 case 0:
                     if(ki.KeyPress_E)
                         CursorChange(5);
                     else
                         if (im.ActiveHand != 5)
                             CursorChange(0);
                     break;
                 case 1: //carrying
                     //Check if they want to drop or throw
                     if (ki.MousePress_1) {
                         CursorChange(3);
                         pc.pm.ItemHolding.GetComponent<InteractableObject>().Deactivate();
                         pc.pm.ItemHolding = null;
                         pc.pm.Holding = PlayerModel.holding.nothing;
                         CursorChange(0);
                     }
                     else if (ki.MousePress_0) {
                         CursorChange(4);
                         pc.pm.ItemHolding.GetComponent<InteractableObject>().Deactivate();
                         pc.pm.ItemHolding = null;
                         pc.pm.Holding = PlayerModel.holding.nothing;
                         CursorChange(0);
                     }
                     break;
                 default:
                     CursorChange(0);
                     break;
             }
         }
     }

     public void UpdateCursor(){
         switch(im.ActiveHand){
             case 0: //Invisible
                //im.CursorObject.transform.position = Camera.main.transform.position + (Camera.main.transform.forward /2f); //about the distance away when you pick up object (looks better this way)
                //im.CursorObject.transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
                break;
             case 1: //open
                im.CursorObject.transform.position = hitInfo.point - (Camera.main.transform.forward / 10f);
                im.CursorObject.transform.LookAt(Camera.main.transform.position, hitInfo.normal * (Time.deltaTime / 2f)); //rotate with respect to camera's look  
                break;
             case 2:
             case 3:
             case 4:
             case 5: //Thumbs up
                im.CursorObject.transform.position = Camera.main.transform.position + (Camera.main.transform.forward /1.60f); //about the distance away when you pick up object (looks better this way)
                im.CursorObject.transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
                break;
             default:
                //Debug.Log("Cursor error");
                break;
         }
     }

     public void CursorChange(int activeHand) {
         if (activeHand != im.ActiveHand) { //Theres been a change!
             switch (activeHand) {
                 case 0:
                     //Debug.Log("0");
                     if (im.cursorObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash("ThumbHand")) {
                         im.cursorObject.GetComponent<Animator>().Play("InvisibleHand", -1, 0f);
                         im.ActiveHand = activeHand;
                     }
                     break;
                 case 1:
                     //Debug.Log("1");
                     im.cursorObject.GetComponent<Animator>().Play("OpenHand", -1, 0f);
                     im.ActiveHand = activeHand;
                     break;
                 case 2:
                     //Debug.Log("2");
                     im.cursorObject.GetComponent<Animator>().Play("CloseHand", -1, 0f);
                     im.ActiveHand = activeHand;
                     break;
                 case 3:
                     im.cursorObject.GetComponent<Animator>().Play("ThrowHand", -1, 0f);
                     im.ActiveHand = activeHand;
                     break;
                 case 4:
                     im.cursorObject.GetComponent<Animator>().Play("DropHand", -1, 0f);
                     im.ActiveHand = activeHand;
                     break;
                 case 5:
                     im.cursorObject.GetComponent<Animator>().Play("ThumbHand", -1, 0f);
                     im.ActiveHand = activeHand;
                     break;

             }
             
         }
      }

}
