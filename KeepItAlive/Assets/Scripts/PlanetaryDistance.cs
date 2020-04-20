using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class PlanetaryDistance : MonoBehaviour
{
    [System.Serializable]
    public class PlanetDefiner 
    {
        public bool reached;
        public string planetName;
        public float planetDistance;
    }

    #region Public fields
    [Readonly]
    public float neutrinoPercurredDistance = 0.0f;
    public ComputePercurredDistance playerDistanceComponent = null;
    public string extraTextBefore= "";
    public string extraTextAfter = "";
    public float timeExposedString = 3.0f;
    public PlanetDefiner[] planets;
    #endregion 

    private Text scoreText;

    
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
                foreach(PlanetDefiner planet in planets)
                {
                    if (!planet.reached)
                    {
                        if (playerDistanceComponent.neutrinoPercurredDistance >= planet.planetDistance)
                        {
                            if (planet.planetName == "Earth") 
                            {
                                scoreText.text = extraTextBefore + " " + planet.planetName + "! Say hello to Gino! " + extraTextAfter;
                            }
                            else if (planet.planetName == "Pluto") 
                            {
                                scoreText.text = extraTextBefore + " " + planet.planetName + "! actually, it's not a planet, but he's cute! " + extraTextAfter;
                            }
                            else if (planet.planetName == "Outside") 
                            {
                                scoreText.text = "You are now leaving the Solar system!";
                            }
                            else
                            {
                                scoreText.text = extraTextBefore + " " + planet.planetName + "! " + extraTextAfter;
                            }
                            planet.reached = true;
                            StartCoroutine(awaitFunc());
                        }
                    }
                } 
            }
        }
    }

    IEnumerator awaitFunc() 
    {
        yield return new WaitForSeconds(timeExposedString);

        scoreText.text = "";
    }
}
