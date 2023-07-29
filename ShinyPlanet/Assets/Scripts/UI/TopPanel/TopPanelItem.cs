using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class TopPanelItem : MonoBehaviour
    {
        public void SetSelectionColor(Color color)
        {
            _selection.color = color;
        }

        [SerializeField]
        private UnityEngine.UI.Image _selection;
    }
}
