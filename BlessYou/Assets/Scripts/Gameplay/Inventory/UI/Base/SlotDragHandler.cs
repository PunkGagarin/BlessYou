using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.Inventory.UI.Base
{
    public class SlotDragHandler<T> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Canvas canvas; // Canvas, чтобы учитывать его масштаб
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private Vector2 originalPosition;

        private T _type;

        public Action<T> OnItemDropped = delegate { };

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponentInParent<Canvas>(); // Находим Canvas, на котором находится объект
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Сохраняем изначальную позицию, чтобы вернуть объект, если нужно
            originalPosition = rectTransform.anchoredPosition;

            // Делаем объект "прозрачным" для взаимодействий (если требуется)
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Перемещаем объект на основе курсора мыши
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Проверяем попадание
            if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropArea"))
            {
                OnItemDropped.Invoke(_type);
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
    }
}