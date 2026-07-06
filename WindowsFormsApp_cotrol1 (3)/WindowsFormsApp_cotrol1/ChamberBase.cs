using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp_cotrol1.ChamberEnum;


namespace WindowsFormsApp_cotrol1
{

    // 모든 챔버의 부모 클래스
    // 공통 속성과 기능을 정의
    public abstract class ChamberBase
    {

        protected IEG3268 EtherCAT;


        //  챔버 상태 (PLC Step 구조)
        public ChamberStatus state;

        // 공정 타이머 (단순 시간 기반 시뮬레이션)
        protected int timer = 0;

        public ChamberBase(IEG3268 eth)
        {
            EtherCAT = eth;
            state = ChamberStatus.IDLE;
        }

        //  도어 제어 (각 챔버별 구현)
        public abstract void OpenDoor();
        public abstract void CloseDoor();

        //  공정 시작 조건
        public abstract bool ProcessStartCondition();

        //  공정 완료 조건
        public abstract bool ProcessDoneCondition();

        //  PLC Scan에서 계속 호출
        public virtual void UpdateProcess()
        {
            switch (state)
            {
                case ChamberStatus.DOOR_OPEN:
                    // 문 열기 실행
                    OpenDoor();

                    // 다음 단계 이동
                    state = ChamberStatus.PROCESS;
                    break;

                case ChamberStatus.PROCESS:
                    // 공정 시작 조건 확인
                    if (!ProcessStartCondition()) return;

                    // 시간 흐름 시뮬레이션
                    timer++;

                    // 일정 시간 후 다음 단계
                    if (timer > 10)
                    {
                        timer = 0;
                        state = ChamberStatus.WAIT_DONE;
                    }
                    break;

                case ChamberStatus.WAIT_DONE:
                    // 공정 완료 조건 확인
                    if (!ProcessDoneCondition()) return;

                    // 다음 단계: 도어 닫기
                    state = ChamberStatus.DOOR_CLOSE;
                    break;

                case ChamberStatus.DOOR_CLOSE:
                    // 문 닫기 실행
                    CloseDoor();

                    // 초기 상태 복귀
                    state = ChamberStatus.IDLE;
                    break;
            }
        }
    }
}


