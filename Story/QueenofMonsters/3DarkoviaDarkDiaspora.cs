/*
path: Story/QueenofMonsters/3DarkoviaDarkDiaspora.cs
fileName: 3DarkoviaDarkDiaspora.cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQoM.cs

using Skua.Core.Interfaces;

public class CompleteDarkDiaspora
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();
    public CoreFarms Farm = new CoreFarms();
    public CoreQOM QOM => new();
    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        QOM.DarkoviaDarkDiaspora();

        Core.SetOptions(false);
    }
}
