using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
      public class ChamberEnum
    {
        //    // 챔버 상태
        //    // 챔버의 현재 동작 상태
        //    public enum ChamberStatus
        //    {
        //        IDLE,       // 대기 상태
        //        RUNNING     // 공정 진행 중
        //    }

        //    // 타워램프 색상
        //    public enum LampColor
        //    {
        //        Yellow,     // 대기 상태
        //        Green       // 공정 진행 중
        //    }

        //    // 식각(Etch) 공정 단계
        //    public enum EtchStep
        //    {
        //        GAS_CHARGE,         // 가스 투입
        //        PRESSURE_STABLE,    // 압력 안정화
        //        PLASMA_ON,          // 플라즈마 생성
        //        PURGE               // 가스 배기
        //    }

        //    // 증착(CVD) 공정 단계
        //    public enum CvdStep
        //    {
        //        PRE_HEATING,        // 예열
        //        GAS_MIX,            // 가스 혼합
        //        DEPOSITION,         // 증착
        //        PURGE_COOL          // 배기 및 냉각
        //    }

        //    // 이온주입 공정 단계
        //    public enum ImplantStep
        //    {
        //        HIGH_VACUUM,        // 초고진공 형성
        //        SOURCE_ON,          // 이온원 ON
        //        BEAM_SCAN,          // 빔 조사
        //        BEAM_OFF            // 빔 OFF
        //    }

       
        public enum ChamberStatus
        {
            IDLE,
            DOOR_OPEN,
            PROCESS,
            WAIT_DONE,
            DOOR_CLOSE,
            ERROR
        }

        public enum LampColor
        {
            Yellow,
            Green
        }

        public enum EtchStep
        {
            GAS_CHARGE,
            PRESSURE_STABLE,
            PLASMA_ON,
            PURGE
        }

        public enum CvdStep
        {
            PRE_HEATING,
            GAS_MIX,
            DEPOSITION,
            PURGE_COOL
        }

        public enum ImplantStep
        {
            HIGH_VACUUM,
            SOURCE_ON,
            BEAM_SCAN,
            BEAM_OFF
        }



        public enum MainState
        {
            INIT,
            ROBOT_HOME,
            PICK_FOUP,
            PROCESS_ETCH,
            PROCESS_CVD,
            PROCESS_IMPLANT,
            RETURN_FOUP,
            COMPLETE,
            STOP
        }
    }
}
