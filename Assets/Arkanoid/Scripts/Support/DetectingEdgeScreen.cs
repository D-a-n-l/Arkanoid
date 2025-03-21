using UnityEngine;

public class DetectingEdgeScreen
{
    public static Vector2 Detect(Enums.Direction direction)
    {
        Vector2 position;

        switch (direction)
        {
            case Enums.Direction.Top:
                position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                break;
            case Enums.Direction.TopRight:
                position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
                break;
            case Enums.Direction.TopLeft:
                position = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
                break;
            case Enums.Direction.Bottom:
                position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
                break;
            case Enums.Direction.BottomRight:
                position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
                break;
            case Enums.Direction.BottomLeft:
                position = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
                break;
            case Enums.Direction.Right:
                position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
                break;
            case Enums.Direction.Left:
                position = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
                break;
            default:
                position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                break;
        }

        position = new Vector3(position.x, position.y, 0);

        return position;
    }
}