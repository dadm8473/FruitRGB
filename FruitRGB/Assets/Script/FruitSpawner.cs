using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public GameObject[] fruitPrefab;
    public Transform[] spawnPoints;

    public float minDelay = 1;
    public float maxDelay = 2;

    public bool setAc = true;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnFruits());
	}

    void Update()
    {
        if (setAc)
        {
            // 시간이 갈 수록 과일이 나오는 딜레이를 줄임
            minDelay -= 0.01f * Time.deltaTime;
            maxDelay -= 0.01f * Time.deltaTime;

            if (minDelay <= 0.3f)
                minDelay = 0.3f;
            if (maxDelay <= 0.5f)
                maxDelay = 0.5f;
        }
    }

    IEnumerator SpawnFruits()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // 과일 소환
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            int fruitIndex = Random.Range(0, fruitPrefab.Length);
            GameObject spawnedFruit = Instantiate(fruitPrefab[fruitIndex], spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 3f);
        }
    }
}
