using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MonoBrickFirmware.Display;
using MonoBrickFirmware.Movement;
using MonoBrickFirmware.Sensors;
using MonoBrickFirmware.Sound;

namespace Aufgabe_6._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Motor motorRechts = new Motor(MotorPort.OutC);
            Motor motorLinks = new Motor(MotorPort.OutB);
            EV3UltrasonicSensor ultraschallSensor = new EV3UltrasonicSensor(SensorPort.In1);

            while (true)
            {
                int entfernung = ultraschallSensor.Read();
                Speaker lautsprecher = new Speaker(50);
                int tonDauer = entfernung / 150;

                if (entfernung < 5)
                {
                    //Der Roboter bleibt stehen
                    motorRechts.Off();
                    motorLinks.Off();
                    lautsprecher.Beep(0);
                    break;
                }

                //Der Roboter fährt rückwärts & ein Piepton ist zu hören
                else if (entfernung < 30) 
                {
                    Fahren(motorRechts, motorLinks, -10);
                    lautsprecher.Beep((ushort)tonDauer);
                }

                else
                {
                    Fahren(motorRechts, motorLinks, 20);
                }

            }
        }
        private static void Fahren(Motor motorRechts, Motor motorLinks, sbyte geschwindigkeit)
        {
            motorRechts.SetSpeed(geschwindigkeit);
            motorLinks.SetSpeed(geschwindigkeit);
        }
    }
}
