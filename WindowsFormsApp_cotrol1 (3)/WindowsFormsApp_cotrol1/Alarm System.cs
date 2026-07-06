using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
   public  class Alarm_System
    {
        private IOMapper io;

        // 현재 알람 상태
        public bool IsAlarm { get; private set; }
        public string LastAlarmMessage { get; private set; }

        public Alarm_System(IOMapper mapper)
        {
            io = mapper;
        }

        // ==========================
        // PLC CYCLE CHECK
        // ==========================
        public void CheckAlarm()
        {
            // 이미 알람 상태면 추가 검사 X
            if (IsAlarm)
                return;

            // EMG (최우선)
            if (io.DI_Read(DI.EMG))
            {
                SetAlarm("EMG PRESSED");
                return;
            }

            // AIR PRESSURE
            if (!io.DI_Read(DI.MainPressure))
            {
                SetAlarm("AIR PRESSURE FAIL");
                return;
            }

            // VACUUM
            if (!io.DI_Read(DI.VacuumPressure))
            {
                SetAlarm("VACUUM FAIL");
                return;
            }
        }

        // ==========================
        // ALARM SET
        // ==========================
        private void SetAlarm(string msg)
        {
            IsAlarm = true;
            LastAlarmMessage = msg;
        }

        // ==========================
        // RESET (수동 복구)
        // ==========================
        public void ResetAlarm()
        {
            // 반드시 조건 확인 후 리셋 (안전)
            if (!io.DI_Read(DI.EMG) &&
                io.DI_Read(DI.MainPressure) &&
                io.DI_Read(DI.VacuumPressure))
            {
                IsAlarm = false;
                LastAlarmMessage = "";
            }
        }
    }
}

