using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MonoMessageReciever : MonoBehaviour
{
    List<MethodInfo> updateMethods = new List<MethodInfo>();

    private void Start()
    {
        Type systemFunctionType = Type.GetType("SystemFunction");
        MethodInfo[] sysMethods= systemFunctionType.GetMethods(BindingFlags.Static|BindingFlags.Public);
        foreach(MethodInfo sysMethod in sysMethods)
        {
            if(sysMethod.GetCustomAttribute(typeof(UpdateAttr)) != null)
            {
                updateMethods.Add(sysMethod);
            }
        }

    }
    private void Update()
    {
        foreach(MethodInfo sysMethod in updateMethods)
        {
            sysMethod.Invoke(null,null);
        }
    }
}
