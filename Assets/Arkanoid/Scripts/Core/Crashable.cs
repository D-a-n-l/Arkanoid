using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Crashable : MonoBehaviour
{
    [SerializeField]
    private HitPreset[] _hitToDestroy = new HitPreset[1];

    private int _currentHit = 0;

    [SerializeField]
    private UnityEvent OnHitted;
    public SpriteRenderer _spriteRenderer;
    private void OnHit()
    {
        _currentHit++;

        OnHitted?.Invoke();

        if (_currentHit >= _hitToDestroy.Length)
            Destroy(gameObject);
        else
            _spriteRenderer.sprite = _hitToDestroy[_currentHit].Sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Bouncable>())
        {
            OnHit();
        }
    }
}

[System.Serializable]
public class HitPreset
{
    public Sprite Sprite;
}