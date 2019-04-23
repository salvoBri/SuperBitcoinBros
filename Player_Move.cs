using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;

    // Update is called once per frame
    void Update() {
        PlayerMove();
        PlayerRaycast();

    }
    void PlayerMove() {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            Jump();
        }

        //animations
        if (moveX != 0) { //theres an input, hence player is current moving
            GetComponent<Animator>().SetBool("IsRunning", true);
        }else {
            GetComponent<Animator>().SetBool("IsRunning", false);

        }

        //player direction
        if (moveX < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true; //flips player to the direction it faces
        } else if (moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }
    void Jump() {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false; // while jumping, player is in air
    }
    

    void PlayerRaycast() {
        //Ray up
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "breakBrick") {
            Destroy (rayUp.collider.gameObject); //destroys object hit up
        }

        //Ray down
        //player movement direction down hits an enemy
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "enemy") {

            //access the Player_Score_Time.cs, access the variable playerScore
            GameObject thePlayerScore = GameObject.Find("Player");
            Player_Score_Time updateScore = thePlayerScore.GetComponent<Player_Score_Time>();
            updateScore.playerScore += 20; //adds 20 points to the overall player score

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
            //boost player to the right then jumping on enemies
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            //parameters for enemy when it killed
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "enemy") {
            isGrounded = true;
        }

    }
}



