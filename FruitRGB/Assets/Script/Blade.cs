using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    private static Blade instance;

    public GameObject[] bladeTrailPrefabs;
    public float minCuttingVelocity = .001f;

    bool isCutting = false;

    Vector2 previousePosition;

    GameObject currentBladeTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    public int type;

    private void Awake()
    {
        Blade.instance = this;
    }

    public static Blade getInstance()
    {
        return instance;
    }

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        type = 0;
    }

    void Update ()
    {
        if (GameManager.isGame == false)
            return;
        
        // 자르기
		if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
            Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = newPosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
	}

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        // 드래그 속도가 너무 느릴 경우 Collider을 활성화 시키지 않음
        float velocity = (newPosition - previousePosition).magnitude * Time.deltaTime;
        if(velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousePosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;

        // 칼의 타입에 따라 다른 Blade Trail을 분배함
        switch (type)
        {
            case 1:
                currentBladeTrail = Instantiate(bladeTrailPrefabs[1], transform);
                break;
            case 2:
                currentBladeTrail = Instantiate(bladeTrailPrefabs[2], transform);
                break;
            case 3:
                currentBladeTrail = Instantiate(bladeTrailPrefabs[3], transform);
                break;
            case 4:
                currentBladeTrail = Instantiate(bladeTrailPrefabs[4], transform);
                break;
            default:
                currentBladeTrail = Instantiate(bladeTrailPrefabs[0], transform);
                break;
        }
        previousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        if(currentBladeTrail)
            currentBladeTrail.transform.SetParent(null);
        circleCollider.enabled = false;
        Destroy(currentBladeTrail, 0.5f);
    }
}
