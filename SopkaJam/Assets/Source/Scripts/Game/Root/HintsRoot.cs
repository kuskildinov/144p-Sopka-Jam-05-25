using UnityEngine;

public class HintsRoot : CompositeRoot
{
    [SerializeField] private UIHintsPanel _hintsPanel;
    public override void Compose()
    {
        _hintsPanel.CloseAllHints();
    }

    public void ShowHintPanelByTrigger(Trigger trigger) => _hintsPanel.ShowHintPanelByTrigger(trigger);
    public void ShowHintByType(HintsType type) => _hintsPanel.ShowHintPanelByType(type);
    public void CloseAllHints() => _hintsPanel.CloseAllHints();
}
