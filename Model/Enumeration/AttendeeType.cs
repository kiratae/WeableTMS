using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Model.Enumeration
{
    public enum AttendeeType : byte
    {
        //ประเภทผู้เข้าร่วมการฝึกอบรม
        Mediator = 1,
        People = 2,
        MediatorAndPeople = 3,
    }
}
