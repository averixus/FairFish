using System.Collections.Generic;
using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace FairFish
{
    [HarmonyPatch(typeof(CollectibleBehaviorHandbookTextAndExtraInfo), "addProcessesIntoInfo")]
    public class HandbookPatch
    {
        public static bool Prefix(ICoreClientAPI capi, ActionConsumable<string> openDetailPageFor, ItemStack stack, List<RichTextComponentBase> components, float marginTop, float marginBottom, List<ItemStack> containers, List<ItemStack> fuels, bool haveText)
        {
            CollectibleBehaviorGroundStoredProcessable behaviour = stack.Collectible.GetCollectibleBehavior<CollectibleBehaviorGroundStoredProcessable>(withInheritance: true);
            if (behaviour == null || behaviour.ProcessedStacks == null) return true;
            foreach (BlockDropItemStack drop in behaviour.ProcessedStacks)
            {
                drop.ResolvedItemstack = drop.GetNextItemStack();
            }
            return true;
        }
    }
}