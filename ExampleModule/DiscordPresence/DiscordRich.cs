using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace turtleclient.DiscordPresence
{
    // Token: 0x02000233 RID: 563
    public class DiscordRich
    {
        // Token: 0x06000C20 RID: 3104
        [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
    public static extern void Initialize(string applicationId, ref DiscordRich.EventHandlers handlers, bool autoRegister, string optionalSteamId);

    // Token: 0x06000C21 RID: 3105
    [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
    public static extern void Shutdown();

    // Token: 0x06000C22 RID: 3106
    [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
    public static extern void RunCallbacks();

    // Token: 0x06000C23 RID: 3107
    [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
    private static extern void UpdatePresenceNative(ref DiscordRich.RichPresenceStruct presence);

    // Token: 0x06000C24 RID: 3108
    [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_ClearPresence")]
    public static extern void ClearPresence();

    // Token: 0x06000C25 RID: 3109
    [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Respond")]
    public static extern void Respond(string userId, DiscordRich.Reply reply);

    // Token: 0x06000C26 RID: 3110
    [DllImport("discord-rpc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdateHandlers")]
    public static extern void UpdateHandlers(ref DiscordRich.EventHandlers handlers);

    // Token: 0x06000C27 RID: 3111 RVA: 0x0001F9D8 File Offset: 0x0001DBD8
    public static void UpdatePresence(DiscordRich.RichPresence presence)
    {
        DiscordRich.RichPresenceStruct @struct = presence.GetStruct();
        DiscordRich.UpdatePresenceNative(ref @struct);
        presence.FreeMem();
    }

    // Token: 0x02000234 RID: 564
    // (Invoke) Token: 0x06000C2A RID: 3114
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ReadyCallback(ref DiscordRich.DiscordUser connectedUser);

    // Token: 0x02000235 RID: 565
    // (Invoke) Token: 0x06000C2E RID: 3118
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisconnectedCallback(int errorCode, string message);

    // Token: 0x02000236 RID: 566
    // (Invoke) Token: 0x06000C32 RID: 3122
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ErrorCallback(int errorCode, string message);

    // Token: 0x02000237 RID: 567
    // (Invoke) Token: 0x06000C36 RID: 3126
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void JoinCallback(string secret);

    // Token: 0x02000238 RID: 568
    // (Invoke) Token: 0x06000C3A RID: 3130
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SpectateCallback(string secret);

    // Token: 0x02000239 RID: 569
    // (Invoke) Token: 0x06000C3E RID: 3134
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void RequestCallback(ref DiscordRich.DiscordUser request);

    // Token: 0x0200023A RID: 570
    public struct EventHandlers
    {
        // Token: 0x04000A02 RID: 2562
        public DiscordRich.ReadyCallback readyCallback;

        // Token: 0x04000A03 RID: 2563
        public DiscordRich.DisconnectedCallback disconnectedCallback;

        // Token: 0x04000A04 RID: 2564
        public DiscordRich.ErrorCallback errorCallback;

        // Token: 0x04000A05 RID: 2565
        public DiscordRich.JoinCallback joinCallback;

        // Token: 0x04000A06 RID: 2566
        public DiscordRich.SpectateCallback spectateCallback;

        // Token: 0x04000A07 RID: 2567
        public DiscordRich.RequestCallback requestCallback;
    }

    // Token: 0x0200023B RID: 571
    [Serializable]
    public struct RichPresenceStruct
    {
        // Token: 0x04000A08 RID: 2568
        public IntPtr state;

        // Token: 0x04000A09 RID: 2569
        public IntPtr details;

        // Token: 0x04000A0A RID: 2570
        public long startTimestamp;

        // Token: 0x04000A0B RID: 2571
        public long endTimestamp;

        // Token: 0x04000A0C RID: 2572
        public IntPtr largeImageKey;

        // Token: 0x04000A0D RID: 2573
        public IntPtr largeImageText;

        // Token: 0x04000A0E RID: 2574
        public IntPtr smallImageKey;

        // Token: 0x04000A0F RID: 2575
        public IntPtr smallImageText;

        // Token: 0x04000A10 RID: 2576
        public IntPtr partyId;

        // Token: 0x04000A11 RID: 2577
        public int partySize;

        // Token: 0x04000A12 RID: 2578
        public int partyMax;

        // Token: 0x04000A13 RID: 2579
        public IntPtr matchSecret;

        // Token: 0x04000A14 RID: 2580
        public IntPtr joinSecret;

        // Token: 0x04000A15 RID: 2581
        public IntPtr spectateSecret;

        // Token: 0x04000A16 RID: 2582
        public bool instance;
    }

    // Token: 0x0200023C RID: 572
    [Serializable]
    public struct DiscordUser
    {
        // Token: 0x04000A17 RID: 2583
        public string userId;

        // Token: 0x04000A18 RID: 2584
        public string username;

        // Token: 0x04000A19 RID: 2585
        public string discriminator;

        // Token: 0x04000A1A RID: 2586
        public string avatar;
    }

    // Token: 0x0200023D RID: 573
    public enum Reply
    {
        // Token: 0x04000A1C RID: 2588
        No,
        // Token: 0x04000A1D RID: 2589
        Yes,
        // Token: 0x04000A1E RID: 2590
        Ignore
    }

    // Token: 0x0200023E RID: 574
    public class RichPresence
    {
        // Token: 0x06000C41 RID: 3137 RVA: 0x0001F9FC File Offset: 0x0001DBFC
        internal DiscordRich.RichPresenceStruct GetStruct()
        {
            bool flag = this._buffers.Count > 0;
            if (flag)
            {
                this.FreeMem();
            }
            this._presence.state = this.StrToPtr(this.state, 128);
            this._presence.details = this.StrToPtr(this.details, 128);
            this._presence.startTimestamp = this.startTimestamp;
            this._presence.endTimestamp = this.endTimestamp;
            this._presence.largeImageKey = this.StrToPtr(this.largeImageKey, 32);
            this._presence.largeImageText = this.StrToPtr(this.largeImageText, 128);
            this._presence.smallImageKey = this.StrToPtr(this.smallImageKey, 32);
            this._presence.smallImageText = this.StrToPtr(this.smallImageText, 128);
            this._presence.partyId = this.StrToPtr(this.partyId, 128);
            this._presence.partySize = this.partySize;
            this._presence.partyMax = this.partyMax;
            this._presence.matchSecret = this.StrToPtr(this.matchSecret, 128);
            this._presence.joinSecret = this.StrToPtr(this.joinSecret, 128);
            this._presence.spectateSecret = this.StrToPtr(this.spectateSecret, 128);
            this._presence.instance = this.instance;
            return this._presence;
        }

        // Token: 0x06000C42 RID: 3138 RVA: 0x0001FB98 File Offset: 0x0001DD98
        private IntPtr StrToPtr(string input, int maxbytes)
        {
            bool flag = string.IsNullOrEmpty(input);
            IntPtr result;
            if (flag)
            {
                result = IntPtr.Zero;
            }
            else
            {
                string s = DiscordRich.RichPresence.StrClampBytes(input, maxbytes);
                int byteCount = Encoding.UTF8.GetByteCount(s);
                IntPtr intPtr = Marshal.AllocHGlobal(byteCount);
                this._buffers.Add(intPtr);
                Marshal.Copy(Encoding.UTF8.GetBytes(s), 0, intPtr, byteCount);
                result = intPtr;
            }
            return result;
        }

        // Token: 0x06000C43 RID: 3139 RVA: 0x0001FC00 File Offset: 0x0001DE00
        private static string StrToUtf8NullTerm(string toconv)
        {
            string text = toconv.Trim();
            byte[] bytes = Encoding.Default.GetBytes(text);
            bool flag = bytes.Length != 0 && bytes[bytes.Length - 1] > 0;
            if (flag)
            {
                text += "\0\0";
            }
            return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(text));
        }

        // Token: 0x06000C44 RID: 3140 RVA: 0x0001FC60 File Offset: 0x0001DE60
        private static string StrClampBytes(string toclamp, int maxbytes)
        {
            string text = DiscordRich.RichPresence.StrToUtf8NullTerm(toclamp);
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            bool flag = bytes.Length <= maxbytes;
            string result;
            if (flag)
            {
                result = text;
            }
            else
            {
                byte[] array = new byte[0];
                Array.Copy(bytes, 0, array, 0, maxbytes - 1);
                array[array.Length - 1] = 0;
                array[array.Length - 2] = 0;
                result = Encoding.UTF8.GetString(array);
            }
            return result;
        }

        // Token: 0x06000C45 RID: 3141 RVA: 0x0001FCCC File Offset: 0x0001DECC
        internal void FreeMem()
        {
            for (int i = this._buffers.Count - 1; i >= 0; i--)
            {
                Marshal.FreeHGlobal(this._buffers[i]);
                this._buffers.RemoveAt(i);
            }
        }

        // Token: 0x04000A1F RID: 2591
        private DiscordRich.RichPresenceStruct _presence;

        // Token: 0x04000A20 RID: 2592
        private readonly List<IntPtr> _buffers = new List<IntPtr>(10);

        // Token: 0x04000A21 RID: 2593
        public string state;

        // Token: 0x04000A22 RID: 2594
        public string details;

        // Token: 0x04000A23 RID: 2595
        public long startTimestamp;

        // Token: 0x04000A24 RID: 2596
        public long endTimestamp;

        // Token: 0x04000A25 RID: 2597
        public string largeImageKey;

        // Token: 0x04000A26 RID: 2598
        public string largeImageText;

        // Token: 0x04000A27 RID: 2599
        public string smallImageKey;

        // Token: 0x04000A28 RID: 2600
        public string smallImageText;

        // Token: 0x04000A29 RID: 2601
        public string partyId;

        // Token: 0x04000A2A RID: 2602
        public int partySize;

        // Token: 0x04000A2B RID: 2603
        public int partyMax;

        // Token: 0x04000A2C RID: 2604
        public string matchSecret;

        // Token: 0x04000A2D RID: 2605
        public string joinSecret;

        // Token: 0x04000A2E RID: 2606
        public string spectateSecret;

        // Token: 0x04000A2F RID: 2607
        public bool instance;
    }
}
}