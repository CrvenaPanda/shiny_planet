using System;

namespace UI
{
    public static class UIController
    {
        public static void ItemSelected(int itemIndex)
        {
            onItemSelected?.Invoke(itemIndex);
        }

        public static event Action<int> onItemSelected;
    }
}
