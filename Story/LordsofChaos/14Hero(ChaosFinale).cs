/*
path: Story/LordsofChaos/14Hero(ChaosFinale).cs
fileName: 14Hero(ChaosFinale).cs
name: null
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;

public class SagaChaosFinale
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new CoreAdvanced();
    public CoreFarms Farm = new CoreFarms();
    public Core13LoC LOC => new Core13LoC();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        LOC.Hero();

        Core.SetOptions(false);
    }
}
