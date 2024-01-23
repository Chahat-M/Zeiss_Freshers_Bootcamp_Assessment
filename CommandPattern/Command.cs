using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//public delegate void Command();

//public class Command
//{
//    private Object targetObj;
//    private string methodName;

//    public Command(Object tgt, string name) { 
//        this.targetObj = tgt;
//        this.methodName = name;
//    }
//    public void Execute()
//    {
//        System.Reflection.MethodInfo methodDetails = targetObj.GetType().GetMethod(methodName);
//        if (methodDetails.ReturnType == typeof(void) && methodDetails.GetParameters().Length == 0 && methodDetails != null )
//        {
//            methodDetails.Invoke(targetObj, null);            
//        }
//    }
//}

