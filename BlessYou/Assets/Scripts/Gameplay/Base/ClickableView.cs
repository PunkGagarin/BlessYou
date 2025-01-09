using System;
using UnityEngine;

namespace Gameplay.Base
{
    public abstract class ClickableView : MonoBehaviour
    {
        [SerializeField]
        protected Collider2D _collider2D;

        public event Action OnClicked = delegate { };

        public virtual void OnMouseDown()
        {
            Interact();
        }

        protected virtual void Interact()
        {
            OnClicked.Invoke();
        }
    }
}