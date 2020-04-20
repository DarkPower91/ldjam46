using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class PlanetesPopUp : MonoBehaviour
{
    #region Public fields
    [Readonly]
    public float neutrinoPercurredDistance = 0.0f;
    public ComputePercurredDistance playerDistanceComponent = null;
    public string extraTextBefore= "";
    public string extraTextAfter = "";
    public float timeShowed = 1.0f;
    #endregion

    #region Private fields
    private Text scoreText;
    private float mercuryDist = 0.3871f;
    private float venusDist = 0.723f;
    private float earthDist = 1.0f;
    private float marsDist = 1.52f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDistanceComponent != null) 
        {
            if (FlowManager.GetGameState() == GameState.InGame) 
            {
                float distPerc = playerDistanceComponent.neutrinoPercurredDistance;
                if ( distPerc > mercuryDist && distPerc < mercuryDist + timeShowed ) 
                {
                    scoreText.text = extraTextBefore + " Mercury! " + extraTextAfter;
                }
                else if (distPerc > venusDist && distPerc < venusDist + timeShowed ) 
                {
                    scoreText.text = extraTextBefore + " Venus! " + extraTextAfter;
                }
                else if (distPerc > earthDist && distPerc < earthDist + timeShowed ) 
                {
                    scoreText.text = extraTextBefore + " Earth! Say hello to Gino!" + extraTextAfter;
                }
            }
        }
    }
}
