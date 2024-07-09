using System;
using System.Collections;
using System.IO;
using Kernel.Unity;
using UnityEditor;
using UnityEngine;

public class TestWin64Builder : BuilderBase
{
    public TestWin64Builder()
    {
        buildTarget = BuildTarget.StandaloneWindows64;
    }

    protected override string GetLocationPathName()
    {
        var path = Path.GetDirectoryName(Application.dataPath);
        return $"{path}/Builds/Win64_{PlayerSettings.bundleVersion}.{DateTime.Now:yyMMddHHmmss}/{PlayerSettings.productName}.exe";
    }
}