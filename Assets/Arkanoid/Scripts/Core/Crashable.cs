using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Crashable : MonoBehaviour
{
    [Min(1)]
    [SerializeField]
    private int _hitToDestroy = 3;

    private int _currentHit = 0;

    [SerializeField]
    private UnityEvent OnHitted;

    private void OnHit()
    {
        _currentHit++;

        OnHitted?.Invoke();

        if (_currentHit >= _hitToDestroy)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Bouncable>())
        {
            OnHit();
        }
    }
}