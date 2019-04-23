using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {

    //public int health;
    


    // Update is called once per frame
    void Update() {
        if (gameObject.transform.position.y < -11) {  //if player is goes below death zone
            Die(); //call Die method
        }
        
    }
    void Die() {
        SceneManager.LoadScene("SampleScene"); //reloads the start of the game
        
    }
}
