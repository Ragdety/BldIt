pipeline {
    agent any 
    
    environment {
        BLDIT_WORKSPACE = "C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt"
    }
    
    parameters {
        choice(
            name: 'Action',
            choices: ['None', 'Add', 'Remove', 'Update'] 
        )
        string(
            name: 'MigrationName', 
            defaultValue: '', 
            trim: true
        )
    }
    
    stages {
        stage('Build') { 
            steps {
                script {
                    dir("${env.BLDIT_WORKSPACE}\\ci-cd\\scripts\\jenkins") {
                        catchError(buildResult: 'FAILURE', stageResult: 'FAILURE') {
                            bat(script: 'build.bat')
                        }
                    }
                }
            }
        }
        stage('Manage Migration') { 
            steps {
                script {
                    dir("${env.BLDIT_WORKSPACE}\\ci-cd\\scripts\\jenkins") {
                        catchError(buildResult: 'FAILURE', stageResult: 'FAILURE') {
                            if(params.Action == 'Add') {
                                bat(script: "ManageORM.bat ${params.Action} ${params.MigrationName}")
                            }
                            else if(params.Action == 'Update' && !params.MigrationName.isEmpty()) {
                                bat(script: "ManageORM.bat ${params.Action} ${params.MigrationName}")
                            }
                            else {
                                bat(script: "ManageORM.bat ${params.Action}")
                            }
                        }
                    }
                }
            }
        }
    }
}