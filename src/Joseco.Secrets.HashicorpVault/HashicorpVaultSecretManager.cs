using Joseco.Secrets.Contrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Joseco.Secrets.HashicorpVault;

internal class HashicorpVaultSecretManager : ISecretManager
{
    private readonly VaultClient _vaultClient;

    public HashicorpVaultSecretManager(VaultSettings vaultSettings)
    {
        IAuthMethodInfo authMethod = new TokenAuthMethodInfo(vaultSettings.VaultToken);
        VaultClientSettings vaultClientSettings = new VaultClientSettings(vaultSettings.VaultUrl, authMethod);

        _vaultClient = new VaultClient(vaultClientSettings);
    }

    public async Task<T> Get<T>(string path, string mountPoint)
        where T : new()
    {

        Secret<SecretData> kv2Secret = await _vaultClient.V1.Secrets.KeyValue.V2
            .ReadSecretAsync(path: path, mountPoint: mountPoint);

        var returnedData = kv2Secret.Data.Data;
        //Deserialize the returned data to the object of type T
        var json = JsonSerializer.Serialize(returnedData);
        T obj = JsonSerializer.Deserialize<T>(json);
        return obj;
    }
}
