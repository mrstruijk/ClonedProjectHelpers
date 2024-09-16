using UnityEngine;


namespace SOSXR.ClonedProjectHelpers
{
    public static class ProjectName
    {
        public static string FullPath
        {
            get
            {
                var fullPath = Application.dataPath;

                Debug.Log(nameof(FullPath) + " Full Path is " + fullPath);

                return fullPath;
            }
        }


        public static string GetProjectName()
        {
            var split = FullPath.Split('/');

            var projectName = split[^2];

            Debug.LogFormat(nameof(ProjectName) + " Project Name is " + projectName);

            return projectName;
        }
    }
}