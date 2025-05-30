using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Player _player;
    private IInput _input;
    private Trigger _currentTrigger;   
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
        if (_currentTrigger == null)
            return;
        _currentTrigger.Activate();
        _currentTrigger.gameObject.SetActive(false);
        _currentTrigger = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Trigger>(out Trigger trigger))
        {
            _player.OnPlayerEnterTrigger(trigger,true);
            _currentTrigger = trigger;           

            if (_currentTrigger.Type == TriggetType.PASSIVE_DIALOG || _currentTrigger.Type == TriggetType.GO_TO_LOCATION_PASSIVE)
            {                
                TryActivateTrigger();             
            }          
            else if(_currentTrigger.Type == TriggetType.DETECTION || _currentTrigger.Type == TriggetType.TAKE_DAMAGE)
            {
                _currentTrigger = trigger;
                _currentTrigger.Activate();
                _currentTrigger = null;               
            }
        }
        if (collision.gameObject.TryGetComponent<SwapHouseTrigger>(out SwapHouseTrigger swqpTrigger))
        {
            swqpTrigger.TeleportPlayer(_player.gameObject);         
        }
        if(collision.gameObject.TryGetComponent<Bush> (out Bush bush))
        {
           
            _currentTrigger = trigger;
            _currentTrigger.Activate();           
            _currentTrigger = null;          
        }        
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Trigger>(out Trigger trigger))
        {
            _player.OnPlayerExitTrigger();
            _currentTrigger = null;        
        }
    }
}
