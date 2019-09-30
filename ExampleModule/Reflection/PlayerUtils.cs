
using System;
using System.Linq;
using System.Reflection;
using VRC;
using VRC.Core;
using VRCClient.VRCheat.Utils;

namespace VRCClient.Reflection
{
    // Token: 0x02000003 RID: 3
    public static class PlayerUtils
    {
        // Token: 0x06000006 RID: 6 RVA: 0x00002764 File Offset: 0x00000964
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
                PropertyInfo propertyInfo6 = typeof(VRCPlayer).GetProperties(BindingFlags.Instance | BindingFlags.Public).First((PropertyInfo p) => p.GetGetMethod().Name == "get_Ping");
                PlayerUtils.getPing = ((propertyInfo6 != null) ? propertyInfo6.GetGetMethod() : null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading player types, fields, and methods.\n {0}", ex.ToString());
            }
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002071 File Offset: 0x00000271
        public static object GetCurrentUser()
        {
            return PlayerUtils.currentUserMethod.Invoke(null, null);
        }

        // Token: 0x06000008 RID: 8 RVA: 0x0000207F File Offset: 0x0000027F
        public static VRCAvatarManager GetVRCAvatarManager(this VRCPlayer player)
        {
            return PlayerUtils.getAvatarManagerMethod.Invoke(player, null) as VRCAvatarManager;
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002092 File Offset: 0x00000292
        public static ApiAvatar GetApiAvatar(this VRCAvatarManager avatarManager)
        {
            return PlayerUtils.getApiAvatarMethod.Invoke(avatarManager, null) as ApiAvatar;
        }

  

        // Token: 0x0600000C RID: 12 RVA: 0x000020BF File Offset: 0x000002BF
        public static APIUser GetAPIUser(this Player player)
        {
            return (APIUser)PlayerUtils.getApiUserMethod.Invoke(player, null);
        }

        // Token: 0x0600000D RID: 13 RVA: 0x000020D2 File Offset: 0x000002D2
        public static bool IsModerator(this Player player)
        {
            return (bool)PlayerUtils.isModeratorMethod.Invoke(player, null);
        }

        // Token: 0x0600000E RID: 14 RVA: 0x000020E5 File Offset: 0x000002E5
        public static ulong GetSteamID(this VRCPlayer player)
        {
            return (ulong)PlayerUtils.getSteamID.Invoke(player, null);
        }

        // Token: 0x06000AE2 RID: 2786 RVA: 0x00019750 File Offset: 0x00017950
        public static ulong GetSteamID(this Player player)
        {
            return player.vrcPlayer.GetSteamID();
        }

        // Token: 0x06000AE4 RID: 2788 RVA: 0x00019794 File Offset: 0x00017994
        public static ApiAvatar GetApiAvatar(this Player player)
        {
            return player.vrcPlayer.GetApiAvatar();
        }

        // Token: 0x06000010 RID: 16 RVA: 0x00002105 File Offset: 0x00000305
        public static short GetPing(VRCPlayer vrcPlayer)
        {
            return (short)PlayerUtils.getPing.Invoke(vrcPlayer, null);
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00002118 File Offset: 0x00000318
        public static int GetPhotonID(this object photonPlayer)
        {
            return (int)photonPlayer.GetType().GetProperties().First((PropertyInfo x) => x.PropertyType == typeof(int)).GetValue(photonPlayer, null);
        }

        // Token: 0x06000012 RID: 18 RVA: 0x00002155 File Offset: 0x00000355
        public static object GetPhotonPlayer(this Player input)
        {
            return typeof(Player).GetMethod("get_PhotonPlayer").Invoke(input, null);
        }

        // Token: 0x06000013 RID: 19 RVA: 0x000029D0 File Offset: 0x00000BD0
        internal static bool IsInRoom()
        {
            return (bool)typeof(RoomManagerBase).GetProperties(BindingFlags.Static | BindingFlags.Public).First((PropertyInfo p) => p.GetGetMethod().Name == "get_inRoom").GetGetMethod().Invoke(null, null);
        }

        // Token: 0x04000002 RID: 2
        public static Type UserType;

        // Token: 0x04000003 RID: 3
        private static Assembly cSharp;

        // Token: 0x04000004 RID: 4
        private static Type photonPlayerType;

        // Token: 0x04000005 RID: 5
        private static readonly MethodInfo getPlayerMethod;

        // Token: 0x04000006 RID: 6
        private static MethodInfo isModeratorMethod;

        // Token: 0x04000007 RID: 7
        private static MethodInfo currentUserMethod;

        // Token: 0x04000008 RID: 8
        private static MethodInfo getApiUserMethod;

        // Token: 0x04000009 RID: 9
        private static readonly MethodInfo getPhotonPlayerMethod;

        // Token: 0x0400000A RID: 10
        private static MethodInfo getAvatarManagerMethod;

        // Token: 0x0400000B RID: 11
        private static MethodInfo getApiAvatarMethod;

        // Token: 0x0400000C RID: 12
        private static MethodInfo getSteamID;

        // Token: 0x0400000D RID: 13
        private static MethodInfo getPing;
    }
}
