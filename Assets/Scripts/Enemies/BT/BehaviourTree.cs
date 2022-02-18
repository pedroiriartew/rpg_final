using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : Node
{
    public BehaviourTree()
    {
        name = "Tree";
    }

    public BehaviourTree(string p_name)
    {
        name = p_name;
    }

    public override Status Process()
    {
        return children[currentChild].Process();
    }



    public struct NodeLevel
    {
        public int level;
        public Node node;
    }

    public void StructPrintTree()
    {
        string treePrintout = "";
        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();

        Node currentNode = this;
        nodeStack.Push(new NodeLevel { level = 0, node = currentNode }) ;

        while (nodeStack.Count !=0)
        {
            NodeLevel nextNode = nodeStack.Pop();
            treePrintout += new string ('-',nextNode.level) + nextNode.node.name + "\n";
            for (int i = nextNode.node.children.Count - 1; i >= 0; i--)//Lo hacemos al revés para que los imprima en el orden correcto
            {
                nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.children[i] } );//We add the childern to the stack
            }
        }

        Debug.Log(treePrintout);
    }
}

//public void UnmodifiedPrintTree()
//{
//    string treePrintout = "";
//    Stack<Node> nodeStack = new Stack<Node>();

//    Node currentNode = this;
//    nodeStack.Push(currentNode);

//    while (nodeStack.Count != 0)
//    {
//        Node nextNode = nodeStack.Pop();
//        treePrintout += nextNode.name + "\n";
//        for (int i = nextNode.children.Count - 1; i >= 0; i--)//Lo hacemos al revés para que los imprima en el orden correcto
//        {
//            nodeStack.Push(nextNode.children[i]);//We add the childern to the stack
//        }
//    }

//    Debug.Log(treePrintout);
//}
