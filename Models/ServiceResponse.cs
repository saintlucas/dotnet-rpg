using System.ComponentModel;
using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.AccessControl;

namespace dotnet_rpg.Models
{
    public class ServiceResponse<T>
    {
        public T Data {get; set;}
        
        public bool Success {get; set;} = true;
        
        public string Message {get; set;} = null;
    }
}