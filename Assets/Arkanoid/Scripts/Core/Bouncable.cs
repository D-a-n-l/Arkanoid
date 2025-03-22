using UnityEngine;

namespace MiniIT.Core
{
    public class Bouncable : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private Rigidbody2D rigidbody = null;

        [Min(0.01f)]
        [SerializeField]
        private float       speed = 50f;

        [Min(1)]
        [SerializeField]
        private int         damage = 1;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out IForcable forcable))
            {
                rigidbody.linearVelocity = forcable.Force(transform, collision) * speed;
            }
        }

        #region IDamagable
        public int GetDamage()
        {
            return damage;
        }
        #endregion
    }
}