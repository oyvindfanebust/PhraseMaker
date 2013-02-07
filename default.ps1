Framework "4.0"

properties {
  $pwd = Split-Path $psake.build_script_file	
  $configuration = "Release"
  $buildDir = "$pwd\Build\"
  $version = "1.0.0"
}

task default -depends Build

task Build {
  Exec { msbuild "PhraseMaker.sln" /t:Build /p:Configuration=$configuration }
}

task CreatePackage {
  Exec { msbuild "PhraseMaker.sln" /t:Build /p:Configuration=$configuration /p:OutputPath=$buildDir }
  Exec { .nuget\nuget.exe pack PhraseMaker.nuspec -Version $version }
}

task ? -Description "Helper to display task info" {
	Write-Documentation
}