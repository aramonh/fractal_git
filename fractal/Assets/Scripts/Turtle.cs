using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle
{


    private class TurtleTransform
    {
        public Vector3 Position { get; }

        public Quaternion Orientation { get; }

        public TurtleTransform(Vector3 position, Quaternion orientation)
        {
            Position = position;
            Orientation = orientation;
        }
    }

    public Vector3 Position { get; private set; }

    public Quaternion Orientation { get; private set; }

    private Stack<TurtleTransform> stack = new Stack<TurtleTransform>();

    public Turtle(Vector3 position)
    {
        Position = position;
    }

    public void Translate(Vector3 delta)
    {
        delta = Orientation * delta;

        Debug.DrawLine(start:Position, end:Position+delta, Color.black , duration:100f);

        Position += delta;
    }

    public void Rotate(Vector3 delta) => Orientation = Quaternion.Euler(Orientation.eulerAngles + delta);

    public void Push() => stack.Push( item:new TurtleTransform(Position, Orientation));

    public void Pop()
    {
        var poppedTransform = stack.Pop();
        Position = poppedTransform.Position;
        Orientation = poppedTransform.Orientation;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
