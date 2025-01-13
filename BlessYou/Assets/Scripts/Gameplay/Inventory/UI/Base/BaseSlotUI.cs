using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory
{
    public class BaseSlotUI<T> : MonoBehaviour
    {

        [field: SerializeField]
        public Button Button { get; private set; }

        [field: SerializeField]
        public T Type { get; private set; }
    }
}