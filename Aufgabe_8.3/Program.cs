using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonoBrickFirmware.Display;
using MonoBrickFirmware.Movement;
using MonoBrickFirmware.Sensors;

namespace Aufgabe_8._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Motor motorRechts = new Motor(MotorPort.OutC);
            Motor motorLinks = new Motor(MotorPort.OutB);
            EV3TouchSensor beschleunigungSensor = new EV3TouchSensor(SensorPort.In4);
            EV3TouchSensor verlangsammungSensor = new EV3TouchSensor(SensorPort.In1);

            sbyte geschwindigkeit = 0;

            while (true)
            {
                if (beschleunigungSensor.IsPressed())
                {
                    // In 10er Einheiten beschleunigen 
                    Beschleunigung(motorRechts, motorLinks, geschwindigkeit);
                }

                else if (verlangsammungSensor.IsPressed())
                {
                    // In 10er Einheiten abbremsen 
                    Verlangsammung(motorRechts, motorLinks, geschwindigkeit);
                }

                else
                {
                    motorRechts.SetSpeed(geschwindigkeit);
                    motorLinks.SetSpeed(geschwindigkeit);
                }

                //Der Wert der Geschwindigkeit wird auf das Display angezeigt 
                LcdConsole.WriteLine("Geschwindigkeit:" + Convert.ToString(geschwindigkeit));
            }
        }
        private static void Beschleunigung(Motor motorRechts, Motor motorLinks, sbyte geschwindigkeit)
        {
            motorRechts.SetSpeed((sbyte)(geschwindigkeit + 10));
            motorLinks.SetSpeed((sbyte)(geschwindigkeit + 10));
        }
        private static void Verlangsammung(Motor motorRechts, Motor motorLinks, sbyte geschwindigkeit)
        {
            motorRechts.SetSpeed((sbyte)(geschwindigkeit - 10));
            motorLinks.SetSpeed((sbyte)(geschwindigkeit - 10));
        }
    }
}
