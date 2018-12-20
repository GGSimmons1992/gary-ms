using System;
using System.Collections.Generic;

namespace FizzbuzzConsole.client
{
  class Program
  {
    static void Main(string[] args)
    {
      FizzBuzzExercise(3,5,15,100);
    }

    public static void FizzBuzzExercise(int fizzNum,int buzzNum,int fizzbuzzNum,int final)
    {

      if (fizzNum != buzzNum)
      {
        Fizzy fizz = new Fizzy("fizz", fizzNum);
        Fizzy buzz = new Fizzy("buzz", buzzNum);


        if ((fizzbuzzNum > fizzNum) && (fizzbuzzNum > buzzNum))
        {
          Fizzy fizzbuzz = new Fizzy("fizzbuzz", fizzbuzzNum);

          int currentNumber = 0;
          while (fizzbuzz.count < final)
          {
            fizz.incrementer(currentNumber);
            buzz.incrementer(currentNumber);
            fizzbuzz.incrementer(currentNumber);
          }

          List<Fizzy> fizzyList = new List<Fizzy> { fizz, buzz, fizzbuzz };
          foreach(fizzy in fizzyList)
          {
            Console.WriteLine(String.Format("We have {0} {1}es",fizzy.counter,fizzy.name));
          }

        }
        else
        {
          Console.WriteLine("Fizzbuzznum is too small, please give Fizzbuzznum larger than fizznum and buzznum");
        }
      }
      else
      {
        Console.WriteLine("fizz and buzz need to be different numbers");
      }

      
    }
  }
}
