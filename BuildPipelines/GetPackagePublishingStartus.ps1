param (
 [Parameter(Mandatory = $true)] [string]$folderName = "D:\Nuget",
 [Parameter(Mandatory = $false)] [string]$secondsToSleep = 60
)

# Find-Package Gamification.Platform.Common.Core -Source https://www.nuget.org/api/v2 -AllowPrereleaseVersions -RequiredVersion 2.0.13-preview

$nugetPackageFiles = "$folderName" + "\*.nupkg" 
Write-Host "Search Path: $nugetPackageFiles"
$fileItems = Get-ChildItem $nugetPackageFiles
Write-Host "Nuget packages found: $fileItems"

$fileItems | ForEach-Object {

  Write-Output "#########################################################################"
  Write-Output "Working on package $_.Name"
  $previewExists = $_.Name -imatch "(?<PackageName>\D+).(?<Version>\d+(\.\d+)+-preview)"

  if ($previewExists) {

    Write-Output "Preview version found."
    $packageName = $matches.PackageName
    $version = $matches.Version

    Write-Output "PackageName: $packageName"
    Write-Output "Version: $version"

  } else {
  
    $stableExists = $_.Name -imatch "(?<PackageName>\D+).(?<Version>\d+(\.\d+)+)"
  
    if ($stableExists) {
    
      Write-Output "Stable version found."
      $packageName = $matches.PackageName
      $version = $matches.Version

      Write-Output "PackageName: $packageName"
      Write-Output "Version: $version"
  
    } else {
      Write-Output "Version or package name cannot be recognized. Exiting the prosess"
      Exit 2
    }

  }

  do {

    $packageFound = $false
    Write-Output "Searching for package $packageName with version $version"
    
    $package = Find-Package $packageName -Source https://www.nuget.org/api/v2 -AllowPrereleaseVersions -RequiredVersion $version -ErrorAction SilentlyContinue -ErrorVariable SearchError

    if ($package) {
      Write-Output "Package published."
      Write-Output $package
      $packageFound = $true
    } else {
      Write-Output "Error: $SearchError "
      Write-Output "Package $package has not been published yet. Sleeping for $secondsToSleep seconds."
      Write-Output "Sleep for $secondsToSleep seconds."
      sleep 20
    }
  
  } until ($packageFound)

}

