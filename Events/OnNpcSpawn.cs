using Microsoft.Xna.Framework;
using TerrariaApi.Server;
using TShockAPI;

namespace TShockPlugin.Events;

public class OnNpcSpawn : Models.Event
{
    public override void Disable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.NpcSpawn.Deregister(plugin, EventMethod);
    }

    public override void Enable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.NpcSpawn.Register(plugin, EventMethod);
    }

    private void EventMethod(NpcSpawnEventArgs args)
    {
        var npcID = args.NpcId;

        TShock.Utils.Broadcast($"NPCID: {npcID}", Color.White);
    }
}
