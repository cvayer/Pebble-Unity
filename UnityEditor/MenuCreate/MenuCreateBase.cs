using UnityEngine;
using UnityEditor;


class MenuCreateBase
{
    public static void Create<T>(string newAssetName) where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = SelectionHelpers.GetSelectionAssetPath();

        AssetDatabase.CreateAsset(asset, path + "/" + newAssetName + ".asset");
        AssetDatabase.SaveAssets();

        Selection.activeObject = asset;

        EditorUtility.FocusProjectWindow();
    }
}

