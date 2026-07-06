using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
    // 장비 전체 안전 조건을 관리하는 핵심 클래스
    // Robot / Chamber 동작 허가 여부 판단
    public class InterlockEngine
    {
        private IOMapper io;

        public InterlockEngine(IOMapper mapper)
        {
            io = mapper;
        }

        // ==========================
        // EMERGENCY STOP
        // ==========================
        public bool Emergency()
        {
            return io.DI_Read(DI.EMG);
        }

        // ==========================
        // POWER
        // ==========================
        public bool PowerOK()
        {
            return io.DI_Read(DI.Power1) &&
                   io.DI_Read(DI.Power2);
        }

        // ==========================
        // AIR PRESSURE
        // ==========================
        public bool PressureOK()
        {
            return io.DI_Read(DI.MainPressure);
        }

        // ==========================
        // VACUUM
        // ==========================
        public bool VacuumOK()
        {
            return io.DI_Read(DI.VacuumPressure);
        }

        // ==========================
        // SYSTEM OK (핵심 게이트)
        // ==========================
        public bool SystemOK()
        {
            return PowerOK() &&
                   PressureOK() &&
                   VacuumOK() &&
                   !Emergency();
        }

        // ==========================
        // ROBOT ENABLE
        // ==========================
        public bool RobotEnable()
        {
            return SystemOK();
        }

        // ==========================
        // HOME / MOVE ENABLE
        // ==========================
        public bool MotionEnable()
        {
            return SystemOK() &&
                   io.DI_Read(DI.RobotBackwardSensor);
        }

        // ==========================
        // PROCESS ENABLE
        // ==========================
        public bool ProcessEnable()
        {
            return SystemOK();
        }

        // ==========================
        // ALARM CHECK
        // ==========================
        public bool IsAlarm()
        {
            return !SystemOK();
        }

        // ==========================
        // DOOR SENSOR
        // ==========================
        public bool DoorA_Open() => io.DI_Read(DI.A_DoorUpSensor);
        public bool DoorA_Close() => io.DI_Read(DI.A_DoorDownSensor);

        public bool DoorB_Open() => io.DI_Read(DI.B_DoorUpSensor);
        public bool DoorB_Close() => io.DI_Read(DI.B_DoorDownSensor);

        public bool DoorC_Open() => io.DI_Read(DI.C_DoorUpSensor);
        public bool DoorC_Close() => io.DI_Read(DI.C_DoorDownSensor);
    }
}
