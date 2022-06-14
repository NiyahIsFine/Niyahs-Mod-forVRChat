using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
namespace Niyah_sMod
{
    public class Niyah_sModClass : MelonMod
    {
        float A = 1;
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                LoggerInstance.Msg("You just pressed T");

                LoggerInstance.Msg("You just pressed T");
                LoggerInstance.Msg("You just pressed T");
                LoggerInstance.Msg("You just pressed T");
                LoggerInstance.Msg("You just pressed T");
                LoggerInstance.Msg("You just pressed T");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                LoggerInstance.Msg("You just pressed F"+ A);

                LoggerInstance.Msg("You just pressed F"+ A);
                LoggerInstance.Msg("You just pressed F"+A);
                LoggerInstance.Msg("You just pressed F"+A);
                LoggerInstance.Msg("You just pressed F"+A);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                int i = 0;
                for(i=0;i<100;i++)
                {
                    LoggerInstance.Msg(i);
                }
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");

                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
                LoggerInstance.Msg("asd");
            }
        }
        public override void OnLateUpdate()
        {
            
        }

        public override void OnFixedUpdate()
        {

        }

    }
}
