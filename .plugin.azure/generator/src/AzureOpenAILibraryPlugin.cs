using System.ComponentModel.Composition;
using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;

namespace AzureOpenAILibraryPlugin
{
    [Export(typeof(CodeModelPlugin))]
    [ExportMetadata("PluginName", nameof(AzureOpenAILibraryPlugin))]
    public class AzureOpenAILibraryPlugin : ClientModelPlugin
    {
        [ImportingConstructor]
        public AzureOpenAILibraryPlugin(GeneratorContext context) : base(context) { }

        public override void Configure()
        {
            base.Configure();
            // AddVisitor(new AzureOpenAILibraryVisitor());
            AddVisitor(new DocEditVisitor());
            AddVisitor(new AdditionalPropertiesVisitor());
            AddVisitor(new ModelSerializationEmptySentinelVisitor());
            AddVisitor(new WriteableSardVisitor());
            AddVisitor(new TypeRemovalVisitor());
            AddVisitor(new InternalSettablePropertiesVisitor());
        }
    }
}