using System.Collections;
using UnityEngine;
using VRCTools;
using VRLoader.Attributes;
using VRLoader.Modules;
using VRCModLoader;
using System;

namespace VRCClient
{
   
    public class socialfix : VRModule
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public void Start()
        {
           StartCoroutine(socialfix.WaitForUIManager());
            Console.WriteLine("test8");

        }
        // Token: 0x06000002 RID: 2 RVA: 0x0000205D File Offset: 0x0000025D
        public static IEnumerator WaitForUIManager()
        {
            yield return VRCUiManagerUtils.WaitForUiManagerInit();
            VRCUiManagerUtils.OnPageShown += delegate (VRCUiPage page)
            {
                if (page.GetType() == typeof(VRCUiPageSocial) && socialfix.ShouldRefresh)
                {
                    socialfix.ShouldRefresh = false;
                    foreach (UiUserList uiUserList in Resources.FindObjectsOfTypeAll<UiUserList>())
                    {
                        uiUserList.ClearAll();
                        uiUserList.FetchAndRenderElementsForCurrentPage();
                        uiUserList.RefreshData();
                    }
                    return;
                }
                if (page.GetType() == typeof(VRCUiPageHeader))
                {
                    socialfix.ShouldRefresh = true;
                }
            };
            yield break;
        }

        // Token: 0x04000005 RID: 5
        private static bool ShouldRefresh = true;
    }
}
