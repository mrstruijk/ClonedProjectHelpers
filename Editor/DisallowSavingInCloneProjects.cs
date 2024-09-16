using SOSXR.ClonedProjectHelpers;
using UnityEditor;
using UnityEngine;
using static System.IO.Path;


[ExecuteAlways]
public class DisallowSavingInCloneProjects : AssetModificationProcessor
{
    #if UNITY_EDITOR
    private const string disallowSavingInProjectNamesContaining = "clone";


    /// <summary>
    ///     If this returns an empty array, the asset (scene) will not be saved.
    ///     So based on the result of some checks we can simply decide to not save the asset.
    /// </summary>
    /// <param name="paths"></param>
    /// <returns></returns>
    public static string[] OnWillSaveAssets(string[] paths)
    {
        if (ProjectName.FullPath.Contains(disallowSavingInProjectNamesContaining))
        {
            Debug.LogError(nameof(DisallowSavingInCloneProjects) + " Saving of scenes and assets is disabled in projects containing the word " + disallowSavingInProjectNamesContaining + "in their path");

            DisplayPopupDialog();

            return new string[] { }; // Return an empty array to prevent any assets from being saved
        }

        // Get the name of the scene to save.
        var sceneName = string.Empty;

        foreach (var path in paths)
        {
            if (!path.Contains(".unity"))
            {
                continue;
            }

            sceneName = GetFileNameWithoutExtension(path);
        }

        return sceneName.Length == 0 ? paths : paths;
    }


    private static void DisplayPopupDialog()
    {
        EditorUtility.DisplayDialog(
            "Saving Disabled",
            $"Saving of scenes and assets is disabled in \"{disallowSavingInProjectNamesContaining}\" projects.",
            "OK"
        );
    }
    #endif
}