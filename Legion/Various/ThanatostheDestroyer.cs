//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;

public class ThanatostheDestroyer
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    private CoreAdvanced Adv => new();


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetRewards();

        Core.SetOptions(false);
    }

    public void GetRewards()
    {
        if (!Core.CheckInventory("Thanatos Paragon Pet") || Core.CheckInventory(Core.EnsureLoad(4101).Rewards.Select(i => i.Name).ToArray()))
            Core.Logger("Pet not owned, or All Items already owned.", stopBot: true);
        else Core.Logger("Thanatos Paragon Pet owned, continueing.");

        List<ItemBase> RewardOptions = Core.EnsureLoad(4101).Rewards;
        string[] QuestRewards = RewardOptions.Select(x => x.Name).ToArray();


        Core.EquipClass(ClassType.Solo);
        Adv.BestGear(GearBoost.Undead);
        Core.RegisterQuests(4101);
        foreach (ItemBase Reward in RewardOptions)
        {
            if (Core.CheckInventory(Reward.ID, toInv: false))
                Core.Logger($"{Reward.Name} Found.");
            else
            {
                Bot.Drops.Add(Reward.ID);
                Core.FarmingLogger(Reward.Name, 1);
                while (Bot.ShouldExit && !Core.CheckInventory(Reward.ID))
                    Core.HuntMonster("underrealm", "Death", "Become Death", log: false);
                Bot.Wait.ForPickup(Reward.ID);
                Core.ToBank(Reward.ID);
            }
        }
        Core.CancelRegisteredQuests();
        Core.Logger($"Jobs Done 👍");
    }
}