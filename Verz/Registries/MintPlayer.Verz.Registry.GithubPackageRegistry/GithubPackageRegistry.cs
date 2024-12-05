﻿using MintPlayer.Verz.Abstractions;
using MintPlayer.Verz.Sdk.Dotnet.Abstractions;
using MintPlayer.Verz.Sdk.Nodejs.Abstractions;

namespace MintPlayer.Verz.Registry.GithubPackageRegistry;

internal interface IGithubPackageRegistry : IPackageRegistry, IFeedSupportsDotnetSDK, IFeedSupportsNodejsSDK { }

internal class GithubPackageRegistry : IGithubPackageRegistry
{
    private readonly string organization;
    public GithubPackageRegistry(string organization)
    {
        this.organization = organization;
    }

    // https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry
    public string NugetFeedUrl => $"https://nuget.pkg.github.com/{organization}/index.json";

    // https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-npm-registry
    public string NpmFeed => "https://npm.pkg.github.com";

    public Task<IEnumerable<string>> GetPackageVersions(string packageId)
    {
        return Task.FromResult<IEnumerable<string>>(new string[0]);
    }

    public Task InitializeFeed()
    {
        return Task.CompletedTask;
    }
}
