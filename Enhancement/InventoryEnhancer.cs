//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using RBot;

public class project
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        EnhanceInventory();

        Core.SetOptions(false);
    }
    /// <summary>
    /// Enhances all non-leveled/non-user-level level enhanced items
    /// </summary>
    public void EnhanceInventory()
    {
        List<string> InventoryItems = Bot.Inventory.Items.FindAll(x => x.EnhancementLevel < Bot.Player.Level && (x.ItemGroup != "None" && x.ItemGroup != "am" && x.ItemGroup != "co" && x.ItemGroup != "pe")).Select(x => x.Name).ToList();

        if (InventoryItems.Count == 0)
            Core.Logger("The bot couldn't find any items in your inventory that need enhancing.");

        Adv.EnhanceItem(InventoryItems.ToArray(), EnhancementType.Lucky);
    }
}