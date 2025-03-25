using UnityEngine;

[System.Serializable]
public struct MinMax
{
    [Range(-3f, 3f)]
    public float Min;

    [Range(-3f, 3f)]
    public float Max;
}