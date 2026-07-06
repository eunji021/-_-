using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static WindowsFormsApp_cotrol1.ChamberEnum;

namespace WindowsFormsApp_cotrol1
{
    // Etch(식각) 챔버 클래스
    //  Etch (식각) 챔버
    // - 가스 + RF + 플라즈마 기반 공정

    public class EtchChamber : ChamberBase

    {
        // 공정 변수
        // ==========================
        public double GasFlowCF4 { get; set; }
        public double RfPower { get; set; }
        public double Pressure { get; set; }

        // ==========================
        // 내부 공정 Step
        // ==========================
        public enum EtchStep
        {
            GAS_CHARGE,
            PRESSURE_STABLE,
            PLASMA_ON,
            PURGE,
            DONE
        }

        public EtchStep Step { get; set; }

        // ==========================
        // 생성자
        // ==========================
        public EtchChamber(IEG3268 ethercat) : base(ethercat)
        {
            GasFlowCF4 = 45.2;
            RfPower = 300;
            Pressure = 0.05;

            Step = EtchStep.GAS_CHARGE;
        }

        // ==========================
        // DOOR OPEN
        // ==========================
        public override void OpenDoor()
        {
            // TODO: DO 제어 (A_DoorUp 등)
            // EtherCAT DO 연결 필요
        }

        // ==========================
        // DOOR CLOSE
        // ==========================
        public override void CloseDoor()
        {
            // TODO: DO 제어 (A_DoorDown 등)
        }

        // ==========================
        // 공정 시작 조건
        // ==========================
        public override bool ProcessStartCondition()
        {
            // 예: 압력 안정 + 인터락 OK
            return true;
        }

        // ==========================
        // 공정 완료 조건
        // ==========================
        public override bool ProcessDoneCondition()
        {
            // 예: 시간 + 센서 완료
            return true;
        }

        // ==========================
        // 핵심 PLC 업데이트
        // ==========================
        public override void UpdateProcess()
        {
            switch (state)
            {
                // ======================
                // 1. DOOR OPEN
                // ======================
                case ChamberStatus.DOOR_OPEN:

                    OpenDoor();
                    state = ChamberStatus.PROCESS;
                    break;

                // ======================
                // 2. PROCESS (ETCH 진행)
                // ======================
                case ChamberStatus.PROCESS:

                    // 시작 조건 체크
                    if (!ProcessStartCondition())
                        return;

                    switch (Step)
                    {
                        case EtchStep.GAS_CHARGE:
                            Step = EtchStep.PRESSURE_STABLE;
                            break;

                        case EtchStep.PRESSURE_STABLE:
                            Step = EtchStep.PLASMA_ON;
                            break;

                        case EtchStep.PLASMA_ON:
                            Step = EtchStep.PURGE;
                            break;

                        case EtchStep.PURGE:
                            Step = EtchStep.DONE;
                            break;

                        case EtchStep.DONE:
                            state = ChamberStatus.WAIT_DONE;
                            break;
                    }

                    break;

                // ======================
                // 3. WAIT DONE
                // ======================
                case ChamberStatus.WAIT_DONE:

                    // 완료 조건 체크
                    if (!ProcessDoneCondition())
                        return;

                    CloseDoor();

                    // 초기화
                    Step = EtchStep.GAS_CHARGE;
                    state = ChamberStatus.IDLE;
                    break;
            }
        }
    }
}

