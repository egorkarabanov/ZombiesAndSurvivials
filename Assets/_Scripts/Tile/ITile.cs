using _Scripts.Item;
using _Scripts.Item.Unit;
using UnityEngine;

namespace _Scripts.Tile {
    public abstract class ITile : MonoBehaviour {
        public int G;
        public int H;

        public int F {
            get { return G + H; }
        }

        public ITile previous;

        [SerializeField] public Color _baseColor;
        public SpriteRenderer _renderer;
        [SerializeField] private bool _isWalkable;

        public IItem OccupiedUnit;
        public float x, y;
        public bool Walkable => _isWalkable && OccupiedUnit == null;

        public void Init(float X, float Y) {
            x = X;
            y = Y;
        }

        public void Render() {
            _renderer.color = _baseColor;
        }

        public void SetUnit(IItem unit) {
            if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
            unit.transform.position = transform.position;
            OccupiedUnit = unit;
            unit.OccupiedTile = this;
            var pos = unit.transform.position;
            unit.transform.position = new Vector3(pos.x, pos.y, -1);
        }
    }
}