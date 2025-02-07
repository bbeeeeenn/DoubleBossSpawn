using System;
using TerrariaApi.Server;

namespace TShockPlugin.Events;

public class OnSendData : Models.Event
{
    public override void Disable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.NetSendData.Deregister(plugin, EventMethod);
    }

    public override void Enable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.NetSendData.Register(plugin, EventMethod);
    }

    private void EventMethod(SendDataEventArgs args)
    {
        if (args.MsgId != PacketTypes.NpcUpdate)
            return;

        var npcID = args.number;
    }
}
