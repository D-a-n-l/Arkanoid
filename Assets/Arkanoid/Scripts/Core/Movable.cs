using UnityEngine;
using Zenject;

namespace MiniIT.Core
{
    public class Movable : MonoBehaviour, IForcable
    {
        [Inject]
        private IInput input = null;

        private void Update()
        {
            transform.position = input.Position(transform);
        }

        #region IForcable
        public Vector2 Force(Transform enterObject, Collision2D collision)
        {
            float x = enterObject.position.x - collision.transform.position.x;
            float width = collision.collider.bounds.size.x / 2;

            float bounceAngle = x / width;

            return new Vector2(bounceAngle, 1).normalized;
        }
        #endregion
    }
}