using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionPanel : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _closeButton;

    private ItemsPanel _itemsPanel;
    public int Index => _index;

    public void Initialize(ItemsPanel itemsPanel)
    {
        _itemsPanel = itemsPanel;
    }

   public void Open()
    {
        _panel.gameObject.SetActive(true);
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    public void Close()
    {
        _panel.gameObject.SetActive(false);
        _closeButton.onClick.RemoveAllListeners();
    }

    private void OnCloseButtonClicked()
    {
        _itemsPanel.CloseDescription(this);
    }

}
