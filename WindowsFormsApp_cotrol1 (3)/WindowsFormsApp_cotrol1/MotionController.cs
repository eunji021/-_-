using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp_cotrol1.RobotPosition;

namespace WindowsFormsApp_cotrol1
{
    public class MotionController
    {
        private IEG3268 eth;

        public bool busyX;
        public bool busyZ;

        private DateTime xStartTime;
        private DateTime zStartTime;

        private int timeoutMs = 5000;

        public MotionController(IEG3268 ethercat)
        {
            eth = ethercat;
        }

        // ==========================
        // Z JOG UP (안전 상승)
        // ==========================
        public void JogZ_Up()
        {
            eth.Axis1_UD_POS_Update(Safe_Z);
            eth.Axis1_UD_Move_Send();

            busyZ = true;
            zStartTime = DateTime.Now;
        }

        // ==========================
        // Z HOME
        // ==========================
        public void HomeZ()
        {
            eth.Axis1_UD_POS_Update(Home_Z);
            eth.Axis1_UD_Move_Send();

            busyZ = true;
            zStartTime = DateTime.Now;
        }

        // ==========================
        // X HOME
        // ==========================
        public void HomeX()
        {
            eth.Axis2_LR_POS_Update(Home_X);
            eth.Axis2_LR_Move_Send();

            busyX = true;
            xStartTime = DateTime.Now;
        }

        // ==========================
        // 상태 체크
        // ==========================
        public bool IsBusy() => busyX || busyZ;

        public bool IsTimeout()
        {
            if (busyZ && (DateTime.Now - zStartTime).TotalMilliseconds > timeoutMs)
                return true;

            if (busyX && (DateTime.Now - xStartTime).TotalMilliseconds > timeoutMs)
                return true;

            return false;
        }

        public void Update()
        {
            if (busyZ && (DateTime.Now - zStartTime).TotalMilliseconds > 300)
                busyZ = false;

            if (busyX && (DateTime.Now - xStartTime).TotalMilliseconds > 300)
                busyX = false;
        }
    }
}

