using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_EnemyDB = new List<GameObject>();
    [SerializeField]
    private float m_SpawnDelay = 1.0f;

    void Start()
    {
        StartCoroutine(SpawnWave());   
    }

    IEnumerator SpawnWave()
    {
        while(true) //TODO give control to start the wave
        {
            yield return new WaitForSeconds(m_SpawnDelay);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int EnemyIndex = Random.Range(0, m_EnemyDB.Count);
        GameObject enemy = Instantiate(m_EnemyDB[EnemyIndex]) as GameObject;

        float enemyBBy = enemy.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector2 screenBounds = ScreenBounds.GetScreenBounds();
        float yPosition = Random.Range(-screenBounds.y + enemyBBy/2, screenBounds.y - enemyBBy/2);

        float speed = Random.Range(0.0f, 5.0f);

 
        enemy.transform.position = new Vector2(screenBounds.x * 1.5f, yPosition);
        enemy.GetComponent<BasicEnemy>().SetSpeed(speed);
    }
}
