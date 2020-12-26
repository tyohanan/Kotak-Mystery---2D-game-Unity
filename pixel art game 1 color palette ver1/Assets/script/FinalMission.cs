using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMission : MonoBehaviour
{
    private Vector3 startPosition;
    public float distance = 1f;
    public float moveSpeed = 1f;
    public GameObject destroyEffect;
    private int direction;

    private float newtest;

    void Start()
    {
        direction = 1;
        startPosition = gameObject.transform.position;
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
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            StartCoroutine(NextLevel(0.5f));
        }
    }

    IEnumerator NextLevel(float time){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level 2");
    }
}