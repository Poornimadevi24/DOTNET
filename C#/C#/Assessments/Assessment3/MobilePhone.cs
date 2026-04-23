using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    internal class MobilePhone
    {
        public delegate void RingEventHandling();
        public event RingEventHandling OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call..");
            if(OnRing!=null)
            {
                OnRing();
            }
        }
    }
    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }
    class ScreenDisplay
    {
        public void ShowInfo()
        {
            Console.WriteLine("Displaying Caller Information..");
        }

    }
    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating..");
        }
    }
    class Moblie
    {
        static void Main()
        {
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowInfo;
            phone.OnRing += vibration.Vibrate;
            phone.ReceiveCall();


        }
    }
}
