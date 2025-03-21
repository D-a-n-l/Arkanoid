using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bouncable : MonoBehaviour
{
    [Min(0.01f)]
    [SerializeField]
    private float _baseSpeed = 50;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IForcable forcable))
        {
            float x = transform.position.x - collision.transform.position.x;
            float width = collision.collider.bounds.size.x / 2;

            float bounceAngle = x / width;

            Vector2 newDirection = new Vector2(bounceAngle, 1).normalized;

            _rigidbody.linearVelocity = newDirection * _baseSpeed;
        }
    }
}