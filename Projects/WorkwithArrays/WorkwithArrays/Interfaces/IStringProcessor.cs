namespace WorkwithArrays
{
    public interface IStringOperator
    {
        string InsertXafterEachY(string str, char tofind, char toadd);
        string MixUp(string str);
        int MoreOften(string str, char c1, char c2);
        int CountFull(string str, char x, char y);
        int CountDifferent(string str);
        bool Hasadjacentcaracters(string str);
        string DeleteMiddle(string str);
        string DoubleX(string str, char x);
        string DeleteX(string str, char x);
        string DeleteSustr(string str, string substr);
        string ReplaceSubstr1WithSubstr2(string str, string substr1, string substr2);
        double CountSumOfNumbers(string str);
        long CountSumOfDigits(string str);
        void FirstAndLast(string str, char x, out int f, out int l);
        string ReplaceAdjacentDotsWith(string str, string substr);
        string DisplayCharsB(string str);
        string DisplayCharsA(string str);
        string DeleteFromParanthesize(string str);
        string DeleteFromCurlyBraces(string str);
        void DisplayStatstics(string str);

    }
}
