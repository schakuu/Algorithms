using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution {
    class Solution {
        static void Main1(string[] args) {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            
            // get input
            var _input = int.Parse(Console.ReadLine());
            
            for (int _i = 1; _i <= _input; _i++) {
                var _r3 = _i % 3;
                var _r5 = _i % 5;
                var _r15 = _i % 15;
                
                //if (_r15 == 0)
                //    Console.WriteLine("FizzBuzz");
                //else {
                //    if (_r5 == 0) 
                //        Console.WriteLine("Buzz");
                //    else {
                //        if (_r3 == 0)
                //            Console.WriteLine("Fizz");
                //        else
                //            Console.WriteLine(_i);
                //        }
                //    }

                if (_r3 == 0)
                {
                    Console.Write("Fizz");
                    if (_r5 == 0)
                        Console.WriteLine("Buzz");
                    else
                        Console.WriteLine("");
                }
                else
                {
                    if (_r5 == 0)
                        Console.WriteLine("Buzz");
                    else
                        Console.WriteLine(_i);
                }
                }
                
            }
        }
    }
