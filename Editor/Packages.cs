using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using static System.IO.File;
using static System.IO.Path;
using static UnityEditor.PackageManager.Client;

namespace NateCurtiss.Utils
{
    static class Packages
    {
        [MenuItem("Tools/Setup/Load Default Packages")]
        static async void DefaultPackages()
        {
            var url = Gist("65a141d85b0d1061a1f5cd09304023ea");
            var contents = await Contents(url);
            ReplacePackages(contents);
        }

        static void ReplacePackages(string contents)
        {
            var existing = Combine(Application.dataPath, "../Packages/manifest.json");
            WriteAllText(existing, contents);
            Resolve();
        }
        
        static string Gist(string id, string user = "natecurtiss") =>
            $"https://gist.githubusercontent.com/{user}/{id}/raw";

        static async Task<string> Contents(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }
    }
}