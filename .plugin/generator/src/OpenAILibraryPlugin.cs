using System.ComponentModel.Composition;
using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;
using OpenAILibraryPlugin.Visitors;

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
            AddVisitor(new ProhibitedNamespaceVisitor());
            AddVisitor(new CollectionInitializationVisitor());
            AddVisitor(new ContentInnerCollectionDefinedVisitor());
            AddVisitor(new NonAbstractPublicTypesVisitor());
            AddVisitor(new OmittedTypesVisitor());
            AddVisitor(new InvariantFormatAdditionalPropertiesVisitor());
            AddVisitor(new OpenAILibraryVisitor());
        }
    }
}