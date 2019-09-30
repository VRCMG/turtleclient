using System.Collections.Generic;
using VRLoader.Attributes;
using VRLoader.Modules;
using VRCModLoader;
using Harmony;
using System.Reflection;
using ExitGames.Client.Photon;
using System;

namespace turtleclient.Fixs
{
    public class AntiIpGrabber : VRModule
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public void OnApplicationStart()
        {
            Console.WriteLine("[Loading] Applying patches...");
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("slaynash.steamspoofer");
            MethodInfo method = typeof(PhotonPeer).Assembly.GetType("ExitGames.Client.Photon.EnetPeer").GetMethod("EnqueueOperation", (BindingFlags)(-1));
            harmonyInstance.Patch(method, new HarmonyMethod(typeof(AntiIpGrabber).GetMethod("EnqueueOperationPrefix", BindingFlags.Static | BindingFlags.NonPublic)), null, null);
           
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000020C4 File Offset: 0x000002C4
        public static void EnqueueOperationPrefix(Dictionary<byte, object> __0, byte __1)
        {
            if (__1 == 252)
            {
                maskProperties(__0, 251);
                return;
            }
            if (__1 == 226)
            {
                maskProperties(__0, 249);
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x000020F0 File Offset: 0x000002F0
        public static void maskProperties(Dictionary<byte, object> param, byte propertyIndex)
        {
            try
            {
                Hashtable hashtable = (Hashtable)param[propertyIndex];
                if (hashtable.ContainsKey("steamUserID"))
                {
                    hashtable["steamUserID"] = "0";
                }
            }
            catch
            {
            }
        }
    }
}
