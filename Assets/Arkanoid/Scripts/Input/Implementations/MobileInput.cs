namespace MiniIT.INPUT
{
    using MiniIT.SUPPORT.SCREEN;
    using UnityEngine;

    public class MobileInput : IInput, IInputClicker
    {
        private float maxDelayBetweenClick = 0.2f;

        private float firstClickTime = 0;

        private int   maxClick = 2;

        private int   clicked = 0;

        #region IInput
        public Vector2 Position(Transform transform)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector3 touchPosition = ScreenPointPosition.Camera.ScreenToWorldPoint(touch.position);

                return new Vector2(touchPosition.x, transform.position.y);
            }

            return new Vector2(transform.position.x, transform.position.y);
        }
        #endregion

        #region IInputClicker
        public bool OnClicked()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                clicked++;

                if (clicked == 1)
                {
                    firstClickTime = Time.time;
                }

                if (clicked >= maxClick && Time.time - firstClickTime < maxDelayBetweenClick)
                {
                    clicked = 0;

                    firstClickTime = 0;

                    return true;
                }
                else if (clicked > maxClick || Time.time - firstClickTime > maxDelayBetweenClick)
                {
                    clicked = 0;
                }
            }

            return false;
        }
        #endregion
    }
}