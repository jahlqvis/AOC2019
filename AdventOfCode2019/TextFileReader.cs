namespace AdventOfCode2019
{
    
    public class TextFileReader
    {
        string[] lines;
        int numberOfLines;

        public string[] Lines { get => lines; set => lines = value; }
        public int NumberOfLines { get => numberOfLines; set => numberOfLines = value; }

        public TextFileReader(string filename)
        {
            Lines = System.IO.File.ReadAllLines(filename);
            NumberOfLines = Lines.GetLength(0);
        }
    }
}
