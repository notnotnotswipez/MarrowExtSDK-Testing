#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using SLZ.Marrow.Warehouse;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SLZ.Marrow.Utilities
{
    public class ImpactPropertiesMeshGizmo : EditorMeshGizmo
    {
        private float timeSinceLastUpdated;
        private float tickRateInSeconds = 1f;
        private Collider collider = null;
        public Collider Collider => collider;

        private ImpactProperties impactProperties = null;
        private Rigidbody rb = null;
        private MeshCollider meshCollider = null;
        private TempSelectionBase tempSelectionBase;
        private Color currentColor;
        private Color currentRandomColor;
        private Color currentHighlight = Color.black;
        private Color currentCheckerboardColor = Color.black;
        private static readonly int ColorProp = Shader.PropertyToID("_Color");
        private static readonly int RandomColorProp = Shader.PropertyToID("_RandomColor");
        private static readonly int HighlightProp = Shader.PropertyToID("_Highlight");
        private static readonly int CheckerboardColorProp = Shader.PropertyToID("_CheckerboardColor");
        public MaterialPropertyBlock propBlock = null;
        private static Mesh cubeModel = null;
        private static Mesh sphereModel = null;
        private static Mesh capsuleModel = null;
        private static Mesh cylinderModel = null;
        private ColliderType colliderType;
        private enum ColliderType
        {
            MESH,
            BOX,
            SPHERE,
            CAPSULE
        }

        private static Dictionary<int, ImpactPropertiesMeshGizmo[]> cachedColliderToGizmos = new Dictionary<int, ImpactPropertiesMeshGizmo[]>();
        private static Dictionary<int, List<ImpactPropertiesMeshGizmo>> cachedIPToGizmos = new Dictionary<int, List<ImpactPropertiesMeshGizmo>>();
        private static readonly int RandomColor = Shader.PropertyToID("_RandomColor");
        private static Material colliderMaterial;
        private static Material colliderTransparentMaterial;
        private static int gizmoDrawTime = 0;
        private static int gizmoDrawPerFrame = 100;
        private static int gizmosDrawnPerFrame = 0;
        private static float timeSinceLastUpdatedStatic = -1f;
        private static float tickRateInSecondsStatic = 2f;
        public static float gizmoVisRange = 50f;
        private static bool _showGizmo = false;
        private static bool _updateGizmo = true;
        public static List<Barcode> surfaceDataCardList = new List<Barcode>();
        public static Dictionary<Barcode, Color> surfaceDataCardColorDict;
        private static bool _gizmoEnabled
        {
            get
            {
                return true;
            }
        }

        private static SceneView _cachedSceneView;
        private static bool _sceneViewCached = false;
        private static bool _noSceneView = false;
        private static bool _gizmoGlobalEnabled
        {
            get
            {
                if (!_sceneViewCached)
                {
                    _cachedSceneView = SceneView.lastActiveSceneView;
                    _sceneViewCached = true;
                    _noSceneView = !_cachedSceneView;
                }

                if (_noSceneView)
                    return false;
                return _cachedSceneView.drawGizmos;
            }
        }

        public static bool ShowGizmo
        {
            get
            {
                return _showGizmo && _gizmoEnabled && _gizmoGlobalEnabled;
            }

            set
            {
                _showGizmo = value;
            }
        }

        private static bool lastGizmoState = true;
        private static bool lastGlobalGizmoState = true;
        protected static Action onEnableGizmo;
        protected static Action onDisableGizmo;
        [InitializeOnLoadMethod]
        private static void Init()
        {
            lastGizmoState = ShowGizmo;
            EditorApplication.update += UpdateGizmoStatus;
        }

        private static void UpdateGizmoStatus()
        {
            bool gizmo = _gizmoEnabled;
            bool globalGizmo = _gizmoGlobalEnabled;
            bool changed = (lastGizmoState && lastGlobalGizmoState) != (gizmo && globalGizmo);
            if (changed)
            {
                if (globalGizmo && gizmo)
                {
                    onEnableGizmo?.Invoke();
                }
                else
                {
                    onDisableGizmo?.Invoke();
                }
            }

            lastGizmoState = gizmo;
            lastGlobalGizmoState = globalGizmo;
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void OnDrawGizmoCollider(BoxCollider collider, GizmoType gizmoType)
        {
            OnDrawGizmoColliderGeneric(collider, gizmoType);
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void OnDrawGizmoCollider(SphereCollider collider, GizmoType gizmoType)
        {
            OnDrawGizmoColliderGeneric(collider, gizmoType);
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void OnDrawGizmoCollider(CapsuleCollider collider, GizmoType gizmoType)
        {
            OnDrawGizmoColliderGeneric(collider, gizmoType);
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void OnDrawGizmoCollider(MeshCollider collider, GizmoType gizmoType)
        {
            OnDrawGizmoColliderGeneric(collider, gizmoType);
        }

        private static void OnDrawGizmoColliderGeneric(Collider collider, GizmoType gizmoType)
        {
            if (!collider.isTrigger && ShowGizmo && _updateGizmo)
            {
                if (!HasColliderMesh(collider))
                {
                    if (gizmoDrawTime != Time.frameCount && CheckGizmoInRange(collider.transform))
                    {
                        var gizmos = CreateColliderPreviewForCollider(collider);
                        if (gizmos.Length == 0)
                        {
                            Selection.activeObject = collider;
                            _showGizmo = false;
                        }

                        gizmosDrawnPerFrame++;
                        if (gizmosDrawnPerFrame > gizmoDrawPerFrame)
                        {
                            gizmoDrawTime = Time.frameCount;
                            gizmosDrawnPerFrame = 0;
                        }
                    }
                }
                else
                {
                }
            }
        }

        private void UpdateGizmo()
        {
            if (ShowGizmo)
            {
                if (_updateGizmo)
                {
                    timeSinceLastUpdated += Time.unscaledDeltaTime;
                    if (timeSinceLastUpdated >= tickRateInSeconds)
                    {
                        timeSinceLastUpdated = 0f;
                        if (CheckGizmoInRange(transform))
                        {
                            Visible = true;
                            if (MeshRenderer.isVisible)
                            {
                                UpdateMaterial();
                            }
                        }
                        else
                        {
                            Visible = false;
                        }
                    }
                }
            }
            else
            {
                DisableGizmo();
                SceneVisibilityManager.instance.EnableAllPicking();
            }
        }

        private void OnDrawGizmos()
        {
            if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
            {
                UpdateGizmo();
            }
        }

        public static bool CheckGizmoInRange(Transform trans)
        {
            var currentCamera = Camera.current;
            if (EditorApplication.isPlaying || EditorApplication.isPlayingOrWillChangePlaymode)
                currentCamera = Camera.main;
            if (!currentCamera)
                return false;
            var cameraTransform = currentCamera.transform;
            return currentCamera && (cameraTransform.position - trans.position).sqrMagnitude < gizmoVisRange * gizmoVisRange;
        }

        public void UpdateMaterial()
        {
            if (!collider)
            {
                DisableGizmo();
                return;
            }

            UpdateMeshCollider();
            MeshRenderer.SetPropertyBlock(propBlock);
        }

        private void UpdateMeshCollider()
        {
            if (meshCollider && meshCollider.sharedMesh != EditorMesh)
            {
                EditorMesh = meshCollider.sharedMesh;
            }
        }

        private bool ColorFastEquals(Color color1, Color color2)
        {
            float r = color1.r - color2.r;
            float g = color1.g - color2.g;
            float b = color1.b - color2.b;
            float a = color1.a - color2.a;
            return r * r + g * g + b * b + a * a < 9.999999439624929E-11;
        }

        private void SetupDefaultPropertyBlock()
        {
            if (propBlock == null)
            {
                propBlock = new MaterialPropertyBlock();
                propBlock.SetColor(ColorProp, Color.black);
                propBlock.SetColor(RandomColor, Color.black);
                propBlock.SetColor(HighlightProp, Color.black);
                propBlock.SetColor(CheckerboardColorProp, Color.black);
            }
        }

        public void SetColor(Color newColor)
        {
            SetupDefaultPropertyBlock();
            if (!ColorFastEquals(currentColor, newColor))
            {
                currentColor = newColor;
                propBlock.SetColor(ColorProp, newColor);
            }
        }

        private void SetRandomColor(Color newRandomColor)
        {
            SetupDefaultPropertyBlock();
            if (!ColorFastEquals(currentRandomColor, newRandomColor))
            {
                currentRandomColor = newRandomColor;
                propBlock.SetColor(RandomColorProp, newRandomColor);
            }
        }

        public void EnableHighlight(bool highlightEnable = true)
        {
            if (highlightEnable)
                SetHighlightColor(Color.white);
            else
                DisableHighlight();
        }

        public void DisableHighlight()
        {
            SetHighlightColor(Color.black);
        }

        private void SetHighlightColor(Color newHighlight)
        {
            SetupDefaultPropertyBlock();
            if (!ColorFastEquals(currentHighlight, newHighlight))
            {
                currentHighlight = newHighlight;
                propBlock.SetColor(HighlightProp, currentHighlight);
            }
        }

        private void SetCheckerboardColor(Color newCheckerboardColor)
        {
            SetupDefaultPropertyBlock();
            if (!ColorFastEquals(currentCheckerboardColor, newCheckerboardColor))
            {
                currentCheckerboardColor = newCheckerboardColor;
                propBlock.SetColor(CheckerboardColorProp, currentCheckerboardColor);
            }
        }

        private void EnableGizmo()
        {
        }

        public void DisableGizmo()
        {
            if (collider)
            {
                var colliderInstanceID = collider.GetInstanceID();
                cachedColliderToGizmos.Remove(colliderInstanceID);
            }

            if (impactProperties)
                cachedIPToGizmos.Remove(impactProperties.GetInstanceID());
            if (tempSelectionBase)
            {
                tempSelectionBase.Destroy();
                tempSelectionBase = null;
            }

            onEnableGizmo -= EnableGizmo;
            onDisableGizmo -= DisableGizmo;
            DestroyImmediate(gameObject);
        }

        public static void DisableGizmo(ImpactProperties ip)
        {
            if (cachedIPToGizmos.TryGetValue(ip.GetInstanceID(), out var gizmos))
            {
                foreach (var gizmo in gizmos)
                {
                    gizmo.DisableGizmo();
                }
            }
        }

        public static void DisableGizmo(Collider collider)
        {
            if (cachedColliderToGizmos.TryGetValue(collider.GetInstanceID(), out var gizmos))
            {
                foreach (var gizmo in gizmos)
                {
                    gizmo.DisableGizmo();
                }
            }
        }

        public static void HighlightGizmo(ImpactProperties ip, bool highlight)
        {
            if (cachedIPToGizmos.TryGetValue(ip.GetInstanceID(), out var gizmos))
            {
                foreach (var gizmo in gizmos)
                {
                    gizmo.EnableHighlight(highlight);
                }
            }
        }

        public static void HighlightGizmo(Collider collider, bool highlight, Color color = default)
        {
            if (cachedColliderToGizmos.TryGetValue(collider.GetInstanceID(), out var gizmos))
            {
                foreach (var gizmo in gizmos)
                {
                    if (color != default)
                    {
                        gizmo.EnableHighlight(highlight);
                    }
                    else
                    {
                        gizmo.SetHighlightColor(color);
                    }

                    gizmo.UpdateMaterial();
                }
            }
        }

        public static void HighlightGizmo(Collider collider, Color color)
        {
            if (cachedColliderToGizmos.TryGetValue(collider.GetInstanceID(), out var gizmos))
            {
                foreach (var gizmo in gizmos)
                {
                    gizmo.SetHighlightColor(color);
                    gizmo.UpdateMaterial();
                }
            }
        }

        private static ImpactPropertiesMeshGizmo SetupGizmo(string id, GameObject targetGameObject, Mesh mesh, Collider collider, Rigidbody rb, ColliderType colliderType, MeshCollider meshCollider = null, Color color = default, Color checkerboardColor = default)
        {
            TempSelectionBase tempSelectionBase;
            if (!targetGameObject.transform.parent.TryGetComponent(out tempSelectionBase))
            {
                tempSelectionBase = targetGameObject.transform.parent.gameObject.AddComponent<TempSelectionBase>();
            }

            tempSelectionBase.ApplyHideFlags();
            if (colliderMaterial == null)
                colliderMaterial = AssetDatabase.LoadAssetAtPath<Material>(MarrowSDK.GetPackagePath("Editor/Assets/Materials/Collider Mat.mat"));
            var mat = colliderMaterial;
            var gizmo = EditorMeshGizmo.SetupGizmo<ImpactPropertiesMeshGizmo>(id, targetGameObject, mesh, mat);
            gizmo.collider = collider;
            gizmo.rb = rb;
            gizmo.colliderType = colliderType;
            gizmo.meshCollider = meshCollider;
            gizmo.tempSelectionBase = tempSelectionBase;
            var randomColor = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
            gizmo.SetColor(color);
            gizmo.SetRandomColor(randomColor);
            gizmo.SetCheckerboardColor(checkerboardColor);
            gizmo.UpdateMaterial();
            onEnableGizmo -= gizmo.EnableGizmo;
            onEnableGizmo += gizmo.EnableGizmo;
            onDisableGizmo -= gizmo.DisableGizmo;
            onDisableGizmo += gizmo.DisableGizmo;
            return gizmo;
        }

        private static Dictionary<Barcode, Color> _surfaceDataColors = new Dictionary<Barcode, Color>();
        public static Color GetSurfaceDataColor(Barcode surfaceDataBarcode)
        {
            if (!_surfaceDataColors.TryGetValue(surfaceDataBarcode, out var color))
            {
                color = GetDistinctColor(GetStringHashCode(surfaceDataBarcode.ID));
                _surfaceDataColors[surfaceDataBarcode] = color;
            }

            return color;
        }

        public static int GetStringHashCode(string str)
        {
            int hash = 32;
            foreach (var character in str)
            {
                hash = hash * 31 + character;
            }

            return hash;
        }

        public static ImpactPropertiesMeshGizmo[] CreateColliderPreviewForCollider(Collider collider)
        {
            Color surfaceDataColor;
            List<ImpactPropertiesMeshGizmo> gizmos = new List<ImpactPropertiesMeshGizmo>();
            ImpactProperties impactProperties = null;
            bool hasRigidBody = collider.attachedRigidbody;
            if (hasRigidBody)
            {
                impactProperties = collider.attachedRigidbody.GetComponent<ImpactProperties>();
            }
            else
            {
                impactProperties = collider.GetComponent<ImpactProperties>();
            }

            Color checkerboardColor = Color.black;
            if (!impactProperties)
            {
                surfaceDataColor = Color.black;
                checkerboardColor = Color.magenta;
            }
            else
            {
                if (ScannableReference.IsValid(impactProperties.SurfaceDataCard) && impactProperties.SurfaceDataCard.TryGetDataCard(out var card) && surfaceDataCardColorDict.TryGetValue(card.Barcode, out var color))
                {
                    surfaceDataColor = color;
                }
                else
                {
                    surfaceDataColor = Color.black;
                    checkerboardColor = Color.cyan;
                }
            }

            if (!collider.isTrigger)
            {
                var added = CreateColliderPreview(collider, "ImpactProperties", color: surfaceDataColor, checkerboardColor: checkerboardColor);
                if (added != null && added.Length > 0)
                    gizmos.AddRange(added);
                if (gizmos.Any() && impactProperties)
                {
                    int ipID = impactProperties.GetInstanceID();
                    if (!cachedIPToGizmos.ContainsKey(ipID))
                    {
                        cachedIPToGizmos[ipID] = new List<ImpactPropertiesMeshGizmo>();
                    }

                    foreach (var gizmo in gizmos)
                    {
                        gizmo.impactProperties = impactProperties;
                        cachedIPToGizmos[ipID].Add(gizmo);
                    }
                }
            }

            return gizmos.ToArray();
        }

        public static bool HasColliderMesh(Collider collider)
        {
            return cachedColliderToGizmos.TryGetValue(collider.GetInstanceID(), out var gizmos) && gizmos != null && gizmos.Length > 0;
        }

        public static ImpactPropertiesMeshGizmo[] CreateColliderPreview(Collider marrowCollider, string idPrefix, Color color = default, Color checkerboardColor = default)
        {
            var colliderID = marrowCollider.GetInstanceID();
            ImpactPropertiesMeshGizmo[] gizmos = null;
            ImpactPropertiesMeshGizmo gizmo = null;
            switch (marrowCollider)
            {
                case MeshCollider meshCollider:
                    {
                        GameObject go = new GameObject($"{idPrefix} MeshCollider Preview");
                        go.transform.parent = marrowCollider.transform;
                        go.transform.localPosition = Vector3.zero;
                        go.transform.localRotation = Quaternion.identity;
                        go.transform.localScale = Vector3.one;
                        SimpleTransform simpleTrans = new SimpleTransform();
                        gizmo = SetupGizmo("Runtime MarrowBody MeshCollider Preview", go, meshCollider.sharedMesh, marrowCollider, marrowCollider.attachedRigidbody, ColliderType.MESH, meshCollider, color: color, checkerboardColor: checkerboardColor);
                        gizmos = new ImpactPropertiesMeshGizmo[]
                        {
                        gizmo
                        };
                        cachedColliderToGizmos.Add(colliderID, gizmos);
                        break;
                    }

                case BoxCollider boxyCollider:
                    {
                        string name = $"{idPrefix} BoxCollider Preview";
                        GameObject go = new GameObject(name);
                        go.transform.parent = boxyCollider.transform;
                        go.transform.localPosition = boxyCollider.center;
                        go.transform.localRotation = Quaternion.identity;
                        go.transform.localScale = boxyCollider.size;
                        if (hideInInspector)
                            go.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
                        else
                            go.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
                        if (cubeModel == null)
                            cubeModel = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
                        gizmo = SetupGizmo(name, go, cubeModel, marrowCollider, marrowCollider.attachedRigidbody, ColliderType.BOX, color: color, checkerboardColor: checkerboardColor);
                        gizmos = new ImpactPropertiesMeshGizmo[]
                        {
                        gizmo
                        };
                        cachedColliderToGizmos.Add(colliderID, gizmos);
                        break;
                    }

                case SphereCollider sphereCollider:
                    {
                        string name = $"{idPrefix} SphereCollider Preview";
                        GameObject go = new GameObject(name);
                        var sphereRadius = sphereCollider.radius;
                        go.transform.parent = sphereCollider.transform;
                        go.transform.localPosition = sphereCollider.center;
                        go.transform.localRotation = Quaternion.identity;
                        go.transform.localScale = new Vector3(sphereRadius * 2f, sphereRadius * 2f, sphereRadius * 2f);
                        if (hideInInspector)
                            go.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
                        else
                            go.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
                        if (sphereModel == null)
                            sphereModel = Resources.GetBuiltinResource<Mesh>("New-Sphere.fbx");
                        gizmo = SetupGizmo(name, go, sphereModel, marrowCollider, marrowCollider.attachedRigidbody, ColliderType.SPHERE, color: color, checkerboardColor: checkerboardColor);
                        gizmos = new ImpactPropertiesMeshGizmo[]
                        {
                        gizmo
                        };
                        cachedColliderToGizmos.Add(colliderID, gizmos);
                        break;
                    }

                case CapsuleCollider capsuleCollider:
                    {
                        string nameCylinder = $"{idPrefix} CapsuleCollider-Cylinder Preview";
                        GameObject cylinderGO = new GameObject(nameCylinder);
                        if (hideInInspector)
                            cylinderGO.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
                        else
                            cylinderGO.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
                        var colliderTransform = capsuleCollider.transform;
                        cylinderGO.transform.parent = colliderTransform;
                        string nameCap1 = $"{idPrefix} CapsuleCollider-Cap1 Preview";
                        GameObject cap1 = new GameObject(nameCap1);
                        if (hideInInspector)
                            cap1.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
                        else
                            cap1.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
                        cap1.transform.parent = colliderTransform;
                        string nameCap2 = $"{idPrefix} CapsuleCollider-Cap2 Preview";
                        GameObject cap2 = new GameObject(nameCap2);
                        if (hideInInspector)
                            cap2.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInInspector;
                        else
                            cap2.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
                        cap2.transform.parent = colliderTransform;
                        var cylTrans = cylinderGO.transform;
                        var cap1Trans = cap1.transform;
                        var cap2Trans = cap2.transform;
                        Quaternion rotation = Quaternion.identity;
                        switch (capsuleCollider.direction)
                        {
                            case 0:
                                rotation = Quaternion.AngleAxis(90f, Vector3.forward);
                                break;
                            case 1:
                                rotation = Quaternion.identity;
                                break;
                            case 2:
                                rotation = Quaternion.AngleAxis(90f, Vector3.right);
                                break;
                        }

                        float capSize = Mathf.Max(capsuleCollider.height - capsuleCollider.radius * 2f, 0f) * 0.5f;
                        var colliderCenter = capsuleCollider.center;
                        var colliderRadius = capsuleCollider.radius;
                        cylTrans.localPosition = colliderCenter;
                        cap1Trans.localPosition = colliderCenter + rotation * (Vector3.up * capSize);
                        cap2Trans.localPosition = colliderCenter + rotation * (Vector3.down * capSize);
                        cylTrans.localRotation = cap1Trans.localRotation = cap2Trans.localRotation = rotation;
                        cylTrans.localScale = new Vector3(colliderRadius * 2f, capSize, colliderRadius * 2f);
                        cap1Trans.localScale = cap2Trans.localScale = 2f * colliderRadius * Vector3.one;
                        if (cylinderModel == null)
                            cylinderModel = Resources.GetBuiltinResource<Mesh>("New-Cylinder.fbx");
                        if (sphereModel == null)
                            sphereModel = Resources.GetBuiltinResource<Mesh>("New-Sphere.fbx");
                        gizmos = new ImpactPropertiesMeshGizmo[3];
                        gizmo = SetupGizmo(nameCylinder, cylinderGO, cylinderModel, marrowCollider, marrowCollider.attachedRigidbody, ColliderType.CAPSULE, color: color, checkerboardColor: checkerboardColor);
                        gizmos[0] = gizmo;
                        gizmo = SetupGizmo(nameCap1, cap1, sphereModel, marrowCollider, marrowCollider.attachedRigidbody, ColliderType.CAPSULE, color: color, checkerboardColor: checkerboardColor);
                        gizmos[1] = gizmo;
                        gizmo = SetupGizmo(nameCap2, cap2, sphereModel, marrowCollider, marrowCollider.attachedRigidbody, ColliderType.CAPSULE, color: color, checkerboardColor: checkerboardColor);
                        gizmos[2] = gizmo;
                        cachedColliderToGizmos.Add(colliderID, gizmos);
                        break;
                    }
            }

            return gizmos;
        }

        private static List<Color> distinctColorPalette = new List<Color>();
        private static int lastUsedColor = -1;
        private static Dictionary<int, Color> colorHashLookup = new Dictionary<int, Color>();
        private static void GenerateDistinctColorPalette()
        {
            distinctColorPalette.Clear();
            float hue;
            float sat = 1f;
            float val = 1f;
            float midValue = 0.5f;
            float hueLength = 9f;
            for (int i = 0; i < hueLength - 1f; i++)
            {
                hue = i / hueLength;
                var color = Color.HSVToRGB(hue, sat, val);
                distinctColorPalette.Add(color);
            }

            for (int i = 0; i < hueLength - 1f; i++)
            {
                hue = i / hueLength;
                var color = Color.HSVToRGB(hue, midValue, val);
                distinctColorPalette.Add(color);
            }

            for (int i = 0; i < hueLength - 1f; i++)
            {
                hue = i / hueLength;
                var color = Color.HSVToRGB(hue, sat, midValue);
                distinctColorPalette.Add(color);
            }
        }

        private static Color GetDistinctColor(int hash)
        {
            Color color = Color.white;
            if (!colorHashLookup.TryGetValue(hash, out color))
            {
                color = GetNewDistinctColor();
                colorHashLookup[hash] = color;
            }

            return color;
        }

        private static Color GetNewDistinctColor()
        {
            if (distinctColorPalette.Count == 0)
                GenerateDistinctColorPalette();
            Color color = Color.white;
            if (lastUsedColor < distinctColorPalette.Count - 1)
            {
                color = distinctColorPalette[lastUsedColor += 1];
            }

            return color;
        }

        public static void GetAWSurfaceDataCards()
        {
            List<Scannable> palletScannables;
            List<Scannable> allScannables = new List<Scannable>();
            if (surfaceDataCardList == null)
            {
                surfaceDataCardList = new List<Barcode>();
            }

            List<Pallet> pallets = AssetWarehouse.Instance.GetPallets();
            pallets = pallets.OrderBy(x => x.Title).ToList();
            palletScannables = new List<Scannable>();
            palletScannables = palletScannables.OrderBy(s => s.Title).ToList();
            for (int p = 0; p < pallets.Count; p++)
            {
                pallets[p].GetScannables(ref palletScannables);
                allScannables.AddRange(palletScannables);
            }

            foreach (var scannable in allScannables)
            {
                if (scannable == null)
                    continue;
                if (scannable is SurfaceDataCard surfaceDataCard)
                {
                    if (!surfaceDataCardList.Contains(surfaceDataCard.Barcode))
                    {
                        surfaceDataCardList.Add(surfaceDataCard.Barcode);
                    }
                }
            }

            if (surfaceDataCardList != null)
            {
                surfaceDataCardList = surfaceDataCardList.OrderBy(p => p.ID).ToList();
            }
        }

        public static void BuildSurfaceDataColorDict()
        {
            if (surfaceDataCardColorDict == null)
            {
                surfaceDataCardColorDict = new Dictionary<Barcode, Color>();
            }

            foreach (var surfaceDataCardBarcode in surfaceDataCardList)
            {
                if (AssetWarehouse.ready && !Application.isPlaying && AssetWarehouse.Instance.TryGetDataCard(surfaceDataCardBarcode, out var dataCard))
                {
                    switch (dataCard.Title.ToLower())
                    {
                        case "blood":
                            ColorUtility.TryParseHtmlString("#ff3000", out Color bloodColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, bloodColor);
                            break;
                        case "hydraulic":
                            ColorUtility.TryParseHtmlString("#0624C3", out Color hydraulicColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, hydraulicColor);
                            break;
                        case "concrete":
                            ColorUtility.TryParseHtmlString("#5e676d", out Color concreteColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, concreteColor);
                            break;
                        case "metal":
                            ColorUtility.TryParseHtmlString("#68aadc", out Color metalColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, metalColor);
                            break;
                        case "metal pure":
                            ColorUtility.TryParseHtmlString("#9468dc", out Color metalPureColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, metalPureColor);
                            break;
                        case "wood":
                            ColorUtility.TryParseHtmlString("#a27255", out Color woodColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, woodColor);
                            break;
                        case "cardboard":
                            ColorUtility.TryParseHtmlString("#9d414e", out Color cardboardColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, cardboardColor);
                            break;
                        case "dirt":
                            ColorUtility.TryParseHtmlString("#4c3e2c", out Color dirtColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, dirtColor);
                            break;
                        case "glass":
                            ColorUtility.TryParseHtmlString("#ffd557", out Color glassColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, glassColor);
                            break;
                        case "bioluminescent":
                            ColorUtility.TryParseHtmlString("#1b92a8", out Color bioluminescentColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, bioluminescentColor);
                            break;
                        case "bone":
                            ColorUtility.TryParseHtmlString("#B4B481", out Color boneColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, boneColor);
                            break;
                        case "cloth":
                            ColorUtility.TryParseHtmlString("#ff9600", out Color clothColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, clothColor);
                            break;
                        case "crystalline":
                            ColorUtility.TryParseHtmlString("#d6e4ff", out Color crystalineColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, crystalineColor);
                            break;
                        case "paper":
                            ColorUtility.TryParseHtmlString("#FFFFFF", out Color paperColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, paperColor);
                            break;
                        case "plant green":
                            ColorUtility.TryParseHtmlString("#1E9300", out Color plantgreenColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, plantgreenColor);
                            break;
                        case "polymer":
                            ColorUtility.TryParseHtmlString("#ffafde", out Color polymerColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, polymerColor);
                            break;
                        case "red brick":
                            ColorUtility.TryParseHtmlString("#862613", out Color redbrickColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, redbrickColor);
                            break;
                        case "void":
                            ColorUtility.TryParseHtmlString("#2e0043", out Color voidColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, voidColor);
                            break;
                        case "metal thin":
                            ColorUtility.TryParseHtmlString("#68dca4", out Color metalthinColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, metalthinColor);
                            break;
                        case "energy blue":
                            ColorUtility.TryParseHtmlString("#37eaff", out Color energyblueColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, energyblueColor);
                            break;
                        case "energy green":
                            ColorUtility.TryParseHtmlString("#05E300", out Color energygreenColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, energygreenColor);
                            break;
                        case "energy purple":
                            ColorUtility.TryParseHtmlString("#7d0aff", out Color energypurpleColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, energypurpleColor);
                            break;
                        case "energy red":
                            ColorUtility.TryParseHtmlString("#ff9174", out Color energyredColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, energyredColor);
                            break;
                        default:
                            ColorUtility.TryParseHtmlString("#3c332d", out Color defaultColor);
                            surfaceDataCardColorDict.TryAdd(surfaceDataCardBarcode, defaultColor);
                            break;
                    }
                }
            }
        }
    }
}
#endif
