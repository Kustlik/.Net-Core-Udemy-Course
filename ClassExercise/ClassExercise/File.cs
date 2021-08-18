using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExercise
{
    /* First Part of Exercise
    abstract class File
    {
        public string FileName { get; set; }
        public int Size { get; set; }
        public DateTime CreatedOn { get; set; }
        protected string ProtectedProp { get; set; }
        private string PrivateProp { get; set; }
        public abstract void Compress();
    }
    */
    interface IFile
    {
        string FileName { get; set; }
        int Size { get; set; }
        DateTime CreatedOn { get; set; }
        void Compress();
    }
}
