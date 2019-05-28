using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject floatingScorePrefab;
    public GameObject fruitSlicedPrefab;
    float startForce = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startForce = Random.Range(10f, 11f);
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    { 
        // 블레이드 타입에 따라 자를 수 있는 과일이 다름
        if(col.tag == "Blade")
        {
            switch(gameObject.tag)
            {
                case "Apple":
                    if(Blade.getInstance().type != 1)
                        return;
                    break;
                case "Blueberry":
                    if (Blade.getInstance().type != 4)
                        return;
                    break;
                case "Orange":
                    if (Blade.getInstance().type != 3)
                        return;
                    break;
                case "WaterMelon":
                    if (Blade.getInstance().type != 2)
                        return;
                    break;
                default:
                    return;
            }

            ShowFloatingText();

            // 잘린 과일 rotation 변경
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            // 자르는 사운드 출력
            SoundManager.instance.PlaySound(1);

            // 잘린 과일 생성
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(slicedFruit, 3f);

            //Debug.Log("과일을 공격하셨습니다 !!");
            Destroy(gameObject);
        }
    }

    void ShowFloatingText()
    {
        // 과일이 잘리고 얻은 점수를 띄움
        Instantiate(floatingScorePrefab, transform.position, Quaternion.identity);

        //Debug.Log("ShowFloatingText!!");
        //GameObject floatingScore = Instantiate(floatingScorePrefab, transform.position, Quaternion.identity, transform);
        //Instantiate(floatingScorePrefab, transform.position, Quaternion.identity, transform);
    }
}