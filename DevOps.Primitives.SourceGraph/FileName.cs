using DevOps.Primitives.Strings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;
using static System.IO.Path;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("FileNames", Schema = nameof(SourceGraph))]
    public class FileName
    {
        public FileName() { }
        public FileName(in AsciiStringReference name, in AsciiStringReferenceList pathParts)
        {
            Name = name;
            PathParts = pathParts;
        }
        public FileName(in string name, in string[] pathParts)
            : this(new AsciiStringReference(in name),
                  Any(pathParts)
                    ? new AsciiStringReferenceList { AsciiStringReferenceListAssociations = pathParts.Select(p => new AsciiStringReferenceListAssociation { AsciiStringReference = new AsciiStringReference(in p) }).ToList() }
                    : null)
        {
        }

        [ProtoMember(1)]
        public int FileNameId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(3)]
        public int NameId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReferenceList PathParts { get; set; }
        [ProtoMember(5)]
        public int? PathPartsId { get; set; }

        public string GetPathRelativeToRepositoryRoot()
        {
            var pathParts = PathParts?.GetAssociations().Select(a => a.GetRecord().Value);
            var relativeDirectory = !Any(pathParts) ? string.Empty : Combine(pathParts.ToArray());
            return Combine(relativeDirectory, Name.Value);
        }
    }
}
