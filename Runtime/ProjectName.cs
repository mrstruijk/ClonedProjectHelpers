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

                return fullPath;
            }
        }


        public static string GetProjectName()
        {
            var split = FullPath.Split('/');

            var projectName = split[^2];

            return projectName;
        }
    }
}