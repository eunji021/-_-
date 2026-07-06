using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
   public class DO
   {
        // TOWER LAMP (장비 상태 표시)
     
        public const int TowerRed = 0;     // ALARM
        public const int TowerYellow = 1;  // READY
        public const int TowerGreen = 2;   // RUN

        // CHAMBER A
    
        public const int A_Lamp = 3;
        public const int A_DoorUp = 4;
        public const int A_DoorDown = 5;

        // CHAMBER B
 
        public const int B_Lamp = 6;
        public const int B_DoorUp = 7;
        public const int B_DoorDown = 8;

        // CHAMBER C
        public const int C_Lamp = 9;
        public const int C_DoorUp = 10;
        public const int C_DoorDown = 11;

        // ROBOT CYLINDER
       
        public const int RobotForward = 12;
        public const int RobotBackward = 13;

        // VACUUM SYSTEM
        public const int VacuumOn = 14;
        public const int VacuumOff = 15;
    }
}
