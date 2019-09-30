using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using VRC.Core;

namespace VRCClient.VRCheat.Utils
{
    // Token: 0x020001D1 RID: 465
    internal static class MiscUtils
    {
        // Token: 0x06000A76 RID: 2678 RVA: 0x00018020 File Offset: 0x00016220
        static MiscUtils()
        {
            try
            {
                PropertyInfo propertyInfo = typeof(VRCFlowManager).GetProperties().FirstOrDefault((PropertyInfo p) => p.PropertyType == typeof(VRCFlowManager));
                MiscUtils.flowManagerMethod = ((propertyInfo != null) ? propertyInfo.GetGetMethod() : null);
                PropertyInfo propertyInfo2 = typeof(VRCUiManager).GetProperties().FirstOrDefault((PropertyInfo p) => p.PropertyType == typeof(VRCUiManager));
                MiscUtils.uiManagerMethod = ((propertyInfo2 != null) ? propertyInfo2.GetGetMethod() : null);
                PropertyInfo propertyInfo3 = typeof(VRCApplicationSetup).GetProperties().FirstOrDefault((PropertyInfo p) => p.PropertyType == typeof(VRCApplicationSetup));
                MiscUtils.appSetupMethod = ((propertyInfo3 != null) ? propertyInfo3.GetGetMethod() : null);
                PropertyInfo propertyInfo4 = typeof(VRCApplicationSetup).GetProperties().FirstOrDefault((PropertyInfo p) => p.PropertyType == typeof(ApiAvatar));
                MiscUtils.currentAvatarMethod = ((propertyInfo4 != null) ? propertyInfo4.GetGetMethod() : null);
            }
            catch
            {
                Console.WriteLine("Error loading VRChat information fields.");
            }
        }

        // Token: 0x06000A77 RID: 2679 RVA: 0x0001812C File Offset: 0x0001632C
        public static string CalculateHash<T>(string input) where T : HashAlgorithm
        {
            byte[] array = MiscUtils.CalculateHash<T>(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        // Token: 0x06000A78 RID: 2680 RVA: 0x0001818C File Offset: 0x0001638C
        public static byte[] CalculateHash<T>(byte[] buffer) where T : HashAlgorithm
        {
            byte[] result;
            using (T t = typeof(T).GetMethod("Create", new Type[0]).Invoke(null, null) as T)
            {
                result = t.ComputeHash(buffer);
            }
            return result;
        }

        // Token: 0x06000A79 RID: 2681 RVA: 0x00018204 File Offset: 0x00016404
        public static VRCFlowManager GetVRCFlowManagerInstance()
        {
            return (VRCFlowManager)MiscUtils.flowManagerMethod.Invoke(null, null);
        }

        // Token: 0x06000A7A RID: 2682 RVA: 0x00018228 File Offset: 0x00016428
        public static VRCApplicationSetup GetVRCApplicationSetup()
        {
            return (VRCApplicationSetup)MiscUtils.appSetupMethod.Invoke(null, null);
        }

        // Token: 0x06000A7B RID: 2683 RVA: 0x0001824C File Offset: 0x0001644C
        public static VRCUiManager GetVRCUiManager()
        {
            return (VRCUiManager)MiscUtils.uiManagerMethod.Invoke(null, null);
        }

        // Token: 0x04000952 RID: 2386
        private static MethodInfo flowManagerMethod;

        // Token: 0x04000953 RID: 2387
        private static MethodInfo uiManagerMethod;

        // Token: 0x04000954 RID: 2388
        private static MethodInfo appSetupMethod;

        // Token: 0x04000955 RID: 2389
        private static MethodInfo currentAvatarMethod;
    }
}
