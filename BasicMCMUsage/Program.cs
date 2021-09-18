using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMCMUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            MCM.openGame(); // Open game up inside of MCM class
            MCM.openWindowHost();

            // Game > ClientInstance > LocalPlayer
            ulong clientInstance = MCM.baseEvaluatePointer(0x041457D8, new ulong[] { 0x0, 0x20 });
            ulong localPlayer = MCM.evaluatePointer(clientInstance, new ulong[] { 0xC8, 0x0 });
            // all this means is Minecraft.Windows.exe+041457D8,0,20,C8,0(LocalPlayerPointer 1.17)
            // we put 0x before a hex number to tell the programing language that its hex
            // to fix this all you have to do is replace the broken pointer information

            // Game > ClientInstance > LocalPlayer > onGround
            ulong onGroundAddr = localPlayer + 0x1E0;

            // if you want more addresses like onGround do it like this (EXAMPLE)
            // ulong newAddr = localPlayer + (LocalPlayerOffset);
            ulong fieldOfViewAddr = localPlayer + 0x10F0;

            while (true) // infinite loop
            {
                MCM.writeInt(onGroundAddr, 16777473);
            }
        }
    }
}
