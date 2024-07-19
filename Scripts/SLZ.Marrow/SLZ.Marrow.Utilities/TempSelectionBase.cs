 
 
 
using UnityEngine;

namespace SLZ.Marrow.Utilities
{
    [SelectionBase]
    public class TempSelectionBase : MonoBehaviour
    {
        private static bool hideInInspector = true;
        public void ApplyHideFlags()
        {
            if (hideInInspector)
                hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
            else
                hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
        }

        public void Destroy()
        {
            DestroyImmediate(this);
        }
    }
}