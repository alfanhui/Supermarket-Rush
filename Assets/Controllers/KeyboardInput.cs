using UnityEngine;
using System.Collections;

public class KeyboardInput : Singleton<KeyboardInput> {

    //Keyboard
    private float moveHorizontal;
    private float moveVertical;

    //Mouse
    private float lookHorizontal;
    private float lookVertical;
    private float lookHorizontalInput;
    private float lookVerticalInput;

    //KeyPress
    private bool keyPress_Space;
    private bool keyPress_E;
    private bool keyPress_Ctrl;
    private bool keyPress_Enter;
    private bool keyPress_Esc;
    private bool mousePress_0;
    private bool mousePress_1;
    private bool mousePress_2;

    /*
    void Awake() {
        //Reset Values
        moveHorizontal = 0f;
        moveVertical = 0f;
        lookHorizontal = 0f;
        lookVertical = 0f;
        lookHorizontalInput = 0f;
        lookVerticalInput = 0f;
        keyPress_Space = false;
        keyPress_E = false;
        keyPress_Ctrl = false;
        keyPress_Enter = false;
        mousePress_0 = false;
        mousePress_1 = false;
        mousePress_2 = false;
    }
     * */
	
	// Update is called once per frame
	void Update () {
        //Get Keyboard
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        keyPress_E = Input.GetButtonDown("Action");
        keyPress_Space = Input.GetButtonDown("Jump");
        keyPress_Ctrl = Input.GetButton("Crouch");
        keyPress_Enter = Input.GetButtonDown("Submit");
        keyPress_Esc = Input.GetButtonDown("Cancel");
        
        //Get Mouse
        mousePress_0 = Input.GetButtonDown("PovInteract");
        mousePress_1 = Input.GetButtonDown("NegInteract");
        mousePress_2 = Input.GetButtonDown("Mouse ScrollWheel");

        if (Time.timeScale != 0) {
            lookHorizontalInput = Input.GetAxis("Mouse X");
            lookVerticalInput = Input.GetAxis("Mouse Y");
        } else { //for pause
              lookHorizontalInput = 0;
              lookVerticalInput = 0;
        }        
	}
    
    //Get methods for keyboard
    public float MoveHorizontal {
        get { return moveHorizontal;}
    }

    public float MoveVertical {
        get { return moveVertical;}
    }

    public bool KeyPress_E {
        get { return keyPress_E; }
    }

    public bool KeyPress_Space {
        get { return keyPress_Space; }
    }
    
    public bool KeyPress_Ctrl {
        get { return keyPress_Ctrl; }
    }

    public bool KeyPress_Enter {
        get { return keyPress_Enter; }
    }

    public bool KeyPress_Esc {
        get { return keyPress_Esc; }
    }


    public float LookHorizontal {
        get { return lookHorizontal; }
        set { lookHorizontal = value; }
    }

    public float LookVertical {
        get { return lookVertical; }
        set { lookVertical = value; }
    }

    //Get methods for mouse
    public float LookHorizontalInput {
        get { return lookHorizontalInput; }
    }

    public float LookVerticalInput {
        get { return lookVerticalInput; }
    }

    public bool MousePress_0 {
        get { return mousePress_0;}
    }

    public bool MousePress_1 {
        get { return mousePress_1; }
    }

    public bool MousePress_2 {
        get { return mousePress_2; }
    }
}
