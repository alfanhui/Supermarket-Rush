using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
    public GameObject Title1, Title2;

	// Use this for initialization
	void Start () {
        Title1.GetComponent<Animator>().Play("SuperMarket Opening", -1, 0f);
        Title2.GetComponent<Animator>().Play("Rush Opening", -1, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
