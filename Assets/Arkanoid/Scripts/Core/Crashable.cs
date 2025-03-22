using UnityEngine;
using UnityEngine.Events;

namespace MiniIT.Core
{
    [RequireComponent(typeof(Collider2D))]
    public class Crashable : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;

        [Space(10)]
        [SerializeField]
        private Sprite[]       hitToDestroy = new Sprite[1];

        [Space(10)]
        [SerializeField]
        private UnityEvent     onHitted = new UnityEvent();

        [SerializeField]
        private UnityEvent     onDestroyed = new UnityEvent();

        private int            currentHit = 0;

        private void OnHit(int damage)
        {
            currentHit += damage;

            onHitted?.Invoke();

            if (currentHit >= hitToDestroy.Length)
            {
                onDestroyed?.Invoke();

                Destroy(gameObject);
            }
            else
            {
                if (hitToDestroy[currentHit] != null)
                {
                    spriteRenderer.sprite = hitToDestroy[currentHit];
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.parent.TryGetComponent(out IDamagable damagable))
            {
                OnHit(damagable.GetDamage());
            }
        }
    }
}