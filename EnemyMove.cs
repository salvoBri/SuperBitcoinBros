﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
   

    // Update is called once per frame
    void Update() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.7f) { //if enemy hits an object, it flip to the other side
            Flip();
            if (hit.collider.tag == "Player") {
                Destroy(hit.collider.gameObject);
                Die();
            }
        }
        //TODO Fix something
        
    }
    void Die() {
        SceneManager.LoadScene("SampleScene"); //reloads the start of the game

    }
    void Flip() {
        if (XMoveDirection > 0) {
            XMoveDirection = -1;
        }
        else {
            XMoveDirection = 1;
        }
    }
}
