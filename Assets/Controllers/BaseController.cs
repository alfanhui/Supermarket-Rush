using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour{
    public PlayerController pc;
    public InteractionController ic;
    public KeyboardInput ki;
    public ObjectController oc;
    public TrolleyController tc;
    public GameController gc;

    public void InstantiateSingletons(){
        Instantiate(pc);
        Instantiate(ic);
        Instantiate(ki);
        Instantiate(oc);
        Instantiate(tc);
        Instantiate(gc);
    }
	
}
