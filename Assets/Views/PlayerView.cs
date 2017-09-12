using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour {

    private PlayerController pc;

    // Use this for initialization
	void Awake () {
        pc = PlayerController.Instance;
        //Camera.main.transform.rotation = Quaternion.Euler(0f, 47.853f, 0f);
        //pc.player.rotation = Quaternion.Euler(0f, 90, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        pc.InputSpeed();
        pc.JumpCheck();
        pc.SetMouseRotate();
        pc.SetMovement();
        pc.CrouchCheck();
        pc.CheckBoundary();
	}
}
