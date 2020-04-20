﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class ShowPercurredDistanceUI : MonoBehaviour
{
    #region Public fields
    [Readonly]
    public float neutrinoPercurredDistance = 0.0f;
    public ComputePercurredDistance playerDistanceComponent = null;
    public string extraTextBefore= "";
    public string extraTextAfter = "";
    #endregion

    #region Private fields
    private Text scoreText;
    private float factorRound = 10000.0f;
    private float approxDist = 0.0f;
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
                approxDist = Mathf.Round( factorRound*(playerDistanceComponent.neutrinoPercurredDistance) )/ factorRound;
                string distToStiring = approxDist.ToString();
                scoreText.text = extraTextBefore +  distToStiring.Substring(0,4) + distToStiring.Substring(distToStiring.Length - 4, 4) + extraTextAfter;
            }
        }
        
    }
}
