import os
import subprocess
import sys


def write_to_github_env_file(env_var, value):
    # Get the env file from GitHub
    env_file = os.getenv('GITHUB_ENV')

    print(f"Adding {env_var} to {env_file} with value {value}")
    with open(env_file, 'a') as env:
        env.write(f"{env_var}={value}\n")
        env.close()


bldIt_builds_contracts         = "src/services/builds/BldIt.Builds.Contracts"
bldIt_buildScheduler_contracts = "src/services/buildScheduler/BldIt.BuildScheduler.Contracts"
bldIt_identity_contracts       = "src/services/identity/BldIt.Identity.Contracts"
bldIt_jobs_contracts           = "src/services/jobs/BldIt.Jobs.Contracts"
bldIt_projects_contracts       = "src/services/projects/BldIt.Projects.Contracts"

bldit_contracts_dict = {
    "CONTRACT_FOLDERS": {
        "BUILDS"          : bldIt_builds_contracts,
        "BUILDSCHEDULER"  : bldIt_buildScheduler_contracts,
        "IDENTITY"        : bldIt_identity_contracts,
        "JOBS"            : bldIt_jobs_contracts,
        "PROJECTS"        : bldIt_projects_contracts
    },
    "CONTRACT_PROJECTS": {
        "BUILDS"          : bldIt_builds_contracts + "/BldIt.Builds.Contracts.csproj",
        "BUILDSCHEDULER"  : bldIt_buildScheduler_contracts + "/BldIt.BuildScheduler.Contracts.csproj",
        "IDENTITY"        : bldIt_identity_contracts + "/BldIt.Identity.Contracts.csproj",
        "JOBS"            : bldIt_jobs_contracts + "/BldIt.Jobs.Contracts.csproj",
        "PROJECTS"        : bldIt_projects_contracts + "/BldIt.Projects.Contracts.csproj"
    }
}

git_diff_command_raw = "git diff HEAD^ HEAD --name-only"
git_diff_cmd_list = git_diff_command_raw.split(' ')

# Run git diff command to get list of changed files
result = subprocess.run(git_diff_cmd_list, stdout=subprocess.PIPE)

if not result.returncode == 0:
    print("Error running git diff command")
    sys.exit(1)

debug = False
if len(sys.argv) == 2 and sys.argv[1] == "debug":
    debug = True

decoded_result = result.stdout.decode('utf-8')

# Split by each new line (skip last extra line the command outputs)
changed_file_paths = decoded_result.split('\n')[0:-1]

# Loop through each changed file path and set env var accordingly
for file in changed_file_paths:
    if debug:
        print(file)

    if bldit_contracts_dict["CONTRACT_FOLDERS"]["BUILDS"] in file:
        print("Builds contracts changed")
        write_to_github_env_file("BUILDS", "true")
        write_to_github_env_file("BUILDS_PROJECT", bldit_contracts_dict["CONTRACT_PROJECTS"]["BUILDS"])

    elif bldit_contracts_dict["CONTRACT_FOLDERS"]["BUILDSCHEDULER"] in file:
        print("BuildScheduler contracts changed")
        write_to_github_env_file("BUILDSCHEDULER", "true")
        write_to_github_env_file("BUILDSCHEDULER_PROJECT", bldit_contracts_dict["CONTRACT_PROJECTS"]["BUILDSCHEDULER"])

    elif bldit_contracts_dict["CONTRACT_FOLDERS"]["IDENTITY"] in file:
        print("Identity contracts changed")
        write_to_github_env_file("IDENTITY", "true")
        write_to_github_env_file("IDENTITY_PROJECT", bldit_contracts_dict["CONTRACT_PROJECTS"]["IDENTITY"])

    elif bldit_contracts_dict["CONTRACT_FOLDERS"]["JOBS"] in file:
        print("Jobs contracts changed")
        write_to_github_env_file("JOBS", "true")
        write_to_github_env_file("JOBS_PROJECT", bldit_contracts_dict["CONTRACT_PROJECTS"]["JOBS"])

    elif bldit_contracts_dict["CONTRACT_FOLDERS"]["PROJECTS"] in file:
        print("Projects contracts changed")
        write_to_github_env_file("PROJECTS", "true")
        write_to_github_env_file("PROJECTS_PROJECT", bldit_contracts_dict["CONTRACT_PROJECTS"]["PROJECTS"])
