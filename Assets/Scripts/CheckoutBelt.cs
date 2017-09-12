using UnityEngine;
using System.Collections;

public class CheckoutBelt : MonoBehaviour {

    private float Speed = 0.5f;
    private Collider other;
    private float smooth =  4f;
    private int counter = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        ToggleRoll();
	}

    void OnTriggerStay(Collider other) {
        this.other = other;
        //other.transform.position = Vector3.Lerp(other.transform.position, other.transform.position - Vector3.forward* 10f, Time.deltaTime * smooth);
        other.transform.position += transform.forward * (Speed*2.5f) * Time.deltaTime;
        //other.transform.GetComponent<Rigidbody>().AddForce(other.transform.position-Vector3.forward * 10f);
        //InvokeRepeating("MoveBelt", 0f, 0.01f);
    }



    public void ToggleRoll() {
        if (IsInvoking("Roll"))
            CancelInvoke("Roll");
        else
            InvokeRepeating("Roll", 0f, 0.06f);
    }

    private void Roll() {
        GetComponent<Renderer>().material.mainTextureOffset = (new Vector2(-(Time.time * Speed), 0));
        
    }

    public void MoveBelt() {
        if (counter == 20)
            CancelInvoke("MoveBelt");
        other.transform.position = Vector3.Lerp(other.transform.position, other.transform.position - Vector3.forward /2f, Time.deltaTime * smooth);

    }
}
