using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEvent<T>
{
    void Raise(T item);
}

public interface IGameEvent<T1, T2>
{
    void Raise(T1 item1, T2 item2);
}

public interface IGameEvent<T1, T2, T3>
{
    void Raise(T1 item1, T2 item2, T3 item3);
}
