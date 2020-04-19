using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_EnemyDB = new List<GameObject>();
    [SerializeField]
    private float m_SpawnDelay = 1.0f;
    private float changeTime = 2;
    private float increasingRate = 2;
    private int iteratorForSpawn = 0;
    private int maxTimeForChangeOfIncreasingIteratorForSpawn = 3;

    void Start()
    {
        StartCoroutine(SpawnWave());   

        StartCoroutine(changeSpawnRate());
    }

    IEnumerator SpawnWave()
    {
        while(true) //TODO give control to start the wave
        {
            yield return new WaitForSeconds(m_SpawnDelay);
            if(FlowManager.GetGameState() == GameState.InGame)
           {
               SpawnEnemy(); 
           }
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

    // My personal functions
    private IEnumerator changeSpawnRate() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(changeTime); 
            
            if(FlowManager.GetGameState() == GameState.InGame)
           {

               if (iteratorForSpawn >= maxTimeForChangeOfIncreasingIteratorForSpawn) 
               {
                   increasingRate++;
                   iteratorForSpawn = 1;

               } else 
               {
                   iteratorForSpawn++;
               }

               m_SpawnDelay = (float) m_SpawnDelay / Random.Range(1, increasingRate + 1);
           }
            
        }
    }
}
