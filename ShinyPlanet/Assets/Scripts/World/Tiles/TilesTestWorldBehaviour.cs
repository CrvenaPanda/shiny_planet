using UnityEngine;

namespace World.Tiles
{
    public class TilesTestWorldBehaviour : MonoBehaviour
    {
        private void Start()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y > -_height; y--)
                {
                    SpawnTile(x, y);
                }
            }
        }

        private void SpawnTile(int x, int y)
        {
            var tile = new GameObject();
            tile.name = x.ToString() + ", " + y.ToString();
            tile.transform.localPosition = new Vector3(x, y, 0);
            tile.transform.parent = this.transform;

            var spriteRenderer = tile.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _sprite;
        }

        [SerializeField]
        private int _width = 100;

        [SerializeField]
        private int _height = 1;

        [SerializeField]
        private Sprite _sprite;

        [SerializeField]
        private Texture _texture;
    }
}
