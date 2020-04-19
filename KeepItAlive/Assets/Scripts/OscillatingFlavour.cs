using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class OscillatingFlavour : MonoBehaviour
{
    #region Public fields
    public Sprite[] neutrinoSprites;
    [Readonly]
    public Flavours idx = Flavours.electronic;
    #endregion

    #region Private fields
    private float changeTime = 1;
    private int availableNeutrinos;
    private Animator animator;
    #endregion

    // My private functions
    private Flavours randomNeutrino() 
    {
        return  (Flavours) Random.Range(0, availableNeutrinos);
    }


    // Unity default functions

    // Awake
    private void Awake() {

        animator = GetComponent<Animator>(); 

        if (neutrinoSprites.Length==0) 
        {
            neutrinoSprites = Resources.LoadAll<Sprite>("Neutrino_Sprites");
        }

        availableNeutrinos = (int) Mathf.Min((float) Flavours.count, (float) neutrinoSprites.Length);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flavourChange());

        idx = randomNeutrino();

        // GetComponent<SpriteRenderer>().sprite = neutrinoSprites[ (int) idx ];

        animator.SetInteger( "flavour", (int) idx );
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

            Flavours index = randomNeutrino();

            while (index == idx) 
            {
                index = randomNeutrino();
            }

            idx = index;

            // GetComponent<SpriteRenderer>().sprite = neutrinoSprites[ (int) idx ];
            animator.SetInteger( "flavour", (int) idx );
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        FlavourDefinition otherFlavour = other.gameObject.GetComponent<FlavourDefinition>();
        
        if (otherFlavour != null) 
        {
            if (otherFlavour.flavour == idx) 
            {
                FlowManager.SetFlowState(GameState.GameOver);
            }
        }
    }
}
