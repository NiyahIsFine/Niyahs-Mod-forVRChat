using VRC.SDKBase;
using UnityEngine;
using Niyah_s_Mod.Base;
namespace Niyah_s_Mod.Components
{
    class FlyingComponent : ComponentBase
    {
        public override void OnApplicationStart()
        {
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Networking.LocalPlayer != null)
                {
                }
            }
            if (Input.GetKeyDown(KeyCode.G))
            {

            }
        }
    }
}
