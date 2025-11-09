using System;
using System.Threading.Tasks;

namespace ReQuantum.Abstractions;

public interface IInitializable
{
    Task InitializeAsync(IServiceProvider serviceProvider);
}
