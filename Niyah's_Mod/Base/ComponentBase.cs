using VRC;
namespace Niyah_s_Mod.Base
{
    class ComponentBase
    {
        public virtual void OnApplicationStart()
        {
        }
        public virtual void OnApplicationQuit()
        {
        }
        public virtual void OnVRCUiManagerInstantiate()
        {
        }
        public virtual void OnQuickMenuInstantiate()
        {
        }
        public virtual void OnUpdate()
        {
        }
        public virtual void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
        }
        public virtual void OnLateUpdate()
        {
        }
        public virtual void OnGUI()
        {
        }
        public virtual void OnPreferencesSaved()
        {
        }
        public virtual void OnPreferencesSaved(string filepath)
        {
        }
        public virtual void OnPreferencesLoaded()
        {
        }
        public virtual void OnPreferencesLoaded(string filepath)
        {
        }
        public virtual void OnPlayerJoined(Player player)
        {
        }
        public virtual void OnPlayerLeft(Player player)
        {
        }
    }
}
