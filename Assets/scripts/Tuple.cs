using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuple<T,A>  {

    public T item1 { get; set; }
    public A item2 { get; set; }

    public Tuple(T item1,A item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }
}
