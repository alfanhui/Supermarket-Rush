using UnityEngine;
using System.Collections;

public class ObjectController : Singleton<ObjectController> {

    private KeyboardInput ki;
    private PlayerController pc;
    private InteractionController ic;

    void Start() {
        ki = KeyboardInput.Instance;
        pc = PlayerController.Instance;
        ic = InteractionController.Instance;
    }

    public void Move() {
        pc.pm.ItemHolding.GetComponent<ObjectModel>().LastLocation = pc.pm.ItemHolding.position;
        pc.pm.ItemHolding.position = Vector3.Lerp(
            pc.pm.ItemHolding.position,
            ic.im.HeadPosition + ic.im.GazeDirection * pc.pm.ItemHolding.GetComponent<ObjectModel>().HoldDistance, 
            Time.deltaTime * ic.im.Smooth
            );
        //To find smooth move transitions https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

        //Boundaries (Stops being able to carry into the floor mainly)
        pc.pm.ItemHolding.position = new Vector3(
               Mathf.Clamp(pc.pm.ItemHolding.position.x, 0, 60),
               Mathf.Clamp(pc.pm.ItemHolding.position.y, .25f, 20f),
               Mathf.Clamp(pc.pm.ItemHolding.position.z, 0, 80));
        
    }

    public void Activate() {
        pc.pm.ItemHolding.GetComponent<ObjectModel>().Holding = true;
        pc.pm.ItemHolding.GetComponent<Rigidbody>().useGravity = false;

    }

    public void Deactivate() {

        pc.pm.ItemHolding.GetComponent<ObjectModel>().Holding = false;
        pc.pm.ItemHolding.GetComponent<Rigidbody>().isKinematic = false;
        pc.pm.ItemHolding.GetComponent<Rigidbody>().useGravity = true;
        //Check if droppping or throwing.
        if (ki.MousePress_0) {
            //Debug.Log("Thowing");
            Vector3 direction = (pc.pm.ItemHolding.position - pc.pm.ItemHolding.GetComponent<ObjectModel>().LastLocation).normalized;
            //To find direction between 2 points in time http://answers.unity3d.com/questions/697830/how-to-calculate-direction-between-2-objects.html
            pc.pm.ItemHolding.GetComponent<Rigidbody>().AddForce(direction * 4f, ForceMode.Impulse);
            
        }
    
    }



}
