using Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : ContentUI
{

    [SerializeField]
    private Button _okayButton;
    
    // Start is called before the first frame update
    void Start()
    {
        _okayButton.onClick.AddListener(Hide);
    }

    private void OnDestroy()
    {
        _okayButton.onClick.RemoveListener(Hide);
    }

}
