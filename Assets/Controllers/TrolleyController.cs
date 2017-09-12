using UnityEngine;
using System.Collections;

public class TrolleyController : Singleton<TrolleyController>{

    
    private PlayerController pc;
    private InteractionController ic;
    private KeyboardInput ki;

    Vector3 movement;

    void Start() {
        pc = PlayerController.Instance;
        ic = InteractionController.Instance;
        ki = KeyboardInput.Instance;
    }


    public void Move() {

    }
    public void Move2() {
              /*
        pc.pm.ItemHolding.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(
            pc.pm.ItemHolding.transform.position,
            ic.im.HeadPosition,
            Time.deltaTime * 40f
            ));
        */

        //Physics time!
        var movement = pc.player.TransformDirection(new Vector3(-ki.MoveVertical * 2.2f, 0f, ki.MoveHorizontal * 1.3f + (pc.pm.LookCharacterHorizontal/3f)));
        //movement = movement.normalized;
       
        //http://answers.unity3d.com/questions/578443/jumping-with-character-controller.html
        pc.pm.ItemHolding.GetComponent<Rigidbody>().AddForce((movement) * 6f, ForceMode.Impulse);

    }

    public void MoveRotate() {  
        /*
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, pc.pm.LookCharacterHorizontal, 0f) * Time.deltaTime * 40f); //35.8f
        pc.pm.ItemHolding.GetComponent<Rigidbody>().MoveRotation(pc.pm.ItemHolding.GetComponent<Rigidbody>().rotation * deltaRotation);
         * */

        //Physics time!
        var rotation = new Vector3(0f, pc.pm.LookCharacterHorizontal, 0f);
        pc.pm.ItemHolding.GetComponent<Rigidbody>().AddTorque(rotation * 8.2f);
    }
    

    public void AdjustSpeed() {
        if (pc.pm.ItemHolding.GetComponent<TrolleyModel>().Holding) {
            pc.pm.Speed *= 2f;
        } else {
            pc.pm.Speed = 4f;
        }
    }

    public void Activate() {
        if (ic.im.HitInfo.collider.tag == "TrolleyHandle") {
            pc.pm.ItemHolding.GetComponent<TrolleyModel>().Holding = true;

         //   pc.pm.ItemHolding.GetComponent<Rigidbody>().isKinematic = false;
            AdjustSpeed();
            //Rotate before moving! Idealy you'd want the player to move over to the object, and not the other way around.
            //pc.pm.ItemHolding.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
            //pc.pm.ItemHolding.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f));
            //trolley.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void Deactivate() {
        //Debug.Log("Throwing trolley");
        pc.pm.ItemHolding.GetComponent<TrolleyModel>().Holding = false;
      //  pc.pm.ItemHolding.GetComponent<Rigidbody>().isKinematic = true;
        //trolley.GetComponent<Rigidbody>().isKinematic = false;
        pc.pm.ItemHolding.GetComponent<Rigidbody>().velocity = pc.pm.ItemHolding.GetComponent<Rigidbody>().velocity.normalized * 6f;
        AdjustSpeed();
    }
   
}
