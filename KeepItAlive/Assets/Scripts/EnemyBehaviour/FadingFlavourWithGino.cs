using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingFlavourWithGino : MonoBehaviour
{
    public float fadingFactor = 0.3f;
    
    private OscillatingFlavour playerFlavour = null;
    private Flavours penemyFlavour =  Flavours.count;
    private SpriteRenderer renderer = null;
    

    // Start is called before the first frame update
    void Start()
    {
        playerFlavour = GameObject.FindGameObjectWithTag("Player").GetComponent<OscillatingFlavour>();
        renderer = GetComponent<SpriteRenderer>();

        if(playerFlavour != null) 
        {
            playerFlavour.OnFlavourChanged += ShadingPenemy;
        }

        penemyFlavour = GetComponent<FlavourDefinition>().flavour;
    }

    private void OnDestroy() 
    {
        if(playerFlavour != null) 
        {
            playerFlavour.OnFlavourChanged -= ShadingPenemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    private void ShadingPenemy(Flavours flavour) 
    {
        var newColor = renderer.material.color;
        newColor.a = (penemyFlavour == flavour) ? 1.0f : fadingFactor;

        renderer.material.color = newColor;
    }
}
