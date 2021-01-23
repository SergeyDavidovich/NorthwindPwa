using Blazor.IndexedDB.WebAssembly;
using Microsoft.JSInterop;
using NorthwindPwa.Models;

namespace NorthwindPwa.Data
{
    public class NorthwindDb : IndexedDb
    {
        public NorthwindDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }

        public IndexedSet<Product> Products { get; set; }
    }
}
