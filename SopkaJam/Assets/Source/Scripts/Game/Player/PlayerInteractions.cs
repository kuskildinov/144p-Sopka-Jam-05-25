using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Player _player;
    private IInput _input;
    private Trigger _currentTrigger;
    private bool _isInsideTrigger;
   public void Initialize(Player player,IInput input)
    {
        _player = player;
        _input = input;
    }

    private void Update()
    {
        if(_input.Interaction())
        {
            TryActivateTrigger();
        }
    }

    private void TryActivateTrigger()
    {
        if (_isInsideTrigger == false || _currentTrigger == null)
            return;
        _currentTrigger.Activate();
        _currentTrigger.gameObject.SetActive(false);
        _currentTrigger = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Trigger>(out Trigger trigger))
        {
            _isInsideTrigger = true;
            _currentTrigger = trigger;    
            if (_currentTrigger.Type == TriggetType.PASSIVE_DIALOG)
            {
                _currentTrigger.Activate();
                _currentTrigger = null;              
            }          
        }
        if (collision.gameObject.TryGetComponent<SwapHouseTrigger>(out SwapHouseTrigger swqpTrigger))
        {
            swqpTrigger.TeleportPlayer(_player.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Trigger>(out Trigger trigger))
        {
            _isInsideTrigger = false;
            _currentTrigger = null;        
        }
    }
}
