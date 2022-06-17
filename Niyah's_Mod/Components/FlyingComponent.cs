using VRC.SDKBase;
using UnityEngine;
using Niyah_s_Mod.Base;
namespace Niyah_s_Mod.Components
{
    class FlyingComponent:ComponentBase
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
                if (Networking.LocalPlayer != null)
                {
                    //VRCPlayerApi player = Networking.LocalPlayer;
                    //if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup") != null)
                    //{
                    //    GameObject ui = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/").transform.Find("Page_DevTools").gameObject;
                    //    NiyahsModClass.Instance.OutputLog(ui.name);
                    //    GameObject ui_Copy = Object.Instantiate(ui, ui.transform.parent);
                    //    ui_Copy.SetActive(true);
                    //    ui_Copy.name = "ModButton";
                    //}
                    //else
                    //{
                    //    NiyahsModClass.Instance.OutputLog("Can't Find UI");
                    //}

                }
            }
        }
    }
}
