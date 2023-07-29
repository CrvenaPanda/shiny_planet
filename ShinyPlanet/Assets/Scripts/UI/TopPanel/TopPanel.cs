using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class TopPanel : MonoBehaviour
    {
        public void SelectItem(int index)
        {
            SetItemSelectionColor(_selectedItem, Color.clear);
            _selectedItem = index;
            SetItemSelectionColor(_selectedItem, _selectionColor);
        }

        private void Start()
        {
            CollectItems();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                SelectItem(-1);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                SelectItem(0);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                SelectItem(1);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                SelectItem(2);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                SelectItem(3);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                SelectItem(4);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                SelectItem(5);
                return;
            }
        }

        private void SetItemSelectionColor(int itemIndex, Color color)
        {
            if (itemIndex < 0 || itemIndex > 5)
            {
                return;
            }

            _items[itemIndex].SetSelectionColor(color);
        }

        private void CollectItems()
        {
            _items = new List<TopPanelItem>();
            foreach (Transform child in this.transform)
            {
                _items.Add(child.GetComponent<TopPanelItem>());
            }
        }

        [SerializeField]
        private Color _selectionColor;

        private List<TopPanelItem> _items;
        private int _selectedItem = -1;
    }
}
