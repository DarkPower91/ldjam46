using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class OscillatingFlavour : MonoBehaviour
{
    #region Public fields
    public Sprite[] neutrinoSprites;
    #endregion

    #region Private fields
    private float changeTime = 1;
    private int idx = 0;
    #endregion

    // Awake
    private void Awake() {
        neutrinoSprites = Resources.LoadAll<Sprite>("Neutrino_Sprites");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flavourChange());

        idx = Random.Range(0, neutrinoSprites.Length);

        GetComponent<SpriteRenderer>().sprite = neutrinoSprites[ idx ];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // My personal functions
    private IEnumerator flavourChange () 
    {
        while (true) {
            
            yield return new WaitForSeconds(changeTime); 

            int index = Random.Range(0, neutrinoSprites.Length);

            while (index == idx) {
                index = Random.Range(0, neutrinoSprites.Length);
            }

            idx = index;

            GetComponent<SpriteRenderer>().sprite = neutrinoSprites[ idx ];
        }
    }
}
