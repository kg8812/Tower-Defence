using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    readonly List<IObserver> observers = new();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }
    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyAll()
    {
        foreach(IObserver observer in observers)
        {
            observer.Notify(this);
        }
    }
}
