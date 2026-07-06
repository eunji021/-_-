using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
    public class Robot
    {

        private IOMapper io;
        private MotionController motion;
        private InterlockEngine interlock;

        private bool isEmergencyStop = false;

        public Robot(IOMapper iomapper, MotionController motionController, InterlockEngine interlockEngine)
        {
            io = iomapper;
            motion = motionController;
            interlock = interlockEngine;
        }

        //  EMERGENCY STOP
        public void EmergencyStop()
        {
            isEmergencyStop = true;

            motion.StopAll();
        }

        public void EmergencyReset()
        {
            isEmergencyStop = false;
        }

        //  SAFETY CHECK
        private bool SafetyOK()
        {
            return !isEmergencyStop && interlock.SystemOK();
        }

        //  HOME
        public void Home()
        {
            if (!SafetyOK()) return;

            if (!interlock.HomeEnable()) return;

            MoveTo(RobotPosition.Home_X, RobotPosition.Home_Z);
        }


        //  MOVE (핵심 수정: WAIT 추가)
        public void MoveTo(long x, long z)
        {
            if (!SafetyOK()) return;

            // 이동 중이면 다른 명령 금지
            if (motion.IsBusy())
                return;

            motion.MoveX(x);
            motion.MoveZ(z);

            while (motion.IsBusy())
            {
                // Timeout 발생 시 비상정지
                if (motion.IsTimeout())
                {
                    EmergencyStop();
                    return;
                }

                System.Threading.Thread.Sleep(10);
            }
        }



        //  PICK
        public void Pick()
        {
            if (!SafetyOK()) return;

            if (!interlock.VacuumOK())
                return;

            io.DO_Write(DO.VacuumOn, true);

            System.Threading.Thread.Sleep(100);
        }

        //  PLACE
        public void Place()
        {
            if (!SafetyOK()) return;

            io.DO_Write(DO.VacuumOn, false);

            System.Threading.Thread.Sleep(100);
        }


        //  FOUP PICK
        public void PickFromFOUP_A(int slot)
        {
            if (!SafetyOK()) return;

            long down = RobotPosition.FOUP_A_Slot1_Down;

            switch (slot)
            {
                case 1:
                    down = RobotPosition.FOUP_A_Slot1_Down;
                    break;

                case 2:
                    down = RobotPosition.FOUP_A_Slot2_Down;
                    break;

                case 3:
                    down = RobotPosition.FOUP_A_Slot3_Down;
                    break;

                case 4:
                    down = RobotPosition.FOUP_A_Slot4_Down;
                    break;

                case 5:
                    down = RobotPosition.FOUP_A_Slot5_Down;
                    break;
            }

            MoveTo(RobotPosition.FOUP_A_X, RobotPosition.Safe_Z);
            MoveTo(RobotPosition.FOUP_A_X, down);

            Pick();

            MoveTo(RobotPosition.FOUP_A_X, RobotPosition.Safe_Z);
        }

        //  CHAMBER PLACE
        public void PlaceToChamber(char chamber)
        {
            if (!SafetyOK()) return;

            long x = 0;
            long down = 0;

            switch (chamber)
            {
                case 'A':
                    x = RobotPosition.CH_A_X;
                    down = RobotPosition.CH_A_Down;
                    break;

                case 'B':
                    x = RobotPosition.CH_B_X;
                    down = RobotPosition.CH_B_Down;
                    break;

                case 'C':
                    x = RobotPosition.CH_C_X;
                    down = RobotPosition.CH_C_Down;
                    break;
            }

            MoveTo(x, RobotPosition.Safe_Z);
            MoveTo(x, down);

            Place();

            MoveTo(x, RobotPosition.Safe_Z);
        }
    }
}

