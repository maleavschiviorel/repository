namespace covariant
{
    public interface IFactory<out T>
    { T Create(); }
}