using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
   public class DI
    {

        // POWER / SYSTEM
       
        public const int Power1 = 0;
        public const int Power2 = 1;

        // MODE / EMERGENCY
        
        public const int SelectSW = 2;
        public const int EMG = 3;          //  Emergency Stop (핵심)

        // PRESSURE

        public const int MainPressure = 5;

        // CHAMBER A SENSORS

        public const int A_DoorUpSensor = 6;
        public const int A_DoorDownSensor = 7;

        // CHAMBER B SENSORS

        public const int B_DoorUpSensor = 8;
        public const int B_DoorDownSensor = 9;

        // CHAMBER C SENSORS

        public const int C_DoorUpSensor = 10;
        public const int C_DoorDownSensor = 11;
       
        // ROBOT CYLINDER SENSORS     
        public const int RobotBackwardSensor = 12;
        public const int RobotForwardSensor = 13;

        // VACUUM SENSO
        public const int VacuumPressure = 14;     // 진공 정상
    }
}

