using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RingBuzzerFeature : IDoorFeature
{
    public Action Activate => () => Console.WriteLine("Buzzer is ringing!");
}
