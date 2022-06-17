using VRC.Core;
using Niyah_s_Mod.Base;
using VRC;
using System;

namespace Niyah_s_Mod.Components
{
    class JoinedAndLefted : ComponentBase
    {
        public override void OnPlayerJoined(Player player)
        {
            if (player != null && player.prop_VRCPlayerApi_0 != null && !player.prop_VRCPlayerApi_0.isLocal)
            {
                if (APIUser.CurrentUser.friendIDs.Contains(player.prop_APIUser_0.id))
                    NiyahsModClass.Instance.OutputLog(player.prop_VRCPlayerApi_0.displayName + " joined the game!", false, ConsoleColor.Magenta);
                else
                    NiyahsModClass.Instance.OutputLog(player.prop_VRCPlayerApi_0.displayName + " joined the game!");
            }
        }
        public override void OnPlayerLeft(Player player)
        {
            if (player != null)
            {
                if (player.prop_VRCPlayerApi_0 != null && !player.prop_VRCPlayerApi_0.isLocal)
                {
                    if (APIUser.CurrentUser.friendIDs.Contains(player.prop_APIUser_0.id))
                        NiyahsModClass.Instance.OutputLog(player.prop_VRCPlayerApi_0.displayName + " lefted the game...", false, ConsoleColor.Magenta);
                    else
                        NiyahsModClass.Instance.OutputLog(player.prop_VRCPlayerApi_0.displayName + " lefted the game...");
                }
            }
        }
    }
}
