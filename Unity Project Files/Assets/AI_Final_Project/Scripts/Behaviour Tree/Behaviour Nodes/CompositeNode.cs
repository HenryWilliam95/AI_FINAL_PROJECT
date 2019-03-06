using System.Collections.Generic;

public class CompositeNode : Node
{
    protected List<Node> children = new List<Node>();
    protected int currentChild;

    public string nodeName;

    public List<Node> GetChildren() { return children; }

    public CompositeNode( string name, params Node[] child)
    {
        nodeName = name;
        children.AddRange(child);
    }
}

public class SelectorNode : CompositeNode
{
    // Build a Selector Node with a name and children
    public SelectorNode(string name, params Node[] child) : base(name, child) { }

    // When node is created or finished, reset the iterator for the list of children
    public override void OnStart(){ currentChild = 0; }
    public override void OnTerminate(Status _status) { currentChild = 0; }

    public override Status Run()
    {
        // Loop through all children in the list
        foreach  (Node child in GetChildren())
        {
            Status status = child.Tick(); // Get the status of the current child

            // If the child wasn't a failure inform the parent node of the success
            if (status != Status.FAILURE)
            {
                return status;
            }

            // If we reach the end of the list of children so return a failure to the parent
            if (++currentChild == GetChildren().Count)
            {
                return Status.FAILURE;
            }
        }
        // Loop ended unexpectedly
        return Status.INVALID;
    }
}

public class SequenceNode : CompositeNode
{
    public SequenceNode(string name, params Node[] child) : base(name, child) { }

    // When node is created or finished, reset the iterator for the list of children
    public override void OnStart() { currentChild = 0;}
    public override void OnTerminate(Status _status) { currentChild = 0; }

    public override Status Run()
    {
        // Loop through all children in the list
        foreach (Node child in GetChildren())
        {
            Status status = child.Tick(); // Get the status of the current child

            // If the child isn't successful, inform parent
            if (status != Status.SUCCESS)
            {
                return status;
            }

            // If we have reached the end of the list, then the sequence has succeeded
            if (++currentChild == GetChildren().Count)
            {
                return Status.SUCCESS;
            }
        }
        // Loop ended unexpectedly
        return Status.INVALID; 
    }
}
