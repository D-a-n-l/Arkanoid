using UnityEngine;
using MiniIT.SupportScreen;
using MiniIT.Enums;
using NaughtyAttributes;

namespace MiniIT.Support
{
    public class BindablePosition : MonoBehaviour
    {
        [SerializeField]
        private bool isChangeSizeCollider = true;

        [ShowIf(nameof(isChangeSizeCollider))]
        [SerializeField]
        private BoxCollider2D boxCollider = null;

        [Space(10)]
        [SerializeField]
        private ScreenSide    side = ScreenSide.Top;

        [SerializeField]
        private Vector3       offset = Vector3.zero;

        private void Start()
        {
            Set();
        }

        public void Set()
        {
            transform.position = ScreenPointPosition.Get(side) + offset;

            if (isChangeSizeCollider == true)
            {
                boxCollider.size = ScreenPointPosition.GetSizeSide(side);
            }
        }

        public void SetLocal()
        {
            transform.localPosition = ScreenPointPosition.Get(side) + offset;

            if (isChangeSizeCollider == true)
            {
                boxCollider.size = ScreenPointPosition.GetSizeSide(side);
            }
        }
    }
}