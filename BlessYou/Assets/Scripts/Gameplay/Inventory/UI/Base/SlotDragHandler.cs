using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.Inventory.UI.Base
{
    public class SlotDragHandler<T> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private Vector2 originalPosition;

        public T Type { get; set; }
        public bool CanDrag { get; set; } = true;

        public Action<T> OnItemDropped = delegate { };

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponentInParent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!CanDrag) return;
            // Сохраняем изначальную позицию, чтобы вернуть объект, если нужно
            originalPosition = rectTransform.anchoredPosition;

            // Делаем объект "прозрачным" для взаимодействий (если требуется)
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!CanDrag) return;
            // Перемещаем объект на основе курсора мыши
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!CanDrag) return;
            // Проверяем попадание
            if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropArea"))
            {
                OnItemDropped.Invoke(Type);
            }
            else
            {
                Debug.Log("Мимо!");
                // Возвращаем объект в исходное положение
            }

            rectTransform.anchoredPosition = originalPosition;

            // Восстанавливаем взаимодействие объекта
            canvasGroup.blocksRaycasts = true;
        }

        private void OnDisable()
        {
            canvasGroup.blocksRaycasts = true;
        }
    }
}