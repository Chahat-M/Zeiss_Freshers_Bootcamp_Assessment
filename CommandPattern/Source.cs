using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Source
{
    private Action commandObj;

    public void SetCommand(Action cmd) { 
        this.commandObj = cmd;
    }

    public void TriggerCommand()
    {
        commandObj.Invoke();
    }
}

