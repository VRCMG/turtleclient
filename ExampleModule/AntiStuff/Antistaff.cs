using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using VRC;
using VRC.Core;


namespace VRCClient
{
    // Token: 0x020001EC RID: 492
    public class Antistaff : MonoBehaviour
    {
        // Token: 0x06000AFA RID: 2810 RVA: 0x00003D9B File Offset: 0x00001F9B
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Anti-Mod Loaded.");
        }

        // Token: 0x06000AFB RID: 2811 RVA: 0x00003DAE File Offset: 0x00001FAE
        public void Awake()
        {
            UnityEngine.Object.DontDestroyOnLoad(this);
        }

        // Token: 0x06000AFC RID: 2812 RVA: 0x0001983C File Offset: 0x00017A3C
        public void Update()
        {
            foreach (Player player in PlayerManager.GetAllPlayers())
            {
                if (player.HGLCOLNAJJJ.hasSuperPowers || player.HGLCOLNAJJJ.hasModerationPowers)
                {
                    VRCFlowManager.BLIOJBDGJKA.GoHome();
                    bool flag = player.HGLCOLNAJJJ.Equals("usr_1d905d19-7bfa-4989-9da8-0edb6998fefe") || player.HGLCOLNAJJJ.Equals("usr_8d5f86b8-9206-48c6-b5ef-0e889e235adf") || player.HGLCOLNAJJJ.Equals("usr_7e0a968a-74fb-426d-97cf-63f1ea15beb2") || player.HGLCOLNAJJJ.Equals("usr_5a44234c-f957-4f06-baf2-56803dc69126") || player.HGLCOLNAJJJ.Equals("usr_db9bc8b0-321c-42c5-baa1-2fdda45f4e23");
                    APIUser user = player.HGLCOLNAJJJ;
                    if (flag && VRCPlayer.AreNameplatesVisible())
                    {
                        player.vrcPlayer.SetNamePlateColor(new Color(0f, 0f, 0f, 0f));
                    }
                }
            }
        }
    }


}
