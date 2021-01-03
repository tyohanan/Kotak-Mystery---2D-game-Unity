using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartMission : MonoBehaviour
{
    public GameObject player;
    private GameMaster gameMasterControl;
    private Rigidbody2D rb;
    private CinemachineVirtualCamera Camera;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        gameMasterControl = GameObject.Find("GAME MASTER").GetComponent<GameMaster>();
        Camera = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
    }
    
    private void Update() {
        IfPlayerDie();
    }



    public void IfPlayerDie()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(player, transform.position, transform.rotation);
            StartCoroutine(PlayerRespown(0.5f));
        }
    }

    IEnumerator PlayerRespown(float time)
        {
         yield return new WaitForSeconds(time);
         Camera.m_Follow = GameObject.FindGameObjectWithTag("Player").transform; 
        }
}