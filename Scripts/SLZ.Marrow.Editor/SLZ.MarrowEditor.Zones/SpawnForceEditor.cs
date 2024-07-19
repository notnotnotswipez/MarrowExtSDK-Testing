#if UNITY_EDITOR
using System;
using System.Reflection;
using SLZ.Marrow.Warehouse;
using SLZ.Marrow.Zones;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

namespace SLZ.MarrowEditor.Zones
{
    [CustomEditor(typeof(SpawnForce))]
    [CanEditMultipleObjects]
    public class SpawnForceEditor : Editor
    {
        SpawnForce script;
        private static GUIContent gizmoIcon = null;
        private PropertyField spawnAngularVelField;
        private PropertyField maxSpawnAngVelField;
        public virtual void OnEnable()
        {
            script = (SpawnForce)target;
            if (gizmoIcon == null)
            {
                gizmoIcon = new GUIContent(EditorGUIUtility.IconContent("d_GizmosToggle On@2x"));
                gizmoIcon.tooltip = "Toggle Preview Mesh Gizmo";
            }
        }

        public override VisualElement CreateInspectorGUI()
        {
            string VISUALTREE_PATH = AssetDatabase.GUIDToAssetPath("3e3f940b32a30e244bdf54810430d033");
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(VISUALTREE_PATH);
            VisualElement tree = visualTree.Instantiate();
            VisualElement validationFeedback = tree.Q<VisualElement>("validationFeedback");
            IMGUIContainer imguiValidationContainer = tree.Q<IMGUIContainer>("imguiValidationContainer");
            imguiValidationContainer.onGUIHandler = () =>
            {
                CrateSpawner _crateSpawner = null;
                Type type = script.GetType();
                FieldInfo fieldInfo = null;
                while (fieldInfo == null && type != null)
                {
                    fieldInfo = type.GetField("_crateSpawner", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    type = type.BaseType;
                }

                if (fieldInfo == null)
                {
                    throw new ArgumentOutOfRangeException("propName", "Field _crateSpawner was not found in Type " + script.GetType().FullName);
                }

                _crateSpawner = fieldInfo.GetValue(script) as CrateSpawner;
                if (_crateSpawner == null)
                {
                    EditorGUILayout.HelpBox("SpawnForce's CrateSpawner is missing.", MessageType.Error);
                }
            };
#if false
#endif
            spawnAngularVelField = tree.Q<PropertyField>("spawnAngularVelocity");
            maxSpawnAngVelField = tree.Q<PropertyField>("maxSpawnAngularVelocity");
            bool usingRandomValue = serializedObject.FindProperty(nameof(SpawnForce.maxSpawnAngularVelocity)).floatValue > 0;
            spawnAngularVelField.SetEnabled(!usingRandomValue);
            tree.Q<Foldout>("RandomAngularVelocityFoldout").value = usingRandomValue;
            maxSpawnAngVelField.RegisterValueChangeCallback(evt =>
            {
                spawnAngularVelField.SetEnabled(evt.changedProperty.floatValue <= 0);
            });
            ToolbarToggle showGizmoToggle = tree.Q<ToolbarToggle>("showGizmoToggle");
            Image gizmoImage = new Image
            {
                image = gizmoIcon.image
            };
            showGizmoToggle.Add(gizmoImage);
            showGizmoToggle.value = SpawnForce.drawVelocityStatic;
            showGizmoToggle.RegisterValueChangedCallback(evt =>
            {
                SpawnForce.drawVelocityStatic = evt.newValue;
                InternalEditorUtility.RepaintAllViews();
            });
            Button marrowDocsButton = tree.Q<Button>("marrowDocsButton");
            marrowDocsButton.clickable.clicked += () =>
            {
                Application.OpenURL("https://github.com/StressLevelZero/MarrowSDK/wiki/SpawnForce");
            };
            IMGUIContainer imguiInspector = tree.Q<IMGUIContainer>("imguiInspector");
            imguiInspector.onGUIHandler = () =>
            {
                DrawDefaultInspector();
            };
            return tree;
        }
    }
}
#endif
