using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image Timer;
    public GameManager gm;

    void Update()
    {
        // 타이머 Amount를 표시
        Timer.fillAmount = GameManager.time * 0.01f;

        if(Timer.fillAmount <= 0)
        {
            // 타이머가 0이 될 경우 게임 종료
            gm.GameOver();
            Timer.fillAmount = 1;
        }
    }
}