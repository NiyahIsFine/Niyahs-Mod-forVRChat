using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Niyah_s_Mod.Base;
using VRC;
namespace Niyah_s_Mod
{
    class ComponentManager
    {
        private List<ComponentBase> components;
        private string componentNameSpace = "Niyah_s_Mod.Components";
        public ComponentManager()
        {
            OnApplicationStart();
        }
        public void OnApplicationStart()
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == componentNameSpace && t.BaseType == typeof(ComponentBase)
                    select t;
            List<Type> types = new List<Type>();

            foreach (var type in q.ToList())
            {
                types.Add(type);
            }
            components = new List<ComponentBase>();
            foreach (var type in types)
            {
                components.Add(Activator.CreateInstance(type) as ComponentBase);
            }
            foreach (var component in components)
            {
                component.OnApplicationStart();
            }

        }
        public void OnApplicationQuit()
        {
            foreach (var component in components)
            {
                component.OnApplicationQuit();
            }
        }
        public void OnVRCUiManagerInstantiate()
        {
            foreach (var component in components)
            {
                component.OnVRCUiManagerInstantiate();
            }
        }
        public void OnQuickMenuInstantiate()
        {
            foreach (var component in components)
            {
                component.OnQuickMenuInstantiate();
            }
        }
        public void OnUpdate()
        {
            foreach (var component in components)
            {
                component.OnUpdate();
            }
        }
        public void OnLateUpdate()
        {
            foreach (var component in components)
            {
                component.OnLateUpdate();
            }
        }
        public void OnGUI()
        {
            foreach (var component in components)
            {
                component.OnGUI();
            }
        }
        public void OnPreferencesSaved()
        {
            foreach (var component in components)
            {
                component.OnPreferencesSaved();
            }
        }
        public void OnPreferencesSaved(string filepath)
        {
            foreach (var component in components)
            {
                component.OnPreferencesSaved(filepath);
            }
        }
        public void OnPreferencesLoaded()
        {
            foreach (var component in components)
            {
                component.OnPreferencesLoaded();
            }
        }
        public void OnPreferencesLoaded(string filepath)
        {
            foreach (var component in components)
            {
                component.OnPreferencesLoaded(filepath);
            }
        }
        public void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            foreach (var component in components)
            {
                component.OnSceneWasLoaded(buildIndex, sceneName);
            }
        }
        public void OnPlayerJoined(Player player)
        {
            foreach (var component in components)
            {
                component.OnPlayerJoined(player);
            }
        }
        public void OnPlayerLeft(Player player)
        {
            foreach (var component in components)
            {
                component.OnPlayerLeft(player);
            }
        }
    }
}
