using UnityEngine;
using VRC.UI.Elements.Controls;
namespace Niyah_s_Mod.UI
{
    class ModPage
    {
        private VRC.UI.Elements.QuickMenu quickMenu;
        public GameObject modPageInstance;
        public ModPage(VRC.UI.Elements.QuickMenu quickMenu)
        {
            this.quickMenu = quickMenu;
           CreatedModPage();
        }
        private void CreatedModPage()
        {
            modPageInstance = Object.Instantiate(quickMenu.field_Public_GameObject_6, quickMenu.field_Public_GameObject_6.transform.parent);
            modPageInstance.SetActive(true);
            modPageInstance.name = "Page_Niyah_s_Mod";
            NiyahsModClass.Instance.OutputLog("modPage已被实例化，命名为" + modPageInstance.name, true);

            MenuTab menuTab= modPageInstance.GetComponent<MenuTab>();
            menuTab.field_Public_String_0 = "QuickMenuNiyah_s_Mod";

            VRC.UI.Elements.Tooltips.UiTooltip uiTooltip = modPageInstance.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
            uiTooltip.field_Public_String_0 = "Niyah_s_Mod";
        }
    }
}
