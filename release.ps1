if ($PSScriptRoot -match '.+?\\bin\\?') {
    $dir = $PSScriptRoot + "\"
}
else {
    $dir = $PSScriptRoot + "\bin\"
}


foreach($target in ("BepInEx5"))
{
    $copy = $dir + "copy\BepInEx\plugins\SaveFolderEditor\"

    Remove-Item -Force -Path ($copy) -Recurse -ErrorAction SilentlyContinue
    New-Item -ItemType Directory -Force -Path ($copy)

	Copy-Item -Path ($PSScriptRoot + "\SaveFolderEditor\bin\Debug\SaveFolderEditor.dll") -Destination ($copy) -Recurse -Force

    Copy-Item -Path ($dir + "\..\README.md") -Destination ($copy) -Recurse -Force
    Copy-Item -Path ($dir + "\..\LICENSE") -Destination ($copy) -Recurse -Force

    $ver = (Get-ChildItem -Path ($PSScriptRoot + "\SaveFolderEditor\bin\") -Filter ("*SaveFolderEditor.dll") -Recurse -Force)[0].VersionInfo.FileVersion.ToString() -replace "([\d+\.]+?\d+)[\.0]*$", '${1}'
    Compress-Archive -Path ($dir + "copy\BepInEx") -Force -CompressionLevel "Optimal" -DestinationPath ($dir + "Distance.SaveFolderEditor" +"_v" + $ver + ".zip")
}

Remove-Item -Force -Path ($dir + "copy") -Recurse -ErrorAction SilentlyContinue