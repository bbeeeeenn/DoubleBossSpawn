using Terraria;
using TShockAPI;

namespace TShockPlugin.Commands;

public class SeeNpcList : Models.Command
{
    public override string[] Aliases { get; set; } = { "test" };
    public override string PermissionNode { get; set; } = "";

    public override void Execute(CommandArgs args)
    {
        args.Player.SendInfoMessage(
            string.Join(
                ", ",
                Main.npc.Select(
                    (npc, i) => npc.netID != 0 ? $"[{i}]{npc.FullName}" : $"[{i}]{npc.netID}"
                )
            )
        );
    }
}
