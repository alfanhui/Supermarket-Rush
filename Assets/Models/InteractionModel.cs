using UnityEngine;
using System.Collections;

public class InteractionModel : MonoBehaviour {

    //Raycasting information
    private RaycastHit hitInfo;
    private Vector3 headPosition, gazeDirection;
    private float distance = 1f;
    private float maxDistance = 2.2f;
    private float smooth = 4f;
    public GameObject cursorObject;
    private int activeHand = 0;


    public RaycastHit HitInfo {
        get { return hitInfo;}
        set { hitInfo = value; }
    }

    public Vector3 HeadPosition {
        get { return headPosition; }
        set { headPosition = value; }
    }
    
    public Vector3 GazeDirection {
        get { return gazeDirection; }
        set { gazeDirection = value; }
    }

    public float Distance {
        get { return distance; }
    }

    public float MaxDistance {
        get { return maxDistance; }
    }
   
    public float Smooth{
        get{return smooth;}
    }

    public int ActiveHand {
        get { return activeHand; }
        set { activeHand = value; }
    }

    public GameObject CursorObject {
        get { return cursorObject; }
        set { cursorObject = value; }
    }
}
