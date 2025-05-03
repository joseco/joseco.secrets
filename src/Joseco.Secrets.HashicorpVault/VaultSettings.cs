using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joseco.Secrets.HashicorpVault;

public record VaultSettings
{
    public string? VaultUrl { get; init; }
    public string? VaultToken { get; init; }

}
