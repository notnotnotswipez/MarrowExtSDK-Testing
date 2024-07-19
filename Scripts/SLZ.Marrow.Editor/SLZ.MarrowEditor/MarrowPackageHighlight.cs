using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SLZ.MarrowEditor
{
    [InitializeOnLoad]
    public class MarrowPackageHighlight
    {
        private static Texture highlightImage;
        static MarrowPackageHighlight()
        {
            EditorApplication.projectWindowItemOnGUI += DrawFolderIcon;
            highlightImage = EditorGUIUtility.IconContent("colorpickerboxfocused").image;
        }

        static void DrawFolderIcon(string guid, Rect rect)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (string.IsNullOrWhiteSpace(path) || Event.current.type != EventType.Repaint || !File.GetAttributes(path).HasFlag(FileAttributes.Directory) || !path.StartsWith("Packages/com.stresslevelzero.marrow.") || path.Count(c => c == '/') != 1)
            {
                return;
            }

            Rect imageRect;
            if (rect.height > 20f)
            {
                imageRect = new Rect(rect.x - 1f, rect.y - 1f, rect.width + 2f, rect.width + 2f);
            }
            else if (rect.x > 20f)
            {
                imageRect = new Rect(rect.x - 1f, rect.y - 1f, rect.height + 2f, rect.height + 2f);
            }
            else
            {
                imageRect = new Rect(rect.x + 2f, rect.y - 1f, rect.height + 2f, rect.height + 2f);
            }

            GUI.DrawTexture(imageRect, highlightImage);
        }
    }
}