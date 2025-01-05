using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectLevelUI : BaseUIObject
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button levelOne;
        [SerializeField] private Button levelTwo;
        [SerializeField] private Button levelThree;

        private void Awake()
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
            levelOne.onClick.AddListener(OnLevelOneClicked);
            levelTwo.onClick.AddListener(OnLevelTwoClicked);
            levelThree.onClick.AddListener(OnLevelThreeClicked);
        }

        private void OnDestroy()
        {
            backButton.onClick.RemoveListener(OnBackButtonClicked);
            levelOne.onClick.RemoveListener(OnLevelOneClicked);
            levelTwo.onClick.RemoveListener(OnLevelTwoClicked);
            levelThree.onClick.RemoveListener(OnLevelThreeClicked);
        }

        private void OnBackButtonClicked()
        {
            Hide();
        }

        private void OnLevelOneClicked()
        {
            //todo
        }

        private void OnLevelTwoClicked()
        {
            //todo
        }

        private void OnLevelThreeClicked()
        {
            //todo
        }
    }
}