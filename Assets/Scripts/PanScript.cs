using UnityEngine;
using System.Collections;

public class PanScript : MonoBehaviour {

    public BaseView bv;

    public void AfterAnimation() {
        bv.StartGame();
    }
}
