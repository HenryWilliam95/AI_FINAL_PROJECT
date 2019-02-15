public enum Status
{
    SUCCESS, FAILURE, RUNNING, INVALID
}

public class Node
{
    public virtual Status Run() { return Status.INVALID; }

    public virtual void OnStart() { }
    public virtual void OnTerminate(Status _status) { }

    private Status status;

    public Node()
    {
        status = Status.INVALID;
    }

    public Status Tick()
    {
        if (status == Status.INVALID)
        {
            OnStart();
        }

        status = Run();

        if (status != Status.RUNNING)
        {
            OnTerminate(status);
        }
        return status;
    }

    Status GetStatus() { return status; }

    void SetStatus(Status newStatus) { status = newStatus; }

}
