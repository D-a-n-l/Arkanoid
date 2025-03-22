using UnityEngine;


public class Movable : MonoBehaviour, IForcable
{
    private void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            transform.position = new Vector2(
                Mathf.Clamp(touchPosition.x, -10, 10),
                transform.position.y
            );
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector2(touchPosition.x, transform.position.y);
        }
#endif
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