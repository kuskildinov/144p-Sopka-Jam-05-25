using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenTiger : MonoBehaviour
{    
    public void Activate(Transform _targetPosition)
    {
        StartCoroutine(MovmentRoutine(_targetPosition));
    }

    private IEnumerator MovmentRoutine(Transform _targetPosition)
    {
        yield return null;
    }
}
