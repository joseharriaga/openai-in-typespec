using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;

namespace AzureOpenAILibraryPlugin;

/// <summary>
/// This visitor ensures consistent formatting of XML doc comments, including normalization of lines
/// that mitigate newline injection causing malformed comments.
/// </summary>
public class DocEditVisitor : ScmLibraryVisitor
{
    protected override PropertyProvider? VisitProperty(PropertyProvider property)
    {
        if (TryUpdateXmlDocs(property.XmlDocs))
        {
            property.Update(xmlDocs: property.XmlDocs);
        }
        return base.VisitProperty(property);
    }

    protected override TypeProvider VisitType(TypeProvider type)
    {
        if (TryUpdateXmlDocs(type.XmlDocs))
        {
            type.Update(xmlDocs: type.XmlDocs);
        }
        return type;
    }

    protected override MethodProvider? VisitMethod(MethodProvider method)
    {
        if (TryUpdateXmlDocs(method.XmlDocs))
        {
            method.Update(xmlDocProvider: method.XmlDocs);
        }
        return base.VisitMethod(method);
    }

    private static bool TryUpdateXmlDocs(XmlDocProvider? xmlDocs)
    {
        if (xmlDocs?.Summary?.Lines is IReadOnlyList<FormattableString> existingSummaryLines
            && existingSummaryLines.Count > 0)
        {
            List<FormattableString> reprocessedSummaryLines = [];
            foreach (var line in existingSummaryLines)
            {
                string[] linesInTheLine = line.ToString().Split('\n');
                reprocessedSummaryLines.AddRange(linesInTheLine.Select(lineInTheLine => (FormattableString)$"{lineInTheLine}"));
            }
            if (reprocessedSummaryLines.Count > existingSummaryLines.Count)
            {
                xmlDocs.Summary = new XmlDocSummaryStatement(reprocessedSummaryLines, [.. xmlDocs.Summary.InnerStatements]);
                return true;
            }
        }
        return false;
    }
}
