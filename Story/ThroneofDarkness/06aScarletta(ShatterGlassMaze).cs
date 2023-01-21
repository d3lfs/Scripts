/*
path: Story/ThroneofDarkness/06aScarletta(ShatterGlassMaze).cs
fileName: 06aScarletta(ShatterGlassMaze).cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
using Skua.Core.Interfaces;

public class ShatterGlassMaze
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreToD TOD = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        TOD.ShatterGlassMaze();

        Core.SetOptions(false);
    }
}
