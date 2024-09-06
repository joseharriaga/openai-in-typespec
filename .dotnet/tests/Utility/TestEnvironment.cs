#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Utils;

namespace OpenAI.Tests.Utility;

/// <summary>
/// Test environment configuration for running the OpenAI tests
/// </summary>
public class TestEnvironment
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public TestEnvironment()
    {
        /**
         * We want to be able to to find "root" folders:
         * - The root of the Git repo on disk
         * - The root folder of the source code (eng/sdk)
         * These two are usually the same. In external repos, they may however be a little different.
         * 
         * To search for these folders, we use a simple method where we search up from these starting folders:
         * - Check the "SourcePath" assembly metadata attribute value. All projects in the Azure C# repo automatically have this attribute
         *   added as part of the build "magic" (see {repo_root}\Directory.Build.Targets)
         * - Where the executing assembly is running from
         * Until we find a parent folder that contains a specific subfolder(s).
         */
        DirectoryInfo?[] startingPoints =
        [
            AssemblyHelper.GetAssemblySourceDir<TestEnvironment>(),
            new FileInfo(Assembly.GetExecutingAssembly().Location).Directory,
        ];

        RepoRoot = FindFirstParentWithSubfolders(startingPoints, ".git")
            ?? throw new InvalidOperationException("Could not determine the root folder for this repository");
        SourceRoot = FindFirstParentWithSubfolders(startingPoints, ".github", "src") ?? RepoRoot;

        DotNetExe = AssemblyHelper.GetDotnetExecutable()
            ?? throw new InvalidOperationException(
                "Could not determine the dotnet executable to use. Do you have .Net installed or have your paths correctly configured?");
        TestProxyDll = new FileInfo(
            AssemblyHelper.GetAssemblyMetadata<TestRecording>("TestProxyPath")
            ?? throw new InvalidOperationException("Could not determine the path to the recording test proxy DLL"));
        TestProxyHttpsCertPassword = "password";
        TestProxyHttpsCert = new FileInfo(Path.Combine(
            SourceRoot.FullName,
            "external",
            "testproxy-devcert.pfx"));

        // Determine where test recordings are stored. Preferred method is as artifacts in another repo using the assets.json file.
        // The fallback is in a subfolders under the tests directory
        FileInfo assetsFile = new FileInfo(Path.Combine(SourceRoot.FullName, "assets.json"));
        if (assetsFile.Exists)
        {
            TestRecordingConfig = assetsFile;
        }
        else
        {
            TestRecordingsDirectory = new DirectoryInfo(Path.Combine(SourceRoot.FullName, "tests"));
            if (!TestRecordingsDirectory.Exists)
            {
                TestRecordingsDirectory.Create();
            }
        }
    }

    /// <summary>
    /// Gets the root Git folder.
    /// </summary>
    public DirectoryInfo RepoRoot { get; }

    /// <summary>
    /// Gets the root folder that contains the source code for the OpenAI project. This is usually the same as <see cref="RepoRoot"/>
    /// </summary>
    public DirectoryInfo SourceRoot { get; }

    /// <summary>
    /// Gets the path to the dotnet executable. This will be used in combination with <see cref="TestProxyDll"/> to start the
    /// recording test proxy service.
    /// </summary>
    public FileInfo DotNetExe { get; }

    /// <summary>
    /// The path to test proxy DLL that will be used when starting the recording test proxy service.
    /// </summary>
    public FileInfo TestProxyDll { get; }

    /// <summary>
    /// Gets the HTTPS certificate file to use as the signing certificate for HTTPS connections to the test proxy.
    /// </summary>
    public FileInfo TestProxyHttpsCert { get; }

    /// <summary>
    /// Gets the password for <see cref="TestProxyHttpsCert"/>.
    /// </summary>
    public string TestProxyHttpsCertPassword { get; }

    /// <summary>
    /// (Optional) The file that controls where the test recordings are saved to and restored from. If this is set then
    /// <see cref="TestRecordingsDirectory"/> will not be set.
    /// </summary>
    public FileInfo? TestRecordingConfig { get; }

    /// <summary>
    /// (Optional) Where to place test recording files. This will only be used if the <see cref="RecordedAssetsConfig"/>
    /// could not be found.
    /// </summary>
    public DirectoryInfo? TestRecordingsDirectory { get; }

    private static DirectoryInfo? FindFirstParentWithSubfolders(IEnumerable<DirectoryInfo?> startingDirs, params string[] subFolders)
        => startingDirs
            .Select(d => FindParentWithSubfolders(d, subFolders))
            .FirstOrDefault(d => d != null);

    private static DirectoryInfo? FindParentWithSubfolders(DirectoryInfo? start, params string[] subFolders)
    {
        if (subFolders == null || subFolders.Length == 0)
        {
            return null;
        }

        for (DirectoryInfo? current = start; current != null; current = current.Parent)
        {
            if (!current.Exists)
            {
                return null;
            }
            else if (subFolders.All(sub => current.EnumerateDirectories(sub).Any()))
            {
                return current;
            }
        }

        return null;
    }
}
