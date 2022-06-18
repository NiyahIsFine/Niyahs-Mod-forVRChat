using UnityEngine;
namespace Niyah_s_Mod.UI
{
    class ModPage
    {
        private VRC.UI.Elements.QuickMenu quickMenu;
        GameObject modPage;
        public ModPage(VRC.UI.Elements.QuickMenu quickMenu)
        {
            this.quickMenu = quickMenu;
            OnModPageCreated();
        }
        private void OnModPageCreated()
        {
            modPage = Object.Instantiate(quickMenu.field_Public_GameObject_6, quickMenu.field_Public_GameObject_6.transform.parent);
            modPage.SetActive(true);
            modPage.name = "Niyah's Mod";
        }
    }
}
