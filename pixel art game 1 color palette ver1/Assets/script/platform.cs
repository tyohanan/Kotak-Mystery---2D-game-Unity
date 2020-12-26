using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool positionTouch;
    private int facingDirection;
    private float StartPositionMoving;

    [Header("Platform Object")]
    public GameObject activePlatform, nonActivePlatform;

    [Header("moving Attribute")]
    public Vector2 PlatformSpeed;
    public float DistanceMove = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activePlatform.SetActive(true);
        nonActivePlatform.SetActive(false);
        positionTouch = false;
        facingDirection = 1;
        StartPositionMoving = transform.position.x;
    }

    public void FixedUpdate() {
        movingPlatform();
    }

    private void OnCollisionEnter2D(Collision2D player) {
        if (player.gameObject.tag == "Player" && positionTouch == false){
            activePlatform.SetActive(false);
            nonActivePlatform.SetActive(true);
            positionTouch = true;
        }
        else if (player.gameObject.tag == "Player" && positionTouch == true){
            activePlatform.SetActive(true);
            nonActivePlatform.SetActive(false);
            positionTouch = false;
        }
        if (player.gameObject.tag == "Player"){
            player.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D player) {
        if (player.gameObject.tag == "Player"){
            player.collider.transform.SetParent(null);
        }
    }

    private void movingPlatform(){
    transform.position += new Vector3(PlatformSpeed.x*facingDirection, PlatformSpeed.y,0);

        if (Mathf.Abs(transform.position.x - StartPositionMoving) > DistanceMove){
            facingDirection *= -1;
            StartPositionMoving = transform.position.x;
        }
    }


}   
