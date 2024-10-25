// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.Composition;

namespace Microsoft.Generator.CSharp.ClientModel.OpenAILibraryPlugin
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