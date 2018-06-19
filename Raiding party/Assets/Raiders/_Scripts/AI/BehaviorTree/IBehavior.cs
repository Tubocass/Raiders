public interface IBehavior
{
    void OnInitialize();
    void OnTerminate(Behavior.Status status);
    Behavior.Status Update();
}