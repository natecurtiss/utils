using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;

namespace NateCurtiss.Utils
{
    static class Folders
    {
        static readonly string _root = Application.dataPath;
        
        [MenuItem("Tools/Setup/Create Default Folders")]
        static void DefaultFolders()
        {
            New("Materials");
            New("Models");
            New("Music");
            New("Plugins");
            New("Prefabs");
            New("Scenes");
            New("Scripts");
            New("Settings");
            New("Shaders");
            New("Sounds");
            New("Textures");
            Refresh();
        }
        
        [MenuItem("Tools/Setup/Create Default Folders Grouped")]
        static void DefaultFoldersGrouped()
        {
            New("Art", out var art);
            New(art, "Materials");
            New(art, "Models");
            New(art, "Shaders");
            New(art, "Textures");
            
            New("Audio", out var audio);
            New(audio, "Sounds");
            New(audio, "Music");

            New("Code", out var code);
            New(code, "Editor");
            New(code, "Runtime");

            New("Plugins");
            New("Prefabs");
            New("Scenes");
            New("Settings");
            
            Refresh();
        }

        static void New(string folder) => New(_root, folder, out _);
        static void New(string folder, out string path) => New(_root, folder, out path);
        static void New(string root, string folder) => New(root, folder, out _);
        static void New(string root, string folder, out string path) => path = CreateDirectory(Combine(root, folder)).FullName;
    }
}
