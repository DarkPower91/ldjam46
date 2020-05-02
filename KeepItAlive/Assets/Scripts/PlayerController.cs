using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    #region Public fields
    public Vector3 startingPosition;
    public float velocity_module = 2;
    #endregion
    
    #region Private fields
    private Camera cam; 
    private SpriteRenderer sprite;
    private Vector2 screenBounds;
    private float[] objectSize = {0,0,0};
    private float[] minValues = {0,0,0};
    private float[] maxValues = {0,0,0};
    private Vector3 versor;
    private Vector3 axis_position;
    private string[] command = {"Horizontal", "Vertical", "Ano"};
    #endregion
    
    void Start()
    {
        transform.position = startingPosition;

        screenBounds = ScreenBounds.GetScreenBounds();

        sprite = GetComponent<SpriteRenderer>();

        objectSize[0] = sprite.bounds.size.x / 2;
        objectSize[1] = sprite.bounds.size.y / 2;

        minValues[0] = - screenBounds.x + objectSize[0];
        minValues[1] = - screenBounds.y + objectSize[1];

        maxValues[0] = screenBounds.x - objectSize[0]; 
        maxValues[1] = screenBounds.y - objectSize[1];

        //velocity_module = velocity[0]; //Mathf.Sqrt(velocity[0]*velocity[0] + velocity[1]*velocity[1] + velocity[2]*velocity[2]);
    }

    void Update()
    {   
        if(FlowManager.GetGameState() == GameState.InGame)
        {
            axis_position = transform.position; 
            for (int i=0; i<3; i++) 
            {
                if (i==2)
                {
                    versor[i] = 0;
                }
                else
                {
                    versor[i] = Input.GetAxis(command[i]);
                }
            }
            versor = Vector3.Normalize(versor);
            for (int i=0; i < 3; i++) 
            { 
                if (i!=2) 
                {
                    axis_position[i] +=versor[i] * velocity_module * Time.deltaTime;
                } 
                else
                {
                axis_position[i] = 0;
                }  
            }
            transform.position = axis_position;
        }
    }
    
    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;

        objectPosition.x = Mathf.Clamp(objectPosition.x, minValues[0], maxValues[0]);
        objectPosition.y = Mathf.Clamp(objectPosition.y, minValues[1], maxValues[1]);

        transform.position = objectPosition;
    }
}
