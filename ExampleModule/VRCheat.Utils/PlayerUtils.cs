using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using VRC;
using VRC.Core;

namespace VRCClient.VRCheat.Utils
{
    // Token: 0x020001D3 RID: 467
    internal static class PlayerUtils
    {
        // Token: 0x06000A82 RID: 2690 RVA: 0x00018270 File Offset: 0x00016470
        static PlayerUtils()
        {
            try
            {
                PropertyInfo propertyInfo = typeof(VRCPlayer).GetProperties().First((PropertyInfo p) => p.GetGetMethod().Name == "get_player");
                PlayerUtils.getPlayerMethod = ((propertyInfo != null) ? propertyInfo.GetGetMethod() : null);
                PlayerUtils.photonPlayerType = typeof(Player).GetProperties().First((PropertyInfo p) => p.GetGetMethod().Name == "get_PhotonPlayer").PropertyType;
                PropertyInfo propertyInfo2 = typeof(Player).GetProperties().First((PropertyInfo p) => p.GetGetMethod().Name == "get_isModerator");
                PlayerUtils.isModeratorMethod = ((propertyInfo2 != null) ? propertyInfo2.GetGetMethod() : null);
                PlayerUtils.cSharp = typeof(VRCApplicationSetup).Assembly;
                PlayerUtils.UserType = PlayerUtils.cSharp.GetTypes().First((Type t) => t.BaseType == typeof(APIUser));
                PropertyInfo propertyInfo3 = PlayerUtils.UserType.GetProperties().First((PropertyInfo p) => p.PropertyType == PlayerUtils.UserType);
                PlayerUtils.currentUserMethod = ((propertyInfo3 != null) ? propertyInfo3.GetGetMethod() : null);
                PropertyInfo propertyInfo4 = typeof(Player).GetProperties().First((PropertyInfo p) => p.PropertyType == typeof(APIUser));
                PlayerUtils.getApiUserMethod = ((propertyInfo4 != null) ? propertyInfo4.GetGetMethod() : null);
                PropertyInfo propertyInfo5 = typeof(Player).GetProperties().First((PropertyInfo p) => p.PropertyType == PlayerUtils.photonPlayerType);
                PlayerUtils.getPhotonPlayerMethod = ((propertyInfo5 != null) ? propertyInfo5.GetGetMethod() : null);
                PlayerUtils.getAvatarManagerMethod = typeof(VRCPlayer).GetProperties().First((PropertyInfo p) => p.PropertyType == typeof(VRCAvatarManager)).GetGetMethod();
                PlayerUtils.getApiAvatarMethod = typeof(VRCAvatarManager).GetProperties().First((PropertyInfo p) => p.PropertyType == typeof(ApiAvatar)).GetGetMethod();
                PlayerUtils.getSteamID = typeof(VRCPlayer).GetProperties().First((PropertyInfo p) => p.PropertyType == typeof(ulong)).GetGetMethod();
            }
            catch
            {
                Console.WriteLine("Error loading player types, fields, and methods.\n");
            }
        }

        // Token: 0x06000A83 RID: 2691 RVA: 0x000184AC File Offset: 0x000166AC
        private static object GetPhotonPlayer(this Player player)
        {
            return PlayerUtils.getPhotonPlayerMethod.Invoke(player, null);
        }

        // Token: 0x06000A84 RID: 2692 RVA: 0x000184CC File Offset: 0x000166CC
        public static bool inWorld()
        {
            return RoomManagerBase.FJLBHBJICFI;
        }

        // Token: 0x06000A85 RID: 2693 RVA: 0x000184E4 File Offset: 0x000166E4
        public static Player GetCurrentUser()
        {
            return VRCPlayer.Instance.gameObject.GetComponent<Player>();
        }

        // Token: 0x06000A86 RID: 2694 RVA: 0x00018508 File Offset: 0x00016708
        public static ulong GetSteamID(this VRCPlayer player)
        {
            return (ulong)PlayerUtils.getSteamID.Invoke(player, null);
        }

        // Token: 0x06000A87 RID: 2695 RVA: 0x0001852C File Offset: 0x0001672C
        public static VRCAvatarManager GetVRCAvatarManager(this VRCPlayer player)
        {
            return PlayerUtils.getAvatarManagerMethod.Invoke(player, null) as VRCAvatarManager;
        }

        // Token: 0x06000A88 RID: 2696 RVA: 0x00018550 File Offset: 0x00016750
        public static ApiAvatar GetApiAvatar(this VRCAvatarManager avatarManager)
        {
            return PlayerUtils.getApiAvatarMethod.Invoke(avatarManager, null) as ApiAvatar;
        }

        // Token: 0x06000A89 RID: 2697 RVA: 0x00018574 File Offset: 0x00016774
        public static ApiAvatar GetApiAvatar(this VRCPlayer player)
        {
            return player.GetVRCAvatarManager().GetApiAvatar();
        }

        // Token: 0x06000A8A RID: 2698 RVA: 0x00018594 File Offset: 0x00016794
        public static ApiAvatar GetApiAvatar(this Player player)
        {
            return player.vrcPlayer.GetApiAvatar();
        }

        // Token: 0x06000A8B RID: 2699 RVA: 0x000185B4 File Offset: 0x000167B4
        public static APIUser GetAPIUser(this Player player)
        {
            return (APIUser)PlayerUtils.getApiUserMethod.Invoke(player, null);
        }

        // Token: 0x06000A8C RID: 2700 RVA: 0x000185D8 File Offset: 0x000167D8
        public static bool IsModerator(this Player player)
        {
            return (bool)PlayerUtils.isModeratorMethod.Invoke(player, null);
        }

        // Token: 0x06000A8D RID: 2701 RVA: 0x00003A2F File Offset: 0x00001C2F
        public static void TeleportTo(Player targetPlayer)
        {
            PlayerUtils.TeleportTo(targetPlayer.vrcPlayer);
        }

        // Token: 0x06000A8E RID: 2702 RVA: 0x00003A3E File Offset: 0x00001C3E
        public static void TeleportTo(VRCPlayer targetPlayer)
        {
            PlayerUtils.Teleport(PlayerManager.GetCurrentPlayer().vrcPlayer, targetPlayer);
        }

        // Token: 0x06000A8F RID: 2703 RVA: 0x00003A52 File Offset: 0x00001C52
        public static void Teleport(Player player, Player targetPlayer)
        {
            PlayerUtils.Teleport(player.vrcPlayer, player.vrcPlayer);
        }

        // Token: 0x06000A90 RID: 2704 RVA: 0x00003A67 File Offset: 0x00001C67
        public static void Teleport(VRCPlayer player, VRCPlayer targetPlayer)
        {
            PlayerUtils.TeleportTransform(player.transform, targetPlayer.transform);
        }

        // Token: 0x06000A91 RID: 2705 RVA: 0x000185FC File Offset: 0x000167FC
        public static Player FindPlayer(string search)
        {
            search = search.ToLower();
            return PlayerManager.GetAllPlayers().FirstOrDefault((Player p) => p.GetAPIUser().displayName.ToLower().Contains(search));
        }

        // Token: 0x06000A92 RID: 2706 RVA: 0x00003A7C File Offset: 0x00001C7C
        private static void TeleportTransform(Transform from, Transform to)
        {
            from.position = to.position;
            from.rotation = to.rotation;
        }

        // Token: 0x04000957 RID: 2391
        public static Type UserType;

        // Token: 0x04000958 RID: 2392
        private static Assembly cSharp;

        // Token: 0x04000959 RID: 2393
        private static Type photonPlayerType;

        // Token: 0x0400095A RID: 2394
        private static MethodInfo getPlayerMethod;

        // Token: 0x0400095B RID: 2395
        private static MethodInfo isModeratorMethod;

        // Token: 0x0400095C RID: 2396
        private static MethodInfo currentUserMethod;

        // Token: 0x0400095D RID: 2397
        private static MethodInfo getApiUserMethod;

        // Token: 0x0400095E RID: 2398
        private static MethodInfo getPhotonPlayerMethod;

        // Token: 0x0400095F RID: 2399
        private static MethodInfo getAvatarManagerMethod;

        // Token: 0x04000960 RID: 2400
        private static MethodInfo getApiAvatarMethod;

        // Token: 0x04000961 RID: 2401
        private static MethodInfo getSteamID;

        // Token: 0x020001D4 RID: 468
        public class Reflection
        {
            // Token: 0x06000A93 RID: 2707 RVA: 0x00018644 File Offset: 0x00016844
            internal static bool isInRoom()
            {
                return (bool)PlayerUtils.Reflection.IsInRoom.Invoke(null, null);
            }

            // Token: 0x04000962 RID: 2402
            internal static MethodInfo IsInRoom = typeof(RoomManagerBase).GetProperties(BindingFlags.Static | BindingFlags.Public).First((PropertyInfo p) => p.GetGetMethod().Name == "get_inRoom").GetGetMethod();
        }
    }
}
