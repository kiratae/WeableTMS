using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Enumeration
{
    public enum TrainingStatus : byte
    {
        //สถานะการอบรม
        WaitOpen = 1,
        Open = 2,
        Close = 3,
        Already = 4
    }
}
