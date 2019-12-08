using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019
{
    // Day 2: 1202 Program Alarm ---

    public class Day02
    {
        string programCode;
        List<int> integers;
        int instructionPointer;

        public Day02()
        {
            integers = new List<int>();
        }

        public void SetNoun(int n)
        {
            WriteMemoryAtAdress(1, n);
        }

        public void SetVerb(int n)
        {
            WriteMemoryAtAdress(2, n);
        }

        public int GetOutput()
        {
            return ReadMemoryAtAdress(0);
        }

        public int ReadMemoryAtAdress(int adress)
        {
            if (adress >= integers.Count)
                throw new ArgumentException("The pos is outside code");

            return integers[adress];
        }

        public bool WriteMemoryAtAdress(int adress, int value)
        {
            if (adress >= integers.Count)
                throw new ArgumentException("The pos is outside code");

            integers[adress] = value;

            return true;
        }

        public string GetIntegersAsString()
        {
            string str = string.Empty;
            foreach(var code in integers)
            {

                if (str.Length != 0)
                    str = string.Concat(str, ",");
                str = string.Concat(str, code.ToString());
            }

            return str;

        }

        public string LoadProgramFromFile()
        {
            return File.ReadAllText("input2.txt");

        }

        public void LoadProgram(string program)
        {
            programCode = program;

            if (programCode.Length == 0)
                throw new SystemException("Program not read from file");


            string[] strArray = programCode.Split(",");

            foreach (string str in strArray)
            {
                if (int.TryParse(str, out int n))
                    AddIntegerToMemory(n);
            }
        }


        public void ResetProgram()
        {
            integers.Clear();

            string[] strArray = programCode.Split(",");

            foreach (string str in strArray)
            {
                if(int.TryParse(str, out int n))
                    AddIntegerToMemory(n);
            }
        }

        public void RunProgram()
        {
            while (RunNextInstruction()) ;
        }

        public void AddIntegerToMemory(int n)
        {
            integers.Add(n);
            instructionPointer = 0; // Always after adding more code, reset pointer
        }

        public bool RunNextInstruction()
        {
            if (instructionPointer >= integers.Count)
                throw new SystemException("OP pointer outside code base");

            int adress1 = -1;
            int adress2 = -1;
            int adress3 = -1;

            switch(integers[instructionPointer])
            {
                case 1:
                    // Addition

                    adress1 = integers[instructionPointer + 1];
                    adress2 = integers[instructionPointer + 2];
                    adress3 = integers[instructionPointer + 3];
                    integers[adress3] = integers[adress1] + integers[adress2];

                    instructionPointer = instructionPointer + 4;
                    break;
                case 2:
                    // Multiplication

                    adress1 = integers[instructionPointer + 1];
                    adress2 = integers[instructionPointer + 2];
                    adress3 = integers[instructionPointer + 3];
                    integers[adress3] = integers[adress1] * integers[adress2];

                    instructionPointer = instructionPointer + 4;
                    break;
                case 99:
                    // End of program
                    return false;
                default:
                    throw new SystemException($"Unknown OP code {integers[instructionPointer]}");

            }

            return true;
        }
    }
}
