using System;
using System.Collections.Generic;
using System.Text;

namespace VarianceWorld.Domain.Models
{
    public class Casting
    {
        public void Implicit()
        {
            int x = 10;
            long y = x;
            Console.WriteLine(y);
        }
        public void Explicit()
        {
            short x = 10;
            byte y = (byte)x;//throws exception if not able to cast (like first)
            Nullable<byte> z = x as Nullable<byte>;//raises a null value if not able to cast. (like firstOrDefault)

            Console.WriteLine(y);
        }

        public IEnumerable<byte?> Explicit(short x)
        {
            byte y = (byte) x;
            byte? z = x as byte?;

            //return new { y1=y,z1=z};//Anonymous object
            return new byte?[]{ y, z };
        }

        public void Explicit(short x, out byte y, out byte? z)
        {
            y = (byte)x;
            z = x as byte?;
        }

        public void Explicit(ref short w,ref short x,out byte y, out byte? z)
        {
            x = 100;
            w = x;
            y = (byte)w;
            z = w as byte?;//You shouldn't do this. As should only be used as reference.
        }

        public void Explicit(short w, short x)
        {
            x = 100;
            w = x;
        }

        public void Converting()
        {
            int x = Convert.ToInt16(true);//This will help convert booleans to ones and zeros
            bool y = Convert.ToBoolean(x);
            int z = Convert.ToInt32("banana");
        }

        public int? ConvertingInt(string s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {

                return null;
            }
        }
        
    }
}
