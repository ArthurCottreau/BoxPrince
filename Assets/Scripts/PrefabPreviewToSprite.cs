using UnityEngine;
using UnityEditor;
using System.IO;

public class PrefabPreviewToSprite : MonoBehaviour
{
    [MenuItem("Tools/Generate Prefab Preview Sprite")]
    public static void GeneratePrefabPreviewSprite()
    {
        // Select the prefab in the Project window
        GameObject prefab = Selection.activeObject as GameObject;

        if (prefab == null)
        {
            Debug.LogError("Please select a prefab in the Project window!");
            return;
        }

        // Generate the prefab preview as a texture
        Texture2D previewTexture = AssetPreview.GetAssetPreview(prefab);

        if (previewTexture == null)
        {
            Debug.LogError("Unable to generate preview. Try selecting the prefab in the Project window.");
            return;
        }

        // Save the texture as a PNG file
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Prefab Preview",
            prefab.name + "_Preview",
            "png",
            "Select a location to save the prefab preview sprite"
        );

        if (string.IsNullOrEmpty(path))
            return;

        File.WriteAllBytes(path, previewTexture.EncodeToPNG());
        AssetDatabase.Refresh();

        // Load the saved texture as a Sprite
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
        if (importer != null)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.SaveAndReimport();
        }

        Debug.Log("Prefab preview saved as a sprite: " + path);
    }
}
