using UnityEngine;

namespace MiniIT.SupportScreen
{
    public static class ScreenPointPosition
    {
        private static Camera mainCamera = Camera.main;

        public static Vector3 Get(Enums.ScreenSide side)
        {
            Vector3 position;

            switch (side)
            {
                case Enums.ScreenSide.Top:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                    break;

                case Enums.ScreenSide.Bottom:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
                    break;

                case Enums.ScreenSide.Right:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
                    break;

                case Enums.ScreenSide.Left:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
                    break;

                default:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                    break;
            }

            return position;
        }

        public static Vector2 GetTopRightPoint()
        {
            return mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        public static Vector2 GetSizeSide(Enums.ScreenSide side)
        {
            Vector2 size;

            switch (side)
            {
                case Enums.ScreenSide.Top:
                    size = new Vector2(GetTopRightPoint().x * 2, 1f);
                    break;

                case Enums.ScreenSide.Bottom:
                    size = new Vector2(GetTopRightPoint().x * 2, 1f);
                    break;

                case Enums.ScreenSide.Right:
                    size = new Vector2(1f, GetTopRightPoint().y * 2);
                    break;

                case Enums.ScreenSide.Left:
                    size = new Vector2(1f, GetTopRightPoint().y * 2);
                    break;

                default:
                    size = new Vector2(GetTopRightPoint().x * 2, 1f);
                    break;
            }

            return size;
        }
    }
}