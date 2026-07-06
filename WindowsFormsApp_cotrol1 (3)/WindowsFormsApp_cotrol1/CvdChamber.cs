using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp_cotrol1.ChamberEnum;

namespace WindowsFormsApp_cotrol1
{
    // CVD(증착) 챔버 클래스

    //  CVD (증착) 챔버
    // - 가스 혼합 + 열 + 증착 공정 수행
    public class CvdChamber : ChamberBase
    {

        public double Temperature { get; set; }

        public enum CvdStep
        {
            PRE_HEATING,
            GAS_MIX,
            DEPOSITION,
            PURGE_COOL,
            DONE
        }

        public CvdStep Step { get; set; }

        public CvdChamber(IEG3268 ethercat) : base(ethercat)
        {
            Temperature = 600;
            Step = CvdStep.PRE_HEATING;
        }

        public override void OpenDoor()
        {
            // TODO: DO 제어
        }

        public override void CloseDoor()
        {
            // TODO: DO 제어
        }

        public override bool ProcessStartCondition()
        {
            // 인터락 연결 자리
            return true;
        }

        public override bool ProcessDoneCondition()
        {
            // 완료 조건 자리
            return true;
        }

        public override void UpdateProcess()
        {
            switch (state)
            {
                case ChamberStatus.DOOR_OPEN:
                    OpenDoor();
                    state = ChamberStatus.PROCESS;
                    break;

                case ChamberStatus.PROCESS:

                    if (!ProcessStartCondition())
                        return;

                    switch (Step)
                    {
                        case CvdStep.PRE_HEATING:
                            Step = CvdStep.GAS_MIX;
                            break;

                        case CvdStep.GAS_MIX:
                            Step = CvdStep.DEPOSITION;
                            break;

                        case CvdStep.DEPOSITION:
                            Step = CvdStep.PURGE_COOL;
                            break;

                        case CvdStep.PURGE_COOL:
                            Step = CvdStep.DONE;
                            break;

                        case CvdStep.DONE:
                            state = ChamberStatus.WAIT_DONE;
                            break;
                    }
                    break;

                case ChamberStatus.WAIT_DONE:

                    if (!ProcessDoneCondition())
                        return;

                    CloseDoor();

                    Step = CvdStep.PRE_HEATING;
                    state = ChamberStatus.IDLE;
                    break;
            }
        }
    }
}
