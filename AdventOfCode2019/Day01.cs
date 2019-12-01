using System;
namespace AdventOfCode2019
{
    //--- Day 1: The Tyranny of the Rocket Equation ---
    
    public class Day01
    {
        TextFileReader tfr;
        int totalFuel = 0;
        int[] moduleFuel;
        int[] moduleMass;

        public int TotalFuel { get => totalFuel; set => totalFuel = value; }
        public int[] ModuleFuel { get => moduleFuel; set => moduleFuel = value; }
        public int[] ModuleMass { get => moduleMass; set => moduleMass = value; }

        public Day01()
        {
            tfr = new TextFileReader("input.txt");

            if (tfr.NumberOfLines == 0)
                throw new SystemException("Could not read any lines from file");

            ModuleMass = new int[tfr.NumberOfLines];

            ConvertFromStringToInt(tfr.Lines, tfr.NumberOfLines);
            
        }

        private void ConvertFromStringToInt(string[] lines, int numLines)
        {
            for (int i = 0; i < numLines; i++)
            {
                ModuleMass[i] = Convert.ToInt32(lines[i]);
            }
        }

        public int CalcFuelByMass(int mass)
        {
            return ((int)(mass / 3)) - 2;
        }

        public int CalcFuelByMassAndFuel(int mass)
        {
            int fuelForMass = ((int)(mass / 3)) - 2;

            int fuelForFuelMass = CalcFuelForFuel(fuelForMass);

            return fuelForMass + fuelForFuelMass;
        }

        public int CalcFuelForFuel(int fuel)
        {
            int extraFuel = 0;
            int temp = 0;

            temp = CalcFuelByMass(fuel);
            while(temp >= 0)
            {
                extraFuel += temp;
                temp = CalcFuelByMass(temp);
            }
            return extraFuel;
        }

        public void CalcTotalFuel()
        {
            if (ModuleMass.GetLength(0) == 0)
                throw new SystemException("No module mass loaded");

            totalFuel = 0;

            ModuleFuel = new int[ModuleMass.GetLength(0)];

            for (int i = 0; i < ModuleFuel.GetLength(0); i++)
                ModuleFuel[i] = CalcFuelByMass(ModuleMass[i]);

            for (int i = 0; i < ModuleFuel.GetLength(0); i++)
                TotalFuel += ModuleFuel[i];
            
        }

        public void CalcTotalFuelWithFuelMassIncluded()
        {
            if (ModuleMass.GetLength(0) == 0)
                throw new SystemException("No module mass loaded");

            totalFuel = 0;

            ModuleFuel = new int[ModuleMass.GetLength(0)];

            for (int i = 0; i < ModuleFuel.GetLength(0); i++)
                ModuleFuel[i] =CalcFuelByMassAndFuel(ModuleMass[i]);

            for (int i = 0; i < ModuleFuel.GetLength(0); i++)
                TotalFuel += ModuleFuel[i];
        }

        public void Run(int i)
        {
            if(i==1)
            {
                CalcTotalFuel();
                Console.WriteLine($"Total amount of fuel needed for {ModuleMass.GetLength(0)} modules is: {TotalFuel}");
                

            }
            else if(i==2)
            {
                CalcTotalFuelWithFuelMassIncluded();
                Console.WriteLine($"Total amount of fuel needed for {ModuleMass.GetLength(0)} modules is: {TotalFuel}");

            }
            else
            {
                
            }
        }
    }
}