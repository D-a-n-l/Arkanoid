namespace MiniIT.INPUT
{
    using UnityEngine;
    using MiniIT.SUPPORT.SCREEN;

    public class DesktopInput : IInput, IInputClicker
    {
        #region IInput
        public Vector2 Position(Transform transform)
        {
            Vector2 mousePosition = ScreenPointPosition.Camera.ScreenToWorldPoint(Input.mousePosition);

            return new Vector2(mousePosition.x, transform.position.y);
        }
        #endregion

        #region IInputClicker
        public bool OnClicked()
        {
            if (Input.GetMouseButtonDown(0))
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}