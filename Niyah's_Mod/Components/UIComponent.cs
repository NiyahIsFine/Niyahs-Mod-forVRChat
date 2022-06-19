using Niyah_s_Mod.Base;
using UnityEngine;
using MelonLoader;
using System.Collections;
using Niyah_s_Mod.UI;
namespace Niyah_s_Mod.Components
{
    class UIComponent : ComponentBase
    {
        private static VRC.UI.Elements.QuickMenu quickMenu_Private;
        public static VRC.UI.Elements.QuickMenu quickMenu
        {
            set
            {
                quickMenu_Private = value;
                if (quickMenu_Private != null)
                    NiyahsModClass.Instance.OnQuickMenuInstantiate();
            }
            get
            {
                if (quickMenu_Private == null)
                {
                    if (GameObject.Find("UserInterface") != null && GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) != null)
                        quickMenu_Private = GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true);
                }
                if (quickMenu_Private == null)
                    NiyahsModClass.Instance.OutputLog("quickMenu_Private==null", false, default, 2);
                return quickMenu_Private;
            }
        }
        private  ModMenu modMenu_Private;
        public  ModMenu modMenu
        {
            set
            {
                modMenu_Private = value;
            }
            get
            {
                return modMenu_Private;
            }
        }
        private  ModPage modPage_Private;
        public  ModPage modPage
        {
            set
            {
                modPage_Private = value;
            }
            get
            {
                return modPage_Private;
            }
        }


        bool uiHasBeInstantiated;
        bool uiInstantiateFailed;
        object routine;
        public override void OnVRCUiManagerInstantiate()
        {
            if (!uiInstantiateFailed && !uiHasBeInstantiated && routine == null)
            {
                routine = MelonCoroutines.Start(WaittingForUIInstantiated());
            }
        }
        public override void OnQuickMenuInstantiate()
        {
            modMenu = new ModMenu(quickMenu);
            modPage = new ModPage(quickMenu);
        }
        IEnumerator WaittingForUIInstantiated()
        {
            float count = 0;
            while (GameObject.Find("UserInterface") == null || GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null)
            {
                yield return null;
                count += Time.deltaTime;
                if (count > 5)
                {
                    NiyahsModClass.Instance.OutputLog("等了5秒UI还没被实例化出来，是出BUG了还是你的电脑太卡了？总之这次运行MOD失效了QWQ", false, default, 2);
                    uiInstantiateFailed = true;
                    break;
                }
            }
            if (count <= 5)
            {
                quickMenu = GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true);
                uiHasBeInstantiated = true;
            }
        }
    }
}
