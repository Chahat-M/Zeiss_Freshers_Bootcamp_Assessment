using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NotifyPagerFeature : IDoorFeature
{
    public Action Activate => () => Console.WriteLine("Pager notified!");


}
