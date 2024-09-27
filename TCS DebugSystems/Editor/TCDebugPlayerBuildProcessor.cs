using System.IO;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace TCDebug.Editor {
    public class PackageAssetMover : UnityEditor.Editor {
        // Menu item to trigger the move
        [MenuItem("Tools/Move Package Assets to Assets Folder")]
        public static void MoveAssets() {
            const string packagePath = "Packages/com.yourpackage.name/AssetsToMove"; // The folder path inside your package
            const string destinationPath = "Assets/CustomAssets"; // The destination inside the user's Assets folder

            // Ensure source package path exists
            if (!Directory.Exists(packagePath)) {
                Debug.LogError($"Source folder not found at: {packagePath}");
                return;
            }

            // Create the destination folder if it doesn't exist
            if (!Directory.Exists(destinationPath)) {
                Directory.CreateDirectory(destinationPath);
                AssetDatabase.Refresh(); // Refresh AssetDatabase to recognize new folder
            }

            // Move all files and subdirectories
            MoveDirectoryAssets(packagePath, destinationPath);

            // Refresh AssetDatabase to reflect changes in the project
            AssetDatabase.Refresh();
            Debug.Log($"Assets have been moved from {packagePath} to {destinationPath}");
        }

        // Helper method to move the directory contents
        static void MoveDirectoryAssets(string sourceDir, string destinationDir) {
            foreach (string file in Directory.GetFiles(sourceDir)) {
                string fileName = Path.GetFileName(file);
                string destinationFile = Path.Combine(destinationDir, fileName);

                // Move asset using Unity's AssetDatabase API
                string error = AssetDatabase.MoveAsset(file, destinationFile);
                if (!string.IsNullOrEmpty(error)) {
                    Debug.LogError($"Failed to move {file} to {destinationFile}. Error: {error}");
                }
            }

            // Recursively move subdirectories
            foreach (string folder in Directory.GetDirectories(sourceDir)) {
                string folderName = Path.GetFileName(folder);
                string destinationSubFolder = Path.Combine(destinationDir, folderName);

                // Recursively move files in subdirectories
                MoveDirectoryAssets(folder, destinationSubFolder);
            }
        }
    }
}