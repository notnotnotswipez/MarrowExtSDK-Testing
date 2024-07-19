 
 
 
 
 
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Marrow.Zones
{
    [RequireComponent(typeof(ZoneLink), typeof(Zone))]
    [AddComponentMenu("MarrowSDK/Zones/Zone Aggro")]
    public class ZoneAggro : MonoBehaviour, IZoneEntityListenable
    {
        [SerializeField]
        private Zone _zone;
        [SerializeField]
        private ZoneLink _zoneLink;
        public MarrowQuery beingTags = new();
        public MarrowQuery playerTag = new();
        void Reset()
        {
            _zone = GetComponent<Zone>();
            _zoneLink = GetComponent<ZoneLink>();
            var query = new TagQuery();
            BoneTagReference btRef = new BoneTagReference(MarrowSettings.RuntimeInstance.BeingTag.Barcode);
            query.BoneTag = btRef;
            beingTags.Tags.Add(query);
            if (playerTag.Tags.Count < 1)
            {
                var queryPlayer = new TagQuery();
                BoneTagReference playerRef = new BoneTagReference(MarrowSettings.RuntimeInstance.PlayerTag.Barcode);
                queryPlayer.BoneTag = playerRef;
                playerTag.Tags.Add(queryPlayer);
            }
        }
    }
}