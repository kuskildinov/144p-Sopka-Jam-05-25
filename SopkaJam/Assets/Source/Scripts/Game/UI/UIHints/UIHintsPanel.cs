using UnityEngine;

public class UIHintsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _interactionHintPanel;
    [SerializeField] private GameObject _dashHintPanel;

    public void ShowHintPanelByTrigger(Trigger trigger)
    {
        switch (trigger.Type)
        {
            case TriggetType.TAKE_ITEM:
                {
                    _interactionHintPanel.gameObject.SetActive(true);
                    break;
                }
            case TriggetType.GO_TO_LOCATION:
                {
                    _interactionHintPanel.gameObject.SetActive(true);
                    break;
                }
            case TriggetType.LEVEL_ACTIVATION:
                {
                    _interactionHintPanel.gameObject.SetActive(true);
                    break;
                }
        }
    }

    public void CloseAllHints()
    {
        _interactionHintPanel.gameObject.SetActive(false);
        _dashHintPanel.gameObject.SetActive(false);
    }
}

public enum HintsType
{
    INTERACTION,
    DASH,
}

