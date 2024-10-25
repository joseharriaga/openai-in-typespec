using System.ComponentModel.Composition;
using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;

namespace OpenAILibraryPlugin
{
    [Export(typeof(CodeModelPlugin))]
    [ExportMetadata("PluginName", nameof(OpenAILibraryPlugin))]
    public class OpenAILibraryPlugin : ClientModelPlugin
    {
        [ImportingConstructor]
        public OpenAILibraryPlugin(GeneratorContext context) : base(context) { }

        public override void Configure()
        {
            base.Configure();
            AddVisitor(new OpenAILibraryVisitor());
        }
    }
}