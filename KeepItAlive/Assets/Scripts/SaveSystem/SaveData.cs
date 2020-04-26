using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : Savable
{
    private static List<Unlockable> _DexUnlockStatus = new List<Unlockable>();
    private static List<float> _HighestScores = new List<float>();

    public static List<Unlockable> DexUnlockStatus
    {
        get
        {
            return _DexUnlockStatus;
        }
    }
    public static List<float> HighestScores
    {
        get
        {
            return _HighestScores;
        }
    }

    private string dexKey = "Dex";
    private string scoreKey = "Scores";

    protected override void OnSave()
    {
        SaveEvents.OnDataUpdateNeeded();

        SaveLoad.Save<List<Unlockable>>(_DexUnlockStatus, dexKey);
        SaveLoad.Save<List<float>>(_HighestScores, scoreKey);
    }

    protected override void OnLoad()
    {
        if(SaveLoad.SaveExist(dexKey))
        {
            _DexUnlockStatus = SaveLoad.Load<List<Unlockable>>(dexKey);
        }
        if(SaveLoad.SaveExist(scoreKey))
       {
            _HighestScores = SaveLoad.Load<List<float>>(scoreKey);
       } 
    }
}
