using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;


namespace SOSXR.ClonedProjectHelpers
{
    [InitializeOnLoad]
    public class DisallowBuildingInCloneProjects : IPreprocessBuildWithReport
    {
        static DisallowBuildingInCloneProjects()
        {
            BuildPlayerWindow.RegisterBuildPlayerHandler(BuildPlayerHandler);
        }


        private const string disallowBuildingInProjectNamesContaining = "clone";

        public int callbackOrder => 0;


        public void OnPreprocessBuild(BuildReport report)
        {
            if (ProjectName.FullPath.Contains(disallowBuildingInProjectNamesContaining))
            {
                Debug.LogError(nameof(DisallowBuildingInCloneProjects) + " Building is disabled in projects containing the word " + disallowBuildingInProjectNamesContaining + " in their path");
                DisplayPopupDialog();

                throw new BuildFailedException("Building is disabled in clone projects.");
            }
        }


        private static void BuildPlayerHandler(BuildPlayerOptions buildPlayerOptions)
        {
            if (ProjectName.FullPath.Contains(disallowBuildingInProjectNamesContaining))
            {
                Debug.LogError(nameof(DisallowBuildingInCloneProjects) + " Building is disabled in projects containing the word " + disallowBuildingInProjectNamesContaining + " in their path");
                DisplayPopupDialog();

                return;
            }

            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(buildPlayerOptions);
        }


        private static void DisplayPopupDialog()
        {
            EditorUtility.DisplayDialog(
                "Building Disabled",
                $"Building is disabled in \"{disallowBuildingInProjectNamesContaining}\" projects.",
                "OK"
            );
        }
    }
}