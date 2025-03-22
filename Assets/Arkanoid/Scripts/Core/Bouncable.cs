using UnityEngine;
using UnityEngine.Events;

namespace MiniIT.Core
{
    public class Bouncable : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private Rigidbody2D rigidbody = null;

        [Space(10)]
        [Min(0.01f)]
        [SerializeField]
        private float       speed = 50f;

        [Min(1)]
        [SerializeField]
        private int         damage = 1;

        [Space(10)]
        [SerializeField]
        private UnityEvent  onForced = new UnityEvent();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out IForcable forcable))
            {
                OnForce(forcable, collision);
            }
        }

        private void OnForce(IForcable forcable, Collision2D collision)
        {
            rigidbody.linearVelocity = forcable.Force(transform, collision) * speed;

            onForced?.Invoke();
        }

        #region IDamagable
        public int GetDamage()
        {
            return damage;
        }
        #endregion
    }
}