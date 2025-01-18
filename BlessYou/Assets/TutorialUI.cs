using System;
using Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : ContentUI
{

    private bool isFirstTimeShow = true;

    [SerializeField]
    private Button _okayButton;

    // Start is called before the first frame update
    void Start()
    {
        _okayButton.onClick.AddListener(Hide);
    }

    private void OnEnable()
    {
        if (!isFirstTimeShow) return;
        
        
        Time.timeScale = 0f;
    }

    public override void Hide()
    {
        base.Hide();
        isFirstTimeShow = false;
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        _okayButton.onClick.RemoveListener(Hide);
    }

}