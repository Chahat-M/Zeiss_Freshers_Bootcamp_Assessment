using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AutoCloseFeature : IDoorFeature
{
    private readonly bool autoCloseCondition;

    public AutoCloseFeature(bool condition)
    {
        autoCloseCondition = condition;
    }

    public Action Activate => () =>
    {
        if (autoCloseCondition == true)
        {
            Console.WriteLine("Auto-closing the door!");
        }
    };
}
