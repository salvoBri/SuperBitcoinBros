using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score_Time : MonoBehaviour {

    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
   
    // Update is called once per frame
    void Update() {
        //Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime; //decreses time for countdown
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left:" + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);

        //Debug.Log(timeLeft);
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene("SampleScene"); //restarts the game
        }
    }

    

    void OnTriggerEnter2D (Collider2D trig) {
        if (trig.gameObject.name == "EndLevel") {
            CountScore();
        }
        if (trig.gameObject.name == "Coin") { 
            playerScore += 10;          //adds 10 points to score
            Destroy (trig.gameObject); //removes a collected coin
        }
        

    }

    void CountScore() {
        playerScore = playerScore + (int)(timeLeft * 5);
        Debug.Log(playerScore);
    }
}
