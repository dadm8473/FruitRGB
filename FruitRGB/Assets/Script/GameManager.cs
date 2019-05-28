using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject stop;
    public GameObject gameOver;
    public Text scoreText;
    public Text highScore_Text;
    public Text scoreText_Scene;
    public GameObject score_Scene;

    public static int score;
    public static float time;
    public static bool isGame;
    float timer = 5;

    void Awake()
    {
        // 스태틱 변수 초기화
        GameManager.score = 0;
        GameManager.time = 100;
        GameManager.isGame = true;

        // 타임 스케일이 0일경우 1로
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    void Update ()
    {
        // 스코어 출력
        scoreText_Scene.text = score.ToString();

        TimeManager();

        // esc 혹은 핸드폰 취소키를 누르면 stop 메뉴를 띄움
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Stop();
        }
    }

    public void Stop()
    {
        stop.SetActive(true);
        isGame = false;
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        score_Scene.SetActive(false);
        gameOver.SetActive(true);
        
        // 게임이 종료됬음을 알려 블레이드 업데이트를 return
        isGame = false;

        // 최고점수 기록
        if (PlayerPrefs.GetInt("High_Score") < score)
            PlayerPrefs.SetInt("High_Score", score);

        PlayerPrefs.Save();

        scoreText.text = score.ToString();
        highScore_Text.text = PlayerPrefs.GetInt("High_Score").ToString();

        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        isGame = true;
        if (stop)
            stop.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }

    public void Leave()
    {
        SceneManager.LoadScene("Main");
        if (stop)
            stop.SetActive(false);
    }
    
    public void TimeManager()
    {
        // 타이머를 닳게하며 시간이 지날수록 빨리 닳음
        if (time >= 100)
            time = 100;

        timer += 0.08f * Time.deltaTime;
        time -= timer * Time.deltaTime;
    }
}
