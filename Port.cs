using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Http;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace psip_zadanie
{
    class Port
    {
        PacketDevice device;
        PacketCommunicator communicator;
        bool isMirrorning;
        int portNumber;
        Dictionary<String, int> statisticsIn, statisticsOut;
        TextBox console;
        delegate void printStatisticsCallback();


        public Port(PacketDevice device, int portNumber)
        {
            this.device = device;
            this.portNumber = portNumber;
            this.console = Application.OpenForms["mainWindow"].Controls["statistics" + this.portNumber] as TextBox;
        }

        public void openPort(int readTimeout) //otvorenie portu pre odosielanie/prijimanie
        {
            this.communicator = this.device.Open(65536, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, readTimeout);
            this.statisticsIn = new Dictionary<string, int>()
            {
                {"eth", 0 },
                {"ip", 0 },
                {"arp", 0 },
                {"icmp", 0 },
                {"http", 0 }
            };
            this.statisticsOut = new Dictionary<string, int>()
            {
                {"eth", 0 },
                {"ip", 0 },
                {"arp", 0 },
                {"icmp", 0 },
                {"http", 0 }
            };
        }

        public void clearStatistics()
        {
            this.statisticsIn = new Dictionary<string, int>()
            {
                {"eth", 0 },
                {"ip", 0 },
                {"arp", 0 },
                {"icmp", 0 },
                {"http", 0 }
            };

            this.statisticsOut = new Dictionary<string, int>()
            {
                {"eth", 0 },
                {"ip", 0 },
                {"arp", 0 },
                {"icmp", 0 },
                {"http", 0 }
            };

            this.printStatistics();
        }

        public void mirrorPackets(Port outPort) //metoda na zrkadlenie paketov na iny port
        {
            this.isMirrorning = true;
            Packet packet;
            do
            {
                PacketCommunicatorReceiveResult result = this.communicator.ReceivePacket(out packet); //pocka kym pride paket
                switch (result)
                {
                    case PacketCommunicatorReceiveResult.Timeout: continue; //ak ubehne timeout nastaveny v openPort
                    case PacketCommunicatorReceiveResult.Ok: //ak pride v poriadku tak ho preposlem na druhy port
                        this.analyzePacket(packet, this.statisticsIn);
                        outPort.sendPacket(packet, outPort); //odoslem paket druhym portom
                        break;
                    default: break; //nepotrebny kedze sa tu nikdy nedostane
                }

                this.printStatistics();

            } while (this.isMirrorning);
        }

        public void printStatistics()
        {
            if (this.console.InvokeRequired)
            {
                printStatisticsCallback d = new printStatisticsCallback(printStatistics);
                this.console.Invoke(d, new object[] { });
            }
            else
            {
                this.console.Text = String.Format("Port {0}: \r\n " +
                "\tIN: \r\n" +
                "\t\t ETH: {1}\r\n" +
                "\t\t IPv4: {2}\r\n" +
                "\t\t ICMP: {3}\r\n" +
                "\t\t ARP: {4}\r\n" +
                "\t\t HTTP: {5}\r\n", this.portNumber, this.statisticsIn["eth"], this.statisticsIn["ip"], this.statisticsIn["icmp"], this.statisticsIn["arp"], this.statisticsIn["http"]);

                this.console.Text += String.Format("Port {0}: \r\n " +
                    "\tOUT: \r\n" +
                    "\t\t ETH: {1}\r\n" +
                    "\t\t IPv4: {2}\r\n" +
                    "\t\t ICMP: {3}\r\n" +
                    "\t\t ARP: {4}\r\n" +
                    "\t\t HTTP: {5}\r\n", this.portNumber, this.statisticsOut["eth"], this.statisticsOut["ip"], this.statisticsOut["icmp"], this.statisticsOut["arp"], this.statisticsOut["http"]);
            }
        }


        public void sendPacket(Packet packet, Port outPort) //preposle paket na prislusny port
        {
            outPort.communicator.SendPacket(packet);
            outPort.analyzePacket(packet, outPort.statisticsOut);
        }

        public void stopMirroring() //ak chcem zastavit preposielanie paketov na druhy port
        {
            this.isMirrorning = false;
        }

        public void analyzePacket(Packet packet, Dictionary<String, int> statistics) //TODO niektore sa zapocitava dvakrát
        {
            if (packet.Ethernet.EtherType == EthernetType.Arp)
            {
                statistics["arp"]++;
                statistics["eth"]++;
            }
            if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.InternetControlMessageProtocol)
            {
                statistics["icmp"]++;
                statistics["eth"]++;
            }
            if (packet.Ethernet.IpV4.Tcp.Http.IsValid || packet.Ethernet.IpV4.Tcp.Http.IsResponse) 
            {
                statistics["http"]++;
                statistics["eth"]++;
                statistics["ip"]++;
            }
            if (packet.Ethernet.EtherType == EthernetType.IpV4)
            {
                statistics["eth"]++;
                statistics["ip"]++;
            }
            if (packet.DataLink.Kind == DataLinkKind.Ethernet) statistics["eth"]++;
        }
    }
}
