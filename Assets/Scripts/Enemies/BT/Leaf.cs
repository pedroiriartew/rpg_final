using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Node.Status Tick();

    public Tick ProcessMethod;

    public Leaf() { }

    public Leaf(string p_name, Tick p_processMethod)
    {
        name = p_name;
        ProcessMethod = p_processMethod;
    }

    public override Status Process()
    {
        if (ProcessMethod != null)
            return ProcessMethod();

        return Status.FAILURE;
    }
}
