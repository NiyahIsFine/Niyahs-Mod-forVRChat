using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using VRC.SDKBase;
using Il2CppSystem;

using UnhollowerRuntimeLib;
namespace Niyah_sMod
{
    public class Niyah_sModClass : MelonMod
    {
        private float originalWalkSpeed;
        private float originalRunSpeed;
        private float originalStrafeSpeed;
        private float speedMultiplier=1;
        private int speedLevel = 0;

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
            LoggerInstance.Msg("Current Speed Multiplier:"+ speedMultiplier);
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (Networking.LocalPlayer != null)
                {
                    VRCPlayerApi player = Networking.LocalPlayer;
                    ClassInjector.RegisterTypeInIl2Cpp<SpeedComponent>();

                    if (player.gameObject.GetComponent<SpeedComponent>())
                    {
                    }
                    else
                    {
                        player.gameObject.AddComponent<SpeedComponent>();
                        speedLevel = 0;
                        speedMultiplier = 1;
                        originalWalkSpeed = player.GetWalkSpeed();
                        originalRunSpeed = player.GetRunSpeed();
                        originalStrafeSpeed = player.GetStrafeSpeed();
                    }

                    speedLevel = Mathf.Clamp(speedLevel + 1, -4, 4);         
                    SetPlayerSpeed(player);
                }

            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                if (Networking.LocalPlayer != null)
                {
                    VRCPlayerApi player = Networking.LocalPlayer;
                    ClassInjector.RegisterTypeInIl2Cpp<SpeedComponent>();
                    if (player.gameObject.GetComponent<SpeedComponent>())
                    {
                    }
                    else
                    {
                        player.gameObject.AddComponent<SpeedComponent>();
                        speedLevel = 0;
                        originalWalkSpeed = player.GetWalkSpeed();
                        originalRunSpeed = player.GetRunSpeed();
                        originalStrafeSpeed = player.GetStrafeSpeed();
                    }
                    speedLevel = Mathf.Clamp(speedLevel - 1, -4, 4);
                    SetPlayerSpeed(player);
                }
            }
        }
        public override void OnLateUpdate()
        {

        }

        public override void OnFixedUpdate()
        {

        }

    }

    [RegisterTypeInIl2Cpp]
    public class SpeedComponent : MonoBehaviour
    {
        public SpeedComponent(System.IntPtr ptr) : base(ptr) { }
        public SpeedComponent() : base(ClassInjector.DerivedConstructorPointer<SpeedComponent>()) => ClassInjector.DerivedConstructorBody(this);
    }

}
