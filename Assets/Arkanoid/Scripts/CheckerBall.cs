using MiniIT.Core;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CheckerBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Bouncable>())
        {
            Debug.Log("Lose");
        }
    }
}