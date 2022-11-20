import os
import subprocess
import sys

bldIt_builds_contracts   = "src/services/builds/BldIt.Builds.Contracts"
bldIt_identity_contracts = "src/services/identity/BldIt.Identity.Contracts"
bldIt_jobs_contracts     = "src/services/jobs/BldIt.Jobs.Contracts"
bldIt_projects_contracts = "src/services/projects/BldIt.Projects.Contracts"

bldit_contracts_dict = {
    "CONTRACT_FOLDERS": {
        "BUILDS"  : bldIt_builds_contracts,
        "IDENTITY": bldIt_identity_contracts,
        "JOBS"    : bldIt_jobs_contracts,
        "PROJECTS": bldIt_projects_contracts
    },
    "CONTRACT_PROJECTS": {
        "BUILDS"  : bldIt_builds_contracts + "/BldIt.Builds.Contracts.csproj",
        "IDENTITY": bldIt_identity_contracts + "/BldIt.Identity.Contracts.csproj",
        "JOBS"    : bldIt_jobs_contracts + "/BldIt.Jobs.Contracts.csproj",
        "PROJECTS": bldIt_projects_contracts + "/BldIt.Projects.Contracts.csproj"
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
if sys.argv[1] == "debug":
    debug = True

decoded_result = result.stdout.decode('utf-8')

# Split by each new line (skip last extra line the command outputs)
changed_file_paths = decoded_result.split('\n')[0:-1]

# Loop through each changed file path and set env var accordingly
for file in changed_file_paths:
    if debug:
        print(file)

    if bldit_contracts_dict["CONTRACT_FOLDERS"]["BUILDS"] in file:
        os.environ["BUILDS"] = "true"
        os.environ["BUILDS_PROJECT"] = bldit_contracts_dict["CONTRACT_PROJECTS"]["BUILDS"]

    elif bldit_contracts_dict["CONTRACT_FOLDERS"]["IDENTITY"] in file:
        os.environ["IDENTITY"] = "true"
        os.environ["IDENTITY_PROJECT"] = bldit_contracts_dict["CONTRACT_PROJECTS"]["IDENTITY"]

    elif bldit_contracts_dict["CONTRACT_FOLDERS"]["JOBS"] in file:
        os.environ["JOBS"] = "true"
        os.environ["JOBS_PROJECT"] = bldit_contracts_dict["CONTRACT_PROJECTS"]["JOBS"]

    elif bldit_contracts_dict["CONTRACT_FOLDERS"]["PROJECTS"] in file:
        os.environ["PROJECTS"] = "true"
        os.environ["PROJECTS_PROJECT"] = bldit_contracts_dict["CONTRACT_PROJECTS"]["PROJECTS"]
