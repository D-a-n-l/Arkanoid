using UnityEngine;
using MiniIT.ENUMS;

namespace MiniIT.SUPPORT.SCREEN
{
    public static class ScreenPointPosition
    {
        public static Camera Camera { get; private set; } = Camera.main;

        public static Vector3 Get(ScreenSide side)
        {
            Vector3 position;

            switch (side)
            {
                case ScreenSide.Top:
                    position = Camera.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                    break;

                case ScreenSide.Bottom:
                    position = Camera.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
                    break;

                case ScreenSide.Right:
                    position = Camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
                    break;

                case ScreenSide.Left:
                    position = Camera.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
                    break;

                default:
                    position = Camera.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                    break;
            }

            position = new Vector3(position.x, position.y, 0f);

            return position;
        }

        public static Vector2 GetTopRightPoint()
        {
            return Camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        public static Vector2 GetSizeSide(ScreenSide side)
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