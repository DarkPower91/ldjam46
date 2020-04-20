﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherThingSpawnerManager : MonoBehaviour
{   
    #region Private 
    private float m_SpawnDelay = 7.5f;
    [SerializeField]
    private List<GameObject> m_OtherDB = new List<GameObject>();
    public float minSpeed = 0.5f;
    public float maxSpeed = 3.0f;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Functions
        IEnumerator SpawnWave()
    {
        while(true) //TODO give control to start the wave
        {
            yield return new WaitForSeconds(m_SpawnDelay);
            if(FlowManager.GetGameState() == GameState.InGame)
           {
               SpawnOther(); 
           }
        }
    }

    void SpawnOther() 
    {
        int otherIndex = Random.Range(0, m_OtherDB.Count);
        GameObject other = Instantiate(m_OtherDB[otherIndex]) as GameObject;

        float otherBBy = other.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector2 screenBounds = ScreenBounds.GetScreenBounds();
        float yPosition = Random.Range(-3*screenBounds.y + otherBBy/2, 3*screenBounds.y - otherBBy/2);

        float speed = - Random.Range(minSpeed, maxSpeed);
 
        other.transform.position = new Vector3(screenBounds.x * 1.5f, yPosition, 10.0f);

        other.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);

    }
}
