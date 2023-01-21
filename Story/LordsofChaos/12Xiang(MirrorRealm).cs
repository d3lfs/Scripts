/*
path: Story/LordsofChaos/12Xiang(MirrorRealm).cs
fileName: 12Xiang(MirrorRealm).cs
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

public class SagaMirrorRealm
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new CoreAdvanced();
    public CoreFarms Farm = new CoreFarms();
    public Core13LoC LOC => new Core13LoC();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        LOC.Xiang();

        Core.SetOptions(false);
    }
}
