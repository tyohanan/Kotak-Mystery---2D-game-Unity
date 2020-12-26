using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLava : MonoBehaviour
{
    public GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Damage(10);
            Debug.Log("player hit by lava");
        }
    }
}