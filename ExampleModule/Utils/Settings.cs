
using System;
using System.IO;
using UnityEngine;
using VRC;

namespace VRCClient.Utils
{
    // Token: 0x02000008 RID: 8
    public class Settings
    {
        // Token: 0x0600003D RID: 61 RVA: 0x00002E88 File Offset: 0x00001088
        public static void SaveConfig()
        {
            if (File.Exists(Settings.FILE_NAME))
            {
                File.Delete(Settings.FILE_NAME);
            }
            using (StreamWriter streamWriter = File.CreateText(Settings.FILE_NAME))
            {
                streamWriter.WriteLine(Settings.runSpeed);
                streamWriter.WriteLine(Settings.walkSpeed);
                streamWriter.WriteLine(Settings.strafeSpeed);
                streamWriter.WriteLine(Settings.worldStr);
                streamWriter.WriteLine(USpeaker.LocalGain);
                streamWriter.WriteLine(Settings.r);
                streamWriter.WriteLine(Settings.g);
                streamWriter.WriteLine(Settings.b);
                streamWriter.WriteLine(Settings.a);
                streamWriter.WriteLine(Settings.portalX);
                streamWriter.WriteLine(Settings.portalY);
            }
        }

        // Token: 0x0600003E RID: 62 RVA: 0x00002F4C File Offset: 0x0000114C
        public static void LoadConfig()
        {
            if (File.Exists(Settings.FILE_NAME))
            {
                StreamReader streamReader = new StreamReader(Settings.FILE_NAME);
                string value = streamReader.ReadLine();
                string value2 = streamReader.ReadLine();
                string value3 = streamReader.ReadLine();
                string text = streamReader.ReadLine();
                string value4 = streamReader.ReadLine();
                string s = streamReader.ReadLine();
                string s2 = streamReader.ReadLine();
                string s3 = streamReader.ReadLine();
                string s4 = streamReader.ReadLine();
                string value5 = streamReader.ReadLine();
                string value6 = streamReader.ReadLine();
                string value7 = streamReader.ReadLine();
                string value8 = streamReader.ReadLine();
                string value9 = streamReader.ReadLine();
                string value10 = streamReader.ReadLine();
                string value11 = streamReader.ReadLine();
                string value12 = streamReader.ReadLine();
                string value13 = streamReader.ReadLine();
                string value14 = streamReader.ReadLine();
                string value15 = streamReader.ReadLine();
                string value16 = streamReader.ReadLine();
                string value17 = streamReader.ReadLine();
                string value18 = streamReader.ReadLine();
                string value19 = streamReader.ReadLine();
                string value20 = streamReader.ReadLine();
                string value21 = streamReader.ReadLine();
                string value22 = streamReader.ReadLine();
                string value23 = streamReader.ReadLine();
                string value24 = streamReader.ReadLine();
                string value25 = streamReader.ReadLine();
                string value26 = streamReader.ReadLine();
                Settings.runSpeed = Convert.ToSingle(value);
                Settings.walkSpeed = Convert.ToSingle(value2);
                Settings.strafeSpeed = Convert.ToSingle(value3);
                USpeaker.LocalGain = Convert.ToSingle(value4);
                Settings.worldStr = text;
                Settings.r = int.Parse(s);
                Settings.g = int.Parse(s2);
                Settings.b = int.Parse(s3);
                Settings.a = int.Parse(s4);
                Settings.portalX = Convert.ToSingle(value5);
                Settings.portalY = Convert.ToSingle(value6);
                Settings.MainWindowX = Convert.ToSingle(value7);
                Settings.MainWindowY = Convert.ToSingle(value8);
                Settings.VisualWindowX = Convert.ToSingle(value9);
                Settings.VisualWindowY = Convert.ToSingle(value10);
                Settings.ConfigWindowX = Convert.ToSingle(value11);
                Settings.ConfigWindowY = Convert.ToSingle(value12);
                Settings.MovementWindowX = Convert.ToSingle(value13);
                Settings.MovementWindowY = Convert.ToSingle(value14);
                Settings.LogWindowX = Convert.ToSingle(value15);
                Settings.LogWindowY = Convert.ToSingle(value16);
                Settings.MiscWindowX = Convert.ToSingle(value17);
                Settings.MiscWindowY = Convert.ToSingle(value18);
                Settings.DebuggerWindowX = Convert.ToSingle(value19);
                Settings.DebuggerWindowY = Convert.ToSingle(value20);
                Settings.SpawnMenuWindowX = Convert.ToSingle(value21);
                Settings.SpawnMenuWindowY = Convert.ToSingle(value22);
                Settings.PlayerMenuWindowX = Convert.ToSingle(value23);
                Settings.PlayerMenuWindowY = Convert.ToSingle(value24);
                Settings.ExploitMenuWindowX = Convert.ToSingle(value25);
                Settings.ExploitMenuWindowY = Convert.ToSingle(value26);
                streamReader.Close();
            }
        }

        // Token: 0x0600003F RID: 63 RVA: 0x00002367 File Offset: 0x00000567
        public static void SetRectXY(Rect g, float x, float y)
        {
            g.Set(x, y, g.width, g.height);
        }

        // Token: 0x04000015 RID: 21
        public static bool debugClient = true;

        // Token: 0x04000016 RID: 22
        public static bool premiumClient = true;

        // Token: 0x04000017 RID: 23
        public static Player target;

        // Token: 0x04000018 RID: 24
        public static bool isEarrapeMicEnabled = false;

        // Token: 0x04000019 RID: 25
        public static float flySpeed = 0.1f;

      

        // Token: 0x0400001A RID: 26
        public static float micVolume = 1f;

        // Token: 0x0400001B RID: 27
        public static float walkSpeed = 3f;

        // Token: 0x0400001C RID: 28
        public static float runSpeed = 4f;

        // Token: 0x0400001D RID: 29
        public static float strafeSpeed = 2f;

        // Token: 0x0400001E RID: 30
        public static float defWalkSpeed = 2f;

        // Token: 0x0400001F RID: 31
        public static float defRunSpeed = 4f;

        // Token: 0x04000020 RID: 32
        public static float defStrafeSpeed = 2f;

        // Token: 0x04000021 RID: 33
        public static float defTalkDistance = 20f;

        // Token: 0x04000022 RID: 34
        public static string worldStr = "wrld_496b11e8-25a0-4f35-976d-faae5e00d60e";

        // Token: 0x04000023 RID: 35
        private static readonly string FILE_NAME = "trash_config.txt";

        // Token: 0x04000024 RID: 36
        public static string foldername = "trash_logs";

        // Token: 0x04000025 RID: 37
        public static string foldernameObjExports = "trash_obj_exports";

        // Token: 0x04000026 RID: 38
        public static string foldernameFbxExports = "trash_fbx_exports";

        // Token: 0x04000027 RID: 39
        public static string foldernameDebug = "trash_debug_logs";

        // Token: 0x04000028 RID: 40
        public static int r = 250;

        // Token: 0x04000029 RID: 41
        public static int g = 0;

        // Token: 0x0400002A RID: 42
        public static int b = 0;

        // Token: 0x0400002B RID: 43
        public static int a = 255;

        // Token: 0x0400002C RID: 44
        public static float talkDistance = 250f;

        // Token: 0x0400002D RID: 45
        public static float portalX = 0f;

        // Token: 0x0400002E RID: 46
        public static float portalY = -1f;

        // Token: 0x0400002F RID: 47
        public static Player spawnSpamTarget;

        // Token: 0x04000030 RID: 48
        public static Player singleSpawnTarget;

        // Token: 0x04000031 RID: 49
        public static Player objectTeleportTarget;

        // Token: 0x04000032 RID: 50
        public static bool steamSpoof;

        // Token: 0x04000033 RID: 51
        public static ulong steamId;

        // Token: 0x04000034 RID: 52
        public static ulong realSteamId;

        // Token: 0x04000035 RID: 53
        public static ulong steamdIdSpoofed;

        // Token: 0x04000036 RID: 54
        public static bool deleteObjects;

        // Token: 0x04000037 RID: 55
        public static bool tapServer;

        // Token: 0x04000038 RID: 56
        public static int lagData = 1000;

        // Token: 0x04000039 RID: 57
        public static bool logIp = true;

        // Token: 0x0400003A RID: 58
        public static bool CanFly = false;

        // Token: 0x0400003B RID: 59
        public static bool portalBlock = false;

        // Token: 0x0400003C RID: 60
        public static string keyvaluestorage = "";

        // Token: 0x0400003D RID: 61
        public static string keyvaluePostUri = "";

        // Token: 0x0400003E RID: 62
        public static float MainWindowX = 20f;

        // Token: 0x0400003F RID: 63
        public static float MainWindowY = 60f;

        // Token: 0x04000040 RID: 64
        public static float VisualWindowX = 40f;

        // Token: 0x04000041 RID: 65
        public static float VisualWindowY = 60f;

        // Token: 0x04000042 RID: 66
        public static float ConfigWindowX = 60f;

        // Token: 0x04000043 RID: 67
        public static float ConfigWindowY = 60f;

        // Token: 0x04000044 RID: 68
        public static float MovementWindowX = 80f;

        // Token: 0x04000045 RID: 69
        public static float MovementWindowY = 60f;

        // Token: 0x04000046 RID: 70
        public static float LogWindowX = 100f;

        // Token: 0x04000047 RID: 71
        public static float LogWindowY = 60f;

        // Token: 0x04000048 RID: 72
        public static float MiscWindowX = 120f;

        // Token: 0x04000049 RID: 73
        public static float MiscWindowY = 60f;

        // Token: 0x0400004A RID: 74
        public static float DebuggerWindowX = 140f;

        // Token: 0x0400004B RID: 75
        public static float DebuggerWindowY = 60f;

        // Token: 0x0400004C RID: 76
        public static float SpawnMenuWindowX = 160f;

        // Token: 0x0400004D RID: 77
        public static float SpawnMenuWindowY = 60f;

        // Token: 0x0400004E RID: 78
        public static float PlayerMenuWindowX = 180f;

        // Token: 0x0400004F RID: 79
        public static float PlayerMenuWindowY = 60f;

        // Token: 0x04000050 RID: 80
        public static float ExploitMenuWindowX = 200f;

        // Token: 0x04000051 RID: 81
        public static float ExploitMenuWindowY = 60f;
    }
}
