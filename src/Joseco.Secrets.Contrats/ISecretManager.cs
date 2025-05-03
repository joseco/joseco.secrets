namespace Joseco.Secrets.Contrats;

public interface ISecretManager
{
    /// <summary>
    /// Gets the secret from the secret manager.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nameOrPath">name or the path where the secred is stored</param>
    /// <param name="mountPoint">Additional parameter used for some secret providers</param>
    /// <returns></returns>
    Task<T> Get<T>(string nameOrPath, string? mountPoint = null) where T : new();
}
