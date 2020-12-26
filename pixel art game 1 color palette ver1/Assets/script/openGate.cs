using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{
    public GameObject gate;
    private Animator anim;
    private Vector3 startPos;
    private bool gateIsOpen;

    [Header("Moving Gate")]
    public float maksDistance = 3f;
    public Vector3 gateSpeed;

    private void Start() {
        anim = GetComponent<Animator>();
        startPos = gate.transform.position;
        gateIsOpen = false;
    }

    private void FixedUpdate() {
        movingGate();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            gateIsOpen = true;
            anim.SetBool("isOn", gateIsOpen);
        }
    }

    private void movingGate(){
        if (gateIsOpen == true){
            gate.transform.position += gateSpeed;
        }

        if ((gate.transform.position.y - startPos.y) > maksDistance){
            gateSpeed = new Vector3 (0,0,0);
        }
    }
}
