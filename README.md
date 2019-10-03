#Taiwu_mods

[![Build Status](https://travis-ci.com/phorcys/Taiwu_mods.svg?branch=master)](https://travis-ci.com/phorcys/Taiwu_mods)

****

## Compile dependencies

* Visual Studio 2017/2019
* .NET Framework 3.5/4.x
* Taiwu game installed
* Install the latest version of cmake (to support VS2019 please download cmake 3.14.3 or newer) and add cmake to the environment variable *PATH*
* The command line runs genvsproj.cmd, which will automatically download the dependent dlls and generate the Visual Studio solution *Taiwu_Mods.sln* to the build directory.
* The .cs in the mod directory will be automatically added to the project. The .dll will automatically be used as a dependency. Other files such as .md, .txt, etc. will be automatically copied to the game's Mod path (if you don't want to copy it, add it to the .modignore).
* cmake will automatically add a post build event for the project. After the build is successful, if there is a mod folder with the same name in the game mod directory, the dll will be automatically copied to the corresponding mod directory in the game mods directory.

****
## New Mod Process

1. Create a new directory and put your mod's .cs file
2. Place **Info.json** (note the case, encoded as *utf8 with bom*) file in this directory, in a similar format:

```json
{
    "Id": "HerbRecipes",
    "DisplayName": "药引烹饪配方精制材料说明",
    "Author": "phorcys",
    "Version": "2.3.0",
    "AssemblyName": "HerbRecipes.dll",
    "EntryMethod": "HerbRecipes.Main.Load",
    "Requirements": ["BaseResourceMod"]
}
```

1. Except for the last line, Requirements is required.
2. In the Mods folder under the Taiwu game path, create a new folder to store your mod, such as: *E:/SteamLibrary/steamapps/common/The Scroll Of Taiwu/Mods/HerbRecipes/*
3. Run genvsproj.cmd to build the project and start mod development.
4. Windows supports .modignore files, which are used to copy files to the mod directory and ignore some files (the default includes .cs.dll .modignore, these three need to be added) (only * and ? matches are supported, ** matches are not supported) )

## Precautions

## Mods Development aids repo

https://github.com/phorcys/Taiwu_Mods_Tools.git
