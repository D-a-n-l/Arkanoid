namespace MiniIT.Input
{
    using MiniIT.SupportScreen;
    using UnityEngine;

    public class MobileInput : IInput
    {
        #region IInput
        public Vector2 Position(Transform transform)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector3 touchPosition = ScreenPointPosition.Camera.ScreenToWorldPoint(touch.position);

                return new Vector2(touchPosition.x, transform.position.y);
            }

            return Vector2.zero;
        }
        #endregion
    }
}