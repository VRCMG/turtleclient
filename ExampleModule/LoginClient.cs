
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using VRC;
using VRC.Core;
using VRLoader.Attributes;
using VRLoader.Modules;
using turtleclient.LogPlayerInfoVR;
using turtleclient.Fixs;
using WebSocketSharp;
using DocumentFormat.OpenXml.Office2010.Excel;
using VRCClient.Reflection;
using turtleclient.CopyAvatarVR;
using turtleclient.AntiStuff;

namespace VRCClient
    {
        [ModuleInfo("Vrfl", "V.1.0", "Minunn")]
        public class TurtleGang : VRModule
        {

                 private MethodInfo _getApiUser = typeof(Player).GetProperties().FirstOrDefault(p => p.PropertyType == typeof(APIUser))?.GetGetMethod();

            private APIUser GetAPIUser(Player player) => (APIUser)_getApiUser.Invoke(player, null);
            public string ClientName = "http://www.wizimodz.ovh/Name.txt"; // Online .txt file containing client name text 

            public string AuthorCredit = "http://www.wizimodz.ovh/Author.txt"; // Online .txt file containing author credit text

            // What should my online whitelist.txt look like?
            // You just put userID's in the .txt file without any spaces and only put one userID on a line, like this:
            // usr_4458f30a-b743-439a-aeef-d342b1d7fbfa
            // usr_f65559b8-5677-4cba-b5fb-df6b00774b3d

            // You can also check the URL's, they are examples.

            private IEnumerator Start() // Start method, first thing to start when module gets loaded.
            {
           
            // Check Client Name (grabs client name out of an online txt so you can change the client name remotely in the future without requiring an update)
            using (WWW CN = new WWW(ClientName)) // Defines online txt containing client name.
                {
                    yield return CN; // Returns the contents inside the online txt as a string so we can turn it into text.
                    this.CN = CN.text + " "; // Passes the contents of the online txt through to the public string "CN" all the way at the bottom of the project so that we can publicly access it anywhere in the project.
                }

                // Client made by (grabs author credits out of an online txt so you can change the author credit remotely in the future without requiring an update)
                using (WWW AC = new WWW(AuthorCredit)) // Defines online txt containing author credit.
                {
                    yield return AC; // Returns the contents inside the online txt as a string so we can turn it into text.
                    this.AC = AC.text; // Passes the contents of the online txt through to the public string "AC" all the way at the bottom of the project so that we can publicly access it anywhere in the project.
                }


            testepc();
            StartupInfo(); // All startup info
  

                //        using (WWW whited = new WWW("http://www.wizimodz.ovh/Clients.txt")) // Defines your online txt containing whitelisted users their userID's.
                //        {
                //            yield return whited;
                //if (whited.text.Contains(player.GetAPIUser().id))
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine("working");
                //    Console.ForegroundColor = ConsoleColor.White;
                //    TurtleGang.GameObject = new GameObject();
                //    TurtleGang.GameObject.AddComponent<VRFly2_0>();
                //    TurtleGang.GameObject.AddComponent<Fly>();
                //    TurtleGang.GameObject.AddComponent<Antistaff>();
                //    TurtleGang.GameObject.AddComponent<antioffgang>();
                //    TurtleGang.GameObject.AddComponent<AntiIpGrabber>();
                //    TurtleGang.GameObject.AddComponent<HWID_Spoof>();
                //    TurtleGang.GameObject.AddComponent<socialfix>();
                //    TurtleGang.GameObject.AddComponent<CloneAvatarVR>();
                //    TurtleGang.GameObject.AddComponent<LogPlayerInfoVR>();
                ////}
                //        }
            yield break;
            }





            private void StartupInfo() // All information you need to know such as commands will be written for you in console so you can read them.
            {

  
            Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(TimeOfOutput); // Writes the time that the message pops up in console (h:mm:ss tt)
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(CN); // Writes text out of online ClientName .txt that you set up in "Start" 
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(AC); // Writes text out of online AuthorCredit .txt that you set up in "Start" method above 

            }


            private void Update()
            {

     
            }



        
        public static void testepc()
        {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                TurtleGang.GameObject = new GameObject();
                TurtleGang.GameObject.AddComponent<VRFly2_0>();
                TurtleGang.GameObject.AddComponent<Fly>();
               TurtleGang.GameObject.AddComponent<Antistaff>();
                TurtleGang.GameObject.AddComponent<antioffgang>();
                TurtleGang.GameObject.AddComponent<AntiIpGrabber>();
                TurtleGang.GameObject.AddComponent<HWID_Spoof>();
                TurtleGang.GameObject.AddComponent<socialfix>();
                TurtleGang.GameObject.AddComponent<CloneAvatarVR>();
                TurtleGang.GameObject.AddComponent<LogPlayerInfoVR>();
                TurtleGang.GameObject.AddComponent<IsTurtleGangMember>();
          
        }


  
        
            // Timer.
            private IEnumerator InvokeMethod(Action method, float interval, int invokeCount)
            {

                for (int i = 0; i < invokeCount; i++)
                {
                    method();

                    yield return new WaitForSeconds(interval);
                }

            }

        public string Whitelist = "http://www.wizimodz.ovh/Clients.txt"; // Online .txt file containing whitelisted users text (check example above)


        // Token: 0x0400005B RID: 91
        public static GameObject GameObject;
        public string TimeOfOutput = DateTime.Now.ToString("h:mm:ss tt") + " "; // Used for message time output and can be globally used throughout the entire project.
            public string CN; // Is undefined here but in the Start() method it will be defined as the Client Name and can be globally used throughout the entire project.
            public string AC; // Is undefined here but in the Start() method it will be defined as the Author Credits and can be globally used throughout the entire project.
    }
    }