using Joseco.Secrets.Contrats;
using Microsoft.Extensions.DependencyInjection;

namespace Joseco.Secrets.HashicorpVault;

public static class DependencyInjection
{
    public static IServiceCollection AddHashicorpVault(this IServiceCollection services, VaultSettings vaultSettings)
    {
        services.AddSingleton(vaultSettings);
        services.AddSingleton<ISecretManager, HashicorpVaultSecretManager>();

        return services;
    }
}
