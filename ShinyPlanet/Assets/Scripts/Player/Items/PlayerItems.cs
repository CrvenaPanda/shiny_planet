using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerItems : MonoBehaviour
    {
        private void Start()
        {
            _items = new List<ItemBase>();
            _items.Add(new ItemBase("Miner"));
            _items.Add(new ItemBase("Dirt"));
            _items.Add(new ItemBase("Pistol"));
        }

        private void OnEnable()
        {
            UI.UIController.onItemSelected += OnItemSelected;
        }

        private void OnDisable()
        {
            UI.UIController.onItemSelected -= OnItemSelected;
        }

        private void OnItemSelected(int itemIndex)
        {
            if (_selectedItem != null)
            {
                _selectedItem.OnDeselected();
            }

            if (itemIndex < 0 || itemIndex > _items.Count - 1)
            {
                return;
            }

            _selectedItem = _items[itemIndex];
            _selectedItem.OnSelected();
        }

        private List<ItemBase> _items;
        private ItemBase _selectedItem = null;
    }
}
