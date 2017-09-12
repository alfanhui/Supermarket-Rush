using UnityEngine;
using System.Collections;

public class PlayerModel: MonoBehaviour {

    //Mouse
    [Header("Mouse")]
    private float horizontalSpeed = 3f;
    private float verticalSpeed = 2f;

    //Clamps
    private int clampHorizontal = 80;
    private int clampVertical = 50;

    //Speed
    [Header("Speed")]
    private float speed = 4f;
    private float jumpSpeed = 2.5f;
    private float vSpeed;
    private float gravity = 20F;

    //Checks
    public enum holding { nothing, carrying, acting};

    private Transform itemHolding;

    //CharacterLook
    private float lookCharacterHorizontal;

    public float HorizontalSpeed {
        get { return horizontalSpeed;}
        set { horizontalSpeed = value; }
    }

    public float VerticalSpeed {
        get { return verticalSpeed;}
        set { verticalSpeed = value;}
    }

    public int ClampHorizontal {
        get { return clampHorizontal; }
    }

    public int ClampVertical {
        get { return clampVertical; }
    }

    public float Speed {
        get { return speed;}
        set { speed = value;}
    }
    public float JumpSpeed {
        get { return jumpSpeed; }
    }

    public float VSpeed {
        get { return vSpeed; }
        set { vSpeed = value; }
    }

    public float Gravity {
        get { return gravity; }
    }


    public float LookCharacterHorizontal {
        get { return lookCharacterHorizontal; }
        set { lookCharacterHorizontal = value; }
    }

    public holding Holding {
        get;
        set;
    }

    public Transform ItemHolding {
        get { return itemHolding; }
        set { itemHolding = value; }
    }

}
