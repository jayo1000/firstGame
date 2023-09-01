using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Start : MonoBehaviour
{
    //public Text Text_Game;
    private void Awake()
    {
        transform.gameObject.SetActive(true); // 게임이 시작되면 GameOver 팝업 창을 보이지 않도록 한다.
    }

    public void Show() {
        transform.gameObject.SetActive(true); // GameOver 팝업 창을 화면에 표시 시키고
        int score = FindObjectOfType<ScoreText>().GetScore(); // ScoreText로 부터 현재 기록된 점수를 불러온다. 
        int highScore = FindObjectOfType<ScoreText>().Get_HighScore();  // ScoreText로 부터 최고점수를 불러온다.                                                                     
    }
}
