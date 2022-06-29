using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public static class ExtensionMethods
    {
        public static bool ChceckIfContainsLayer (this LayerMask source, int layer)
        {
            return source == (source | 1 << layer);
        }

        public static void SetActiveOptimized (this GameObject source, bool active)
        {
            if (source.activeSelf != active)
            {
                source.SetActive(active);
            }
        }
    }
}
