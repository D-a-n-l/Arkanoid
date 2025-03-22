using UnityEngine;
using MiniIT.SupportScreen;
using MiniIT.Enums;

namespace MiniIT.Support
{
    public class BindablePosition : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider2D boxCollider = null;

        [Space(10)]
        [SerializeField]
        private ScreenSide    side = ScreenSide.Top;

        [SerializeField]
        private Vector3       offset = Vector3.zero;

        private void Start()
        {
            transform.position = ScreenPointPosition.Get(side) + offset;

            boxCollider.size = ScreenPointPosition.GetSizeSide(side);
        }
    }
}