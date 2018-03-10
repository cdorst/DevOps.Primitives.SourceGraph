﻿using DevOps.Primitives.Strings;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.Functions.CheckNullableEnumerationForAnyElements.NullableEnumerationAny;
using System.Linq;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("FileNames", Schema = nameof(SourceGraph))]
    public class FileName
    {
        public FileName() { }
        public FileName(AsciiStringReference name, AsciiStringReferenceList pathParts)
        {
            Name = name;
            PathParts = pathParts;
        }
        public FileName(string name, IEnumerable<string> pathParts)
            : this(new AsciiStringReference(name),
                  Any(pathParts)
                    ? new AsciiStringReferenceList { AsciiStringReferenceListAssociations = pathParts.Select(p => new AsciiStringReferenceListAssociation { AsciiStringReference = new AsciiStringReference(p) }).ToList() }
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
    }
}