using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseView : MonoBehaviour{

    public GameObject View, Model;
    public GameObject MenuHUD, GameHUD, EndHUD, PauseMenu;
    public GameObject Player, Camera, Sun;
    public GameObject PanCamera;

    public GameObject Warning;
    
    private KeyboardInput ki;

    private string[] leaderboardResults= new string[62];

    public bool DebugMode = false;

	// Use this for initialization
	void Awake () {
        MenuHUD.SetActive(true);
        GetScore();
        if (DebugMode) {
            StartGame();
            return;
        }
        //Player.SetActive(false);
        
        //View.SetActive(false);
        //GameHUD.SetActive(false);
        //EndHUD.SetActive(false);
        //Camera.SetActive(false);
        

    }

    public void MainMenu() {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
             Destroy(o);
         }
         SceneManager.UnloadScene(0);
         SceneManager.LoadScene(0);
         Time.timeScale = 1;
         MenuHUD.SetActive(true);
         GetScore();
         
        //RunStart();
    }

    public void RunStart() {
        GetScore();
        if (DebugMode) {
            //StartGame();
            return;
        }
        MenuHUD.SetActive(true);
        View.SetActive(false);
        GameHUD.SetActive(false);
        EndHUD.SetActive(false);
        Camera.SetActive(false);
    }

    public void StartPan() {
        //Deactive Main menu
        MenuHUD.SetActive(false);
        PanCamera.GetComponent<Animator>().Play("Pan1", -1, 0f); 
    }   

    public void StartGame() {
        PanCamera.SetActive(false);
        MenuHUD.SetActive(false);
        
        //Start Game
        View.SetActive(true);
        GameHUD.SetActive(true);
        Camera.SetActive(true);
        Sun.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
        GameController.Instance.InitialiseGame();  //Reset game score and timer
    }

    public void EndGame() {
        Cursor.lockState = CursorLockMode.None;
        EndHUD.transform.GetChild(0).GetComponent<Text>().text = GameController.Instance.Score.ToString();
        View.SetActive(false);
        GameHUD.SetActive(false);
        Camera.SetActive(false);
        Player.SetActive(false);
        GameHUD.SetActive(false);

        PanCamera.SetActive(true);
        PanCamera.GetComponent<Animator>().Play("Pan", -1, 0f);
        EndHUD.SetActive(true);
    }

    public void ButtonPressCheck() {
        
        if (GameObject.FindGameObjectWithTag("Input").GetComponent<Text>().text.Length == 0) {
            Warning.GetComponent<Text>().text = "PLEASE ENTER NAME";
            return;
        }
        else {
            Warning.GetComponent<Text>().text = "";
            PostScore();
            MainMenu();
        }
    }


    public void PostScore() {
        string name = GameObject.FindGameObjectWithTag("Input").GetComponent<Text>().text;
        name = name.Replace('_', '-');
        string data = name + ":" + GameObject.FindGameObjectWithTag("scoreInput").GetComponent<Text>().text;
        //string data = "hello:1234";
        //Debug.Log(data);
        string encryptedData = Cipher.Encryption(data);


        //https://msdn.microsoft.com/en-us/library/debx8sh9(v=vs.110).aspx
        if (encryptedData != null) {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true; //Because of bad certifcate on ssl server
            var request = (HttpWebRequest)WebRequest.Create("https://zeno.computing.dundee.ac.uk/2016-games/stuarthuddy/post.php");
            byte[] data2 = Encoding.ASCII.GetBytes("data=" + encryptedData);
    
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data2.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data2, 0, data2.Length);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //Debug.Log(responseString);
        }
    }


    public void GetScore(){
        /**
         * Connection code taken from arsho from StackOverflow
         *  http://stackoverflow.com/questions/5512951/best-practice-for-c-sharp-calling-php-which-then-queries-the-database
         * */


        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true; //Because of bad certifcate on ssl server
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://zeno.computing.dundee.ac.uk/2016-games/stuarthuddy/get.php");
        myRequest.Method = "GET";
        WebResponse myResponse = myRequest.GetResponse();
        StreamReader sr = new StreamReader(myResponse.GetResponseStream(),System.Text.Encoding.UTF8);
        string results = sr.ReadToEnd();
        results = results.Substring(2, results.Length-2);
        leaderboardResults = results.Split('+');
        sr.Close();
        myResponse.Close();
        if(results !=null)
            UpdateLeaderboard();
    }

    public void UpdateLeaderboard() {

        Text[] sbn = {GameObject.FindGameObjectWithTag("Section0n").GetComponent<Text>(), 
                     GameObject.FindGameObjectWithTag("Section1n").GetComponent<Text>(),
                     GameObject.FindGameObjectWithTag("Section2n").GetComponent<Text>(),
                     GameObject.FindGameObjectWithTag("Section3n").GetComponent<Text>(),
                     GameObject.FindGameObjectWithTag("Section4n").GetComponent<Text>()};

        Text[] sbs = {GameObject.FindGameObjectWithTag("Section0s").GetComponent<Text>(), 
                     GameObject.FindGameObjectWithTag("Section1s").GetComponent<Text>(),
                     GameObject.FindGameObjectWithTag("Section2s").GetComponent<Text>(),
                     GameObject.FindGameObjectWithTag("Section3s").GetComponent<Text>(),
                     GameObject.FindGameObjectWithTag("Section4s").GetComponent<Text>()};

        string nameText = "";
        string scoreText = "";
        int sbCounter = 0;
        for (int i = 0, j = 1; i < leaderboardResults.Length-1; i++, j++) {
            Debug.Log(leaderboardResults[i]);
            if (leaderboardResults[i].Length == 0)
                break;
            if (i > 63)
                break;
            if (i == 10) {
                sbn[sbCounter].text = nameText;
                sbs[sbCounter].text = scoreText;
                nameText = "";
                scoreText = "";
                sbCounter += 1;
                j = 1;
            }
            if (j == 13) {
                sbn[sbCounter].text = nameText;
                sbs[sbCounter].text = scoreText;
                nameText = "";
                scoreText = "";
                sbCounter += 1;
                j = 0;
            }
            string temp = leaderboardResults[i];
            string[] data = temp.Split('_');
                        
            if(data[0].Length > 15){
                data[0] = data[0].Substring(0, 14);
            }
            data[0] = data[0].PadRight(10);
            nameText +=(i+1) + ". " + data[0] + '\n';
            scoreText +=data[1] + '\n';
            sbn[sbCounter].text = nameText;
            sbs[sbCounter].text = scoreText;

        }



    }


    public void Quit() {
        SceneManager.UnloadScene(0);
        Application.Quit();
        
    }
    
 
 


}
