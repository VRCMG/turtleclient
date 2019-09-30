using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace turtleclient.CopyAvatarVR
{
    // Token: 0x020001DD RID: 477
    public class Reflection
    {
        // Token: 0x06000ACE RID: 2766 RVA: 0x00019328 File Offset: 0x00017528
        internal static bool isInRoom()
        {
            return (bool)Reflection.IsInRoom.Invoke(null, null);
        }

        // Token: 0x04000984 RID: 2436
        internal static MethodInfo IsInRoom = typeof(RoomManagerBase).GetProperties(BindingFlags.Static | BindingFlags.Public).First((PropertyInfo p) => p.GetGetMethod().Name == "get_inRoom").GetGetMethod();
    }
}
