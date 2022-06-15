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

            }
            if (Input.GetKeyDown(KeyCode.F))
            {

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
