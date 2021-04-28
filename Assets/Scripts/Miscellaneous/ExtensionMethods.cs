using UnityEngine;

namespace Miscellaneous
{
    public static class ExtensionMethods
    {
        public static bool CompareLayer(this Collider collider, int layerMask)
        {
            return ((1 << collider.gameObject.layer) & layerMask) != 0;
        }
    }
}