using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public void Update()
    {
        // 취소키 누르면 앱 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameStart()
    {
        // 게임 시작 버튼
        SceneManager.LoadScene("Game");
    }
}
