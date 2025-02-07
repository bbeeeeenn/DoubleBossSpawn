using System;
using TerrariaApi.Server;

namespace TShockPlugin.Events;

public class OnGetData : Models.Event
{
    public override void Disable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.NetGetData.Deregister(plugin, EventMethod);
    }

    public override void Enable(TerrariaPlugin plugin)
    {
        ServerApi.Hooks.NetGetData.Register(plugin, EventMethod);
    }

    private void EventMethod(GetDataEventArgs args)
    {
        if (args.MsgID != PacketTypes.NpcUpdate)
            return;

        using BinaryReader reader = new(
            new MemoryStream(args.Msg.readBuffer, args.Index, args.Length)
        );

        var npcID = reader.ReadInt16();
        var posx = reader.ReadSingle();
        var posy = reader.ReadSingle();
        _ = reader.ReadSingle();
        _ = reader.ReadSingle();
        var target = reader.ReadUInt16();
    }
}
