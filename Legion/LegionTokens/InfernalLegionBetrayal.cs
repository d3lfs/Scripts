/*
name: InfernalLegionBetrayal
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class InfernalLegionBetrayal
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreLegion Legion = new CoreLegion();
    public CoreAdvanced Adv = new CoreAdvanced();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        Legion.LTInfernalLegionBetrayal();

        Core.SetOptions(false);
    }
}
