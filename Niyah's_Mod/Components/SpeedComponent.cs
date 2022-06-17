using VRC.SDKBase;
using UnityEngine;
using Niyah_s_Mod.Base;
using VRC;

namespace Niyah_s_Mod.Components
{
    class SpeedComponent : ComponentBase
    {
        private float originalWalkSpeed;
        private float originalRunSpeed;
        private float originalStrafeSpeed;
        private float speedMultiplier = 1;
        private int speedLevel = 0;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
        }
        public override void OnPlayerJoined(Player player)
        {
            if (player.prop_VRCPlayerApi_0.isLocal)
            {
                originalWalkSpeed = player.prop_VRCPlayerApi_0.GetWalkSpeed();
                originalRunSpeed = player.prop_VRCPlayerApi_0.GetRunSpeed();
                originalStrafeSpeed = player.prop_VRCPlayerApi_0.GetStrafeSpeed();
                speedLevel = 0;
                speedMultiplier = 1;
                NiyahsModClass.Instance.OutputLog("速度初始化", true);
                NiyahsModClass.Instance.OutputLog("originalWalkSpeed=" + originalWalkSpeed + " originalRunSpeed=" + originalRunSpeed + " originalStrafeSpeed=" + originalStrafeSpeed, true);
            }
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (Networking.LocalPlayer != null)
                {
                    VRCPlayerApi player = Networking.LocalPlayer;
                    speedLevel = Mathf.Clamp(speedLevel + 1, -4, 4);
                    SetPlayerSpeed(player);
                }
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                if (Networking.LocalPlayer != null)
                {
                    VRCPlayerApi player = Networking.LocalPlayer;
                    speedLevel = Mathf.Clamp(speedLevel - 1, -4, 4);
                    SetPlayerSpeed(player);
                }
            }
        }
        private void SetPlayerSpeed(VRCPlayerApi mySelf)
        {
            if (speedLevel >= 0)
            {
                speedMultiplier = speedLevel + 1;
            }
            else
            {
                speedMultiplier = 1 + speedLevel * 0.2f;
            }
            mySelf.SetWalkSpeed(originalWalkSpeed * speedMultiplier);
            mySelf.SetRunSpeed(originalRunSpeed * speedMultiplier);
            mySelf.SetStrafeSpeed(originalStrafeSpeed * speedMultiplier);
            NiyahsModClass.Instance.OutputLog("Current Speed Multiplier:" + speedMultiplier);
        }

    }
}
