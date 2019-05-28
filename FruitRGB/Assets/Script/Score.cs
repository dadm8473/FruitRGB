using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    //Renderer rend;
    TextMesh text;
    int score;

    public float ScoreDelay = 0.5f;
    void Start()
    {
        text = GetComponent<TextMesh>();

        // 점수 랜덤으로 줌
        score = Random.Range(70, 150);

        // 스코어 증가 및 타이머 증가
        GameManager.score += score;
        GameManager.time += 10;

        text.text = "+" + score.ToString();

        Debug.Log("점수 " + score.ToString() + "점 추가!! 현재점수 : " + GameManager.score);

        StartCoroutine("DisplayScore");
    }

    void Update()
    {
        // 글자가 위로 올라가는 효과
        Vector3 pos = transform.position;
        pos.y += 0.01f;
        transform.position = pos;
    }

    IEnumerator DisplayScore()
    {
        yield return new WaitForSeconds(ScoreDelay);

        // 글자 알파 값이 내려가면서 사라짐
        for (float a = 1; a >= 0; a -= 0.05f)
        {
            text.color = new Vector4(1, 1, 1, a);
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }
}