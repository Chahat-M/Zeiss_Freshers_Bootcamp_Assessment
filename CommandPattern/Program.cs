using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        //Source srcObj = new Source();
        //Target tgtObj = new Target();
        //Command cmdObj = new Command(tgtObj.ExecuteTask);
        ////srcObj.SetCommand(cmdObj);
        ////srcObj.TriggerCommand();

        //Target2 tgtObj2 = new Target2();
        //Command cmdObj2 = new Command(tgtObj2.DoTask);
        ////srcObj.SetCommand(cmdObj2);
        ////srcObj.TriggerCommand();

        //Target3 tgtObj3 = new Target3();
        //Command cmdObj3 = new Command(tgtObj3.InvokeTask);
        ////srcObj.SetCommand(cmdObj3);
        ////srcObj.TriggerCommand();

        //cmdObj += cmdObj2 + cmdObj3;    /* Multicast objects in one */
        //Command compositeCommand = cmdObj2 + cmdObj3;   /* Compiler will auto-generate the below code */
        /*Command compositeCommand = System.Delegate.Combine(cmdObj, cmdObj2, cmdObj3) as Command;*/


        // Using Built-in Delegates

        Source srcObj = new Source();
        Target tgtObj = new Target();
        Target2 tgtObj2 = new Target2();
        Target3 tgtObj3 = new Target3();

        Action delObj1 = new Action(tgtObj.ExecuteTask);
        Action delObj2 = new Action(tgtObj2.DoTask);
        Action delObj3 = new Action(tgtObj3.InvokeTask);

        Action compositeCommand2 = delObj1 + delObj2 + delObj3;
        srcObj.SetCommand(compositeCommand2);
        srcObj.TriggerCommand();
    }
    
}
