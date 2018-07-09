def OCRTestProj = "capture-platform-tests/Hyland.Capture.Recognition.IntegrationTests.Basic/bin/Debug/Hyland.Capture.Recognition.IntegrationTests.Basic.dll"
def BCTestProj = "capture-platform-tests/Hyland.Capture.Barcode.IntegrationTests.Basic/bin/Debug/Hyland.Capture.Barcode.IntegrationTests.Basic.dll"
def nunitConsole = "M:/Source/dockerstuffs/.nuget/packages/nunit.consolerunner/3.8.0/tools/nunit3-console.exe"

pipeline 
{
	agent 
	{
		node 
		{
			label 'performance'
		}    
	}
	stages
	{
		stage ("Testage")
		{
			steps
			{
				//powershell "${WORKSPACE}/capture-platform-tests/build.ps1 -Verbosity Diagnostic --target='build'"
				bat "${nunitConsole} --result=$WORKSPACE/Barcode.Test.Result.xml $WORKSPACE/${BCTestProj}"
				bat "${nunitConsole} --result=$WORKSPACE/OCR.Test.Result.xml $WORKSPACE/${OCRTestProj}"
			}
			post
			{
				always
				{
					nunit failIfNoResults: false, testResultsPattern: '*.Test.Result.xml'
				}
			}
		}
		stage("Say Whaaaaatttttt!!!!!!!")
		{
			steps
			{
				emailext body: 'http://localhost:8080/job/$JOB_NAME/$BUILD_NUMBER/testReport/history/', subject: "${JOB_NAME} (${BUILD_NUMBER})", to: 'tim.bush@onbase.com'
			}
		}
	}
}
