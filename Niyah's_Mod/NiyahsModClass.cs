//#define ENABLE_TEST
using MelonLoader;
using VRC.Core;
using System;
using VRC;


namespace Niyah_s_Mod
{
    public class NiyahsModClass : MelonMod
    {
        private static NiyahsModClass instance;
        private ComponentManager componentsManager;
        public static NiyahsModClass Instance
        {
            get
            {
                return instance;
            }
        }
        public override void OnApplicationStart()
        {
            instance = this;
            componentsManager = new ComponentManager();
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            OutputLog("buildIndex:" + buildIndex + "sceneName:" + sceneName, true);
            componentsManager.OnSceneWasLoaded(buildIndex, sceneName);
            if (buildIndex == 1)
            {
                if (VRCUiManager.field_Private_Static_VRCUiManager_0 == null)
                {
                    OutputLog("出bug了，毁灭吧", true, ConsoleColor.White, 2);
                }
                else
                {
                    OutputLog("VRCUiManager已被实例化", true);
                    VRCEventDelegate<Player> playerJoined = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0;
                    VRCEventDelegate<Player> playerLeft = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;
                    playerJoined.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(player => { if (player != null) OnPlayerJoined(player); }));

                    playerLeft.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(player => { if (player != null) OnPlayerLeft(player); }));
                }
            }
        }
        private void OnPlayerJoined(Player player)
        {
            componentsManager.OnPlayerJoined(player);
        }
        private void OnPlayerLeft(Player player)
        {
            componentsManager.OnPlayerLeft(player);
        }
        public override void OnUpdate()
        {
            componentsManager.OnUpdate();
        }

        public void OutputLog(object message, bool debug = false, ConsoleColor consoleColor = ConsoleColor.White, int logType = 0)
        {
            if (message == null)
            {
                message = "null";
            }
            if (debug)
            {
#if ENABLE_TEST
                switch (logType)
                {
                    case 0:
                        LoggerInstance.Msg(message);
                        break;
                    case 1:
                        LoggerInstance.Warning(message);
                        break;
                    case 2:
                        LoggerInstance.Error(message);
                        break;
                    default:
                        LoggerInstance.Msg(message);
                        break;
                }
#endif
            }
            else
            {
                switch (logType)
                {
                    case 0:
                        LoggerInstance.Msg(consoleColor, message);
                        break;
                    case 1:
                        LoggerInstance.Warning(message);
                        break;
                    case 2:
                        LoggerInstance.Error(message);
                        break;
                    default:
                        LoggerInstance.Msg(consoleColor, message);
                        break;
                }
            }
        }
    }
}
