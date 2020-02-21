
namespace BasicServiceLocator
{
    public interface IPeople : IHobby { }
    public interface IAnimal : IVoice { }
    public interface IHobby
    {
        void Hobby();
    }
    public interface IVoice
    {
        void Voice();
    }
}