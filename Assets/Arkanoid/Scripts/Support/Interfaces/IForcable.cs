using UnityEngine;

public interface IForcable
{
    public Vector2 Force(Transform enterObject, Collision2D collision);
}