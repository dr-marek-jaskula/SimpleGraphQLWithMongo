using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Moviefactory.Infrastructure.Options;

internal sealed class DatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
{
    private const string _configurationSectionName = "DatabaseOptions";
    private const string _defaultConnection = "DefaultConnection";
    private const string _databaseName = "DatabaseName";
    private const string _collectionName = "CollectionName";
    private readonly IConfiguration _configuration = configuration;

    public void Configure(DatabaseOptions options)
    {
        options.ConnectionString = _configuration
            .GetConnectionString(_defaultConnection);

        _configuration
            .GetSection(_configurationSectionName)
            .Bind(options);

        _configuration
            .GetSection(_databaseName)
            .Bind(options);

        _configuration
            .GetSection(_collectionName)
            .Bind(options);
    }
}