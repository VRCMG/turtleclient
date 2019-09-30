using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using VRC;
using VRC.Core;
using VRCClient.Reflection;

namespace turtleclient.LogPlayerInfoVR
{
    // Token: 0x020001DC RID: 476
    public class LogPlayerInfoVR : MonoBehaviour
    {
        // Token: 0x06000ACB RID: 2763 RVA: 0x00019174 File Offset: 0x00017374
        public void Start()
        {
            this.userInteractGO = GameObject.Find("/UserInterface/QuickMenu/UserInteractMenu");
            this.userInteract = this.userInteractGO.GetComponent<UserInteractMenu>();
            this.TakePlayersInfotoggles = this.userInteractGO.transform.Find("TakePlayerInfo").gameObject;
            this.NewCloneAvatarButton = UnityEngine.Object.Instantiate<GameObject>(this.TakePlayersInfotoggles, this.userInteractGO.transform);
            this.TakePlayersInfotoggles.transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("TakePlayerLog loaded.");
            Console.ResetColor();
        }

        // Token: 0x06000ACC RID: 2764 RVA: 0x00019218 File Offset: 0x00017418
        public void Update()
        {
            if (userInteractGO.active)
            {
                Player allPlayers = PlayerManager.GetCurrentPlayer();
                    Player x = allPlayers;
                    if (x.GetAPIUser().id != APIUser.CurrentUser.id && APIUserIDCache.FirstOrDefault((string c) => c == x.GetAPIUser().id) == null)
                    {
                        APIUserIDCache.Add(x.GetAPIUser().id);
                        ApiAvatar apiAvatar = x.GetApiAvatar();
                        if (!this.avatarcache.Contains(x.GetAPIUser().id + " - " + apiAvatar.id))
                        {
                            this.avatarcache = this.avatarcache + x.GetAPIUser().id + " - " + apiAvatar.id;
                            File.AppendAllText("AvatarLogger.txt", string.Concat(new object[]
                            {
                            x.GetAPIUser().id,
                            " - ",
                            apiAvatar.id,
                            Environment.NewLine,
                            "Player Name: ",
                            x.GetAPIUser().displayName,
                            Environment.NewLine,
                            "Avatar ID: ",
                            apiAvatar.id,
                            Environment.NewLine,
                            "Avatar Name: ",
                            apiAvatar.name,
                            Environment.NewLine,
                            "Author ID: ",
                            apiAvatar.authorId,
                            Environment.NewLine,
                            "Asset URL: ",
                            apiAvatar.assetUrl,
                            Environment.NewLine,
                            "Release Status: ",
                            apiAvatar.releaseStatus,
                            Environment.NewLine,
                            "version: ",
                            apiAvatar.version,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine,
                            Environment.NewLine
                            }));
                        }
                        if (!this.playercache.Contains(x.GetAPIUser().id))
                        {
                            this.playercache += x.GetAPIUser().id;
                            File.AppendAllText("PlayerLog.txt", string.Concat(new object[]
                            {
                            Environment.NewLine,
                            "PlayerName: ",
                            x.name,
                            Environment.NewLine,
                            "UserID: ",
                            x.GetAPIUser().id,
                            Environment.NewLine,
                            "SteamUserID: ",
                            x.GetSteamID().ToString(),
                            Environment.NewLine,
                            Environment.NewLine
                            }));
                        }
                    
                }
            }
        }

        // Token: 0x0400097E RID: 2430
        public string currentUserID;

        // Token: 0x0400097F RID: 2431
        public UserInteractMenu InteractMenu;

        // Token: 0x04000980 RID: 2432
        private GameObject userInteractGO;

        // Token: 0x04000981 RID: 2433
        private GameObject TakePlayersInfotoggles;

        // Token: 0x04000982 RID: 2434
        private GameObject NewCloneAvatarButton;

        // Token: 0x04000983 RID: 2435
        private UserInteractMenu userInteract;

        // Token: 0x04000916 RID: 2326
        private static List<string> DebugLogs = new List<string>();

        // Token: 0x04000917 RID: 2327
        private static List<string> APIUserIDCache = new List<string>();

        // Token: 0x04000918 RID: 2328
        private static List<string> IPLogCache = new List<string>();

        // Token: 0x04000919 RID: 2329
        private string avatarcache;

        // Token: 0x0400091A RID: 2330
        private string playercache;

    }
}
