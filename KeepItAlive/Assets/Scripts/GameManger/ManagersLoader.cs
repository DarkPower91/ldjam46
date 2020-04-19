﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersLoader : MonoBehaviour
{
    #region Serialized fields
    [SerializeField]
    private  GameObject m_FlowManager;
    [SerializeField]
    private GameObject m_MusicManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if(!GameObject.FindGameObjectWithTag("MusicManager"))
        {
            GameObject musicManager = Instantiate(m_MusicManager, transform.position, Quaternion.identity) as GameObject;
            DontDestroyOnLoad(musicManager);
        }

        if(!GameObject.FindGameObjectWithTag("FlowManager"))
        {
            GameObject flowManager = Instantiate(m_FlowManager, transform.position, Quaternion.identity) as GameObject;
            DontDestroyOnLoad(flowManager);
        }
    }
}
