def OCRTestProj = "capture-platform-tests/Hyland.Capture.Recognition.IntegrationTests.Basic/bin/Debug/Hyland.Capture.Recognition.IntegrationTests.Basic.dll"
def BCTestProj = "capture-platform-tests/Hyland.Capture.Barcode.IntegrationTests.Basic/bin/Debug/Hyland.Capture.Barcode.IntegrationTests.Basic.dll"
def nunitConsole = "M:/Source/dockerstuffs/.nuget/packages/nunit.consolerunner/3.8.0/tools/nunit3-console.exe"
//def nunit = "nunit3-console.exe"

node("testman")
{
    try
    {
        stage ("Testage")
        {
            powershell "${WORKSPACE}/build.ps1 -Verbosity Diagnostic --target='build'"
			powershell "${WORKSPACE}/build.ps1 -Verbosity Diagnostic --target='test'"
            //bat "${nunitConsole} --result=$WORKSPACE/Barcode.Test.Result.xml $WORKSPACE/${BCTestProj}"
            //bat "${nunitConsole} --result=$WORKSPACE/OCR.Test.Result.xml $WORKSPACE/${OCRTestProj}"
       
        }
        
    }
    catch(err)
    {
        currentBuild.result = 'FAILURE'
    }
    finally
    {
        stage("Publish Stuffs")
        {
            nunit failIfNoResults: false, testResultsPattern: '*TestResult.xml'
        }
        
        stage("Say Whaaaaatttttt!!!!!!!")
        {
            emailext body: '$BUILD_URL/testReport/history/', subject: "${JOB_NAME} (${BUILD_NUMBER})", to: 'tim.bush@onbase.com'
        }
    }
}
