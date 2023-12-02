using UnityEngine;
using UnityEngine.Events;

public static class GameUtils
{
    public static bool IsOnLayerMask(int layer, LayerMask mask)
    {
        return mask == (mask | (1 << layer));
    }

    public static float Map(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
    }
}