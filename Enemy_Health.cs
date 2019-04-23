using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Health : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        if (gameObject.transform.position.y < -11) {  //if enemy is below death zone
            Destroy(gameObject); //call Die method
            //destroys the enemy gameObject
            
        }

    }
     
}
