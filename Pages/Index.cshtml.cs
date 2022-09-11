using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Diagnostics;

namespace MagicSquareSolver.Pages
{
    public class IndexModel : PageModel
    {
        public string Solve1 => (string)TempData[nameof(Solve1)];
        public string Solve2 => (string)TempData[nameof(Solve2)];
        public string Solve3 => (string)TempData[nameof(Solve3)];
        public string Solve4 => (string)TempData[nameof(Solve4)];
        public string Solve5 => (string)TempData[nameof(Solve5)];
        public string Solve6 => (string)TempData[nameof(Solve6)];
        public string Solve7 => (string)TempData[nameof(Solve7)];
        public string Solve8 => (string)TempData[nameof(Solve8)];
        public string Solve9 => (string)TempData[nameof(Solve9)];

        private readonly ILogger<IndexModel> _logger;
        private string[] _resultStringList = new string[9];
        private static List<string> _listOfAllPossibleCombinationsFirstRow = GenerateListOfAllPossibleThreeCombinationsNumbers();
        private static List<string> _listOfAllPossibleCombinationsColumns = GenerateListOfAllPossibleTwoCombinationsNumbers();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPostResolveMagicSquare(string input1, string input2, string input3, string input4, string operation5, string operation6, string input7, string operation8,
            string operation9, string operation10, string input11, string operation12, string operation13, string input14, string operation15, string operation16, string operation17,
            string input18, string operation19, string operation20, string input21, string input22, string input23, string input24)
        {
            Calculate(input1, input2, input3, input4, operation5, operation6, input7, operation8, operation9, operation10, input11, operation12, operation13, input14, operation15,
                operation16, operation17, input18, operation19, operation20, input21, input22, input23, input24);

            Console.WriteLine("----------");
            Console.WriteLine("Solve:");
            Console.WriteLine(_resultStringList[0] + " " + _resultStringList[1] + " " + _resultStringList[2]);
            Console.WriteLine(_resultStringList[3] + " " + _resultStringList[4] + " " + _resultStringList[5]);
            Console.WriteLine(_resultStringList[6] + " " + _resultStringList[7] + " " + _resultStringList[8]);

            TempData["Solve1"] = _resultStringList[0];
            TempData["Solve2"] = _resultStringList[1];
            TempData["Solve3"] = _resultStringList[2];
            TempData["Solve4"] = _resultStringList[3];
            TempData["Solve5"] = _resultStringList[4];
            TempData["Solve6"] = _resultStringList[5];
            TempData["Solve7"] = _resultStringList[6];
            TempData["Solve8"] = _resultStringList[7];
            TempData["Solve9"] = _resultStringList[8];
        }


        private void Calculate(string input1, string input2, string input3, string input4, string operation5, string operation6, string input7, string operation8,
            string operation9, string operation10, string input11, string operation12, string operation13, string input14, string operation15, string operation16, string operation17,
            string input18, string operation19, string operation20, string input21, string input22, string input23, string input24)
        {
            foreach (var possibleCombinationFirstRow in _listOfAllPossibleCombinationsFirstRow)
            {
                if (Validate(Convert.ToInt32(possibleCombinationFirstRow.Substring(0, 1)), operation5, Convert.ToInt32(possibleCombinationFirstRow.Substring(1, 1)), operation6, Convert.ToInt32(possibleCombinationFirstRow.Substring(2, 1)), input7))
                {
                    _resultStringList[0] = possibleCombinationFirstRow.Substring(0, 1).ToString();
                    _resultStringList[1] = possibleCombinationFirstRow.Substring(1, 1).ToString();
                    _resultStringList[2] = possibleCombinationFirstRow.Substring(2, 1).ToString();

                    foreach (var possibleCombinationColumn in _listOfAllPossibleCombinationsColumns)
                    {
                        if (Validate(Convert.ToInt32(possibleCombinationFirstRow.Substring(0,1)), operation8, Convert.ToInt32(possibleCombinationColumn.Substring(0, 1)), operation15, Convert.ToInt32(possibleCombinationColumn.Substring(1, 1)), input22))
                        {
                            _resultStringList[3] = possibleCombinationColumn.Substring(0, 1).ToString();
                            _resultStringList[6] = possibleCombinationColumn.Substring(1, 1).ToString();

                            foreach (var possibleCombinationColumn2 in _listOfAllPossibleCombinationsColumns)
                            {
                                if (Validate(Convert.ToInt32(possibleCombinationFirstRow.Substring(1, 1)), operation9, Convert.ToInt32(possibleCombinationColumn2.Substring(0, 1)), operation16, Convert.ToInt32(possibleCombinationColumn2.Substring(1, 1)), input23))
                                {
                                    _resultStringList[4] = possibleCombinationColumn2.Substring(0, 1).ToString();
                                    _resultStringList[7] = possibleCombinationColumn2.Substring(1, 1).ToString();

                                    foreach (var possibleCombinationColumn3 in _listOfAllPossibleCombinationsColumns)
                                    {
                                        if (Validate(Convert.ToInt32(possibleCombinationFirstRow.Substring(2, 1)), operation10, Convert.ToInt32(possibleCombinationColumn3.Substring(0, 1)), operation17, Convert.ToInt32(possibleCombinationColumn3.Substring(1, 1)), input24))
                                        {
                                            _resultStringList[5] = possibleCombinationColumn3.Substring(0, 1).ToString();
                                            _resultStringList[8] = possibleCombinationColumn3.Substring(1, 1).ToString();

                                            if (Validate(Convert.ToInt32(_resultStringList[3]), operation12, Convert.ToInt32(_resultStringList[4]), operation13, Convert.ToInt32(_resultStringList[5]), input14))
                                            {
                                                if (Validate(Convert.ToInt32(_resultStringList[6]), operation19, Convert.ToInt32(_resultStringList[7]), operation20, Convert.ToInt32(_resultStringList[8]), input21))
                                                {
                                                    Console.WriteLine("Return solve!");
                                                    return;
                                                }
                                            }

                                        }
                                    }

                                }
                            }

                        }
                    }
                }
            }

            TempData["Solve1"] = "";
            TempData["Solve2"] = "";
            TempData["Solve3"] = "";
            TempData["Solve4"] = "";
            TempData["Solve5"] = "";
            TempData["Solve6"] = "";
            TempData["Solve7"] = "";
            TempData["Solve8"] = "";
            TempData["Solve9"] = "";

            Console.WriteLine("Error, no solve :/");
            return;
        }

        private static List<string> GenerateListOfAllPossibleThreeCombinationsNumbers()
        {
            List<string> listReturn = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                if(!i.ToString("D3").Contains("0"))
                    listReturn.Add(i.ToString("D3"));
            }

            return listReturn;
        }

        private static List<string> GenerateListOfAllPossibleTwoCombinationsNumbers()
        {
            List<string> listReturn = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                if (!i.ToString("D2").Contains("0"))
                    listReturn.Add(i.ToString("D2"));
            }

            return listReturn;
        }

        private bool Validate(int input1, string operation2, int input3, string operation4, int input5, string result)
        {
            if (operation4 == "x" || operation4 == "X" || operation4 == "*" || operation4 == "/" || operation4 == ":")
            {
                var partialResult = DoOperation(input3, operation4, input5);
                var finalResult = DoOperation(input1, operation2, partialResult);
                return finalResult == Convert.ToInt32(result);
            }
            else
            {
                var partialResult = DoOperation(input1, operation2, input3);
                var finalResult = DoOperation(partialResult, operation4, input5);
                return finalResult == Convert.ToInt32(result);
            }
        }

        private int DoOperation(int value1, string operation2, int value3)
        {
            switch(operation2)
            {
                case "+":
                    return value1 + value3;
                case "-":
                    return value1 - value3;
                case "*":
                case "x":
                case "X":
                    return value1 * value3;
                case "/":
                case ":":
                    return value1 / value3;
                default:
                    throw new Exception("Invalid operation char");
            }
        }
    }
}