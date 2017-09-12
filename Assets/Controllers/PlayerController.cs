using UnityEngine;
using System.Collections;

public class PlayerController : Singleton<PlayerController> {

    public Transform player;
    public PlayerModel pm;
    private CharacterController cc; //This is a component NOT an actual controller!
    private KeyboardInput ki;

    void Start() {
        ki = KeyboardInput.Instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pm = GameObject.FindWithTag("Model").GetComponent<PlayerModel>();
        cc = player.GetComponent<CharacterController>();
    }

    //Get input
    public void InputSpeed() {
        ki.LookHorizontal += pm.HorizontalSpeed * ki.LookHorizontalInput;
        pm.LookCharacterHorizontal = pm.HorizontalSpeed * ki.LookHorizontalInput;
        ki.LookVertical += pm.VerticalSpeed * ki.LookVerticalInput;
    }

    public void JumpCheck() {
        if (cc.isGrounded) {
            pm.VSpeed = -1;
            if (ki.KeyPress_Space && (int)pm.Holding != 1) {
                pm.VSpeed = pm.JumpSpeed;
            }
        }
    }

    public void CrouchCheck() {
        //Crouch has to happen after movement, since its connected to how high camera is after movement.
        //Crouch
        var headPosition = player.position;
        if (ki.KeyPress_Ctrl) {
            headPosition.y += 0.12f;
        }
        else {
            headPosition.y += 0.52f;
        }
        Camera.main.transform.position = headPosition;
    }


    public void SetMouseRotate() {
        //Rotate character with camera
        Camera.main.transform.rotation = Quaternion.Euler(
            Mathf.Clamp(-ki.LookVertical, -pm.ClampVertical, pm.ClampVertical), //Stops overlooking vertically
            ki.LookHorizontal,
            0f);
        player.Rotate(0f, pm.LookCharacterHorizontal, 0f); //rotate character only on y axis cuz hes cardboard
        ki.LookVertical = Mathf.Clamp(ki.LookVertical, -pm.ClampVertical, pm.ClampVertical); //Stops over scrolling vertically

    }

    public void SetMovement() {
        //Do movement
        var movement = player.TransformDirection(new Vector3(-ki.MoveVertical, 0f, ki.MoveHorizontal));
        movement *= pm.Speed;
        
        pm.VSpeed -= pm.Gravity * (Time.deltaTime / 2f);
        movement.y = pm.VSpeed;
        //http://answers.unity3d.com/questions/578443/jumping-with-character-controller.html

        cc.Move((movement) * Time.deltaTime);
        //https://docs.unity3d.com/ScriptReference/CharacterController.Move.html 
        //to get the basic understanding of Character Controller as before I was moving by velocity on the player's rigidedbody, 
        //but the character did not react to objects. (The player went throw them)
    }

    //Stops player from leaving the level
    public void CheckBoundary() {
        player.position = Vector3.Lerp(
            player.position,
            new Vector3(
                Mathf.Clamp(player.position.x, 0, 60),
                Mathf.Clamp(player.position.y, .25f, 1f),
                Mathf.Clamp(player.position.z, 0, 80)),
            Time.deltaTime * 20f);
    }
}
