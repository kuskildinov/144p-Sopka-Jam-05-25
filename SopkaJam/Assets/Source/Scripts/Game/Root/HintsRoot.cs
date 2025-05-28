using UnityEngine;

public class HintsRoot : CompositeRoot
{
    [SerializeField] private UIHintsPanel _hintsPanel;
    public override void Compose()
    {
        _hintsPanel.CloseAllHints();
    }

    public void ShowHintPanelByTrigger(Trigger trigger) => _hintsPanel.ShowHintPanelByTrigger(trigger);
    public void CloseAllHints() => _hintsPanel.CloseAllHints();
}
