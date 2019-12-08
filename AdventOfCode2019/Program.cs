using System;
using System.IO;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        { 
            Day02 day02 = new Day02();
            string program = day02.LoadProgramFromFile();
            day02.LoadProgram(program);

            //before running the program, replace position 1 with the value 12 and replace position 2 with the value 2.
            //day02.WriteMemoryAtAdress(1, 12);
            //day02.WriteMemoryAtAdress(2, 2);
            int output = 0;
            bool found = false;
            int noun = 0;
            int verb = 0;
            for(noun=0;noun<=99 && !found; noun++)
            {
                
                

                for(verb=0;verb<=99 && !found; verb++)
                {
                    day02.SetNoun(noun);
                    day02.SetVerb(verb);
                    day02.RunProgram();

                    output = day02.GetOutput();
                    if (output == 19690720)
                        found = true;
                    day02.ResetProgram();
                }

                
            }

            if (found)
            {
                noun--;
                verb--;
                Console.WriteLine($"Found noun and verb! Noun={noun} Verb={verb}. Solution to puzzle is: {100 * noun + verb}");
            }   
            else
               Console.WriteLine("Did not find a noun and a verb!");
        }
    }
}
