using UnityEngine;

namespace MiniIT.SUPPORT
{
    [System.Serializable]
    public struct MinMax
    {
        [Range(0f, 3f)]
        public float Min;

        [Range(0f, 3f)]
        public float Max;
    }
}