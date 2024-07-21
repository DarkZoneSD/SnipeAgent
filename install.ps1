# Define paths
$FilePath = "$PSScriptRoot\SystemTrayApp\bin\Debug\net8.0-windows"
$Destination = "$env:ProgramFiles\SnipeAgent"
$ExePath = "$Destination\SystemTrayApp.exe"
$StartupFolder = "$env:APPDATA\Microsoft\Windows\Start Menu\Programs\Startup"
$ShortcutName = "SnipeAgent"

# Display paths for debugging
Write-Output "FilePath: $FilePath"
Write-Output "Destination: $Destination"

# Create destination folder if it does not exist
if (-not (Test-Path -Path $Destination)) {
    New-Item -Path $Destination -ItemType Directory
}

# Copy files from source to destination
Copy-Item -Path "$FilePath\*" -Destination $Destination -Recurse -Force

Write-Output "Files copied successfully."

# Create a shortcut in the Startup folder
$Shell = New-Object -ComObject WScript.Shell
$Shortcut = $Shell.CreateShortcut("$StartupFolder\$ShortcutName.lnk")
$Shortcut.TargetPath = $ExePath
$Shortcut.Save()

Write-Output "Shortcut created successfully."
