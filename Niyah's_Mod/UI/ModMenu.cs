using UnityEngine;
using VRC.UI.Elements.Menus;
using VRC.UI.Elements;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Niyah_s_Mod.Components;

namespace Niyah_s_Mod.UI
{
    class ModMenu
    {
        public GameObject modMenuInstance;
        private VRC.UI.Elements.QuickMenu quickMenu;

        private GameObject sampleHeader;
        private GameObject sampleGroup;
        private GameObject sampleButton;

        public ModMenu(VRC.UI.Elements.QuickMenu quickMenu)
        {
            this.quickMenu = quickMenu;
            CreatedModPage();
        }
        private void CreatedModPage()
        {
            if (quickMenu.transform.Find("Container/Window/QMParent/Menu_DevTools") == null)
            {
                NiyahsModClass.Instance.OutputLog("Menu_DevTools==null，构建UI失败", false, default, 2);
                return;
            }

            Transform sample = quickMenu.transform.Find("Container/Window/QMParent/Menu_DevTools");
            modMenuInstance = Object.Instantiate(sample.gameObject, sample.parent);
            modMenuInstance.name = "Menu_Niyah_s_Mod";
            NiyahsModClass.Instance.OutputLog("modMenu已被实例化，命名为" + modMenuInstance.name, true);

            DevMenu devMenu = modMenuInstance.GetComponent<DevMenu>();
            devMenu.field_Public_String_0 = "QuickMenuNiyah_s_Mod";
            List<UIPage> uiPage = quickMenu.GetComponent<MenuStateController>().field_Public_ArrayOf_UIPage_0.ToList();
            uiPage.Add(modMenuInstance.GetComponent<DevMenu>());
            quickMenu.GetComponent<MenuStateController>().field_Public_ArrayOf_UIPage_0 = uiPage.ToArray();

            modMenuInstance.transform.Find("Header_DevTools").gameObject.name = "Header_Niyah_s_Mod";
            modMenuInstance.transform.Find("Header_Niyah_s_Mod").GetComponentInChildren<TextMeshProUGUI>().text = "Niyah's Mod";
            modMenuInstance.SetActive(false);
            CopySample(sample);
            AddContent(sample);
        }
        private void CopySample(Transform sample)
        {
            if (modMenuInstance.transform.parent.Find("Menu_AudioSettings") == null)
            {
                NiyahsModClass.Instance.OutputLog("Menu_AudioSettings==null，构建UI失败", false, default, 2);
                return;
            }
            try
            {
                sampleHeader = sample.parent.Find("Menu_AudioSettings/Content/Header_H2").gameObject;
                sampleGroup = sample.parent.Find("Menu_AudioSettings/Content/Mic").gameObject;
                sampleButton = sample.Find("Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_WarpAllToHub").gameObject;
            }
            catch
            {
                NiyahsModClass.Instance.OutputLog("获取UI元素失败", false, default, 2);
            }
        }


        private Transform elementsParent;
        private Slider movingSpeedSlider;
        private void AddContent(Transform sample)
        {

            Object.DestroyImmediate(modMenuInstance.transform.Find("Scrollrect").gameObject);
            elementsParent = Object.Instantiate(modMenuInstance.transform.parent.Find("Menu_AudioSettings/Content").gameObject, modMenuInstance.transform).transform;
            elementsParent.gameObject.name = "Content";
            NiyahsModClass.Instance.OutputLog("elementsParent:" + elementsParent.gameObject.name, true);
            try
            {
                Object.DestroyImmediate(elementsParent.Find("Header_H2 (1)").gameObject);
                Object.DestroyImmediate(elementsParent.Find("Mic").gameObject);
                Object.DestroyImmediate(elementsParent.Find("Audio/VolumeSlider_World").gameObject);
                Object.DestroyImmediate(elementsParent.Find("Audio/VolumeSlider_Voices").gameObject);
                Object.DestroyImmediate(elementsParent.Find("Audio/VolumeSlider_Avatars").gameObject);
            }
            catch
            {
                NiyahsModClass.Instance.OutputLog("Content子物体被更名", false, default, 2);
            }

            //移动：
            elementsParent.Find("Header_H2").gameObject.name = "Header_Movement";
            elementsParent.Find("Header_Movement").GetComponentInChildren<TextMeshProUGUI>().text = "Movement";


            elementsParent.Find("Audio/VolumeSlider_Master").gameObject.name = "Moving Speed";
            elementsParent.Find("Audio").gameObject.name = "Movement";
            elementsParent.Find("Movement/Moving Speed").GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = "Adjust your moving-speed";
            elementsParent.Find("Movement/Moving Speed/Text_QM_H4").GetComponent<TextMeshProUGUI>().text = "Moving-Speed";
            Object.DestroyImmediate(elementsParent.Find("Movement/Moving Speed/Text_QM_H4 (1)").GetComponent<ListCountBinding>());
            movingSpeedSlider = elementsParent.Find("Movement/Moving Speed/Slider").GetComponent<Slider>();
            Object.DestroyImmediate(movingSpeedSlider.GetComponent<SliderBinding>());
            movingSpeedSlider.minValue = 0.1f;
            movingSpeedSlider.maxValue = 2;
            movingSpeedSlider.onValueChanged.RemoveAllListeners();
            movingSpeedSlider.onValueChanged.AddListener(ComponentManager.instance.GetComponent<SpeedComponent>().AdjustSpeed);
            movingSpeedSlider.onValueChanged.AddListener(new System.Action<float>(SpeedMultiDisplay));
        }

        private void SpeedMultiDisplay(float value)
        {
            string textContent;

            if (value <= 1)
            {
                textContent = ((int)(value * 100 + 0.49f)).ToString() + "%";
            }
            else if (value <= 1.5f)
            {

                textContent = ((int)((value * 8 - 7) * 100 + 0.49f)).ToString() + "%";
            }
            else
            {
                textContent = ((int)((value * 30 - 40) * 100 + 0.49f)).ToString() + "%";
            }
            elementsParent.Find("Movement/Moving Speed/Text_QM_H4 (1)").GetComponent<TextMeshProUGUI>().text = textContent;
        }
        public void SyncMovementInfos(float speedMulti)
        {
            movingSpeedSlider.value = speedMulti;
            SpeedMultiDisplay(speedMulti);
        }
    }
}
