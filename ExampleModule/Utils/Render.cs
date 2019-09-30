using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCClient.Reflection;
using UnityEngine;
using VRC;
using VRC.Core;

namespace VRCClient.Utils
{
    // Token: 0x02000006 RID: 6
    public static class Render
    {
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000027 RID: 39 RVA: 0x0000228F File Offset: 0x0000048F
        // (set) Token: 0x06000028 RID: 40 RVA: 0x00002296 File Offset: 0x00000496
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000029 RID: 41 RVA: 0x0000229E File Offset: 0x0000049E
        // (set) Token: 0x0600002A RID: 42 RVA: 0x000022A5 File Offset: 0x000004A5
        public static Color Color
        {
            get
            {
                return GUI.color;
            }
            set
            {
                GUI.color = value;
            }
        }

    



        // Token: 0x0600002F RID: 47 RVA: 0x000022CF File Offset: 0x000004CF
        public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
        {
            Render.Color = color;
            Render.DrawCross(position, size, thickness);
        }

        // Token: 0x06000030 RID: 48 RVA: 0x00002B94 File Offset: 0x00000D94
        public static void DrawCross(Vector2 position, Vector2 size, float thickness)
        {
            GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
        }


   
        // Token: 0x06000033 RID: 51 RVA: 0x00002314 File Offset: 0x00000514
        public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
        {
            Render.Color = color;
            Render.DrawString(position, label, centered);
        }

        // Token: 0x06000034 RID: 52 RVA: 0x00002C00 File Offset: 0x00000E00
        public static void DrawString(Vector2 position, string label, bool centered = true)
        {
            GUIContent content = new GUIContent(label);
            Vector2 vector = Render.StringStyle.CalcSize(content);
            GUI.Label(new Rect(centered ? (position - vector / 2f) : position, vector), content);
        }




        // Token: 0x06000038 RID: 56 RVA: 0x00002DEC File Offset: 0x00000FEC
        public static Texture2D MakeTex(int width, int height, Color col)
        {
            Color[] array = new Color[width * height];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = col;
            }
            Texture2D texture2D = new Texture2D(1, 1);
            texture2D.SetPixels(array);
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x04000013 RID: 19
        private static Dictionary<int, Render.RingArray> ringDict = new Dictionary<int, Render.RingArray>();

        // Token: 0x02000007 RID: 7
        private class RingArray
        {
            // Token: 0x17000003 RID: 3
            // (get) Token: 0x0600003A RID: 58 RVA: 0x00002356 File Offset: 0x00000556
            // (set) Token: 0x0600003B RID: 59 RVA: 0x0000235E File Offset: 0x0000055E
            public Vector2[] Positions { get; private set; }

            // Token: 0x0600003C RID: 60 RVA: 0x00002E2C File Offset: 0x0000102C
            public RingArray(int numSegments)
            {
                this.Positions = new Vector2[numSegments];
                float num = 360f / (float)numSegments;
                for (int i = 0; i < numSegments; i++)
                {
                    float f = 0.0174532924f * num * (float)i;
                    this.Positions[i] = new Vector2(Mathf.Sin(f), Mathf.Cos(f));
                }
            }
        }
    }
}
