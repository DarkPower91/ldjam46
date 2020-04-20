using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip m_MainMenuSound = null;
    public AudioClip m_InGameSound = null;
    public AudioClip m_InCreditsEasterEgg = null;

    private AudioSource m_BackgroundMusicSource =  null;
    private GameState m_PreviousGameState = GameState.MainMenu;

    void Start()
    {
        m_BackgroundMusicSource = GetComponent<AudioSource>();
        
        m_BackgroundMusicSource.clip = m_MainMenuSound;
        m_BackgroundMusicSource.Play();

        FlowManager.OnGameStateChanged += OnGameStateChanged;
    }

    void OnDestroy() 
    {
        FlowManager.OnGameStateChanged -= OnGameStateChanged;
    }

    void OnGameStateChanged(GameState newState)
    {
        if(newState != m_PreviousGameState)
        {
            m_BackgroundMusicSource.Stop();
            switch(newState)
            {
                case GameState.MainMenu:
                {
                    m_BackgroundMusicSource.clip = m_MainMenuSound;
                    break;
                }
                case GameState.InGame:
                {
                    m_BackgroundMusicSource.clip = m_InGameSound;
                    break;
                }
                case GameState.InCredits:
                {
                    m_BackgroundMusicSource.clip = m_InCreditsEasterEgg;
                    break;
                }
            }
            m_PreviousGameState = newState;
            m_BackgroundMusicSource.Play();
        }
    }
}
