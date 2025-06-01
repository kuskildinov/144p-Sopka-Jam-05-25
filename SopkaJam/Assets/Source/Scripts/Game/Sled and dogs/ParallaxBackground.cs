using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private LevelRoot _levelRoot;
    [SerializeField] private string _nextScenename;
    public float[] layerSpeeds;
    public Transform[] layers;

    public TimerToEnd timerToEnd;
    private bool timerEnd;
    private bool houseMove;   

    private float spriteWidth = 48f;


    void Update()
    {
        if(timerToEnd != null)
        {
            timerEnd = timerToEnd._timeIsOver;
            houseMove = timerToEnd._stopHouse;
        }      
        

        if (timerEnd == false)
        {
            IncreaseSpeedByTime();
        }
        else
        {
            if (houseMove == true)
            {
                DecreaseSpeedOnFinish();
                StartCoroutine(LoadNextSceneRoutine());
            }           
            
        }

        for (int i = 0; i < layers.Length; i++)
        {
            Movment(layers[i], layerSpeeds[i]);
        }

        for (int i = 0; i < layers.Length; i++)
        {
            LayersTeleportation();
        }
    }

    private void Movment(Transform layer, float speed)
    {
        layer.position += Vector3.left * speed * Time.deltaTime;
    }

    private void LayersTeleportation()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            if (layers[i].position.x < -48) // ”кажи нужное значение
            {
                layers[i].position += Vector3.right * (spriteWidth * 2); // —мести вперЄд
            }
        }
    }

    private void IncreaseSpeedByTime()
    {
        for (int i = 0; i < layers.Length-1; i++)
        {
            layerSpeeds[i] += 0.0005f;
        }
    }

    private void DecreaseSpeedOnFinish()
    {

        for (int i = 0; i < layers.Length-1; i++)
        {
            layerSpeeds[i] = 0;
        }
    }

    private IEnumerator LoadNextSceneRoutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        _levelRoot.LoadSceneByName(_nextScenename);
    }


    
}
