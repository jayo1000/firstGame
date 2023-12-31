﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float speed = 0.005f;
    public float move_term = 0.25f;
    public float boost_term = 3.0f;
    public float boost_speed = 4.0f;

    GameObject Player;
    BoxCollider2D boxCollider;

    // <주의 변경 사항 >
    public Panel_GameOver panel_GameOver; // 변경된 부분
    private void Awake()
    {
        Player = FindObjectOfType<JUMP>().gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void Start()
    {
        StartCoroutine(Move());
    }

    public Vector2 GetTopPosition()
    {
        Vector2 topPos;
        topPos = boxCollider.bounds.max;
        return topPos;
    }

    IEnumerator Move() {
        while(true) {
            float cur_speed = speed;
            if (Player.transform.position.y > GetTopPosition().y + boost_term) {
                cur_speed *= boost_speed;
            }

            transform.position = new Vector2(transform.position.x, transform.position.y + cur_speed); 
            yield return new WaitForSeconds(move_term);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // 변경된 부분!
            GameOver();
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
    }
    
    public void GameOver() //  새로 추가된 함수
    {
        Debug.Log("GameOver");
        Stop(); // 용암아 그만 움직여.
        FindObjectOfType<PlatformManager>().Stop(); // 발판 그만 만들어.
        FindObjectOfType<JUMP>().Die(); // 그만 점프뛰어. 너 죽었어.


        // **************새로 추가된 부분*****************//
        ScoreText scoreText = FindObjectOfType<ScoreText>();
        scoreText.Set_HightScore(scoreText.GetScore());
        // ***********************************************//



        panel_GameOver.Show(); // 게임오버 팝업 띄어줘!

    }

}
