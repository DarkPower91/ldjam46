using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWithFlow : MonoBehaviour
{
    public GameState HiddenInFlowState = GameState.MainMenu;

    void Start()
    {
        FlowManager.OnGameStateChanged += OnFlowStateChanged;
    }

    void OnDestroy()
    {
        FlowManager.OnGameStateChanged -= OnFlowStateChanged;
    }

    private void OnFlowStateChanged(GameState newState)
    {
        if(newState == HiddenInFlowState)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
