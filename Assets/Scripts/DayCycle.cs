using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class DayCycle : MonoBehaviour {

    public float rotationSpeed = 40f;  //normal time runs 10 seconds per day.   

    private Material daySky;
    public Material nightSky;
    private float rotate;
    private float xAxis, yAxis;

    private bool change;

    void Start() {
        rotate = 0f;
        ///RenderSettings.skybox.SetFloat("_Blend", 0f);
        daySky = RenderSettings.skybox;
        change = false;
        
    }

	// Update is called once per frame
	void Update () {
        RotateSun();
	}

    void RotateSun() {
        rotate = Time.deltaTime /4;
        xAxis = Mathf.Sin(rotate) / rotationSpeed;
        yAxis = Mathf.Cos(rotate) / rotationSpeed;
        //transform.Rotate(xAxis, yAxis, 0);

        transform.Rotate(Vector3.down, xAxis * (Time.deltaTime/ 4) * rotationSpeed);
        if ((int)transform.eulerAngles.x == 350 && change == false){
            GetComponent<Light>().intensity = 0f;
            RenderSettings.skybox = nightSky;
            change = true;
        }
        else if ((int)transform.eulerAngles.x == 190 && change == true) {
            GetComponent<Light>().intensity = 1f;

            RenderSettings.skybox = daySky;
            change = false;
        }
        transform.Rotate(Vector3.up, yAxis * (Time.deltaTime/4) * rotationSpeed);
        //http://answers.unity3d.com/questions/595467/controlling-the-rotation-speed-of-an-object.html   //to help with varying the speed of the cycle

    }


}
