namespace MiniIT.Input
{
    using UnityEngine;
    using MiniIT.SupportScreen;

    public class DesktopInput : IInput
    {
        #region IInput
        public Vector2 Position(Transform transform)
        {
            Vector2 mousePosition = ScreenPointPosition.Camera.ScreenToWorldPoint(Input.mousePosition);

            return new Vector2(mousePosition.x, transform.position.y);
        }
        #endregion
    }
}