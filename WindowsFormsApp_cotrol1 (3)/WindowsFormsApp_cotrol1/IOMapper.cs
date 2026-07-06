using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_cotrol1
{
    // EtherCAT Digital Input / Output 제어 클래스
    // Robot, Chamber, Alarm, Interlock에서 공통으로 사용
    public class IOMapper
    {
        private IEG3268 eth;

        // 생성자
        public IOMapper(IEG3268 ethercat)
        {
            eth = ethercat;
        }

        // ================================
        // DIGITAL OUTPUT (DO)
        // ================================
        // 출력 신호 ON / OFF
        public void DO_Write(int address, bool value)
        {
            eth.Digital_Output(address, value);

            // 디버깅용 로그
            Console.WriteLine($"[DO] Addr : {address}, Value : {value}");
        }

        // ================================
        // DIGITAL INPUT (DI)
        // ================================
        // 입력 신호 읽기
        public bool DI_Read(int address)
        {
            bool value = eth.Digital_Input(address);

            // 디버깅용 로그
            Console.WriteLine($"[DI] Addr : {address}, Value : {value}");

            return value;
        }

        // ================================
        // ALL OUTPUT OFF
        // ================================
        // EMG 또는 Alarm 발생 시 모든 출력 OFF
        public void AllOutputOff()
        {
            for (int i = 0; i <= 15; i++)
            {
                eth.Digital_Output(i, false);
            }

            Console.WriteLine("[DO] ALL OUTPUT OFF");
        }
    }
}
