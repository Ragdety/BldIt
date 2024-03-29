﻿using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Enums;
using BldIt.Builds.Contracts.Keys;

namespace BldIt.BuildScheduler.Core.Models;

public class SchedulerBuildStep : IEntity<BuildStepKey>
{
    public BuildStepKey Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public string Command { get; set; }
    public BuildStepType Type { get; set; }
}