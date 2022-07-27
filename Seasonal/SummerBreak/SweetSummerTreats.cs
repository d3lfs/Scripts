//cs_include Scripts/CoreBots.cs
using RBot;

public class SweetSummerTreats
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetTreats();

        Core.SetOptions(false);
    }

    public void GetTreats()
    {
        string[] rewards = { "Sunflower Outfit", "SunFlower Locks", "Sunflower Hair" };
        if (Core.CheckInventory(rewards, toInv: false))
            return;

        Core.AddDrop(rewards);
        Core.RegisterQuests(7578);
        while (!Bot.ShouldExit() && Core.CheckInventory(rewards))
        {
            Core.HuntMonster("summerbreak", "Ice Cream Shark", "Icecream Shark", 3, false);
            Core.HuntMonster("summerbreak", "MMMirage", "MMMirage", 3, false);
            Core.HuntMonster("summerbreak", "Bananasplit", "Bananasplit", 3, false);
        }
        Core.CancelRegisteredQuests();
    }
}