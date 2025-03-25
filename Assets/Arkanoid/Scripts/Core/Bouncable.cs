using UnityEngine;
using UnityEngine.Events;

namespace MiniIT.Core
{
    [RequireComponent(typeof(Collider2D))]
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

        public void ChangeBodyType(RigidbodyType2D type)
        {
            rigidbody.bodyType = type;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out IForcable forcable))
            {
                OnForce(forcable, collision);
            }

            onForced?.Invoke();
        }

        private void OnForce(IForcable forcable, Collision2D collision)
        {
            rigidbody.linearVelocity = forcable.Force(transform, collision) * speed;
        }

        public void OnZeroingVelocity()
        {
            rigidbody.linearVelocity = Vector3.zero;
        }

        #region IDamagable
        public int GetDamage()
        {
            return damage;
        }
        #endregion
    }
}