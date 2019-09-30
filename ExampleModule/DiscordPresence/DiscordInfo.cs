using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using VRC;
using VRC.Core;

namespace turtleclient.DiscordPresence
{
    // Token: 0x02000242 RID: 578
    public class DiscordInfo
    {
        // Token: 0x06000C5A RID: 3162 RVA: 0x0001FF10 File Offset: 0x0001E110
        public static void Start()
        {
            DiscordRich.EventHandlers eventHandlers = default(DiscordRich.EventHandlers);
            new Thread(delegate ()
            {
                //change le 457563383340859403 par le new rich presence
                DiscordRich.Initialize("457563383340859403", ref eventHandlers, false, string.Empty);
                for (; ; )
                {
                    DiscordInfo.OnThisUpdate();
                    Thread.Sleep(5000);
                }
            })
            {
                //le nom du rich je supose ?
                Name = "DiscordRich Thread",
                IsBackground = true
            }.Start();
        }

        // Token: 0x06000C5B RID: 3163 RVA: 0x0001FF5C File Offset: 0x0001E15C
        public static void OnThisUpdate()
        {
            bool flag = RoomManagerBase.currentRoom != null;
            if (flag)
            {
                ApiWorld currentRoom = RoomManagerBase.currentRoom;
                DiscordInfo.thisScene = default(Scene);
                bool flag2 = DiscordInfo.currentWorld != currentRoom;
                if (flag2)
                {
                    DiscordInfo.currentWorld = RoomManagerBase.currentRoom;
                    ApiWorldInstance currentWorldInstance = RoomManagerBase.currentWorldInstance;
                    ApiWorldInstance.AccessType accessType = currentWorldInstance.GetAccessType();
                    int count = currentWorldInstance.users.Count;
                    bool flag3 = accessType == ApiWorldInstance.AccessType.Public;
                    if (flag3)
                    {       //info 1
                        DiscordInfo.ResetTime();
                        DiscordInfo.Presence.details = DiscordInfo.GetWorldName();
                        DiscordInfo.Presence.state = "In a " + DiscordInfo.GetWorldInstanceType(accessType) + " Lobby";
                        DiscordInfo.Presence.startTimestamp = DiscordInfo.timestamp;
                        DiscordInfo.Presence.largeImageKey = "default_logo";
                        DiscordInfo.Presence.largeImageText = "VRChat";
                        DiscordInfo.Presence.smallImageKey = "public_img";
                        DiscordInfo.Presence.smallImageText = "Using TurtleGangClient";
                        DiscordInfo.PlayerCount();
                        DiscordRich.UpdatePresence(DiscordInfo.Presence);
                        return;
                    }
                    bool flag4 = accessType == ApiWorldInstance.AccessType.InvitePlus;
                    if (flag4)
                    {       //info 2
                        DiscordInfo.ResetTime();
                        DiscordInfo.Presence.details = DiscordInfo.GetWorldName();
                        DiscordInfo.Presence.state = "In a " + DiscordInfo.GetWorldInstanceType(accessType) + " Lobby";
                        DiscordInfo.Presence.startTimestamp = DiscordInfo.timestamp;
                        DiscordInfo.Presence.largeImageKey = "default_logo";
                        DiscordInfo.Presence.largeImageText = "VRChat";
                        DiscordInfo.Presence.smallImageKey = "inviteplus_img";
                        DiscordInfo.Presence.smallImageText = "Using TurtleGangClient";
                        DiscordInfo.PlayerCount();
                        DiscordRich.UpdatePresence(DiscordInfo.Presence);
                        return;
                    }
                    bool flag5 = accessType == ApiWorldInstance.AccessType.InviteOnly;
                    if (flag5)
                    {       //info 3
                        DiscordInfo.ResetTime();
                        DiscordInfo.Presence.details = DiscordInfo.GetWorldName();
                        DiscordInfo.Presence.state = "In a " + DiscordInfo.GetWorldInstanceType(accessType) + " Lobby";
                        DiscordInfo.Presence.startTimestamp = DiscordInfo.timestamp;
                        DiscordInfo.Presence.largeImageKey = "default_logo";
                        DiscordInfo.Presence.largeImageText = "VRChat";
                        DiscordInfo.Presence.smallImageKey = "inviteonly_img";
                        DiscordInfo.Presence.smallImageText = "Using TurtleGangClient";
                        DiscordInfo.PlayerCount();
                        DiscordRich.UpdatePresence(DiscordInfo.Presence);
                        return;
                    }
                    bool flag6 = accessType == ApiWorldInstance.AccessType.FriendsOfGuests;
                    if (flag6)
                    {       //info 4
                        DiscordInfo.ResetTime();
                        DiscordInfo.Presence.details = DiscordInfo.GetWorldName();
                        DiscordInfo.Presence.state = "In a " + DiscordInfo.GetWorldInstanceType(accessType) + " Lobby";
                        DiscordInfo.Presence.startTimestamp = DiscordInfo.timestamp;
                        DiscordInfo.Presence.largeImageKey = "default_logo";
                        DiscordInfo.Presence.largeImageText = "VRChat";
                        DiscordInfo.Presence.smallImageKey = "friendofguests_img";
                        DiscordInfo.Presence.smallImageText = "Using TurtleGangClient";
                        DiscordInfo.PlayerCount();
                        DiscordRich.UpdatePresence(DiscordInfo.Presence);
                        return;
                    }
                    bool flag7 = accessType == ApiWorldInstance.AccessType.FriendsOnly;
                    if (flag7)
                    {       //info 5
                        DiscordInfo.ResetTime();
                        DiscordInfo.Presence.details = DiscordInfo.GetWorldName();
                        DiscordInfo.Presence.state = "In a " + DiscordInfo.GetWorldInstanceType(accessType) + " Lobby";
                        DiscordInfo.Presence.startTimestamp = DiscordInfo.timestamp;
                        DiscordInfo.Presence.largeImageKey = "default_logo";
                        DiscordInfo.Presence.largeImageText = "VRChat";
                        DiscordInfo.Presence.smallImageKey = "friendsonly_img";
                        DiscordInfo.Presence.smallImageText = "Using TurtleGangClient";
                        DiscordInfo.PlayerCount();
                        DiscordRich.UpdatePresence(DiscordInfo.Presence);
                        return;
                    }
                    bool flag8 = accessType == ApiWorldInstance.AccessType.Counter;
                    if (flag8)
                    {       //info 6
                        DiscordInfo.ResetTime();
                        DiscordInfo.Presence.details = DiscordInfo.GetWorldName();
                        DiscordInfo.Presence.state = "In a " + DiscordInfo.GetWorldInstanceType(accessType) + " Lobby";
                        DiscordInfo.Presence.startTimestamp = DiscordInfo.timestamp;
                        DiscordInfo.Presence.largeImageKey = "default_logo";
                        DiscordInfo.Presence.largeImageText = "VRChat";
                        DiscordInfo.Presence.smallImageKey = "counter_img";
                        DiscordInfo.Presence.smallImageText = "Using TurtleGangClient";
                        DiscordInfo.PlayerCount();
                        DiscordRich.UpdatePresence(DiscordInfo.Presence);
                        return;
                    }
                }
                bool flag9 = DiscordInfo.currentWorld != null;
                if (flag9)
                { //nb de gens la room ?
                    DiscordInfo.Presence.partySize = PlayerManager.GetAllPlayers().Length;
                    DiscordInfo.Presence.partyMax = DiscordInfo.currentWorld.capacity;
                    DiscordRich.UpdatePresence(DiscordInfo.Presence);
                }
                else
                { //idk
                    DiscordInfo.Presence.partySize = 0;
                    DiscordInfo.Presence.partyMax = 0;
                    DiscordRich.UpdatePresence(DiscordInfo.Presence);
                }
            }
            else
            {
                Scene activeScene = SceneManager.GetActiveScene();
                bool flag10 = DiscordInfo.thisScene != activeScene;
                if (flag10)
                {
                    DiscordInfo.thisScene = activeScene;
                    Scene scene = DiscordInfo.thisScene; //nom de scene idk ?
                    bool flag11 = DiscordInfo.thisScene.name == "ui";
                    if (flag11)
                    {
                        //info 7
                        DiscordInfo.ResetTime();
                        DiscordInfo.Presence.details = "In Loading Screen";
                        DiscordInfo.Presence.state = string.Empty;
                        DiscordInfo.Presence.startTimestamp = DiscordInfo.timestamp;
                        DiscordInfo.Presence.partySize = 0;
                        DiscordInfo.Presence.partyMax = 0;
                        DiscordInfo.Presence.largeImageKey = "default_logo";
                        DiscordInfo.Presence.largeImageText = "VRChat";
                        DiscordInfo.Presence.smallImageKey = "loading_img";
                        DiscordInfo.Presence.smallImageText = "Using TurtleGangClient";
                        DiscordRich.UpdatePresence(DiscordInfo.Presence);
                        return;
                    }
                }
            }
            DiscordRich.RunCallbacks();
        }

        // Token: 0x06000C5C RID: 3164 RVA: 0x0000475D File Offset: 0x0000295D
        public static void PlayerCount()
        { //players dans la room
            DiscordInfo.Presence.partySize = PlayerManager.GetAllPlayers().Length;
            DiscordInfo.Presence.partyMax = DiscordInfo.currentWorld.capacity;
        }

        // Token: 0x06000C5D RID: 3165 RVA: 0x00004785 File Offset: 0x00002985
        public static void ResetTime()
        { // reset le temps dans la room
            DiscordInfo.time = DateTime.UtcNow - new DateTime(1970, 1, 1);
            DiscordInfo.timestamp = (long)DiscordInfo.time.TotalSeconds;
        }

        // Token: 0x06000C5E RID: 3166 RVA: 0x000047B3 File Offset: 0x000029B3
        public void OnDestroy()
        { //disable le rich si quitte le jeu
            DiscordRich.Shutdown();
        }

        // Token: 0x06000C5F RID: 3167 RVA: 0x000204F4 File Offset: 0x0001E6F4
        public static string GetWorldInstanceType(ApiWorldInstance.AccessType accessType)
        {
            string result;
            switch (accessType)
            {  //les info de room
                case ApiWorldInstance.AccessType.Public:
                    result = "Public";
                    break;
                case ApiWorldInstance.AccessType.FriendsOfGuests:
                    result = "Friends of Guests";
                    break;
                case ApiWorldInstance.AccessType.FriendsOnly:
                    result = "Friends Only";
                    break;
                case ApiWorldInstance.AccessType.InviteOnly:
                    result = "Invite Only";
                    break;
                case ApiWorldInstance.AccessType.InvitePlus:
                    result = "Invite+";
                    break;
                case ApiWorldInstance.AccessType.Counter:
                    result = "Counter";
                    break;
                default:
                    result = "none";
                    break;
            }
            return result;
        }

        // Token: 0x06000C60 RID: 3168 RVA: 0x00020560 File Offset: 0x0001E760
        public static string GetWorldName()
        { //nom de la map
            return RoomManagerBase.currentRoom.name;
        }

        // Token: 0x04000A38 RID: 2616
        public static readonly DiscordRich.RichPresence Presence = new DiscordRich.RichPresence();

        // Token: 0x04000A39 RID: 2617
        public static ApiWorld currentWorld;

        // Token: 0x04000A3A RID: 2618
        public static Scene thisScene;

        // Token: 0x04000A3B RID: 2619
        public static TimeSpan time = DateTime.UtcNow - new DateTime(1970, 1, 1);

        // Token: 0x04000A3C RID: 2620
        public static long timestamp = (long)DiscordInfo.time.TotalSeconds;
    }
}
