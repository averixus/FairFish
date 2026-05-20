using HarmonyLib;
using Vintagestory.API.Common;

namespace FairFish;

public class FairFishModSystem : ModSystem
{
    Harmony Harmony;

    public override void Start(ICoreAPI api)
    {
        Harmony = new Harmony(Mod.Info.ModID);
        if (!Harmony.HasAnyPatches(Harmony.Id))
        {
            Harmony.PatchAll(typeof(FairFishModSystem).Assembly);
        }
    }

    public override void Dispose()
    {
        base.Dispose();
        Harmony.UnpatchAll();
    }
}
