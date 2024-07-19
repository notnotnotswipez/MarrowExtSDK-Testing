#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SLZ.Marrow.Utilities;
using SLZ.Marrow.Warehouse;
using SLZ.MarrowEditor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SLZ.Marrow
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ImpactProperties))]
    public class ImpactPropertiesEditor : Editor
    {
        ImpactProperties script;
        private static GUIContent previewMeshGizmoIcon = null;
        private static GUIContent materialIconOn = null;
        private static GUIContent materialIconOff = null;
        public ToolbarToggle showPreviewMeshToolbarToggle;
        private static List<GameObject> allGameObjects = new List<GameObject>();
        private static List<GameObject> unattachedColsMissingImpactProperties = new List<GameObject>();
        private static List<GameObject> rbAttachedColsMissingImpactProperties = new List<GameObject>();
        VisualElement applyPhysMatsContainer;
        private static GameObject m_LastHoveredObject;
        private void OnEnable()
        {
            script = (ImpactProperties)target;
            if (previewMeshGizmoIcon == null)
            {
                previewMeshGizmoIcon = new GUIContent(EditorGUIUtility.IconContent("d_GizmosToggle On@2x"));
                previewMeshGizmoIcon.tooltip = "Toggle Preview Mesh Gizmo";
            }

            if (allGameObjects == null)
            {
                allGameObjects = new List<GameObject>();
            }

            if (allGameObjects?.Count == 0)
            {
                allGameObjects = FindObjectsOfType<GameObject>().ToList();
                foreach (GameObject gameObj in allGameObjects)
                {
                    if (gameObj.TryGetComponent<Collider>(out var gameObjHasCol) && !gameObjHasCol.isTrigger)
                    {
                        if (!gameObj.GetComponent<ImpactProperties>())
                        {
                            if (gameObjHasCol.attachedRigidbody == null)
                            {
                                if (!unattachedColsMissingImpactProperties.Contains(gameObj))
                                {
                                    unattachedColsMissingImpactProperties.Add(gameObj);
                                }
                            }
                            else
                            {
                                if (gameObjHasCol.attachedRigidbody.gameObject.GetComponent<ImpactProperties>() == null)
                                {
                                    if (!rbAttachedColsMissingImpactProperties.Contains(gameObjHasCol.attachedRigidbody.gameObject))
                                    {
                                        rbAttachedColsMissingImpactProperties.Add(gameObjHasCol.attachedRigidbody.gameObject);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public override VisualElement CreateInspectorGUI()
        {
            string VISUALTREE_PATH = AssetDatabase.GUIDToAssetPath("2956736148bce0e4eb269d7c6a26fb1f");
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(VISUALTREE_PATH);
            VisualElement tree = visualTree.Instantiate();
            VisualElement validationFeedback = tree.Q<VisualElement>("validationFeedback");
            PropertyField surfaceDataCardField = tree.Q<PropertyField>("_surfaceDataCard");
            EnumField decalTypeField = tree.Q<EnumField>("DecalType");
            PropertyField surfaceDataField = tree.Q<PropertyField>("surfaceData");
            if (serializedObject.FindProperty("surfaceData") == null)
            {
                surfaceDataField.style.display = DisplayStyle.None;
            }

            applyPhysMatsContainer = tree.Q<VisualElement>("applyPhysMatsContainer");
            PhysicMaterial suggestedPhysMat = null;
            Label suggsetedPhysMatLabel = tree.Q<Label>("suggsetedPhysMatLabel");
            suggsetedPhysMatLabel.text = "";
            IMGUIContainer imguiValidationContainer = tree.Q<IMGUIContainer>("imguiValidationContainer");
            imguiValidationContainer.onGUIHandler = () =>
            {
            };
            if (ImpactPropertiesMeshGizmo.ShowGizmo == false)
            {
                SceneVisibilityManager.instance.EnableAllPicking();
            }

            string[] surfaceDCBarcode = new string[targets.Length];
            string[] surfaceDataName = new string[targets.Length];
            for (int t = 0; t < targets.Length; t++)
            {
                ImpactProperties impactProperties = (ImpactProperties)targets[t];
                if (impactProperties != null && impactProperties.SurfaceDataCard != null)
                {
                    surfaceDCBarcode[t] = impactProperties.SurfaceDataCard.Barcode.ToString();
                }

#if false
#endif
                ShowImpactPropsFieldHasOverride(impactProperties, decalTypeField);
                ShowImpactPropsFieldHasOverride(impactProperties, surfaceDataCardField);
            }

            suggestedPhysMat = UpdateSuggestedPhysMat(script);
            if (suggestedPhysMat != null && suggsetedPhysMatLabel.text.Replace(" (Instance)", "").Trim() != suggestedPhysMat.name.Trim())
            {
                suggsetedPhysMatLabel.text = suggestedPhysMat.name;
            }

            surfaceDataCardField.RegisterValueChangeCallback((evt) =>
            {
                for (int t = 0; t < targets.Length; t++)
                {
                    ImpactProperties impactProperties = (ImpactProperties)targets[t];
                    if (impactProperties != null && impactProperties.SurfaceDataCard != null && impactProperties.SurfaceDataCard.IsValid() && impactProperties.SurfaceDataCard.TryGetDataCard(out SurfaceDataCard sdc))
                    {
                        if (sdc != null && sdc.Barcode.ToString() != surfaceDCBarcode[t])
                        {
                            ImpactPropertiesMeshGizmo.DisableGizmo(impactProperties);
                            Undo.RecordObject(impactProperties, impactProperties.name + "SD Card updated");
                            surfaceDCBarcode[t] = sdc.Barcode.ToString();
                            EditorUtility.SetDirty(impactProperties);
                            if (PrefabUtility.GetPrefabAssetType(impactProperties) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(impactProperties) == PrefabAssetType.Variant)
                            {
                                PrefabUtility.RecordPrefabInstancePropertyModifications(impactProperties);
                                ShowImpactPropsFieldHasOverride(impactProperties, surfaceDataCardField);
                            }
                        }

                        suggestedPhysMat = UpdateSuggestedPhysMat(impactProperties);
                        if (suggestedPhysMat != null && suggsetedPhysMatLabel.text.Replace(" (Instance)", "").Trim() != suggestedPhysMat.name.Trim())
                        {
                            suggsetedPhysMatLabel.text = suggestedPhysMat.name;
                        }
                    }
                    else
                    {
                        if (impactProperties != null && ImpactPropertiesMeshGizmo.ShowGizmo)
                        {
                            ImpactPropertiesMeshGizmo.DisableGizmo(impactProperties);
                        }
                    }
                }
            });
            decalTypeField.RegisterValueChangedCallback((evt) =>
            {
                foreach (UnityEngine.Object target in targets)
                {
                    ImpactProperties impactProperties = (ImpactProperties)target;
                    Undo.RecordObject(impactProperties, impactProperties.name + "DecalType updated");
                    impactProperties.decalType = (ImpactProperties.DecalType)decalTypeField.value;
                    EditorUtility.SetDirty(impactProperties);
                    if (PrefabUtility.GetPrefabAssetType(impactProperties) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(impactProperties) == PrefabAssetType.Variant)
                    {
                        PrefabUtility.RecordPrefabInstancePropertyModifications(impactProperties);
                        ShowImpactPropsFieldHasOverride(impactProperties, decalTypeField);
                    }
                }
            });
            decalTypeField.value = script.decalType;
#if false
#endif
            Texture physmatIcon = EditorGUIUtility.ObjectContent(null, typeof(PhysicMaterial)).image;
            Image physmatIconImage = new Image();
            physmatIconImage.image = physmatIcon;
            physmatIconImage.style.flexShrink = 0;
            physmatIconImage.StretchToParentSize();
            VisualElement suggestPhysMatsIcon = tree.Q<VisualElement>("suggestPhysMatsIcon");
            suggestPhysMatsIcon.style.flexShrink = 0;
            suggestPhysMatsIcon.Add(physmatIconImage);
            Button applyPhysMatsButton = tree.Q<Button>("applyPhysMatsButton");
            applyPhysMatsButton.style.flexShrink = 0;
            applyPhysMatsButton.tooltip = "Applies the suggested Physics Material to this Impact Properties sibling collider(s)";
            applyPhysMatsButton.clickable.clicked += () =>
            {
                for (int t = 0; t < targets.Length; t++)
                {
                    ImpactProperties impactProperties = (ImpactProperties)targets[t];
                    if (impactProperties != null && impactProperties.SurfaceDataCard != null && impactProperties.SurfaceDataCard.IsValid() && suggestedPhysMat != null)
                    {
                        if (impactProperties.TryGetComponent<Collider>(out var siblingCol))
                        {
                            if (siblingCol.sharedMaterial != suggestedPhysMat)
                            {
                                if (PrefabUtility.HasPrefabInstanceAnyOverrides(impactProperties.gameObject, false))
                                {
                                    siblingCol.sharedMaterial = suggestedPhysMat;
                                }
                                else
                                {
                                    siblingCol.sharedMaterial = suggestedPhysMat;
                                }

                                EditorUtility.SetDirty(siblingCol);
                                if (PrefabUtility.GetPrefabAssetType(siblingCol) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(siblingCol) == PrefabAssetType.Variant)
                                {
                                    PrefabUtility.RecordPrefabInstancePropertyModifications(siblingCol);
                                }
                            }
                        }
                    }
                }
            };
            Button marrowDocsButton = tree.Q<Button>("marrowDocsButton");
            marrowDocsButton.clickable.clicked += () =>
            {
                Application.OpenURL("https://github.com/StressLevelZero/MarrowSDK/wiki/ImpactProperties");
            };
            IMGUIContainer imguiInspector = tree.Q<IMGUIContainer>("imguiInspector");
            imguiInspector.onGUIHandler = () =>
            {
                DrawDefaultInspector();
            };
            showPreviewMeshToolbarToggle = tree.Q<ToolbarToggle>("showPreviewMeshToolbarToggle");
            Image showPreviewMeshIconImage = new Image
            {
                image = previewMeshGizmoIcon.image
            };
            showPreviewMeshToolbarToggle.Add(showPreviewMeshIconImage);
            showPreviewMeshToolbarToggle.RegisterValueChangedCallback(evt =>
            {
                ImpactPropertiesMeshGizmo.ShowGizmo = showPreviewMeshToolbarToggle.value;
                UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
                if (ImpactPropertiesMeshGizmo.ShowGizmo)
                {
                    SurfaceDataPainterOverlay.DoWithInstances(instance => instance.displayed = true);
                    SurfaceDataPainterOverlay.DoWithInstances(instance => instance.collapsed = false);
                }
                else
                {
                    SurfaceDataPainterOverlay.DoWithInstances(instance => instance.displayed = false);
                }
            });
            SliderInt gizmoVisRangeSlider = tree.Q<SliderInt>("gizmoVisRangeSlider");
            gizmoVisRangeSlider.RegisterValueChangedCallback(evt =>
            {
                ImpactPropertiesMeshGizmo.gizmoVisRange = gizmoVisRangeSlider.value;
            });
            showPreviewMeshToolbarToggle.SetValueWithoutNotify(ImpactPropertiesMeshGizmo.ShowGizmo);
            gizmoVisRangeSlider.SetValueWithoutNotify((int)ImpactPropertiesMeshGizmo.gizmoVisRange);
            return tree;
        }

        private PhysicMaterial UpdateSuggestedPhysMat(ImpactProperties impactProperties)
        {
            bool colMatSuggestedMismatch = false;
            PhysicMaterial suggestedPhysMat;
            impactProperties.TryGetComponent(out Rigidbody ipRigidBody);
            if (impactProperties.SurfaceDataCard.TryGetDataCard(out SurfaceDataCard sdc))
            {
                if (ipRigidBody)
                {
                    suggestedPhysMat = (PhysicMaterial)AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(sdc.PhysicsMaterial.AssetGUID));
                }
                else
                {
                    suggestedPhysMat = (PhysicMaterial)AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(sdc.PhysicsMaterialStatic.AssetGUID));
                    ;
                }

                for (int t = 0; t < targets.Length; t++)
                {
                    ImpactProperties impactProp = (ImpactProperties)targets[t];
                    if (impactProp.TryGetComponent<Collider>(out var siblingColSelected))
                    {
                        if (siblingColSelected.sharedMaterial != suggestedPhysMat)
                        {
                            colMatSuggestedMismatch = true;
                        }
                    }
                }

                if (impactProperties.TryGetComponent<Collider>(out var siblingCol))
                {
                    if (siblingCol.sharedMaterial != suggestedPhysMat)
                    {
                        applyPhysMatsContainer.style.display = DisplayStyle.Flex;
                    }
                    else if (colMatSuggestedMismatch)
                    {
                        applyPhysMatsContainer.style.display = DisplayStyle.Flex;
                    }
                    else
                    {
                        applyPhysMatsContainer.style.display = DisplayStyle.None;
                    }
                }

                return suggestedPhysMat;
            }

            return null;
        }

        private void ShowImpactPropsFieldHasOverride(ImpactProperties impactProperties, VisualElement overrideField)
        {
            Color overrideMarginColor = new Color32(5, 147, 224, 255);
            if (PrefabUtility.HasPrefabInstanceAnyOverrides(impactProperties.gameObject, false))
            {
                PropertyModification[] prefabOverrides = PrefabUtility.GetPropertyModifications(impactProperties.gameObject);
                int decalOverrideCount = 0;
                int sdCardOverrideCount = 0;
                int obsSDOverrideCount = 0;
                foreach (var prefabOverride in prefabOverrides)
                {
                    if (PrefabStageUtility.GetCurrentPrefabStage() == null)
                    {
                        if (prefabOverride.propertyPath == "_surfaceDataCard._barcode._id" && overrideField.name == "_surfaceDataCard")
                        {
                            overrideField.style.marginLeft = 3;
                            overrideField.style.paddingLeft = 3;
                            overrideField.style.unityFontStyleAndWeight = FontStyle.Bold;
                            overrideField.style.borderLeftColor = overrideMarginColor;
                            overrideField.style.borderLeftWidth = 3;
                            sdCardOverrideCount++;
                        }

                        if (prefabOverride.propertyPath == "decalType" && overrideField.name == "DecalType")
                        {
                            overrideField.style.marginLeft = 3;
                            overrideField.style.paddingLeft = 3;
                            overrideField.style.unityFontStyleAndWeight = FontStyle.Bold;
                            overrideField.style.borderLeftColor = overrideMarginColor;
                            overrideField.style.borderLeftWidth = 3;
                            decalOverrideCount++;
                        }

                        if (prefabOverride.propertyPath == "surfaceData" && overrideField.name == "surfaceData")
                        {
                            overrideField.style.paddingLeft = 3;
                            overrideField.style.unityFontStyleAndWeight = FontStyle.Bold;
                            overrideField.style.borderLeftColor = overrideMarginColor;
                            overrideField.style.borderLeftWidth = 3;
                            obsSDOverrideCount++;
                        }
                    }
                }

                if (sdCardOverrideCount == 0 && overrideField.name == "_surfaceDataCard")
                {
                    overrideField.style.marginLeft = 0;
                    overrideField.style.paddingLeft = 0;
                    overrideField.style.unityFontStyleAndWeight = FontStyle.Normal;
                    overrideField.style.borderLeftColor = overrideMarginColor;
                    overrideField.style.borderLeftWidth = 0;
                }

                if (decalOverrideCount == 0 && overrideField.name == "DecalType")
                {
                    overrideField.style.paddingLeft = 0;
                    overrideField.style.unityFontStyleAndWeight = FontStyle.Normal;
                    overrideField.style.borderLeftColor = overrideMarginColor;
                    overrideField.style.borderLeftWidth = 0;
                }

                if (sdCardOverrideCount == 0 && overrideField.name == "surfaceData")
                {
                    overrideField.style.paddingLeft = 0;
                    overrideField.style.unityFontStyleAndWeight = FontStyle.Normal;
                    overrideField.style.borderLeftColor = overrideMarginColor;
                    overrideField.style.borderLeftWidth = 0;
                }
            }
        }

        private void ApplyObsoleteSurfaceDataMats(ImpactProperties impactProperties)
        {
            object[] parametersArray = new Transform[]
            {
                impactProperties.transform
            };
            Type type = impactProperties.GetType();
            MethodInfo methodInfo = type.GetMethod("ObsoleteUpdateMaterialRecursive", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            methodInfo.Invoke(impactProperties, parametersArray);
        }

        private void ApplySurfaceDataCardMats(ImpactProperties impactProperties)
        {
            object[] parametersArray = new Transform[]
            {
                impactProperties.transform
            };
            Type type = impactProperties.GetType();
            MethodInfo methodInfo = type.GetMethod("ApplyPhysMatsRecursive", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            methodInfo.Invoke(impactProperties, parametersArray);
        }

        private static void OnGlobalSceneGUI(SceneView sceneView)
        {
            if (ImpactPropertiesMeshGizmo.ShowGizmo)
            {
                PickHoverObject();
                GenerateHoverText();
            }

            if (ImpactProperties.showMissingImpactProperties)
            {
                foreach (GameObject gameObj in unattachedColsMissingImpactProperties)
                {
                    Gizmos.color = Color.red;
                    DrawGizmoHelper.DrawText("MISSING IMPACT PROPS", gameObj.transform.position);
                }

                foreach (GameObject gameObj in rbAttachedColsMissingImpactProperties)
                {
                    Gizmos.color = Color.red;
                    DrawGizmoHelper.DrawText("ATTACHED RB MISSING IMPACT PROPS", gameObj.transform.position);
                }
            }
        }

        public static void PickHoverObject()
        {
            var evt = Event.current;
            if (evt.type == EventType.MouseMove)
            {
                var picked = HandleUtility.PickGameObject(evt.mousePosition, false);
                if (picked != m_LastHoveredObject)
                {
                    m_LastHoveredObject = picked;
                }
            }
            else if (evt.type == EventType.MouseDrag && evt.button == 1)
            {
                var picked = HandleUtility.PickGameObject(evt.mousePosition, false);
                if (picked != m_LastHoveredObject)
                {
                    m_LastHoveredObject = picked;
                }
            }

            HoverHighlight();
        }

        [InitializeOnLoadMethod]
        static void InitSceneGUICallback()
        {
            SceneView.duringSceneGui += OnGlobalSceneGUI;
        }

        private static GameObject lastHoveredObject;
        private static Collider lastHighlightedCollider = null;
        private static List<Collider> currentSelectedColliders = new List<Collider>();
        private static List<Collider> lastSelectedColliders = new List<Collider>();
        private static Color selectColor = new Color(0.5f, 0.5f, 0.5f);
        private static Color hoverColor = new Color(0.25f, 0.25f, 0.25f);
        private static HashSet<int> selectedColliderIDs = new HashSet<int>();
        static void HoverHighlight()
        {
            if (ImpactPropertiesMeshGizmo.ShowGizmo)
            {
                var evt = Event.current;
                var selectedGOs = Selection.gameObjects;
                selectedColliderIDs.Clear();
                currentSelectedColliders.Clear();
                foreach (var selected in selectedGOs)
                {
                    if (selected.TryGetComponent<Collider>(out var selectedCollider) && !selectedCollider.isTrigger)
                    {
                        currentSelectedColliders.Add(selectedCollider);
                        selectedColliderIDs.Add(selectedCollider.GetInstanceID());
                    }
                }

                var deselected = lastSelectedColliders.Except(currentSelectedColliders);
                foreach (var lastSelected in deselected)
                {
                    ImpactPropertiesMeshGizmo.HighlightGizmo(lastSelected, false);
                }

                var newSelection = currentSelectedColliders.Except(lastSelectedColliders);
                foreach (var newSelected in newSelection)
                {
                    ImpactPropertiesMeshGizmo.HighlightGizmo(newSelected, selectColor);
                }

                lastSelectedColliders.Clear();
                foreach (var selectedCollider in currentSelectedColliders)
                {
                    lastSelectedColliders.Add(selectedCollider);
                }

                if (evt.type != EventType.Repaint)
                {
                    switch (evt.type)
                    {
                        case EventType.MouseMove:
                        case EventType.MouseDown:
                        case EventType.MouseUp:
                            var picked = HandleUtility.PickGameObject(evt.mousePosition, out _);
                            if (picked != null && (lastHoveredObject == null || picked != lastHoveredObject))
                            {
                                Collider pickedCollider = null;
                                if (picked.activeInHierarchy)
                                {
                                    if (!picked.TryGetComponent<Collider>(out pickedCollider) || pickedCollider.isTrigger)
                                    {
                                        if (picked.TryGetComponent<ImpactPropertiesMeshGizmo>(out var gizmo) && !gizmo.Collider.isTrigger)
                                        {
                                            pickedCollider = gizmo.Collider;
                                        }
                                    }

                                    if (pickedCollider && selectedColliderIDs.Contains(pickedCollider.GetInstanceID()))
                                    {
                                        if (lastHighlightedCollider && !selectedColliderIDs.Contains(lastHighlightedCollider.GetInstanceID()))
                                        {
                                            ImpactPropertiesMeshGizmo.HighlightGizmo(lastHighlightedCollider, false);
                                        }

                                        lastHighlightedCollider = null;
                                        lastHoveredObject = null;
                                        return;
                                    }
                                }

                                if (pickedCollider)
                                {
                                    if (lastHighlightedCollider)
                                    {
                                        if (!selectedColliderIDs.Contains(lastHighlightedCollider.GetInstanceID()))
                                        {
                                            ImpactPropertiesMeshGizmo.HighlightGizmo(lastHighlightedCollider, false);
                                        }

                                        lastHighlightedCollider = null;
                                    }

                                    if (!lastHighlightedCollider || pickedCollider != lastHighlightedCollider)
                                    {
                                        ImpactPropertiesMeshGizmo.HighlightGizmo(pickedCollider, hoverColor);
                                        lastHighlightedCollider = pickedCollider;
                                    }
                                }
                                else
                                {
                                    if (lastHighlightedCollider)
                                        ImpactPropertiesMeshGizmo.HighlightGizmo(lastHighlightedCollider, false);
                                }

                                lastHoveredObject = picked;
                            }
                            else if (picked == null)
                            {
                                if (lastHoveredObject)
                                {
                                    if (lastHighlightedCollider)
                                    {
                                        if (!selectedColliderIDs.Contains(lastHighlightedCollider.GetInstanceID()))
                                        {
                                            ImpactPropertiesMeshGizmo.HighlightGizmo(lastHighlightedCollider, false);
                                        }

                                        lastHighlightedCollider = null;
                                    }

                                    lastHoveredObject = null;
                                }

                                if (lastHighlightedCollider)
                                {
                                    if (!selectedColliderIDs.Contains(lastHighlightedCollider.GetInstanceID()))
                                    {
                                        ImpactPropertiesMeshGizmo.HighlightGizmo(lastHighlightedCollider, false);
                                    }

                                    lastHighlightedCollider = null;
                                }
                            }

                            break;
                    }
                }
            }
        }

        public static void GenerateHoverText()
        {
            if (m_LastHoveredObject == null)
            {
                return;
            }

            Camera sceneCam = SceneView.lastActiveSceneView.camera;
            Vector3 mousePosition = Event.current.mousePosition;
            mousePosition.y = SceneView.lastActiveSceneView.camera.pixelHeight - mousePosition.y;
            mousePosition.z = sceneCam.nearClipPlane + 0.5f;
            Vector3 cursorPos = sceneCam.ScreenToWorldPoint(mousePosition);
            int fontSize = 15;
            Collider hitCol = m_LastHoveredObject?.GetComponentInParent<Collider>();
            string mouseInfoString = "";
            GUIStyle linkHandleStyle = new GUIStyle();
            linkHandleStyle.richText = true;
            ;
            if (hitCol != null && hitCol.isTrigger == false)
            {
                if (Camera.current != null && Camera.current == SceneView.lastActiveSceneView.camera && Vector3.Dot(hitCol.transform.position - Camera.current.transform.position, Camera.current.transform.forward) < ImpactPropertiesMeshGizmo.gizmoVisRange)
                {
                    if (hitCol.attachedRigidbody == null)
                    {
                        ImpactProperties impactProp = hitCol.GetComponent<ImpactProperties>();
                        ImpactProperties.surfaceDataBrushTarget = null;
                        if (impactProp == null)
                        {
                            mouseInfoString = $"\n<size={fontSize}><color=red>     <b>MISSING IMPACT PROPERTIES</b></color>\n";
                            if (ImpactProperties.surfaceDataBrush)
                            {
                                string hexColor = ColorUtility.ToHtmlStringRGB(ImpactPropertiesMeshGizmo.surfaceDataCardColorDict[ImpactProperties.surfaceDataBrush.Barcode]);
                                mouseInfoString += $"     <color=#{hexColor}>Brush: {ImpactProperties.surfaceDataBrush.Title}</color></size>";
                            }
                            else
                            {
                                mouseInfoString += $"     <color=grey>Brush: No brush selected</color></size>";
                            }
                        }
                        else
                        {
                            mouseInfoString = "";
                            if (impactProp.SurfaceDataCard != null && impactProp.SurfaceDataCard.IsValid() && impactProp.SurfaceDataCard.TryGetDataCard(out var dataCard))
                            {
                                mouseInfoString = $"\n<size={fontSize}><color=white>     Surface Data: {dataCard.Title}</color>\n";
                                ImpactProperties.surfaceDataBrushTarget = dataCard;
                            }
                            else
                            {
                                mouseInfoString = $"\n<size={fontSize}><color=red>     Surface Data: <b>SURFACE DATA MISSING</b></color>\n";
                            }

                            if (ImpactProperties.surfaceDataBrush)
                            {
                                string hexColor = ColorUtility.ToHtmlStringRGB(ImpactPropertiesMeshGizmo.surfaceDataCardColorDict[ImpactProperties.surfaceDataBrush.Barcode]);
                                mouseInfoString += $"     <color=#{hexColor}>Brush: {ImpactProperties.surfaceDataBrush.Title}</color></size>";
                            }
                            else
                            {
                                mouseInfoString += $"     <color=grey>Brush: No brush selected</color></size>";
                            }
                        }
                    }
                    else
                    {
                        ImpactProperties impactPropsRB = hitCol.attachedRigidbody.GetComponent<ImpactProperties>();
                        ImpactProperties.surfaceDataBrushTarget = null;
                        if (impactPropsRB == null)
                        {
                            mouseInfoString = $"\n<size={fontSize}><color=red>     <b>ATTACHED RB MISSING IMPACT PROPERTIES</b></color>\n";
                            if (ImpactProperties.surfaceDataBrush)
                            {
                                string hexColor = ColorUtility.ToHtmlStringRGB(ImpactPropertiesMeshGizmo.surfaceDataCardColorDict[ImpactProperties.surfaceDataBrush.Barcode]);
                                mouseInfoString += $"     <color=#{hexColor}>Brush: {ImpactProperties.surfaceDataBrush.Title}</color></size>";
                            }
                            else
                            {
                                mouseInfoString += $"     <color=grey>Brush: No brush selected</color></size>";
                            }
                        }
                        else
                        {
                            mouseInfoString = "";
                            if (impactPropsRB.SurfaceDataCard != null && impactPropsRB.SurfaceDataCard.IsValid() && impactPropsRB.SurfaceDataCard.TryGetDataCard(out var rbDataCard))
                            {
                                mouseInfoString = $"\n<size={fontSize}><color=white>     Surface Data: {rbDataCard.Title}</color>\n";
                                ImpactProperties.surfaceDataBrushTarget = rbDataCard;
                            }
                            else
                            {
                                mouseInfoString = $"\n<size={fontSize}><color=red>     Surface Data: <b>SURFACE DATA MISSING</b></color>\n";
                            }

                            if (ImpactProperties.surfaceDataBrush)
                            {
                                string hexColor = ColorUtility.ToHtmlStringRGB(ImpactPropertiesMeshGizmo.surfaceDataCardColorDict[ImpactProperties.surfaceDataBrush.Barcode]);
                                mouseInfoString += $"     <color=#{hexColor}>Brush: {ImpactProperties.surfaceDataBrush.Title}</color></size>";
                            }
                            else
                            {
                                mouseInfoString += $"     <color=grey>Brush: No brush selected</color></size>";
                            }
                        }
                    }

                    Handles.Label(cursorPos, $"{mouseInfoString}", linkHandleStyle);
                }
            }
        }
    }
}
#endif
