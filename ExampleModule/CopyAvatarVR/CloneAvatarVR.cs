using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace turtleclient.CopyAvatarVR
{
        // Token: 0x020001DC RID: 476
        public class CloneAvatarVR : MonoBehaviour
        {
            // Token: 0x06000ACB RID: 2763 RVA: 0x00019174 File Offset: 0x00017374
            public void Start()
            {
                this.userInteractGO = GameObject.Find("/UserInterface/QuickMenu/UserInteractMenu");
                this.userInteract = this.userInteractGO.GetComponent<UserInteractMenu>();
                this.ifYouDeleteThisEverythingDiesCloneAvatarButton = this.userInteractGO.transform.Find("CloneAvatarButton").gameObject;
                this.NewCloneAvatarButton = UnityEngine.Object.Instantiate<GameObject>(this.ifYouDeleteThisEverythingDiesCloneAvatarButton, this.userInteractGO.transform);
                this.ifYouDeleteThisEverythingDiesCloneAvatarButton.transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Avatar Clone loaded.");
                Console.ResetColor();
            }

        // Token: 0x06000ACC RID: 2764 RVA: 0x00019218 File Offset: 0x00017418
        [Obsolete]
        public void Update()
            {
                if (userInteractGO.active)
                {
                    if (this.userInteract.menuController.activeAvatar != null && !this.userInteract.menuController.activeUser.allowAvatarCopying && this.userInteract.menuController.activeAvatar.releaseStatus == "public")
                    {
                        this.NewCloneAvatarButton.GetComponent<Button>().enabled = true;
                        this.NewCloneAvatarButton.GetComponentInChildren<Text>().text = "<color=#fe000c>S</color><color=#f1000c>t</color><color=#e3010b>e</color><color=#d6010b>a</color><color=#c9010b>l</color><color=#bb020a> </color><color=#ae020a>P</color><color=#a7030b>u</color><color=#9f040b>b</color><color=#98050c>l</color><color=#90050c>i</color><color=#89060d>c</color><color=#81070d> </color><color=#6c060b>A</color><color=#560509>v</color><color=#410307>a</color><color=#2b0204>t</color><color=#160102>a</color><color=#000000>r</color>";
                        return;
                    }
                    if (this.userInteract.menuController.activeAvatar != null && this.userInteract.menuController.activeAvatar.releaseStatus == "private")
                    {
                        this.NewCloneAvatarButton.GetComponent<Button>().enabled = false;
                        this.NewCloneAvatarButton.GetComponentInChildren<Text>().text = "<color=#fe000c>P</color><color=#ea010c>r</color><color=#d6010b>i</color><color=#c2020b>v</color><color=#ae020a>a</color><color=#a5030b>t</color><color=#9c040b>e</color><color=#93050c> </color><color=#8a060c>A</color><color=#81070d>v</color><color=#61050a>a</color><color=#410407>t</color><color=#200203>a</color><color=#000000>r</color>";
                        return;
                    }
                    this.NewCloneAvatarButton.GetComponentInChildren<Text>().text = "<color=#fe000c>C</color><color=#f1000c>l</color><color=#e3010b>o</color><color=#d6010b>n</color><color=#c9010b>e</color><color=#bb020a> </color><color=#ae020a>P</color><color=#a7030b>u</color><color=#9f040b>b</color><color=#98050c>l</color><color=#90050c>i</color><color=#89060d>c</color><color=#81070d> </color><color=#6c060b>A</color><color=#560509>v</color><color=#410307>a</color><color=#2b0204>t</color><color=#160102>a</color><color=#000000>r</color>";
                    this.NewCloneAvatarButton.GetComponent<Button>().enabled = true;
                }
            }

            // Token: 0x0400097E RID: 2430
            public string currentUserID;

        // Token: 0x0400097F RID: 2431
        public UserInteractMenu InteractMenu;

            // Token: 0x04000980 RID: 2432
            private GameObject userInteractGO;

            // Token: 0x04000981 RID: 2433
            private GameObject ifYouDeleteThisEverythingDiesCloneAvatarButton;

            // Token: 0x04000982 RID: 2434
            private GameObject NewCloneAvatarButton;

            // Token: 0x04000983 RID: 2435
            private UserInteractMenu userInteract;
        }
 }
