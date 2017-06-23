using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.ViewModels
{
    public class ErrorVM
    {
        public ErrorVM(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}