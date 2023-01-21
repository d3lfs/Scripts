/*
path: Dailies/Pyromancer.cs
fileName: Pyromancer.cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;

public class Pyromancer
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreDailies Daily = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Daily.Pyromancer();

        Core.SetOptions(false);
    }
}
