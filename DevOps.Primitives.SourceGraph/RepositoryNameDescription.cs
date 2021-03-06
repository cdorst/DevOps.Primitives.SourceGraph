﻿using DevOps.Primitives.Strings;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.SourceGraph
{
    [ProtoContract]
    [Table("RepositoryNameDescriptions", Schema = nameof(SourceGraph))]
    public class RepositoryNameDescription
    {
        public RepositoryNameDescription() { }
        public RepositoryNameDescription(in AsciiStringReference name, in AsciiStringReference description)
        {
            Description = description;
            Name = name;
        }
        public RepositoryNameDescription(in string name, in string description)
            : this(new AsciiStringReference(in name), new AsciiStringReference(in description))
        {
        }

        [Key]
        [ProtoMember(1)]
        public int RepositoryNameDescriptionId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Description { get; set; }
        [ProtoMember(3)]
        public int DescriptionId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReference Name { get; set; }
        [ProtoMember(5)]
        public int NameId { get; set; }
    }
}
