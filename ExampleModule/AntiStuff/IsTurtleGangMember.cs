using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Collections;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRCClient.VRCheat.Utils;

    namespace turtleclient.AntiStuff
    {
        // Token: 0x020001E8 RID: 488
        public class IsTurtleGangMember : MonoBehaviour
        {
            // Token: 0x06000AE8 RID: 2792 RVA: 0x00003D29 File Offset: 0x00001F29
            public void Awake()
            {
                UnityEngine.Object.DontDestroyOnLoad(this);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("TurtleMembers loaded !");
            }

            // Token: 0x06000AE9 RID: 2793 RVA: 0x00003D42 File Offset: 0x00001F42
            private IEnumerator Check()
            {
                yield return new WaitForSeconds(10f);
                PlayerUtils.inWorld();
                foreach (Player player in PlayerManager.GetAllPlayers())
                {
                    try
                    {
                        APIUser user = player.HGLCOLNAJJJ;
                        if (VRCPlayer.AreNameplatesVisible() && (player.GetAPIUser().id == "usr_5d6d5cdb-5ad3-4452-81ac-831573e30c0a" || player.GetAPIUser().id == "usr_f5986dff-c03d-435d-a83d-d19369782b61" || player.GetAPIUser().id == "usr_46cadc1c-4d14-4403-ad75-24e39e6580f1" || player.GetAPIUser().id == "thenew"))
                        {
                            player.vrcPlayer.SetNamePlateColor(UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                            UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                        player.vrcPlayer.namePlate.mainText.text = "<color=green>TurtleGangMember</color><color=white>" + user.displayName + "</color>";
                            //player.vrcPlayer.playerSelector.transform.
                        }
                    }
                    catch
                    {
                    }
                }
                yield break;
            }

            // Token: 0x06000AEA RID: 2794 RVA: 0x00003D4A File Offset: 0x00001F4A
            public void Update()
            {
                base.StartCoroutine(this.Check());
            }
        }
    }

