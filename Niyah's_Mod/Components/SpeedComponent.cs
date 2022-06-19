using VRC.SDKBase;
using Niyah_s_Mod.Base;
using VRC;
using UnityEngine.Events;
using System;

namespace Niyah_s_Mod.Components
{
    class SpeedComponent : ComponentBase
    {
        public UnityAction<float> AdjustSpeed;
        private float originalWalkSpeed;
        private float originalRunSpeed;
        private float originalStrafeSpeed;
        private float speedMultiplier = 1;
        public SpeedComponent()
        {
            AdjustSpeed = new Action<float>(SetPlayerSpeed);
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

        }
        public override void OnPlayerJoined(Player player)
        {
            //movement初始化
            if (player.prop_VRCPlayerApi_0.isLocal)
            {
                originalWalkSpeed = player.prop_VRCPlayerApi_0.GetWalkSpeed();
                originalRunSpeed = player.prop_VRCPlayerApi_0.GetRunSpeed();
                originalStrafeSpeed = player.prop_VRCPlayerApi_0.GetStrafeSpeed();
                speedMultiplier = 1;
                manager.GetComponent<UIComponent>().modMenu.SyncMovementInfos(1);
                NiyahsModClass.Instance.OutputLog("速度初始化", true);
                NiyahsModClass.Instance.OutputLog("originalWalkSpeed=" + originalWalkSpeed + " originalRunSpeed=" + originalRunSpeed + " originalStrafeSpeed=" + originalStrafeSpeed, true);
            }
        }

        private void SetPlayerSpeed(float value)
        {
            if (Networking.LocalPlayer != null)
            {
                VRCPlayerApi player = Networking.LocalPlayer;

                if (value <= 1)
                {
                    speedMultiplier = value;
                }
                else if (value <= 1.5f)
                {
                    speedMultiplier = value * 8 - 7;
                }
                else
                {
                    speedMultiplier = value * 30 - 40;
                }
                player.SetWalkSpeed(originalWalkSpeed * speedMultiplier);
                player.SetRunSpeed(originalRunSpeed * speedMultiplier);
                player.SetStrafeSpeed(originalStrafeSpeed * speedMultiplier);
                NiyahsModClass.Instance.OutputLog("Current Speed Multiplier:" + speedMultiplier, true);
            }
        }
    }
}
