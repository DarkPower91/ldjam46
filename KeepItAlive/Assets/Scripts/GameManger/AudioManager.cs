using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip m_MainMenuSound = null;
    public AudioClip m_InGameSound = null;

    private AudioSource m_BackgroundMusicSource =  null;

    void Start()
    {
        m_BackgroundMusicSource = GetComponent<AudioSource>();
        
        m_BackgroundMusicSource.clip = m_MainMenuSound;
        m_BackgroundMusicSource.Play();

        FlowManager.OnGameStateChanged += OnGameStateChanged;
    }

    void OnGameStateChanged(GameState newState)
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
        }
        m_BackgroundMusicSource.Play();
    }
}
