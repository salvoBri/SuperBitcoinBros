using UnityEngine;
using System.Collections;

public class Sun_Move : MonoBehaviour {

    public Transform target;
    public float moveSpeed = 3;

    void Start() {
        target = GameObject.Find("Player").transform;
    }

    void Update() {
        Chase();
    }

    void Chase() {
        Vector3 targetDirection = target.position - transform.position;
        transform.position += targetDirection * moveSpeed * Time.deltaTime;
    }
}