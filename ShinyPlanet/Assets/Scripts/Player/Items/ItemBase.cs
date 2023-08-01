using UnityEngine;

namespace Player
{
    public class ItemBase
    {
        public ItemBase(string name)
        {
            this.name = name;
        }

        public virtual void OnSelected()
        {
            Debug.Log(string.Format("[ItemBase] Selected: {0}", name));
        }

        public virtual void OnDeselected()
        {
        }

        public virtual void OnMousePress()
        {
            Debug.Log(string.Format("[ItemBase] Mouse pressed: {0}", name));
        }

        public string name;
    }
}
