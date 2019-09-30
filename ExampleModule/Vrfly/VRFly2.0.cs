using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using VRC;


namespace VRCClient
{
    // Token: 0x02000009 RID: 9
    internal class VRFly2_0 : MonoBehaviour
    {
        // Token: 0x06000043 RID: 67 RVA: 0x000033C0 File Offset: 0x000015C0
        public void Start()
        {
            this.ShortCutMenu = GameObject.Find("/UserInterface/QuickMenu/ShortcutMenu");
            this.PortalButton = UnityEngine.Object.Instantiate<GameObject>(GameObject.Find("/UserInterface/QuickMenu/UserInteractMenu/DetailsButton"), this.ShortCutMenu.transform);
            this.PortalButton.transform.localPosition = this.ShortCutMenu.transform.Find("WorldsButton").localPosition + Vector3.right * 1650f;
            this.PortalButton.GetComponent<Button>().onClick.RemoveAllListeners();
            this.PortalButton.GetComponentInChildren<Text>().text = "Fly OFF";
            this.PortalButton.AttachClick(delegate
            {
                this.antiportal = !this.antiportal;
                if (this.antiportal)
                {
                    Fly.ToggleFly();
                    this.PortalButton.GetComponentInChildren<Text>().text = "Fly on";
                    return;
                }
                Fly.ToggleFly();
                this.PortalButton.GetComponentInChildren<Text>().text = "fly off";
            });
        }
        
        // Token: 0x06000044 RID: 68 RVA: 0x0000238F File Offset: 0x0000058F
        public void gae()
        {
        }

        // Token: 0x06000045 RID: 69 RVA: 0x000034A8 File Offset: 0x000016A8
        private static void LoadStyle()
        {
            VRFly2_0.Texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            VRFly2_0.Texture.SetPixel(0, 0, new Color(0.3f, 0.3f, 0.3f, 0.5f));
            VRFly2_0.Texture.Apply();
            VRFly2_0.Label = new GUIStyle();
            VRFly2_0.Label.fontSize = 17;
            VRFly2_0.Label.normal.textColor = Color.white;
            VRFly2_0.Box = new GUIStyle();
            VRFly2_0.Box.normal.background = VRFly2_0.Texture;
            VRFly2_0.Loaded = true;
        }

      

        // Token: 0x06000049 RID: 73 RVA: 0x00002391 File Offset: 0x00000591
        public void Update()
        {
            if (Event.current.control && Input.GetKeyDown(KeyCode.Alpha2))
            {
                VRFly2_0.Show = !VRFly2_0.Show;
            }
        }

        // Token: 0x04000052 RID: 82
        private GameObject ShortCutMenu;

        // Token: 0x04000053 RID: 83
        private GameObject PortalButton;

        // Token: 0x04000054 RID: 84
        private bool antiportal = true;

        // Token: 0x04000055 RID: 85
        public static bool Show = true;

        // Token: 0x04000056 RID: 86
        public static Rect Window = new Rect(((float)Screen.width - 510f) / 2f, ((float)Screen.height - 500f) / 2f, 510f, 500f);

        // Token: 0x04000058 RID: 88
        private static GUIStyle Label;

        // Token: 0x04000059 RID: 89
        private static GUIStyle Box;

        // Token: 0x0400005A RID: 90
        private static Texture2D Texture;

        // Token: 0x0400005B RID: 91
        public static bool Loaded = true;
    }
}