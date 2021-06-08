using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFramework.Utilities
{
    public static class PwaCheck
    {
        public static async Task<bool> Check(string site)
        {
            HtmlWeb web = new();
            var result = await GetManifest(site, web);
            if (result.Success) return true;
            else return false;
        }

        public static async Task<bool> Check(IEnumerable<string> sites)
        {
            HtmlWeb web = new();
            foreach (var _ in sites)
            {
                var result = await GetManifest(_, web);
                if (result.Success) return true;
                else return false;
            }
            return false;
        }

        private static async Task<OperationResult> GetManifest(string site, HtmlWeb web)
        {
            HtmlDocument doc = await web.LoadFromWebAsync($"https://{site}");
            var node = doc.DocumentNode.SelectSingleNode("//link[@rel='manifest']");
            if (node is not null)
            {
                var href = node.Attributes.Where(w => w.Name == "href").FirstOrDefault();
                return new OperationResult(message: "not a problem man");
            }
            else return new OperationResult(false, "it is not pwa");
        }
    }
}
