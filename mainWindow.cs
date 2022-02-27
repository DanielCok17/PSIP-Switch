using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PcapDotNet.Core;

namespace psip_zadanie
{
    public partial class mainWindow : Form
    {
        IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine; //vsetky sietove porty
        PacketDevice loopBackPort1;
        PacketDevice loopBackPort2;

        Port port1;
        Port port2;

        List<Port> switchPorts;

        Switch switchik;

        public mainWindow()
        {
            InitializeComponent();    
        }

        void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            switchik.stopSwitching();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            loopBackPort1 = allDevices[8]; //loopback1
            loopBackPort2 = allDevices[9]; //loopback2

            
            switchPorts = new List<Port>();
            switchPorts.Add(new Port(loopBackPort1, 2)); //gns2
            switchPorts.Add(new Port(loopBackPort2, 1)); //gns1

            port1 = new Port(loopBackPort1, 2); //gns2
            port2 = new Port(loopBackPort2, 1); //gns1
            switchik = new Switch(port1, port2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switchik.start();
            switchik.startSwitching();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switchik.stopSwitching();
        }

        private void clearStatistics_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Vymazať štatistiky");
            foreach (Port port in switchPorts)
            {
                port.clearStatistics();
            }
        }
    }
}
