//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/Nation/Fiendshard.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/AFDL/WillpowerExtraction.cs
//cs_include Scripts/Story/Nation/Originul.cs
using RBot;
using RBot.Items;
using RBot.Options;


public class ArchfiendDeathLord
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public CoreAdvanced Adv = new CoreAdvanced();
    public CoreStory Story = new CoreStory();
    public CoreDailies Daily = new();
    public Fiendshard_Story fiendshard = new();
    public CoreNation Nation = new();
    public WillpowerExtraction Willpower = new();

    public string OptionsStorage = "Class or All";
    public List<IOption> Options = new List<IOption>()
    {
        new Option<bool>("OnlyArmor", "Only get the Armor?", "Whether to only get the Armor or all quest rewards"),
    };

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetArm();

        Core.SetOptions(false);
    }

    public void GetArm(bool OnlyArmor = true)
    {
        if (Core.CheckInventory("Archfiend DeathLord"))
            return;

        OnlyArmor = Bot.Config.Get<bool>("OnlyArmor");
        string[] RewardsList = OnlyArmor ? new[] { "Archfiend DeathLord" } : Core.EnsureLoad(7900).Rewards.Select(x => x.Name).ToList().ToArray();
        Core.AddDrop(RewardsList.ToArray());

        fiendshard.Fiendshard_Questline();

        while (!Bot.ShouldExit() && !Core.CheckInventory(RewardsList))
        {
            Core.EnsureAccept(7900);

            Nation.FarmBloodGem(20);
            Nation.FarmUni13(5);
            Nation.FarmTotemofNulgath(3);
            Nation.FarmVoucher(false);
            Nation.FarmDiamondofNulgath(150);
            Nation.FarmGemofNulgath(50);
            Willpower.Unidentified34(10);

            Core.EnsureCompleteChoose(7900, RewardsList);
            Bot.Wait.ForPickup("*");
        }

    }
}
