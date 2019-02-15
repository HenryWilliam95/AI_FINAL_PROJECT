//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public enum NodeStates
//{
//    FAILURE,
//    SUCCESS,
//    RUNNING
//}

//public class BehaviourTree
//{

//}


//// Base class for the nodes handled by the behaviour tree (BT)
//public abstract class Node
//{
//    public abstract NodeStates Run();
//}

//// A base composite node to handle the creation of lists to hold the children
//public abstract class CompositeNode : Node
//{
//    protected List<Node> m_children = new List<Node>();
//    public string compositeName;

//    // A base constructor to be used to set up the name and the children
//    public CompositeNode(string name, params Node[] children)
//    {
//        compositeName = name;
//        m_children.AddRange(children);
//    }

//    // Method to add children into the lists of nodes that inherit from the composite node
//    public void AddChildren(params Node[] children)
//    {
//        m_children.AddRange(children);
//    }

//    // Method to remove children into the lists of nodes that inherit from the composite node
//    public void ResetChildren()
//    {
//        foreach (Node node in m_children)
//        {
//            m_children.Remove(node);
//        }
//    }

//    // Method to get the children into the lists of nodes that inherit from the composite node
//    public List<Node> GetChildren()
//    {
//        return m_children;
//    }
//}

//// A sequence node runs through the children, if one node fails the sequence node fails
//public class Sequence : CompositeNode
//{
//    int activeChild = 0;

//    // Constructor that takes in a name and array of children, uses the parent's constructor to assign
//    public Sequence(string compositeName, params Node[] children) : base(compositeName, children) { }

//    public override NodeStates Run()
//    {
//        // Prepare a switch statement which checks the conditions of its children, if it's a success move onto the next child
//        // if a failure return to the parent with a failure code     
//        NodeStates behaviour = m_children[activeChild].Run();

//        switch (behaviour)
//        {
//            case NodeStates.SUCCESS:
//                activeChild++;
//                break;

//            //case NodeStates.RUNNING:
//            //  return behaviour;

//            // If a failure, don't wait to process other children, just return out
//            case NodeStates.FAILURE:
//                return NodeStates.FAILURE;
//        }

//        // If the sequence gets to the end of its children, then return a success to the parent
//        if (activeChild >= m_children.Count)
//        {
//            activeChild = 0;
//            return NodeStates.SUCCESS;
//        }   // if the child returns a success move onto the next child
//        else if (behaviour == NodeStates.SUCCESS)
//        {
//            return Run();
//        }

//        // If it is neither success or failure, must still be running
//        return NodeStates.RUNNING;
//    }
//}

//// A selector node runs through the children, however if one child returns a success the selector node is a success
//public class Selector : CompositeNode
//{
//    int activeChild = 0;

//    // Constructor that takes in a name and array of children, uses the parent's constructor to assign
//    public Selector(string compositeName, params Node[] children) : base(compositeName, children) { }

//    public override NodeStates Run()
//    {
//        NodeStates behaviour = m_children[activeChild].Run();

//        switch (behaviour)
//        {
//            // If the child is a success return to the parent 
//            case NodeStates.SUCCESS:
//                return NodeStates.SUCCESS;

//            //case NodeStates.RUNNING:
//            //  return behaviour;

//            case NodeStates.FAILURE:
//                activeChild++;

//                // If the child fails, move onto the next child
//                return Run();
//        }

//        // If it is neither success or failure, must still be running
//        return NodeStates.RUNNING;
//    }
//}

//public abstract class Leaf : Node { }
