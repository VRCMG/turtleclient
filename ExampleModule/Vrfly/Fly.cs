using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCClient.Utils;
using UnityEngine;
namespace VRCClient
{
    // Token: 0x02000002 RID: 2
    internal class Fly : MonoBehaviour
{
    // Token: 0x06000001 RID: 1 RVA: 0x000024A4 File Offset: 0x000006A4
    private void Update()
    {
        if (!Settings.CanFly && !this.SpeedHack)
        {
            return;
        }
        Transform transform = Camera.main.transform;
        Vector3 position = VRCPlayer.Instance.transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            base.transform.position += transform.transform.forward * Settings.flySpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            base.transform.position -= transform.transform.forward * Settings.flySpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
                base.transform.position -= transform.transform.right * Settings.flySpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            base.transform.position += transform.transform.right * Settings.flySpeed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            base.transform.position = new Vector3(position.x, position.y - Settings.flySpeed * Time.deltaTime, position.z);
        }
        if (Input.GetKey(KeyCode.E))
        {
            base.transform.position = new Vector3(position.x, position.y + Settings.flySpeed * Time.deltaTime, position.z);
        }
        if (Input.GetAxis("Vertical") != 0f)
        {
            base.transform.position += transform.transform.forward * Settings.flySpeed * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Horizontal") != 0f)
        {
            base.transform.position += transform.transform.right * Settings.flySpeed * Input.GetAxis("Horizontal");
        }
        VRCPlayer.Instance.AlignTrackingToPlayer();
    }

    // Token: 0x06000002 RID: 2 RVA: 0x000026BC File Offset: 0x000008BC
    public static void ToggleFly()
    {
        GameObject gameObject = VRCPlayer.Instance.gameObject;
        if (!gameObject.GetComponent<Fly>())
        {
            gameObject.AddComponent<Fly>();
        }
        Settings.CanFly = !Settings.CanFly;
        gameObject.GetComponent<CharacterController>().enabled = !Settings.CanFly;
        Console.WriteLine(string.Format("Fly is now {0}", Settings.CanFly));
    }

    // Token: 0x06000003 RID: 3 RVA: 0x00002724 File Offset: 0x00000924
    public static void ToggleSpeed()
    {
        GameObject gameObject = VRCPlayer.Instance.gameObject;
        if (!gameObject.GetComponent<Fly>())
        {
            gameObject.AddComponent<Fly>();
        }
        Fly component = gameObject.GetComponent<Fly>();
        component.SpeedHack = !component.SpeedHack;
    }

    // Token: 0x04000001 RID: 1
    public bool SpeedHack;
    }
}