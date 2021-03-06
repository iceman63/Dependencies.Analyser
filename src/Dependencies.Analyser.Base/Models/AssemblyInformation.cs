﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dependencies.Analyser.Base.Models
{
    public enum TargetProcessor
    {
        AnyCpu,
        x86,
        x64,
    }

    [DebuggerDisplay("Name = {Name}, Loaded Version = {LoadedVersion}, Local= {IsLocalAssembly}, Resolved={IsResolved} , Links = {Links.Count}")]
    public class AssemblyInformation : IEquatable<AssemblyInformation?>
    {

        public AssemblyInformation(string name,
                                   string? loadedVersion,
                                   string? filePath)
        {
            Name = name;
            LoadedVersion = loadedVersion;
            Links = new List<AssemblyLink>();
            ParentLinkName = new HashSet<string>();
            FilePath = filePath;
        }

        public string Name { get; }
        public string? LoadedVersion { get; set; }

        public string? AssemblyName { get; set; }

        public bool IsLocalAssembly { get; set; }

        public bool IsNative { get; set; }

        public bool IsResolved { get; set; } = true;

        public string FullName => AssemblyName ?? Name;

        public string? FilePath { get; }

        public bool? IsDebug { get; set; }

        public bool IsILOnly { get; set; }

        public string? TargetFramework { get; set; }

        public bool HasEntryPoint { get; set; }

        public TargetProcessor? TargetProcessor { get; set; }

        public string? Creator { get; set; }

        public DateTime CreationDate { get; set; }

        public List<AssemblyLink> Links { get; }

        public HashSet<string> ParentLinkName { get; }

        public override bool Equals(object? obj) => Equals(obj as AssemblyInformation);
        public virtual bool Equals(AssemblyInformation? other) => other != null && FullName == other.FullName && IsDebug == other.IsDebug && TargetFramework == other.TargetFramework && TargetProcessor == other.TargetProcessor;
        public override int GetHashCode() => HashCode.Combine(FullName, IsDebug, TargetFramework, TargetProcessor);

        public static bool operator ==(AssemblyInformation? left, AssemblyInformation? right) => EqualityComparer<AssemblyInformation>.Default.Equals(left, right);
        public static bool operator !=(AssemblyInformation? left, AssemblyInformation? right) => !(left == right);
    }
}
