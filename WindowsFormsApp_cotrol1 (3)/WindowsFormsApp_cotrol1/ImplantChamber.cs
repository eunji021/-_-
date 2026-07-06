using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp_cotrol1.ChamberEnum;

namespace WindowsFormsApp_cotrol1
{
    // Implant(이온주입) 챔버 클래스

    //  Implant (이온주입) 챔버
    // - 고에너지 이온 빔을 이용한 공정

    public class ImplantChamber : ChamberBase
    {
        public double BeamCurrent { get; set; }

        public enum ImplantStep
        {
            HIGH_VACUUM,
            SOURCE_ON,
            BEAM_SCAN,
            BEAM_OFF,
            DONE
        }

        public ImplantStep Step { get; set; }

        public ImplantChamber(IEG3268 ethercat) : base(ethercat)
        {
            BeamCurrent = 15.5;
            Step = ImplantStep.HIGH_VACUUM;
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
            return true;
        }

        public override bool ProcessDoneCondition()
        {
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
                        case ImplantStep.HIGH_VACUUM:
                            Step = ImplantStep.SOURCE_ON;
                            break;

                        case ImplantStep.SOURCE_ON:
                            Step = ImplantStep.BEAM_SCAN;
                            break;

                        case ImplantStep.BEAM_SCAN:
                            Step = ImplantStep.BEAM_OFF;
                            break;

                        case ImplantStep.BEAM_OFF:
                            Step = ImplantStep.DONE;
                            break;

                        case ImplantStep.DONE:
                            state = ChamberStatus.WAIT_DONE;
                            break;
                    }
                    break;

                case ChamberStatus.WAIT_DONE:

                    if (!ProcessDoneCondition())
                        return;

                    CloseDoor();

                    Step = ImplantStep.HIGH_VACUUM;
                    state = ChamberStatus.IDLE;
                    break;
            }
        }
    }

}