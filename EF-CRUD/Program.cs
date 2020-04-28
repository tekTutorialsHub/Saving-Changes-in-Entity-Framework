using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            AddExample addExample = new AddExample();
            UpdateExample updateExample = new UpdateExample();
            DeleteExample deleteExample = new DeleteExample();



            addExample.Qry();

            //updateExample.Update();

            //deleteExample.Delete();


        }



    }
}
