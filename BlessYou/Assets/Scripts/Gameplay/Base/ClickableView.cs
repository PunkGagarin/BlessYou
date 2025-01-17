using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.Base
{
    public abstract class ClickableView : MonoBehaviour
    {
        [SerializeField]
        protected Collider2D _collider2D;

        public event Action OnClicked = delegate { };

        public virtual void OnMouseDown()
        {
            if (IsPointerOverUI())
                return;

            Interact();
        }

        private bool IsPointerOverUI()
        {
            return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
        }

        protected virtual void Interact()
        {
            OnClicked.Invoke();
        }
    }
}