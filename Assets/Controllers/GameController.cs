using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : Singleton<GameController> {

    private Text timer_bk, score_bk;
    public GameObject bv;

    private float timer = 200f; 
    private float score;

    private bool start = false;

	// Use this for initialization
	public void InitialiseGame() {
        score = 0;
        Cursor.lockState = CursorLockMode.Locked; //keeps mouse locked to screen
        PlayerController.Instance.player.transform.position = new Vector3(11.8f, 0.52f, 19.8f);
        PlayerController.Instance.player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        timer_bk = GameObject.FindGameObjectWithTag("Timer").transform.GetComponent<Text>();
        score_bk = GameObject.FindGameObjectWithTag("Score").transform.GetComponent<Text>();
	}
	
    public void EnteredBuilding() {
         if(!start)
             InvokeRepeating("UpdateTimer", 0f, 0.01f);
         start = true;
    }


    void UpdateTimer() {
        timer -= 0.01f;
        timer_bk.text = timer.ToString("0.00");
        if (timer < 0) {
            //End game
            Time.timeScale = 0;
            CancelInvoke("UpdateTimer");
            GameObject.FindGameObjectWithTag("BaseView").GetComponent<BaseView>().EndGame();
        }

    }

    public void UpdateScore(float add) {
        score += add;
        score_bk.text = score.ToString();
    
    }

    public float Score {
        get { return score;}
    }
}
