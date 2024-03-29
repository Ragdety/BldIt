﻿namespace BldIt.Shared.Git;

public interface IGitManager
{
    Task Initialize(string repositoryPath);
    
    // git init <LocalDir>
    Task<int> GitInit(CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git clone <RemoteUrl> <LocalDir>
    Task<int> GitClone(string remoteUrl, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git remote add <RemoteName> <RemoteUrl>
    Task<int> GitRemoteAdd(string remoteName, string remoteUrl, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git remote add <RemoteName> <RemoteUrl>
    Task<int> GitRemoteAddWithAuth(string remoteName, string username, string repoName, string accessToken, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git remote remove <RemoteName>
    Task<int> GitRemoteRemove(string remoteName, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git add <File>
    Task<int> GitAdd(string filePath, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git commit -m <Message>
    Task<int> GitCommit(string message, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git push <RemoteName> <BranchName>
    Task<int> GitPush(string remoteName, string branchName, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git pull <RemoteName> <BranchName>
    Task<int> GitPull(string remoteName, string branchName, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git fetch <RemoteName> <BranchName>
    Task<int> GitFetch(string remoteName, string branchName, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git checkout <BranchName>
    Task<int> GitCheckout(string branchName, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git branch <BranchName>
    Task<int> GitBranch(string branchName, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git status
    Task<int> GitStatus(CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
    
    // git config 
    Task<int> GitConfig(string key, string value, CancellationToken cancellationToken, Func<string, Task>? outputCallback = null);
}