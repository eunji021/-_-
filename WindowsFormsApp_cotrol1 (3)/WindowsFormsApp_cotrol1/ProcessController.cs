using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Windows Forms(UI) 기능을 사용하기 위한 라이브러리
//
// 버튼(Button), 라벨(Label), 폼(Form)
//  타이머(Timer), 메시지박스(MessageBox)
//  화면(UI) 이벤트 처리 기능 포함
//
//  WinForms 기반 자동화 프로그램에서 반드시 필요
//  Robot / ProcessController Timer 동작에도 사용됨

namespace WindowsFormsApp_cotrol1
{
     public class ProcessController
    {
        private Robot robot;
        private EtchChamber etch;
        private CvdChamber cvd;
        private ImplantChamber implant;
        private InterlockEngine interlock;
        private Alarm_System alarm;

        private int wafer = 1;
        private int step = 0;

        public ProcessController(
            Robot r,
            EtchChamber e,
            CvdChamber c,
            ImplantChamber i,
            InterlockEngine inter,
            Alarm_System a)
        {
            robot = r;
            etch = e;
            cvd = c;
            implant = i;
            interlock = inter;
            alarm = a;
        }

        // ==========================
        // ALL STOP
        // ==========================
        private void AllStop()
        {
            robot.EmergencyStop();

            etch.state = ChamberEnum.ChamberStatus.IDLE;
            cvd.state = ChamberEnum.ChamberStatus.IDLE;
            implant.state = ChamberEnum.ChamberStatus.IDLE;
        }

        // ==========================
        // PLC SCAN
        // ==========================
        public void Scan()
        {
            // 1. ALARM
            alarm.CheckAlarm();
            if (alarm.IsAlarm)
            {
                AllStop();
                return;
            }

            // 2. INTERLOCK
            if (!interlock.SystemOK())
            {
                AllStop();
                return;
            }

            switch (step)
            {
                // ======================
                // HOME
                // ======================
                case 0:
                    robot.Home();
                    step = 1;
                    break;

                // ======================
                // PICK
                // ======================
                case 1:
                    robot.PickFromFOUP_A(wafer);
                    step = 2;
                    break;

                // ======================
                // ETCH
                // ======================
                case 2:
                    etch.UpdateProcess();

                    if (etch.state != ChamberEnum.ChamberStatus.IDLE)
                        return;

                    step = 3;
                    break;

                // ======================
                // CVD
                // ======================
                case 3:
                    cvd.UpdateProcess();

                    if (cvd.state != ChamberEnum.ChamberStatus.IDLE)
                        return;

                    step = 4;
                    break;

                // ======================
                // IMPLANT
                // ======================
                case 4:
                    implant.UpdateProcess();

                    if (implant.state != ChamberEnum.ChamberStatus.IDLE)
                        return;

                    step = 5;
                    break;

                // ======================
                // RETURN
                // ======================
                case 5:
                    robot.MoveTo(
                        RobotPosition.FOUP_A_X,
                        RobotPosition.Safe_Z
                    );

                    wafer++;
                    step = (wafer > 5) ? 99 : 1;
                    break;

                // ======================
                // END
                // ======================
                case 99:
                    AllStop();
                    break;
            }
        }
    }
}

