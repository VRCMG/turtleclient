using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using VRC;
using VRC.Core;
using VRCClient.VRCheat.Utils;

namespace VRCClient
{
    // Token: 0x020001E8 RID: 488
    public class antioffgang : MonoBehaviour 
    {
        // Token: 0x06000AE8 RID: 2792 RVA: 0x00003D29 File Offset: 0x00001F29
        public void Awake()
        {
            UnityEngine.Object.DontDestroyOnLoad(this);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Anti off gang loaded !");
        }

        // Token: 0x06000AE9 RID: 2793 RVA: 0x00003D42 File Offset: 0x00001F42
        private IEnumerator Check()
        {
            yield return new WaitForSeconds(10f);
            PlayerUtils.inWorld();
            foreach (Player player in PlayerManager.GetAllPlayers())
            {
                try
                {
                    APIUser user = player.HGLCOLNAJJJ;
                    if (VRCPlayer.AreNameplatesVisible() && (player.GetAPIUser().id == "usr_d0801d9a-b12a-4469-a4a5-6206d72d48f3" || player.GetAPIUser().id == "usr_74a59e4d-dac8-471c-b115-529e27c41d84" || player.GetAPIUser().id == "usr_804e5c9a-9114-420c-98bf-356c33975aa0" || player.GetAPIUser().id == "usr_0229e143-8726-42ec-8487-29957ef092f9" || player.GetAPIUser().id == "usr_f656e21d-6eb2-407d-8271-b839d93a5dc9" || player.GetAPIUser().id == "usr_98c3fe96-e249-43b6-afb3-82859b9e474c" || player.GetAPIUser().id == "usr_6e0dae27-ca48-4af5-8616-4cc9d3034e26" || player.GetAPIUser().id == "usr_138d6dd8-dafb-4498-8e29-4adab80f45c7" || player.GetAPIUser().id == "usr_8b00e8e7-72ec-4336-94e6-aca69f4fef3e" || player.GetAPIUser().id == "usr_0ae8e35a-4a54-4a60-b159-ed4c3d8d0256" || player.GetAPIUser().id == "usr_e7e2eef3-0c88-45aa-b22f-27092fff08c7" || player.GetAPIUser().id == "usr_3ac318b5-91e2-4b42-ac49-745930006819" || player.GetAPIUser().id == "usr_a6aa5748-90da-42b6-907e-fed9b104a948" || player.GetAPIUser().id == "usr_25cef19f-f81f-4047-b838-c05df7aa614e" || player.GetAPIUser().id == "usr_488ef27d-05bd-4498-82fe-5684c24da469" || player.GetAPIUser().id == "usr_3975d23e-8734-40e2-aab5-187f9c050706" || player.GetAPIUser().id == "usr_b162fa34-0da1-437d-8aa4-28167743eda0" || player.GetAPIUser().id == "usr_99201f6a-dcef-4970-8cdf-c3d8e98986ed" || player.GetAPIUser().id == "usr_bb0a9976-57e6-48f8-b1d2-2bf338f3855f" || player.GetAPIUser().id == "usr_9a58fb66-c9a1-4ce4-8b80-a76b6fb6c642" || player.GetAPIUser().id == "usr_3340977d-f625-482c-bfe6-f7eb5f4eba08" || player.GetAPIUser().id == "usr_adbdfa56-20f2-4d53-8c67-e2cca166506d" || player.GetAPIUser().id == "usr_e5cc9898-b2e9-40e9-bef6-477bf8b81943" || player.GetAPIUser().id == "usr_75bbcc0e-88e3-4c3c-918d-d2fe071d2a69" || player.GetAPIUser().id == "usr_086a0925-1bf6-4dd6-9a55-f8e8e177921d" || player.GetAPIUser().id == "usr_f787b611-bd4e-4dfd-8f1b-ff5bea841147" || player.GetAPIUser().id == "usr_b54a1ee7-c0cc-4f98-bbe8-5bd0e97c489e"))
                    {
                        player.vrcPlayer.SetNamePlateColor(UnityEngine.Random.ColorHSV(1f, 0f, 0f, 0f, 0f, 0f));
                        UnityEngine.Random.ColorHSV(1f, 0f, 0f, 0f, 0f, 0f);
                        player.vrcPlayer.namePlate.mainText.text = "<color=blue>FUCK OFF GANG :</color><color=blue>" + user.displayName + "</color>";
                        UnityEngine.Object.DestroyObject(player.vrcPlayer.avatarGameObject);
                        UnityEngine.Object.Destroy(player.vrcPlayer);
                        UnityEngine.Object.Destroy(player);
                        UnityEngine.Object.Destroy(player.transform);
                        UnityEngine.Object.DestroyImmediate(player);
                        UnityEngine.Object.DestroyObject(player);
                        UnityEngine.Object.DestroyObject(player.vrcPlayer);
                        UnityEngine.Object.DestroyObject(player);
                        player.vrcPlayer.canSpeak = false;
                        player.vrcPlayer.canSpeak = false;
                        player.vrcPlayer.canHear = false;
                        player.vrcPlayer.canPickupObjects = false;
                        player.vrcPlayer.HideNonFriendsCustomAvatars = false;
                        player.vrcPlayer.isSpeaking = false;
                        APIUser.CurrentUser.friendIDs.RemoveAll((string id) => id == user.id);
                        APIUser.CurrentUser.friendIDs.Remove(user.id);
                        player.vrcPlayer._status = "FUCK OFF GANG";
                        player.vrcPlayer.vipPlate.name = "FUCK OFF GANG";
                        player.vrcPlayer.namePlate.mainText.tag = "FUCK OFF GANG";
                        player.vrcPlayer.namePlate.mainText.text = user.displayName;
                        player.vrcPlayer.namePlate.mainText.tag = "FUCK OFF GANG";
                        player.vrcPlayer.statusPlate.name = "FUCK OFF GANG";
                        player.vrcPlayer.statusPlate.tag = "FUCK OFF GANG";
                    }
                }
                catch
                {
                }
            }
            yield break;
        }

        // Token: 0x06000AEA RID: 2794 RVA: 0x00003D4A File Offset: 0x00001F4A
        public void Update()
        {
            base.StartCoroutine(this.Check());
        }
    }
}
