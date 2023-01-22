/*
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQoM.cs

using Skua.Core.Interfaces;

public class CompleteQOM
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();
    public CoreFarms Farm = new CoreFarms();
    public CoreQOM QOM => new();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        QOM.CompleteEverything();

        Core.SetOptions(false);
    }
}
