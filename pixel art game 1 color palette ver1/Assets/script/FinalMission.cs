using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class FinalMission : MonoBehaviour
{
    private Vector3 startPosition;
    public float distance = 1f;
    public float moveSpeed = 1f;
    public GameObject destroyEffect;
    private int direction;
    private float newtest;
    public float radiusCheck = 0.5f;
    public LayerMask whatIsPlayer;
    private bool isDestroyed;

    void Start()
    {
        isDestroyed = true;
        direction = 1;
        startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        checkIfPlayer();
    }

    private void FixedUpdate() {
        transform.position += new Vector3(0, direction*moveSpeed,0);
        if (Mathf.Abs(transform.position.y-startPosition.y) > distance){
            direction *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
        }
    }

    private void checkIfPlayer()
    {
        bool isCollidePlayer = Physics2D.OverlapCircle(transform.position, radiusCheck, whatIsPlayer);
        if (isCollidePlayer)
        {
            if (isDestroyed)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                isDestroyed = false;
            }
            StartCoroutine(NextLevel(0.5f));
        }
    }

    IEnumerator NextLevel(float time){
        yield return new WaitForSeconds(time);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if ((currentScene+1) > 3)
        {
            currentScene = -1;
        }
        SceneManager.LoadScene(currentScene+1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusCheck);
    }
}