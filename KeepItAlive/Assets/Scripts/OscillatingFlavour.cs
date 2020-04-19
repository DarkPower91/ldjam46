using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class OscillatingFlavour : MonoBehaviour
{
    #region Public fields
    [Readonly]
    public Flavours CurrentFlavour = Flavours.electronic;
    public FlavourDefinition m_GameOverFlavorMessage = null;
    #endregion

    #region Private fields
    private float changeTime = 1;
    private int availableNeutrinos = (int)Flavours.count;
    private Animator animator;
    private Flavours m_NextFlavour;
    #endregion

    private Flavours randomNeutrino() 
    {
        return  (Flavours) Random.Range(0, availableNeutrinos);
    }

    private void Awake() 
    {
        animator = GetComponent<Animator>(); 
    }

    void Start()
    {
        StartCoroutine(flavourChange());
        m_NextFlavour = CurrentFlavour = randomNeutrino();
        animator.SetInteger( "flavour", (int) CurrentFlavour );
    }

    void Update()
    {
        if(m_NextFlavour == CurrentFlavour)
        {
            m_NextFlavour = randomNeutrino();
        }
    }

    private IEnumerator flavourChange() 
    {
        while (true) 
        {    
            yield return new WaitForSeconds(changeTime); 
            CurrentFlavour = m_NextFlavour;
            animator.SetInteger( "flavour", (int) CurrentFlavour );
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        FlavourDefinition otherFlavour = other.gameObject.GetComponent<FlavourDefinition>();
        if (otherFlavour != null) 
        {
            if (otherFlavour.flavour == CurrentFlavour) 
            {
                FlowManager.SetFlowState(GameState.GameOver);
                m_GameOverFlavorMessage.SetFlavour(CurrentFlavour);
            }
        }
    }
}
