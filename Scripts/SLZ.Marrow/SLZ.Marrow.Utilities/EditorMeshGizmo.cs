#if UNITY_EDITOR
  
 
using System.Collections.Generic;
 
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using Matrix4x4 = UnityEngine.Matrix4x4;
using Vector3 = UnityEngine.Vector3;

namespace SLZ.Marrow.Utilities
{
    public class EditorMeshGizmo : MonoBehaviour
    {
        protected static bool hideInInspector = true;
        public readonly static string EditorMeshGizmoName = "Editor Mesh Gizmo";
        [SerializeField]
        private string id;
        public string ID { get => id; set => id = value; }

        [SerializeField]
        private Mesh _editorMesh;
        public Mesh EditorMesh
        {
            get
            {
                return _editorMesh;
            }

            set
            {
                if (_editorMesh != value || _meshFilter.sharedMesh != value)
                {
                    _editorMesh = value;
                    if (_meshFilter != null)
                    {
                        _meshFilter.sharedMesh = _editorMesh;
                    }
                }
            }
        }

        [SerializeField]
        private Material editorMaterial;
        public Material EditorMaterial
        {
            get
            {
                return editorMaterial;
            }

            set
            {
                if (editorMaterial != value || _meshRenderer.sharedMaterial != value)
                {
                    editorMaterial = value;
                    if (_meshRenderer != null)
                    {
                        _meshRenderer.sharedMaterial = editorMaterial;
                    }
                }
            }
        }

        public bool Visible
        {
            get => MeshRenderer.enabled;
            set
            {
                if (MeshRenderer.enabled != value)
                    MeshRenderer.enabled = value;
            }
        }

        [SerializeField]
        private Bounds? _editorBounds = null;
        public Bounds? EditorBounds { get => _editorBounds; set => _editorBounds = value; }

        [SerializeField]
        private bool _showInPlaymode = false;
        public bool ShowInPlaymode
        {
            get
            {
                return _showInPlaymode;
            }

            set
            {
                _showInPlaymode = value;
            }
        }

        [SerializeField]
        private MeshRenderer _meshRenderer;
        protected MeshRenderer MeshRenderer { get => _meshRenderer; }

        [SerializeField]
        private MeshFilter _meshFilter;
        protected MeshFilter MeshFilter { get => _meshFilter; }

        Color boundColor = new Color(0f, 0.86f, 0.91f);
        private static readonly Dictionary<(string, GameObject), EditorMeshGizmo> meshGizmoCache = new Dictionary<(string, GameObject), EditorMeshGizmo>();
        private static int ignoreRaycastLayer = -1;
        public void DrawBounds()
        {
            if (EditorBounds.HasValue || EditorBounds.Value != default)
            {
                Bounds bounds = EditorBounds.Value;
                var transform1 = transform;
                var position = transform1.position;
                var rotation = transform1.rotation;
                Gizmos.color = boundColor;
                Gizmos.matrix = Matrix4x4.TRS(position + rotation * bounds.center, rotation, Vector3.one);
                Gizmos.DrawWireCube(Vector3.zero, bounds.size);
            }
        }

        public void ShowGizmo()
        {
            if (_meshRenderer.forceRenderingOff)
                _meshRenderer.forceRenderingOff = false;
        }

        public bool ShowGizmo(bool show)
        {
            if (_meshRenderer.forceRenderingOff != !show)
                _meshRenderer.forceRenderingOff = !show;
            return !_meshRenderer.forceRenderingOff;
        }

        public void HideGizmo()
        {
            if (!_meshRenderer.forceRenderingOff)
                _meshRenderer.forceRenderingOff = true;
        }

        public void DestroyGizmo(bool destroyGameObject = false, bool destroyOnlyGizmo = false)
        {
            if (!destroyOnlyGizmo)
            {
                if (_meshFilter != null)
                    DestroyImmediate(_meshFilter);
                if (_meshRenderer != null)
                    DestroyImmediate(_meshRenderer);
            }

            DestroyImmediate(this);
            if (destroyGameObject)
                DestroyImmediate(this.gameObject);
        }

        public static void DestroyGizmoStatic(string id, GameObject targetGameObject, bool destroyGameObject = false, bool destroyOnlyGizmo = false)
        {
            if (meshGizmoCache.TryGetValue((id, targetGameObject), out var meshGizmo))
            {
                meshGizmo.DestroyGizmo(destroyGameObject: destroyGameObject, destroyOnlyGizmo: destroyOnlyGizmo);
                meshGizmoCache.Remove((id, targetGameObject));
            }
        }

        public static EditorMeshGizmo Draw(string id, GameObject targetGameObject, Mesh mesh, Material material, Bounds bounds = default, bool showInPlayMode = false)
        {
            return Draw<EditorMeshGizmo>(id, targetGameObject, mesh, material, bounds, showInPlayMode);
        }

        protected static EditorGizmoT Draw<EditorGizmoT>(string id, GameObject targetGameObject, Material material, Bounds bounds = default, bool showInPlayMode = false)
            where EditorGizmoT : EditorMeshGizmo
        {
            return Draw<EditorGizmoT>(id, targetGameObject, null, material, bounds, showInPlayMode);
        }

        protected static EditorGizmoT Draw<EditorGizmoT>(string id, GameObject targetGameObject, Mesh mesh, Material material, Bounds bounds = default, bool showInPlayMode = false)
            where EditorGizmoT : EditorMeshGizmo
        {
            EditorGizmoT editorMeshGizmo = null;
            if (!Application.isPlaying)
            {
                if (meshGizmoCache.TryGetValue((id, targetGameObject), out var foundEditorMeshGizmo))
                {
                    editorMeshGizmo = foundEditorMeshGizmo as EditorGizmoT;
                }
                else
                {
                    var existingGizmos = targetGameObject.GetComponents<EditorGizmoT>();
                    foreach (var existingGizmo in existingGizmos)
                    {
                        if (existingGizmo.ID == id)
                        {
                            editorMeshGizmo = existingGizmo;
                            meshGizmoCache[(id, targetGameObject)] = editorMeshGizmo;
                        }
                    }
                }

                if (editorMeshGizmo == null)
                {
                    editorMeshGizmo = SetupGizmo<EditorGizmoT>(id, targetGameObject, mesh, material, bounds, showInPlayMode);
                    meshGizmoCache[(id, targetGameObject)] = editorMeshGizmo;
                }

                if (editorMeshGizmo != null)
                {
                    editorMeshGizmo.EditorMesh = mesh;
                    editorMeshGizmo.EditorBounds = bounds;
                    editorMeshGizmo.EditorMaterial = material;
                    editorMeshGizmo.DrawBounds();
                }
            }

            return editorMeshGizmo;
        }

        public static EditorGizmoT SetupGizmo<EditorGizmoT>(string id, GameObject targetGameObject, Mesh mesh = null, Material material = null, Bounds bounds = default, bool showInPlayMode = false)
            where EditorGizmoT : EditorMeshGizmo
        {
            GameObjectUtility.SetStaticEditorFlags(targetGameObject, 0);
            EditorGizmoT editorMeshGizmo = targetGameObject.AddComponent<EditorGizmoT>();
            editorMeshGizmo.ID = id;
            if (hideInInspector)
                editorMeshGizmo.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
            else
                editorMeshGizmo.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
            if (ignoreRaycastLayer == -1)
                ignoreRaycastLayer = LayerMask.NameToLayer("Ignore Raycast");
            targetGameObject.layer = ignoreRaycastLayer;
            editorMeshGizmo.ShowInPlaymode = showInPlayMode;
            var meshFilter = targetGameObject.GetComponent<MeshFilter>();
            editorMeshGizmo._meshFilter = meshFilter != null ? meshFilter : targetGameObject.AddComponent<MeshFilter>();
            if (hideInInspector)
                editorMeshGizmo._meshFilter.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
            else
                editorMeshGizmo._meshFilter.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
            var meshRenderer = targetGameObject.GetComponent<MeshRenderer>();
            editorMeshGizmo._meshRenderer = meshRenderer != null ? meshRenderer : targetGameObject.AddComponent<MeshRenderer>();
            if (hideInInspector)
                editorMeshGizmo._meshRenderer.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
            else
                editorMeshGizmo._meshRenderer.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
            editorMeshGizmo._meshRenderer.receiveGI = 0;
            editorMeshGizmo._meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
            editorMeshGizmo._meshRenderer.lightProbeUsage = LightProbeUsage.Off;
            editorMeshGizmo._meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
            if (mesh != null)
            {
                editorMeshGizmo.EditorMesh = mesh;
            }

            if (material != null)
            {
                editorMeshGizmo.EditorMaterial = material;
            }

            if (bounds != default)
            {
                editorMeshGizmo.EditorBounds = bounds;
            }

            return editorMeshGizmo;
        }
    }
}
#endif
