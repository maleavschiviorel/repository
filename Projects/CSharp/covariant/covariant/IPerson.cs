namespace covariant
{
    public interface IPerson
    {
        int Age { get; set; }
        string Code { get; set; }
        string Name { get; set; }

        string ToString();
        string ToString1(string str);
    }
}