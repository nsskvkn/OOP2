using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.DAL;

namespace Lab3._5.BLL
{
    public readonly struct FileAccessResult
    {
        public readonly bool IsSuccess;
        public readonly string Message;
        public static FileAccessResult EmptySuccess => new FileAccessResult(true, string.Empty);

        public FileAccessResult(bool ok, string msg)
        {
            IsSuccess = ok;
            Message = msg;
        }
    }
}