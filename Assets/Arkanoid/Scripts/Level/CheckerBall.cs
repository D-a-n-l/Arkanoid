using MiniIT.CORE;
using UnityEngine;

namespace MiniIT.LEVEL
{
    [RequireComponent(typeof(Collider2D))]
    public class CheckerBall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<Bouncable>())
            {
                CoreEvents.onFalledBall?.Invoke();
            }
        }
    }
}