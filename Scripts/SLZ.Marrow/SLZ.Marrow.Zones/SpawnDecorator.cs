using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Marrow.Zones
{
    [RequireComponent(typeof(CrateSpawner))]
    public class SpawnDecorator : MonoBehaviour, ISpawnListenable
    {
        [SerializeField]
        protected CrateSpawner _crateSpawner;
#if UNITY_EDITOR
        protected virtual void Reset()
        {
            _crateSpawner = GetComponent<CrateSpawner>();
        }
#endif

        public void Capture()
        {
            _crateSpawner = GetComponent<CrateSpawner>();
        }
    }
}