using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;

namespace Knockout.Bootstrap.Demo.Web.Common
{
    public class TemplateStore : ITemplateStore
    {
        private string path;
        private Dictionary<string, Dictionary<string, string>> templates;
        private string mask;

        public TemplateStore()
        {
            path = HostingEnvironment.MapPath("~/Views");
            mask = "*.htm*";

            var watcher = new FileSystemWatcher(path, mask);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Changed += (s, e) => LoadTemplatesWithRetry();

            LoadTemplates();
        }

        private void LoadTemplatesWithRetry()
        {
            while (true)
            {
                try
                {
                    LoadTemplates();
                    break;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
         
        }

        private void LoadTemplates()
        {
            var folders = Directory.GetDirectories(path);
            templates = folders.ToDictionary(f => Path.GetFileName(f).ToLower(), LoadFolder);
        }

        private Dictionary<string, string> LoadFolder(string path)
        {
            return Directory
                .GetFiles(path, mask)
                .Select(f => new { Name = Path.GetFileNameWithoutExtension(f), Content = File.ReadAllText(f)})
                .ToDictionary(f => f.Name, f => f.Content);
        }

        public Dictionary<string, string> LoadTemplates(string root)
        {
            return templates[root.ToLower()];
        } 
    }
}