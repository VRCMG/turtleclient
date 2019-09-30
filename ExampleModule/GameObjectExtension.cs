using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace VRCClient
{
    // Token: 0x0200000A RID: 10
    public static class GameObjectExtension
{
    // Token: 0x0600004A RID: 74 RVA: 0x000023B8 File Offset: 0x000005B8
    public static void AttachClick(this GameObject main, UnityAction onClick)
    {
        Button component = main.GetComponent<Button>();
        component.onClick = new Button.ButtonClickedEvent();
        component.onClick.AddListener(onClick);
    }
}
}