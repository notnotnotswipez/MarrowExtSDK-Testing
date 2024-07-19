using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using SLZ.Marrow;
using System;
using UnityEditor.UIElements;
using System.Collections.Generic;
using System.Linq;
using SLZ.Marrow.Warehouse;
using System.Threading.Tasks;
using UnityEditor.SceneManagement;
using ObjectField = UnityEditor.UIElements.ObjectField;
using SLZ.Marrow.Utilities;

#if UNITY_EDITOR
namespace SLZ.MarrowEditor
{
    public class PrefabRootAndImpactPropAndCol
    {
        public GameObject prefabRoot;
        public ImpactProperties impactProp;
        public Collider siblingCollider;
    }

    public class ImpactPropUtilsNewEditorWindow : EditorWindow
    {
        List<PrefabRootAndImpactPropAndCol> impactPropsList;
        List<string> surfaceDataCardNames = new List<string>();
        List<Barcode> surfaceDataCardList = new List<Barcode>();
        Button ipSetSelectionAsIPList;
        Toggle ipRecursiveSelectionToggle;
        Label impactPropsAssetSearchPathLabel;
        Button impactPropsAssetSearchPathButton;
        ToolbarToggle impactPropsAllScene;
        ToolbarToggle impactPropsOverridesOnly;
        ToolbarToggle impactPropsSDCardMissingOverride;
        ToolbarToggle impactPropsAllProjectPrefabs;
        ToolbarToggle impactPropsSDCardMissing;
        VisualElement multiSelectApplyContainer;
        VisualElement allAndEmptyBorderContainer;
        VisualElement listViewContainer;
        private string assetSearchPath;
        Label objectsListedLabel;
        Dictionary<int, SurfaceDataCard> changedSurfaceDataCards;
        Dictionary<int, PhysicMaterial> changedPhysMats;
        Button ipApplyModifiedButton;
        Button ipSurfaceDataPainterToolButton;
        VisualElement ipSurfaceDataPainterIconContainer;
        Toggle applyPhysMatsToggle;
        Texture colliderIcon;
        VisualElement tree;
        [MenuItem("Stress Level Zero/LevelTools/Impact Properties Utilities")]
        public static void ShowImpactPropUtilsWindow()
        {
            string sdImagePath = MarrowSDK.GetPackagePath("Editor/Assets/Icons/Warehouse/surfacedata.png");
            Texture2D surfaceDataCardIconImage = EditorGUIUtility.Load(sdImagePath) as Texture2D;
            EditorWindow createIPUtilsWin = GetWindow<ImpactPropUtilsNewEditorWindow>();
            createIPUtilsWin.titleContent = new GUIContent(" Impact Prop Utils");
            createIPUtilsWin.titleContent.image = surfaceDataCardIconImage;
            createIPUtilsWin.minSize = new Vector2(1420, 800);
        }

        public void CreateGUI()
        {
            string VISUALTREE_PATH = AssetDatabase.GUIDToAssetPath("09cb1d48edcb3684ebbd6a0c46a09b8e");
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(VISUALTREE_PATH);
            tree = visualTree.Instantiate();
            tree.StretchToParentSize();
            rootVisualElement.Add(tree);
            IMGUIContainer imguiValidationContainer = tree.Q<IMGUIContainer>("imguiValidationContainer");
            imguiValidationContainer.onGUIHandler = () =>
            {
            };
            string sdImagePath = MarrowSDK.GetPackagePath("Editor/Assets/Icons/Warehouse/surfacedata.png");
            Texture2D surfaceDataCardIcon = EditorGUIUtility.Load(sdImagePath) as Texture2D;
            impactPropsAssetSearchPathLabel = tree.Q<Label>("impactPropsAssetSearchPathLabel");
            impactPropsAssetSearchPathButton = tree.Q<Button>("impactPropsAssetSearchPathButton");
            impactPropsAllProjectPrefabs = tree.Q<ToolbarToggle>("impactPropsAllProjectPrefabs");
            impactPropsSDCardMissing = tree.Q<ToolbarToggle>("impactPropsSDCardMissing");
            impactPropsAllScene = tree.Q<ToolbarToggle>("impactPropsAllScene");
            impactPropsOverridesOnly = tree.Q<ToolbarToggle>("impactPropsOverridesOnly");
            impactPropsSDCardMissingOverride = tree.Q<ToolbarToggle>("impactPropsSDCardMissingOverride");
            ipSetSelectionAsIPList = tree.Q<Button>("ipSetSelectionAsIPList");
            ipRecursiveSelectionToggle = tree.Q<Toggle>("ipRecursiveSelectionToggle");
            objectsListedLabel = tree.Q<Label>("objectsListedLabel");
            ipApplyModifiedButton = tree.Q<Button>("ipApplyModifiedButton");
            applyPhysMatsToggle = tree.Q<Toggle>("applyPhysMatsToggle");
            multiSelectApplyContainer = tree.Q<VisualElement>("multiSelectApplyContainer");
            allAndEmptyBorderContainer = tree.Q<VisualElement>("allAndEmptyBorderContainer");
            ipSurfaceDataPainterToolButton = tree.Q<Button>("ipSurfaceDataPainterToolButton");
            ipSurfaceDataPainterIconContainer = tree.Q<VisualElement>("ipSurfaceDataPainterIconContainer");
            Image surfaceDataCardIconImage = new Image();
            surfaceDataCardIconImage.image = surfaceDataCardIcon;
            ipSurfaceDataPainterIconContainer.Add(surfaceDataCardIconImage);
            listViewContainer = tree.Q<VisualElement>("listViewContainer");
            changedSurfaceDataCards = new Dictionary<int, SurfaceDataCard>();
            changedPhysMats = new Dictionary<int, PhysicMaterial>();
            colliderIcon = EditorGUIUtility.ObjectContent(null, typeof(BoxCollider)).image;
            GetAWSurfaceDataCards();
            ipApplyModifiedButton.style.display = DisplayStyle.None;
            applyPhysMatsToggle.value = false;
            applyPhysMatsToggle.style.display = DisplayStyle.None;
            allAndEmptyBorderContainer.style.display = DisplayStyle.None;
            assetSearchPath = "Assets";
            impactPropsAssetSearchPathLabel.text = assetSearchPath;
            objectsListedLabel.text = $"Objects<br>Listed: 0";
            SceneVisibilityManager.instance.EnableAllPicking();
            string stripPathExcess = Application.dataPath;
            stripPathExcess = stripPathExcess.Replace("Assets", "");
            impactPropsAssetSearchPathButton.clickable.clicked += () =>
            {
                assetSearchPath = EditorUtility.OpenFolderPanel($"Set Asset Search Path", "Assets", "");
                assetSearchPath = assetSearchPath.Replace(stripPathExcess, "");
                impactPropsAssetSearchPathLabel.text = assetSearchPath;
                impactPropsAssetSearchPathLabel.tooltip = assetSearchPath;
            };
            impactPropsAllProjectPrefabs.RegisterValueChangedCallback((evt) =>
            {
                ClearToolbarToggles();
                impactPropsAllProjectPrefabs.SetValueWithoutNotify(true);
                if (impactPropsAllProjectPrefabs.value)
                {
                    objectsListedLabel.text = "Please wait...";
                    FindImpactPropsProjectPrefabs();
                }
            });
            impactPropsSDCardMissing.RegisterValueChangedCallback((evt) =>
            {
                ClearToolbarToggles();
                impactPropsSDCardMissing.SetValueWithoutNotify(true);
                if (impactPropsSDCardMissing.value)
                {
                    objectsListedLabel.text = "Please wait...";
                    FindImpactPropsMissingSDCardOnPrefab();
                }
            });
            impactPropsAllScene.RegisterValueChangedCallback((evt) =>
            {
                ClearToolbarToggles();
                impactPropsAllScene.SetValueWithoutNotify(true);
                if (impactPropsAllScene.value)
                {
                    objectsListedLabel.text = "Please wait...";
                    FindAllImpactPropsScene();
                }
            });
            impactPropsOverridesOnly.RegisterValueChangedCallback((evt) =>
            {
                ClearToolbarToggles();
                impactPropsOverridesOnly.SetValueWithoutNotify(true);
                if (impactPropsOverridesOnly.value)
                {
                    objectsListedLabel.text = "Please wait...";
                    FindImpactPropsOverridesOnlyScene();
                }
            });
            impactPropsSDCardMissingOverride.RegisterValueChangedCallback((evt) =>
            {
                ClearToolbarToggles();
                impactPropsSDCardMissingOverride.SetValueWithoutNotify(true);
                if (impactPropsSDCardMissingOverride.value)
                {
                    objectsListedLabel.text = "Please wait...";
                    FindImpactPropsMissingSDCardOverride();
                }
            });
            ipSetSelectionAsIPList.clickable.clicked += () =>
            {
                FindSelectedImpactPropsScene();
            };
            ipSurfaceDataPainterToolButton.clickable.clicked += () =>
            {
                ImpactPropertiesMeshGizmo.ShowGizmo = true;
                SurfaceDataPainterOverlay.DoWithInstances(instance => instance.displayed = true);
                SurfaceDataPainterOverlay.DoWithInstances(instance => instance.collapsed = false);
                this.Close();
            };
            AssetWarehouse.OnReady(() =>
            {
                impactPropsAllScene.value = true;
            });
        }

        private void GetAWSurfaceDataCards()
        {
            List<Scannable> palletScannables;
            List<Scannable> allScannables = new List<Scannable>();
            if (surfaceDataCardNames == null)
            {
                surfaceDataCardNames = new List<string>();
            }

            if (surfaceDataCardList == null)
            {
                surfaceDataCardList = new List<Barcode>();
            }

            AssetWarehouse.OnReady(() =>
            {
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
                            surfaceDataCardNames.Add(surfaceDataCard.Title);
                        }
                    }
                }
            });
        }

        private void FindImpactPropsProjectPrefabs()
        {
            FindPrefabsInProject("allprojectprefabs");
            CreateImpactPropsList("allprojectprefabs");
        }

        private void FindImpactPropsMissingSDCardOnPrefab()
        {
            FindPrefabsInProject("missingsdcardprefab");
            CreateImpactPropsList("missingsdcardprefab");
        }

        private void FindAllImpactPropsScene()
        {
            FindPrefabInstances("allscene");
            CreateImpactPropsList("allscene");
        }

        private void FindSelectedImpactPropsScene()
        {
            FindPrefabInstances("selectedscene");
            CreateImpactPropsList("selectedscene");
        }

        private void FindImpactPropsOverridesOnlyScene()
        {
            FindPrefabInstances("overridesonlyscene");
            CreateImpactPropsList("overridesonlyscene");
        }

        private void FindImpactPropsMissingSDCardOverride()
        {
            FindPrefabInstances("missingsdcardoverride");
            CreateImpactPropsList("missingsdcardoverride");
        }

        private void ClearToolbarToggles()
        {
            impactPropsAllProjectPrefabs.SetValueWithoutNotify(false);
            impactPropsSDCardMissing.SetValueWithoutNotify(false);
            impactPropsAllScene.SetValueWithoutNotify(false);
            impactPropsOverridesOnly.SetValueWithoutNotify(false);
            impactPropsSDCardMissingOverride.SetValueWithoutNotify(false);
            ipApplyModifiedButton.style.display = DisplayStyle.None;
            applyPhysMatsToggle.style.display = DisplayStyle.None;
        }

        private void CreateImpactPropsList(string searchMode)
        {
            listViewContainer.Clear();
            ListView impactPropsMultiListView = new ListView();
            impactPropsMultiListView.name = "impactPropsMultiListView";
            impactPropsMultiListView.fixedItemHeight = 20;
            impactPropsMultiListView.selectionType = SelectionType.Multiple;
            impactPropsMultiListView.showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly;
            impactPropsMultiListView.showBoundCollectionSize = false;
            listViewContainer.Add(impactPropsMultiListView);
            impactPropsMultiListView.itemsSource = impactPropsList;
            impactPropsMultiListView.onSelectionChange -= ListSelectionChanged;
            impactPropsMultiListView.onSelectionChange += ListSelectionChanged;
            impactPropsMultiListView.makeItem = () => new VisualElement();
            Color origRowBGColor = new Color();
            Color changedRowBGColor = new Color(0.5f, 0.5f, 0f);
            Color changedRowPhysMatBGColor = new Color(0f, 0.5f, 0f);
            impactPropsMultiListView.bindItem = (VisualElement ipContainer, int i) =>
            {
                ipContainer.Clear();
                ipContainer.style.flexDirection = FlexDirection.Row;
                ipContainer.style.alignItems = Align.Center;
                VisualElement dropdownFieldContainer = new VisualElement();
                dropdownFieldContainer.style.backgroundColor = origRowBGColor;
                dropdownFieldContainer.style.flexDirection = FlexDirection.Row;
                dropdownFieldContainer.style.alignItems = Align.Center;
                VisualElement ipItemLabelContainer = new VisualElement();
                ipItemLabelContainer.style.flexDirection = FlexDirection.Row;
                ipItemLabelContainer.style.width = 440;
                ipItemLabelContainer.style.height = 20;
                ipItemLabelContainer.style.flexShrink = 0;
                dropdownFieldContainer.Add(ipItemLabelContainer);
                VisualElement ipPrefabIcon = new VisualElement();
                ipPrefabIcon.name = "ipPrefabIcon";
                ipPrefabIcon.style.flexShrink = 0;
                ipPrefabIcon.style.width = 20;
                ipPrefabIcon.style.height = 20;
                ipItemLabelContainer.Add(ipPrefabIcon);
                Label ipPrefabRootLabel = new Label();
                ipPrefabRootLabel.name = "ipPrefabRootLabel";
                ipPrefabRootLabel.style.height = 20;
                ipPrefabRootLabel.style.unityTextAlign = TextAnchor.MiddleLeft;
                ipItemLabelContainer.Add(ipPrefabRootLabel);
                VisualElement ipColliderIcon = new VisualElement();
                ipColliderIcon.name = "ipColliderIcon";
                ipColliderIcon.style.flexShrink = 0;
                ipColliderIcon.style.width = 20;
                ipColliderIcon.style.height = 20;
                ipItemLabelContainer.Add(ipColliderIcon);
                Label ipImpactPropLabel = new Label();
                ipImpactPropLabel.name = "ipImpactPropLabel";
                ipImpactPropLabel.style.height = 20;
                ipImpactPropLabel.style.unityTextAlign = TextAnchor.MiddleLeft;
                ipItemLabelContainer.Add(ipImpactPropLabel);
                Texture2D prefabIcon;
                if (impactPropsList[i].prefabRoot != null)
                {
                    prefabIcon = PrefabUtility.GetIconForGameObject(impactPropsList[i].prefabRoot);
                }
                else
                {
                    prefabIcon = EditorGUIUtility.ObjectContent(null, typeof(GameObject)).image as Texture2D;
                }

                Image prefabIconImage = new Image();
                prefabIconImage.image = prefabIcon;
                prefabIconImage.StretchToParentSize();
                ipPrefabIcon.Add(prefabIconImage);
                ipPrefabRootLabel.text = impactPropsList[i].prefabRoot?.name + " -> ";
                ipPrefabRootLabel.tooltip = $"Prefab Root: {impactPropsList[i].prefabRoot?.name}";
                Image colliderIconImage = new Image();
                colliderIconImage.image = colliderIcon;
                colliderIconImage.StretchToParentSize();
                ipColliderIcon.Add(colliderIconImage);
                ipImpactPropLabel.text = $"<b>{impactPropsList[i]?.impactProp?.name}</b>";
                ipImpactPropLabel.tooltip = $"ImpactProperties: {impactPropsList[i]?.impactProp?.name}";
                DropdownField ipSurfaceCardDataObjField = new DropdownField();
                ipSurfaceCardDataObjField.name = "ipSurfaceCardDataObjField";
                ipSurfaceCardDataObjField.style.width = 250;
                ipSurfaceCardDataObjField.style.paddingLeft = 10;
                ipSurfaceCardDataObjField.style.paddingRight = 10;
                ipSurfaceCardDataObjField.choices = surfaceDataCardNames;
                ImpactProperties impactProperties = impactPropsList[i].impactProp;
                ipSurfaceCardDataObjField.RegisterValueChangedCallback(evt =>
                {
                    foreach (var sdCardBarcode in surfaceDataCardList)
                    {
                        if (AssetWarehouse.ready && !Application.isPlaying && AssetWarehouse.Instance.TryGetDataCard(sdCardBarcode, out var sdCard))
                        {
                            if (ipSurfaceCardDataObjField.value.ToLower().Trim() == sdCard.Title.ToLower().Trim())
                            {
                                changedSurfaceDataCards.TryAdd(i, sdCard as SurfaceDataCard);
                                if (changedSurfaceDataCards[i] != sdCard as SurfaceDataCard)
                                {
                                    changedSurfaceDataCards[i] = sdCard as SurfaceDataCard;
                                }

                                dropdownFieldContainer.style.backgroundColor = changedRowBGColor;
                            }
                        }
                    }
                });
                if (changedSurfaceDataCards.Keys.Contains(i))
                {
                    string sdcFieldName = ipSurfaceCardDataObjField.value;
                    if (sdcFieldName != changedSurfaceDataCards[i].Title)
                    {
                        ipSurfaceCardDataObjField.value = changedSurfaceDataCards[i].Title;
                        dropdownFieldContainer.style.backgroundColor = changedRowBGColor;
                    }
                }
                else
                {
                    if (impactProperties.SurfaceDataCard != null && impactProperties.SurfaceDataCard.IsValid() && impactProperties.SurfaceDataCard.DataCard != null)
                    {
                        ipSurfaceCardDataObjField.value = impactProperties.SurfaceDataCard.DataCard.Title;
                    }

                    dropdownFieldContainer.style.backgroundColor = origRowBGColor;
                }

                dropdownFieldContainer.Add(ipSurfaceCardDataObjField);
                ipContainer.Add(dropdownFieldContainer);
                if (impactPropsList[i].siblingCollider)
                {
                    VisualElement physMatFieldContainer = new VisualElement();
                    physMatFieldContainer.style.backgroundColor = origRowBGColor;
                    physMatFieldContainer.style.flexDirection = FlexDirection.Row;
                    physMatFieldContainer.style.alignItems = Align.Center;
                    Collider physMatCol = impactPropsList[i].siblingCollider;
                    Button ipSuggestMatsButton = new Button();
                    ipSuggestMatsButton.name = "ipSuggestMatsButton";
                    ipSuggestMatsButton.style.width = 24;
                    ipSuggestMatsButton.style.height = 16;
                    ipSuggestMatsButton.style.marginLeft = 10;
                    physMatFieldContainer.Add(ipSuggestMatsButton);
                    VisualElement ipColliderMatsIcon = new VisualElement();
                    ipColliderMatsIcon.name = "ipColliderMatsIcon";
                    ipColliderMatsIcon.style.flexShrink = 0;
                    ipColliderMatsIcon.style.width = 12;
                    ipColliderMatsIcon.style.height = 12;
                    ipSuggestMatsButton.Add(ipColliderMatsIcon);
                    ObjectField ipPhysicMaterialField = new ObjectField();
                    ipPhysicMaterialField.name = "ipPhysicMaterialField";
                    ipPhysicMaterialField.objectType = typeof(PhysicMaterial);
                    ipPhysicMaterialField.style.width = 260;
                    ipPhysicMaterialField.style.paddingRight = 10;
                    ipPhysicMaterialField.style.paddingLeft = 10;
                    physMatFieldContainer.Add(ipPhysicMaterialField);
                    Texture colliderMatsIcon = EditorGUIUtility.ObjectContent(null, typeof(BoxCollider)).image;
                    Image colliderMatsIconImage = new Image();
                    colliderMatsIconImage.image = colliderMatsIcon;
                    colliderMatsIconImage.StretchToParentSize();
                    ipColliderMatsIcon.Add(colliderMatsIconImage);
                    ipPhysicMaterialField.RegisterValueChangedCallback(evt =>
                    {
                        if (evt?.newValue?.name.Replace(" (Instance)", "").Trim() != physMatCol.sharedMaterial?.name.Replace(" (Instance)", "").Trim())
                        {
                            changedPhysMats.TryAdd(i, evt.newValue as PhysicMaterial);
                            if (changedPhysMats[i] != evt.newValue as PhysicMaterial)
                            {
                                changedPhysMats[i] = evt.newValue as PhysicMaterial;
                            }

                            physMatFieldContainer.style.backgroundColor = changedRowPhysMatBGColor;
                        }
                    });
                    if (changedPhysMats.Keys.Contains(i))
                    {
                        PhysicMaterial physMatField = ipPhysicMaterialField.value as PhysicMaterial;
                        if (physMatField != changedPhysMats[i])
                        {
                            ipPhysicMaterialField.value = changedPhysMats[i];
                            physMatFieldContainer.style.backgroundColor = changedRowPhysMatBGColor;
                        }
                    }
                    else
                    {
                        ipPhysicMaterialField.value = physMatCol.sharedMaterial;
                    }

                    ipSuggestMatsButton.text = " ";
                    ipSuggestMatsButton.tooltip = "Suggests a reasonable Physics Material based on the Surface Data Card";
                    ipSuggestMatsButton.clickable.clicked += () =>
                    {
                        SurfaceDataCard sdc = impactPropsList[i].impactProp.SurfaceDataCard.DataCard;
                        if (changedSurfaceDataCards.ContainsKey(i))
                        {
                            sdc = changedSurfaceDataCards[i];
                        }

                        PhysicMaterial suggestedPhysMat = null;
                        impactPropsList[i].impactProp.TryGetComponent(out Rigidbody ipRigidBody);
                        if (sdc)
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
                        }

                        if (suggestedPhysMat != null && ipPhysicMaterialField.value?.name.Replace(" (Instance)", "").Trim() != suggestedPhysMat.name.Trim())
                        {
                            ipPhysicMaterialField.value = suggestedPhysMat;
                            changedPhysMats.TryAdd(i, suggestedPhysMat);
                            physMatFieldContainer.style.backgroundColor = changedRowPhysMatBGColor;
                        }
                    };
                    ipContainer.Add(physMatFieldContainer);
                }
                else
                {
                    Label noSiblingCollider = new Label();
                    noSiblingCollider.text = "No Sibling Collider Found";
                    noSiblingCollider.style.paddingLeft = 10;
                    ipContainer.Add(noSiblingCollider);
                }

                Collider siblingCol = impactPropsList[i].siblingCollider;
                Collider[] siblingColliders = impactProperties.GetComponents<Collider>();
                Button ipApplyButton = new Button();
                ipApplyButton.name = "ipApplyButton";
                ipApplyButton.style.width = 80;
                ipApplyButton.style.height = 16;
                ipApplyButton.style.marginLeft = 10;
                ipApplyButton.text = "Apply";
                ipApplyButton.tooltip = "Applies any modified Surface Data Card or Physics Material values for this list item.";
                ipApplyButton.clickable.clicked += () =>
                {
                    if (changedSurfaceDataCards.Keys.Contains(i))
                    {
                        List<GameObject> selObjs = new List<GameObject>
                        {
                            impactProperties.gameObject
                        };
                        Undo.RecordObject(impactProperties.gameObject, impactProperties.gameObject.name + "ImpactProperties updated");
                        Selection.objects = null;
                        Selection.activeGameObject = null;
                        if (changedSurfaceDataCards[i]?.Barcode)
                        {
                            impactProperties.SurfaceDataCard.Barcode = changedSurfaceDataCards[i].Barcode;
                        }
                        else
                        {
                            impactProperties.SurfaceDataCard.Barcode = null;
                        }

                        changedSurfaceDataCards.Remove(i);
                        EditorUtility.SetDirty(impactProperties);
                        if (PrefabUtility.GetPrefabAssetType(impactProperties.gameObject) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(impactProperties.gameObject) == PrefabAssetType.Variant)
                        {
                            PrefabUtility.RecordPrefabInstancePropertyModifications(impactProperties.gameObject);
                        }

                        impactPropsMultiListView.Rebuild();
                        if (selObjs != null)
                            DelayMultiSelectionAsync(selObjs.ToArray(), 10);
                    }

                    if (changedPhysMats.Keys.Contains(i))
                    {
                        List<GameObject> selObjs = new List<GameObject>
                        {
                            impactProperties.gameObject
                        };
                        Undo.RecordObject(impactProperties.gameObject, impactProperties.gameObject.name + "ImpactProperties updated");
                        Selection.objects = null;
                        Selection.activeGameObject = null;
                        foreach (var siblingCollider in siblingColliders)
                        {
                            if (PrefabUtility.IsPartOfPrefabAsset(siblingCollider))
                            {
                                siblingCollider.sharedMaterial = changedPhysMats[i];
                            }
                            else
                            {
                                siblingCollider.material = changedPhysMats[i];
                            }

                            EditorUtility.SetDirty(siblingCollider);
                            if (PrefabUtility.GetPrefabAssetType(siblingCollider.gameObject) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(siblingCollider.gameObject) == PrefabAssetType.Variant)
                            {
                                PrefabUtility.RecordPrefabInstancePropertyModifications(siblingCollider.gameObject);
                            }
                        }

                        changedPhysMats.Remove(i);
                        impactPropsMultiListView.Rebuild();
                        if (selObjs != null)
                            DelayMultiSelectionAsync(selObjs.ToArray(), 10);
                    }
                };
                ipContainer.Add(ipApplyButton);
            };
            multiSelectApplyContainer.Clear();
            multiSelectApplyContainer.style.borderBottomWidth = 2;
            multiSelectApplyContainer.style.borderTopWidth = 2;
            multiSelectApplyContainer.style.borderRightWidth = 2;
            multiSelectApplyContainer.style.borderLeftWidth = 2;
            multiSelectApplyContainer.style.height = 40;
            multiSelectApplyContainer.style.alignItems = Align.Center;
            Label multiSelectApplyLabel = new Label();
            multiSelectApplyLabel.style.width = 440;
            multiSelectApplyLabel.style.unityTextAlign = TextAnchor.MiddleLeft;
            multiSelectApplyLabel.text = "<b>Apply to Entire Selection</b>";
            multiSelectApplyContainer.Add(multiSelectApplyLabel);
            DropdownField multiSelectApplySDCardField = new DropdownField();
            multiSelectApplySDCardField.name = "multiSelectApplySDCardField";
            multiSelectApplySDCardField.choices = surfaceDataCardNames;
            multiSelectApplySDCardField.style.width = 240;
            multiSelectApplySDCardField.style.height = 20;
            ObjectField multiSelectApplyPhysMatsField = new ObjectField();
            multiSelectApplyPhysMatsField.name = "multiSelectApplyPhysMatsField";
            multiSelectApplyPhysMatsField.objectType = typeof(PhysicMaterial);
            multiSelectApplyPhysMatsField.style.width = 240;
            multiSelectApplyPhysMatsField.style.height = 20;
            multiSelectApplyContainer.Add(multiSelectApplySDCardField);
            Texture colliderMatsMultiSelIcon = EditorGUIUtility.ObjectContent(null, typeof(BoxCollider)).image;
            Image colliderMatsMultiSelIconImage = new Image();
            colliderMatsMultiSelIconImage.image = colliderMatsMultiSelIcon;
            Button multiSelectionSuggestMatsButton = new Button();
            multiSelectionSuggestMatsButton.name = "multiSelectionApplyMatsButton";
            multiSelectionSuggestMatsButton.style.height = 22;
            multiSelectionSuggestMatsButton.text = "";
            multiSelectionSuggestMatsButton.tooltip = "Suggests a reasonable Physics Material based on the Surface Data Card.  Click the button to toggle betweeen the Static and Dynamic version of the Physics Material.";
            multiSelectionSuggestMatsButton.style.width = 30;
            multiSelectionSuggestMatsButton.style.marginLeft = 10;
            multiSelectionSuggestMatsButton.style.marginRight = 10;
            multiSelectionSuggestMatsButton.Add(colliderMatsMultiSelIconImage);
            multiSelectionSuggestMatsButton.clickable.clicked += () =>
            {
                SurfaceDataCard sdc = null;
                foreach (var sdCardBarcode in surfaceDataCardList)
                {
                    if (AssetWarehouse.ready && !Application.isPlaying && AssetWarehouse.Instance.TryGetDataCard(sdCardBarcode, out var sdCard))
                    {
                        if (multiSelectApplySDCardField.value.ToLower().Trim() == sdCard.Title.ToLower().Trim())
                        {
                            sdc = sdCard as SurfaceDataCard;
                        }
                    }
                }

                PhysicMaterial suggestedPhysMat = null;
                if (sdc)
                {
                    PhysicMaterial sdcStaticMaterial = (PhysicMaterial)AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(sdc.PhysicsMaterialStatic.AssetGUID));
                    PhysicMaterial sdcDynamicMaterial = (PhysicMaterial)AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(sdc.PhysicsMaterial.AssetGUID));
                    if (multiSelectApplyPhysMatsField.value == sdcStaticMaterial)
                    {
                        suggestedPhysMat = sdcDynamicMaterial;
                    }
                    else
                    {
                        suggestedPhysMat = sdcStaticMaterial;
                    }
                }

                if (suggestedPhysMat != null && multiSelectApplyPhysMatsField.value?.name.Replace(" (Instance)", "").Trim() != suggestedPhysMat.name.Trim())
                {
                    multiSelectApplyPhysMatsField.value = suggestedPhysMat;
                }
            };
            ipApplyModifiedButton.clickable = null;
            ipApplyModifiedButton.clickable = new Clickable(() =>
            {
            });
            ipApplyModifiedButton.clickable.clicked += () =>
            {
                if (EditorUtility.DisplayDialog("Apply Modified Surface Data / PhysMats?", "WARNING: This button will apply any changes made to the Surface Data Cards and Physics Materials as Overrides.", "APPLY MODIFIED SD CARD and PHYSICS MATS", "Cancel"))
                {
                    List<GameObject> selObjs = new List<GameObject>
                    {
                        Selection.activeGameObject
                    };
                    Selection.objects = null;
                    Selection.activeGameObject = null;
                    foreach (KeyValuePair<int, SurfaceDataCard> changedSDCard in changedSurfaceDataCards)
                    {
                        int index = changedSDCard.Key;
                        ImpactProperties impactProperties = impactPropsList[index].impactProp;
                        Undo.RecordObject(impactProperties, "Apply Modified ImpactProperties");
                        if (changedSDCard.Value != null && changedSDCard.Value.Barcode.IsValid())
                        {
                            impactProperties.SurfaceDataCard.Barcode = changedSDCard.Value.Barcode;
                        }
                        else
                        {
                            impactProperties.SurfaceDataCard.Barcode = null;
                        }

                        EditorUtility.SetDirty(impactProperties);
                        if (PrefabUtility.GetPrefabAssetType(impactProperties.gameObject) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(impactProperties.gameObject) == PrefabAssetType.Variant)
                        {
                            PrefabUtility.RecordPrefabInstancePropertyModifications(impactProperties.gameObject);
                        }
                    }

                    changedSurfaceDataCards.Clear();
                    foreach (KeyValuePair<int, PhysicMaterial> changedPhysMat in changedPhysMats)
                    {
                        int index = changedPhysMat.Key;
                        Collider physCol = impactPropsList[index].siblingCollider;
                        Collider[] physMatCols = impactPropsList[index].impactProp.GetComponents<Collider>();
                        foreach (var physMatCol in physMatCols)
                        {
                            Undo.RecordObject(physMatCol, "Apply Modified Physics Materials");
                            if (physMatCol != null)
                            {
                                if (changedPhysMat.Value != null)
                                {
                                    physMatCol.sharedMaterial = changedPhysMat.Value;
                                }
                                else
                                {
                                    physMatCol.sharedMaterial = null;
                                }

                                EditorUtility.SetDirty(physMatCol);
                                if (PrefabUtility.GetPrefabAssetType(physMatCol.gameObject) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(physMatCol.gameObject) == PrefabAssetType.Variant)
                                {
                                    PrefabUtility.RecordPrefabInstancePropertyModifications(physMatCol.gameObject);
                                }
                            }
                        }
                    }

                    changedPhysMats.Clear();
                    impactPropsMultiListView.Rebuild();
                    if (selObjs != null)
                        DelayMultiSelectionAsync(selObjs.ToArray(), 10);
                }
            };
            multiSelectApplyContainer.Add(multiSelectionSuggestMatsButton);
            multiSelectApplyContainer.Add(multiSelectApplyPhysMatsField);
            Button multiSelectionApplyButton = new Button();
            multiSelectionApplyButton.name = "multiSelectionApplyButton";
            multiSelectionApplyButton.text = "<b>Apply</b>";
            multiSelectionApplyButton.style.width = 90;
            multiSelectionApplyButton.style.height = 22;
            multiSelectionApplyButton.style.marginLeft = 30;
            multiSelectionApplyButton.clickable.clicked += () =>
            {
                SurfaceDataCard sdc = null;
                foreach (var sdCardBarcode in surfaceDataCardList)
                {
                    if (AssetWarehouse.ready && !Application.isPlaying && AssetWarehouse.Instance.TryGetDataCard(sdCardBarcode, out var sdCard))
                    {
                        if (multiSelectApplySDCardField.value.ToLower().Trim() == sdCard.Title.ToLower().Trim())
                        {
                            sdc = sdCard as SurfaceDataCard;
                        }
                    }
                }

                List<GameObject> selObjs = new List<GameObject>();
                foreach (var listSelIndex in impactPropsMultiListView.selectedIndices)
                {
                    if (!selObjs.Contains(impactPropsList[listSelIndex].impactProp.gameObject))
                    {
                        selObjs.Add(impactPropsList[listSelIndex].impactProp.gameObject);
                    }
                }

                foreach (GameObject selGO in selObjs)
                {
                    ImpactProperties impactProperties = selGO.gameObject.GetComponent<ImpactProperties>();
                    Collider physCol = selGO.gameObject.GetComponent<Collider>();
                    Collider[] physMatsCols = impactProperties.GetComponents<Collider>();
                    Undo.RecordObject(impactProperties.gameObject, impactProperties.gameObject.name + "ImpactProperties updated");
                    Selection.objects = null;
                    Selection.activeGameObject = null;
                    if (sdc != null && sdc.Barcode.IsValid())
                    {
                        impactProperties.SurfaceDataCard.Barcode = sdc.Barcode;
                        EditorUtility.SetDirty(impactProperties);
                        if (PrefabUtility.GetPrefabAssetType(impactProperties.gameObject) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(impactProperties.gameObject) == PrefabAssetType.Variant)
                        {
                            PrefabUtility.RecordPrefabInstancePropertyModifications(impactProperties.gameObject);
                        }
                    }

                    if (multiSelectApplyPhysMatsField.value != null)
                    {
                        foreach (var physMatsCol in physMatsCols)
                        {
                            physMatsCol.sharedMaterial = multiSelectApplyPhysMatsField.value as PhysicMaterial;
                            EditorUtility.SetDirty(physMatsCol);
                            if (PrefabUtility.GetPrefabAssetType(physMatsCol.gameObject) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(physMatsCol.gameObject) == PrefabAssetType.Variant)
                            {
                                PrefabUtility.RecordPrefabInstancePropertyModifications(physMatsCol.gameObject);
                            }
                        }
                    }

                    changedSurfaceDataCards.Clear();
                    impactPropsMultiListView.Rebuild();
                    if (selObjs != null)
                        DelayMultiSelectionAsync(selObjs.ToArray(), 10);
                }
            };
            multiSelectApplyContainer.Add(multiSelectionApplyButton);
            multiSelectApplyContainer.style.marginTop = 60;
            allAndEmptyBorderContainer.style.display = DisplayStyle.Flex;
            ipApplyModifiedButton.style.display = DisplayStyle.Flex;
            impactPropsMultiListView.style.marginTop = 20;
        }

        private void ListSelectionChanged(IEnumerable<object> objects)
        {
            List<GameObject> selectedObjs = new List<GameObject>();
            foreach (var obj in objects)
            {
                PrefabRootAndImpactPropAndCol impactPropObj = obj as PrefabRootAndImpactPropAndCol;
                if (impactPropObj != null)
                {
                    selectedObjs.Add(impactPropObj.impactProp.gameObject);
                }
            }

            Selection.objects = selectedObjs.ToArray();
        }

        private void FindPrefabInstances(string searchMode)
        {
            int n = 0;
            EditorUtility.DisplayProgressBar("Building Prefab Instances List", "This may take a while.", 0.5f);
            if (impactPropsList == null)
            {
                impactPropsList = new List<PrefabRootAndImpactPropAndCol>();
            }
            else
            {
                impactPropsList.Clear();
            }

            List<ImpactProperties> ipTempList = new List<ImpactProperties>();
            if (searchMode == "selectedscene")
            {
                List<ImpactProperties> selImpactPropsList = new List<ImpactProperties>();
                if (ipRecursiveSelectionToggle.value)
                {
                    foreach (var selImpactPropObj in Selection.gameObjects)
                    {
                        selImpactPropsList.AddRange(selImpactPropObj.GetComponentsInChildren<ImpactProperties>());
                    }
                }
                else
                {
                    foreach (var selImpactPropObj in Selection.gameObjects)
                    {
                        selImpactPropsList.AddRange(selImpactPropObj.GetComponents<ImpactProperties>());
                    }
                }

                selImpactPropsList = selImpactPropsList.Distinct().ToList();
                foreach (var impactProp in selImpactPropsList)
                {
                    if (PrefabUtility.GetPrefabAssetType(impactProp) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(impactProp) == PrefabAssetType.Variant)
                    {
                        if (impactProp == null)
                        {
                        }
                        else
                        {
                            PrefabRootAndImpactPropAndCol prefabRootAndImpactPropAndCol = new PrefabRootAndImpactPropAndCol();
                            impactProp.TryGetComponent(out Collider siblingCol);
                            prefabRootAndImpactPropAndCol.prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(impactProp);
                            prefabRootAndImpactPropAndCol.impactProp = impactProp;
                            prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                            if (!ipTempList.Contains(impactProp))
                            {
                                ipTempList.Add(impactProp);
                                impactPropsList.Add(prefabRootAndImpactPropAndCol);
                            }
                        }
                    }

                    if (PrefabUtility.IsPartOfAnyPrefab(impactProp) == false)
                    {
                        if (impactProp == null)
                        {
                        }
                        else
                        {
                            PrefabRootAndImpactPropAndCol prefabRootAndImpactPropAndCol = new PrefabRootAndImpactPropAndCol();
                            MeshRenderer meshRend = impactProp.GetComponentInParent<MeshRenderer>();
                            impactProp.TryGetComponent(out Collider siblingCol);
                            if (meshRend != null)
                            {
                                prefabRootAndImpactPropAndCol.prefabRoot = meshRend.gameObject;
                            }
                            else
                            {
                                prefabRootAndImpactPropAndCol.prefabRoot = impactProp.gameObject;
                            }

                            prefabRootAndImpactPropAndCol.impactProp = impactProp;
                            prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                            if (!ipTempList.Contains(impactProp))
                            {
                                ipTempList.Add(impactProp);
                                impactPropsList.Add(prefabRootAndImpactPropAndCol);
                            }
                        }
                    }
                }

                ipTempList.Clear();
            }
            else
            {
                ImpactProperties[] impactPropertiesObjs = GameObject.FindObjectsOfType<ImpactProperties>(true);
                if (impactPropertiesObjs != null)
                {
                    foreach (var impactProp in impactPropertiesObjs)
                    {
                        if (impactProp == null)
                        {
                        }
                        else
                        {
                            impactProp.TryGetComponent(out Collider siblingCol);
                            string parentName = "NO PARENT";
                            if (impactProp.transform.parent != null)
                            {
                                parentName = impactProp.transform.parent.name;
                            }

                            if (searchMode == "missingsdcardoverride")
                            {
                                if (!impactProp.SurfaceDataCard.IsValid())
                                {
                                    PrefabRootAndImpactPropAndCol prefabRootAndImpactPropAndCol = new PrefabRootAndImpactPropAndCol();
                                    if (PrefabUtility.IsPartOfAnyPrefab(impactProp))
                                    {
                                        prefabRootAndImpactPropAndCol.prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(impactProp);
                                    }
                                    else
                                    {
                                        MeshRenderer meshRend = impactProp.GetComponentInParent<MeshRenderer>();
                                        if (meshRend != null)
                                        {
                                            prefabRootAndImpactPropAndCol.prefabRoot = meshRend.gameObject;
                                        }
                                        else
                                        {
                                            prefabRootAndImpactPropAndCol.prefabRoot = impactProp.gameObject;
                                        }
                                    }

                                    prefabRootAndImpactPropAndCol.impactProp = impactProp;
                                    prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                                    if (!ipTempList.Contains(impactProp))
                                    {
                                        ipTempList.Add(impactProp);
                                        impactPropsList.Add(prefabRootAndImpactPropAndCol);
                                    }
                                }
                            }
                            else if (searchMode == "allscene")
                            {
                                PrefabRootAndImpactPropAndCol prefabRootAndImpactPropAndCol = new PrefabRootAndImpactPropAndCol();
                                if (PrefabUtility.IsPartOfAnyPrefab(impactProp))
                                {
                                    prefabRootAndImpactPropAndCol.prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(impactProp);
                                }
                                else
                                {
                                    MeshRenderer meshRend = impactProp.GetComponentInParent<MeshRenderer>();
                                    if (meshRend != null)
                                    {
                                        prefabRootAndImpactPropAndCol.prefabRoot = meshRend.gameObject;
                                    }
                                    else
                                    {
                                        prefabRootAndImpactPropAndCol.prefabRoot = impactProp.gameObject;
                                    }
                                }

                                prefabRootAndImpactPropAndCol.impactProp = impactProp;
                                prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                                if (!ipTempList.Contains(impactProp))
                                {
                                    ipTempList.Add(impactProp);
                                    impactPropsList.Add(prefabRootAndImpactPropAndCol);
                                }

                                if (PrefabUtility.IsPartOfAnyPrefab(impactProp) == false)
                                {
                                    MeshRenderer meshRend = impactProp.GetComponentInParent<MeshRenderer>();
                                    if (meshRend != null)
                                    {
                                        prefabRootAndImpactPropAndCol.prefabRoot = meshRend.gameObject;
                                    }
                                    else
                                    {
                                        prefabRootAndImpactPropAndCol.prefabRoot = impactProp.gameObject;
                                    }

                                    prefabRootAndImpactPropAndCol.impactProp = impactProp;
                                    prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                                    if (!ipTempList.Contains(impactProp))
                                    {
                                        ipTempList.Add(impactProp);
                                        impactPropsList.Add(prefabRootAndImpactPropAndCol);
                                    }
                                }
                            }
                            else if (searchMode == "overridesonlyscene")
                            {
                                if (PrefabUtility.GetPrefabAssetType(impactProp.gameObject) == PrefabAssetType.Regular || PrefabUtility.GetPrefabAssetType(impactProp.gameObject) == PrefabAssetType.Variant)
                                {
                                    GameObject prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(impactProp);
                                    if (PrefabUtility.HasPrefabInstanceAnyOverrides(prefabRoot, false))
                                    {
                                        PropertyModification[] prefabOverrides = PrefabUtility.GetPropertyModifications(impactProp);
                                        if (prefabOverrides == null)
                                        {
                                            continue;
                                        }

                                        foreach (var prefabOverride in prefabOverrides)
                                        {
                                            if (prefabOverride != null)
                                            {
                                                if (PrefabStageUtility.GetCurrentPrefabStage() == null)
                                                {
                                                    if (prefabOverride.propertyPath == "_surfaceDataCard._barcode._id")
                                                    {
                                                        if (prefabOverride.value != null)
                                                        {
                                                            if (prefabOverride.target != null)
                                                            {
                                                                ImpactProperties targetObj = (ImpactProperties)prefabOverride.target;
                                                                if (targetObj != null)
                                                                {
                                                                    if (impactProp.SurfaceDataCard != null && prefabOverride.value == impactProp.SurfaceDataCard.Barcode.ToString())
                                                                    {
                                                                        PrefabRootAndImpactPropAndCol prefabRootAndImpactPropAndCol = new PrefabRootAndImpactPropAndCol();
                                                                        prefabRootAndImpactPropAndCol.prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(impactProp);
                                                                        prefabRootAndImpactPropAndCol.impactProp = impactProp;
                                                                        prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                                                                        if (!ipTempList.Contains(impactProp))
                                                                        {
                                                                            ipTempList.Add(impactProp);
                                                                            impactPropsList.Add(prefabRootAndImpactPropAndCol);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            objectsListedLabel.text = $"Objects<br>Listed: {impactPropsList.Count}";
            if (impactPropsList.Count > 0)
            {
                impactPropsList = impactPropsList.OrderBy(x => x?.prefabRoot?.name).ToList();
            }

            EditorUtility.ClearProgressBar();
        }

        private void FindPrefabsInProject(string searchMode)
        {
            int n = 0;
            if (string.IsNullOrEmpty(assetSearchPath))
            {
                Debug.Log("Search Path empty.  Please set the Project Search Path and try again.");
                return;
            }

            impactPropsList = new List<PrefabRootAndImpactPropAndCol>();
            List<ImpactProperties> ipTempList = new List<ImpactProperties>();
            EditorUtility.DisplayProgressBar("Finding Prefab Assets in Project", "This may take a while. Use Project Search Path to refine.", 0.5f);
            string[] results = AssetDatabase.FindAssets("t:prefab", new string[] { assetSearchPath });
            EditorUtility.ClearProgressBar();
            for (int r = 0; r < results.Length; r++)
            {
                EditorUtility.DisplayProgressBar("Building Project ImpactProperties Prefabs List", "This may take a while. Use Project Search Path to refine.", r / results.Length);
                var prefabPath = AssetDatabase.GUIDToAssetPath(results[r]);
                var obj = AssetDatabase.LoadMainAssetAtPath(prefabPath);
                GameObject gameObject = obj as GameObject;
                if (gameObject == null)
                    continue;
                if (gameObject.GetComponentInChildren<ImpactProperties>() == null)
                    continue;
                ImpactProperties[] impactProps = gameObject.GetComponentsInChildren<ImpactProperties>();
                foreach (var impactProp in impactProps)
                {
                    if (impactProp == null)
                    {
                    }
                    else
                    {
                        impactProp.TryGetComponent(out Collider siblingCol);
                        string parentName = "NO PARENT";
                        if (impactProp.transform.parent != null)
                        {
                            parentName = impactProp.transform.parent.name;
                        }

                        if (searchMode == "missingsdcardprefab")
                        {
                            if (!impactProp.SurfaceDataCard.IsValid())
                            {
                                PrefabRootAndImpactPropAndCol prefabRootAndImpactPropAndCol = new PrefabRootAndImpactPropAndCol();
                                prefabRootAndImpactPropAndCol.prefabRoot = impactProp.transform.root.gameObject;
                                prefabRootAndImpactPropAndCol.impactProp = impactProp;
                                prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                                if (!ipTempList.Contains(impactProp))
                                {
                                    ipTempList.Add(impactProp);
                                    impactPropsList.Add(prefabRootAndImpactPropAndCol);
                                }
                            }
                        }
                        else if (searchMode == "allprojectprefabs")
                        {
                            PrefabRootAndImpactPropAndCol prefabRootAndImpactPropAndCol = new PrefabRootAndImpactPropAndCol();
                            prefabRootAndImpactPropAndCol.prefabRoot = impactProp.transform.root.gameObject;
                            prefabRootAndImpactPropAndCol.impactProp = impactProp;
                            prefabRootAndImpactPropAndCol.siblingCollider = siblingCol;
                            if (!ipTempList.Contains(impactProp))
                            {
                                ipTempList.Add(impactProp);
                                impactPropsList.Add(prefabRootAndImpactPropAndCol);
                            }
                        }
                    }
                }
            }

            EditorUtility.ClearProgressBar();
            objectsListedLabel.text = $"Objects<br>Listed: {impactPropsList.Count}";
        }

        async static void DelayMultiSelectionAsync(GameObject[] selObjects, int delay)
        {
            await Task.Delay(delay);
            if (selObjects != null)
            {
                Selection.objects = selObjects;
            }
        }
    }
}
#endif
