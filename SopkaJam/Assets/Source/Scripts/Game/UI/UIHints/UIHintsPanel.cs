using UnityEngine;

public class UIHintsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _interactionHintPanel;
    [SerializeField] private GameObject _dashHintPanel;
    [SerializeField] private GameObject _levelHintPanel;

    public void ShowHintPanelByTrigger(Trigger trigger)
    {
        switch (trigger.Type)
        {
            case TriggetType.TAKE_ITEM:
                {
                    _interactionHintPanel.gameObject.SetActive(true);
                    break;
                }
            case TriggetType.GO_TO_LOCATION_ACTIVE:
                {
                    _interactionHintPanel.gameObject.SetActive(true);
                    break;
                }

            case TriggetType.LEVEL_ACTIVATION:
                {
                    if (trigger.Index == 0)
                        _interactionHintPanel.gameObject.SetActive(true);
                    else if (trigger.Index == 1)
                        _levelHintPanel.gameObject.SetActive(true);
                    break;
                }
        }
    }

    public void ShowHintPanelByType(HintsType type)
    {
        switch (type)
        {
            case HintsType.INTERACTION:
                {
                    _interactionHintPanel.gameObject.SetActive(true);
                    break;
                }
            case HintsType.DASH:
                {
                    _dashHintPanel.gameObject.SetActive(true);
                    break;
                }
            case HintsType.LEVEL:
                {
                    _levelHintPanel.gameObject.SetActive(true);
                    break;
                }
        }

    }

    public void CloseAllHints()
    {       
        if (_interactionHintPanel != null)
            _interactionHintPanel.gameObject.SetActive(false);
        if (_dashHintPanel != null)
            _dashHintPanel.gameObject.SetActive(false);
        if(_levelHintPanel != null)
            _levelHintPanel.gameObject.SetActive(false);
    }
}

public enum HintsType
{
    INTERACTION,
    DASH,
    LEVEL,
}

