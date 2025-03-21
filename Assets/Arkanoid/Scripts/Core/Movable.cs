using UnityEngine;

public class Movable : MonoBehaviour, IForcable
{
    [Min(0.01f)]
    [SerializeField]
    private float _speed;

    private float edgeX;

    private float edgeXX;

    private void Start()
    {
        edgeX = DetectingEdgeScreen.Detect(Enums.Direction.Left).x;
        edgeXX = DetectingEdgeScreen.Detect(Enums.Direction.Right).x;
    }

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

            transform.position = new Vector2(
                Mathf.Clamp(touchPosition.x, edgeX, edgeXX),
                transform.position.y
            );
        }
#endif
    }
}