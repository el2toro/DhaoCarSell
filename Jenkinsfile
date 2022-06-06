pipeline {

    agent any

     stages{

      stage("Build"){

            steps{

              echo("Build")
              
            }
        }

        stage("Test"){

            steps{

              echo("Test")
              
            }
        }

        stage("Integration Test"){

            steps{

              echo("Integration Test")

            }
        }

        post{

            always{
                echo("I will run always!!!")
            }

            succes{
                echo("I will run succesfull!!!")
            }

            failure{
                echo("I will run when fails!!!")
            }
        }
    }
}