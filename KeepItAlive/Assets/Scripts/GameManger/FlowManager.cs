using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    InCredits,
    InGame,
    InPause,
    GameOver
}

public delegate void GameStateChanged(GameState newState);

public class FlowManager : MonoBehaviour
{
    #region Private fields
    private static GameState m_CurrentState = GameState.MainMenu;
    #endregion

    public static event GameStateChanged OnGameStateChanged = null;

    public static GameState GetGameState()
    {
        return m_CurrentState;
    }

    public static void SetFlowState(GameState state)
    {
        m_CurrentState = state;
        
        switch(m_CurrentState)
        {
            case GameState.MainMenu:
            case GameState.InGame:
            case GameState.GameOver:
            case GameState.InCredits:
            {
                Time.timeScale = 1;
                break;
            }
            case GameState.InPause:
            {
                Time.timeScale = 0;
                break;
            }
        }
        
        if(OnGameStateChanged != null)
        {
            OnGameStateChanged(m_CurrentState);
        }
    }
}
