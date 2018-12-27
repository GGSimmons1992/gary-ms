using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateWorld.Domain.Models
{
    public class Boxing
    {
        public object Shipping()
        {
            string content = "happy new year";
            object box = content;
            box = null;
            content = null;

            int? num = 10;
            object box2 = num;
            //box2 = null;
            return box2;
        }

        public void OpenTheBox()
        {
            var elf = (new Boxing()).Shipping();
            var content = (int) elf;
        }
    }
}
