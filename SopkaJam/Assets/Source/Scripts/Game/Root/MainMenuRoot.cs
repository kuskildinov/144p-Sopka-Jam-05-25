using UnityEngine;

public class MainMenuRoot : CompositeRoot
{
    [SerializeField] private MainMenuPanel _mainMenuPanel;
    public override void Compose()
    {
        _mainMenuPanel.Initialize();
    }
}
