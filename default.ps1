Framework "4.0"

properties {
  $pwd = Split-Path $psake.build_script_file	
  $configuration = "Release"
  $buildDir = "$pwd\Build\"
}

task default -depends Build

task Build {
  Exec { msbuild "PhraseMaker.sln" /t:Build /p:Configuration=$configuration /p:OutputPath=$buildDir }
}

task ? -Description "Helper to display task info" {
	Write-Documentation
}