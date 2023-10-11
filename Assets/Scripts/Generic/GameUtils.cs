using UnityEngine;

public static class GameUtils
{
    public static bool IsOnLayerMask(int layer, LayerMask mask)
    {
        return mask == (mask | (1 << layer));
    }
}