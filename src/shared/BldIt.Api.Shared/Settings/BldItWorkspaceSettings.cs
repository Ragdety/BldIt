namespace BldIt.Api.Shared.Settings;

/// <summary>
/// Class that represents the BldIt path settings
/// </summary>
/// <remarks>
/// This can be used if a custom installation (running on a local machine) is used
/// </remarks>
[Obsolete("Configure BldItHome in FileSettings instead")]
public class BldItWorkspaceSettings
{
    /// <summary>
    /// Represents the home where the bldIt hosting installation is located
    /// </summary>
    public string BldItHome { get; set; }
}