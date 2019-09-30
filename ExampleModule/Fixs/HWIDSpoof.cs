using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using VRCTools;
using VRLoader.Attributes;
using VRLoader.Modules;
using VRCModLoader;
using Harmony;
using Transmtn;
using System.Reflection;
using System.Security.Cryptography;
using VRC.Core;

namespace turtleclient.Fixs
{
  
    public class HWID_Spoof : VRModule
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public void Start()
    {
        HarmonyInstance harmonyInstance = HarmonyInstance.Create("HWID_Spoof");
        harmonyInstance.Patch(typeof(API).GetProperty("DeviceID").GetGetMethod(), new HarmonyMethod(typeof(HWID_Spoof).GetMethod("API_DeviceID", BindingFlags.Static | BindingFlags.NonPublic)), null, null);
        harmonyInstance.Patch(typeof(Api).GetConstructors().First((ConstructorInfo x) => x.GetParameters().Length == 10), new HarmonyMethod(typeof(HWID_Spoof).GetMethod("Transmtn_Api", BindingFlags.Static | BindingFlags.NonPublic)), null, null);
        harmonyInstance.Patch(typeof(Api).Assembly.GetTypes().First((Type x) => x.Name == "WebsocketPipeline").GetConstructors().First((ConstructorInfo x) => x.GetParameters().Length == 6), new HarmonyMethod(typeof(HWID_Spoof).GetMethod("Transmtn_WebsocketPipeline1", BindingFlags.Static | BindingFlags.NonPublic)), null, null);
        harmonyInstance.Patch(typeof(Api).Assembly.GetTypes().First((Type x) => x.Name == "WebsocketPipeline").GetConstructors().First((ConstructorInfo x) => x.GetParameters().Length == 7), new HarmonyMethod(typeof(HWID_Spoof).GetMethod("Transmtn_WebsocketPipeline2", BindingFlags.Static | BindingFlags.NonPublic)), null, null);
        harmonyInstance.Patch(typeof(Api).Assembly.GetTypes().First((Type x) => x.Name == "WebsocketPipeline").GetConstructors().First((ConstructorInfo x) => x.GetParameters().Length == 8), new HarmonyMethod(typeof(HWID_Spoof).GetMethod("Transmtn_WebsocketPipeline3", BindingFlags.Static | BindingFlags.NonPublic)), null, null);
    }

    // Token: 0x06000002 RID: 2 RVA: 0x0000228C File Offset: 0x0000048C
    private static string GetHardwareID()
    {

        if (HWID_Spoof.HardwareID == null)
        {
            HWID_Spoof.HardwareID = HWID_Spoof.CalculateHash<SHA1>(Guid.NewGuid().ToString());
        }
        return HWID_Spoof.HardwareID;
    }

    // Token: 0x06000003 RID: 3 RVA: 0x000022C2 File Offset: 0x000004C2
    public static bool API_DeviceID(ref string __result)
    {
        __result = HWID_Spoof.GetHardwareID();
        return false;
    }

        // Token: 0x06000004 RID: 4 RVA: 0x000022CC File Offset: 0x000004CC
        public static bool Transmtn_Api(Uri httpEndpoint, Uri websocketEndpoint, ApiAuth auth, ref string macAddress, string clientVersion, string platform, Api.ErrorResponse defaultErrorResponse, Api.LogResponse defaultLogResponse, Api.OnReady onReadyResponse, Api.OnConnectionLost onLostConnectionResponse)
    {
        macAddress = HWID_Spoof.GetHardwareID();
        return true;
    }

        // Token: 0x06000005 RID: 5 RVA: 0x000022CC File Offset: 0x000004CC
        public static bool Transmtn_WebsocketPipeline1(Guid connectionId, Uri endpoint, string authToken, ref string macAddress, string clientVersion, string platform)
    {
        macAddress = HWID_Spoof.GetHardwareID();
        return true;
    }

        // Token: 0x06000006 RID: 6 RVA: 0x000022CC File Offset: 0x000004CC
        public static bool Transmtn_WebsocketPipeline2(Guid connectionId, Uri endpoint, string authToken, ref string macAddress, string clientVersion, string platform, IStream<string> inputStream)
    {
        macAddress = HWID_Spoof.GetHardwareID();
        return true;
    }

        // Token: 0x06000007 RID: 7 RVA: 0x000022CC File Offset: 0x000004CC
        public static bool Transmtn_WebsocketPipeline3(Guid connectionId, Uri endpoint, string authToken, ref string macAddress, string clientVersion, string platform, IStream<string> inputStream, IStream<string> outputStream)
    {
        macAddress = HWID_Spoof.GetHardwareID();
        return true;
    }

        // Token: 0x06000008 RID: 8 RVA: 0x000022D8 File Offset: 0x000004D8
        public static string CalculateHash<T>(string input) where T : HashAlgorithm
    {
        byte[] array = HWID_Spoof.CalculateHash<T>(Encoding.UTF8.GetBytes(input));
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < array.Length; i++)
        {
            stringBuilder.Append(array[i].ToString("x2"));
        }
        return stringBuilder.ToString();
    }

        // Token: 0x06000009 RID: 9 RVA: 0x00002328 File Offset: 0x00000528
        public static byte[] CalculateHash<T>(byte[] buffer) where T : HashAlgorithm
    {
        T t = typeof(T).GetMethod("Create", new Type[0]).Invoke(null, null) as T;
        byte[] result;
        try
        {
            result = t.ComputeHash(buffer);
        }
        finally
        {
            if (t != null)
            {
                ((IDisposable)((object)t)).Dispose();
            }
        }
        return result;
    }

    // Token: 0x04000005 RID: 5
    private static string HardwareID;
}
}

