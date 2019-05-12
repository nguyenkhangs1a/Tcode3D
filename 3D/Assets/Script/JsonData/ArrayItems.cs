using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class ArrayItems  {
    public string name = "";
    public ItemOBJ[] itemObjs;
    public void CreateArrayObject()
    {
        itemObjs = new ItemOBJ[10];
        for(int i=1;i<=10;i++)
        {
            ItemOBJ item = new ItemOBJ();
            item.coin = 1;
            itemObjs[i-1] = item;
        }
    }
}
