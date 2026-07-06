using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
    // 로봇 위치 값
     public  class RobotPosition
    {


        // HOME 위치
   
        public const long Home_X = 0;
        public const long Home_Z = 0;

        // PICK 위치 (작업 높이)
        public const long Pick_Z = 50;

        // SAFE 위치 (이동용 높이)
        public const long Safe_Z = 200;


   
        // FOUP A (좌/우 = 14140)
        public const long FOUP_A_X = 14140;

        public const long FOUP_A_Slot1_Up = 302380;
        public const long FOUP_A_Slot1_Down = 102379;

        public const long FOUP_A_Slot2_Up = 982378;
        public const long FOUP_A_Slot2_Down = 782378;

        public const long FOUP_A_Slot3_Up = 1627604;
        public const long FOUP_A_Slot3_Down = 1432388;

        public const long FOUP_A_Slot4_Up = 2332102;
        public const long FOUP_A_Slot4_Down = 2119399;

        public const long FOUP_A_Slot5_Up = 3018457;
        public const long FOUP_A_Slot5_Down = 2818463;


        //  FOUP B (좌/우 = -394293)
        public const long FOUP_B_X = -394293;

        public const long FOUP_B_Slot1_Up = 302380;
        public const long FOUP_B_Slot1_Down = 102379;

        public const long FOUP_B_Slot2_Up = 982378;
        public const long FOUP_B_Slot2_Down = 782378;

        public const long FOUP_B_Slot3_Up = 1627604;
        public const long FOUP_B_Slot3_Down = 1432388;

        public const long FOUP_B_Slot4_Up = 2332102;
        public const long FOUP_B_Slot4_Down = 2119399;

        public const long FOUP_B_Slot5_Up = 3018457;
        public const long FOUP_B_Slot5_Down = 2818463;


        //  CHAMBER A
        public const long CH_A_X = 62000;

        public const long CH_A_Up = 1156931;
        public const long CH_A_Down = 806931;



        //  CHAMBER B
        public const long CH_B_X = 190823;

        public const long CH_B_Up = 1156931;
        public const long CH_B_Down = 806931;


 
        //  CHAMBER C

        public const long CH_C_X = 322000;

        public const long CH_C_Up = 1156931;
        public const long CH_C_Down = 806931;
    }
}

