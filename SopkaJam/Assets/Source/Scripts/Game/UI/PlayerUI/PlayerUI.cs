using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject[] _lifecounters; 

    public void UpdateLifeCount(int newLifeCount)
    {
        for (int i = 0; i < _lifecounters.Length - newLifeCount; i++)
        {
            if(_lifecounters[i] != null)
                _lifecounters[i].gameObject.SetActive(false);
        }
    }
}
