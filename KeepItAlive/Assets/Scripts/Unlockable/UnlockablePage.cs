using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockablePage : MonoBehaviour
{
    [SerializeField]
    private Unlockable m_UnlockableType = Unlockable.Invalid;

    void Awake()
    {
        if(m_UnlockableType != Unlockable.Invalid && SaveData.DexUnlockStatus != null && SaveData.DexUnlockStatus.Contains(m_UnlockableType))
        {
            gameObject.SetActive(true);
            return;
        }
        gameObject.SetActive(false);

    }
}
