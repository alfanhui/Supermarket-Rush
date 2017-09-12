using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIView : MonoBehaviour {

    private GameObject pauseObject;
    private KeyboardInput ki;

    // Use this for initialization
    void Start() {
        ki = KeyboardInput.Instance;
        Time.timeScale = 1;
        pauseObject = GameObject.FindGameObjectWithTag("ShowOnPause");
        if(pauseObject != null)
            hidePaused();
    }

    // Update is called once per frame
    void Update() {
        if (ki.KeyPress_Esc) {
            if (Time.timeScale == 1) {
                //Cursor.lockState = CursorLockMode.None; //keeps mouse locked to screen
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0) {
              //  Cursor.lockState = CursorLockMode.Locked; //keeps mouse locked to screen
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused() {
            Cursor.lockState = CursorLockMode.None;
            pauseObject.SetActive(true);
    }

    //hides objects with ShowOnPause tag
    public void hidePaused() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseObject.SetActive(false);
    }

    //loads inputted level
    public void LoadLevel(string level) {
        SceneManager.UnloadScene(level);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }



}
