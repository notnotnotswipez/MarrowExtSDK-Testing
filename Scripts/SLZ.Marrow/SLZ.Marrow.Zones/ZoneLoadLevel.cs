 
 
using SLZ.Marrow.Warehouse;
using UnityEngine;
using UnityEngine.Events;

namespace SLZ.Marrow.Zones
{
    [AddComponentMenu("MarrowSDK/Zones/Zone Load Level")]
    public class ZoneLoadLevel : ZoneItem
    {
        public LevelCrateReference level;
        public LevelCrateReference loadScreenLevelOverride;
        public UnityAction OnLevelSwitch;
    }
}