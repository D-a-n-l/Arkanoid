using UnityEngine;
using MiniIT.Enums;

namespace MiniIT.SupportScreen
{
    public static class ScreenPointPosition
    {
        private static Camera mainCamera = Camera.main;

        public static Vector3 Get(ScreenSide side)
        {
            Vector3 position;

            switch (side)
            {
                case ScreenSide.Top:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                    break;

                case ScreenSide.Bottom:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
                    break;

                case ScreenSide.Right:
                    position = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
                    break;

                case ScreenSide.Left:
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
                case ScreenSide.Top:
                    size = new Vector2(GetTopRightPoint().x * 2, 1f);
                    break;

                case ScreenSide.Bottom:
                    size = new Vector2(GetTopRightPoint().x * 2, 1f);
                    break;

                case ScreenSide.Right:
                    size = new Vector2(1f, GetTopRightPoint().y * 2);
                    break;

                case ScreenSide.Left:
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