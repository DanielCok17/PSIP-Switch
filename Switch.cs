using System.Threading;

namespace psip_zadanie
{
    class Switch
    {
        Port port1, port2;
        public Switch(Port port1, Port port2)
        {
            this.port1 = port1;
            this.port2 = port2;
        }
        public void start()
        {
            port1.openPort(1); //otvori obidva porty aby som mohol prijimat/posielat
            port2.openPort(1);
        }

        public void startSwitching()
        {
            Thread t1 = new Thread(() => { port1.mirrorPackets(port2); }); //Loopback1 to Loopback2
            Thread t2 = new Thread(() => { port2.mirrorPackets(port1); }); //Loopback2 to Loopback1
            t1.Start();
            t2.Start();
        }

        public void stopSwitching()
        {
            this.port1.stopMirroring();
            this.port2.stopMirroring();
        }
        
    }
}
