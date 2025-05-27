using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Triggers Data", menuName = "Triggers Data")]
public class TriggersDataSO : ScriptableObject
{
    [SerializeField] private List<ChangeLocationData> _locationsData;

    public string GetLoactionNameByIndex(int index)
    {
        foreach (ChangeLocationData data in _locationsData)
        {
            if(data.Index == index)
            {
                return data.SceneName;
            }
        }

        return string.Empty;
    }
}

[Serializable]
public class ChangeLocationData
{
    public int Index;
    public string SceneName;
}

