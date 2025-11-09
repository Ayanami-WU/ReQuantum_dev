using ReQuantum.Models;
using System.Text.Json.Serialization;

namespace ReQuantum.Client;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(ZjuSsoState))]
public partial class SourceGenerationContext : JsonSerializerContext;