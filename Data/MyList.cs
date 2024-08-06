using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyList<T> : IEnumerable<T>
{
    private T[] array = new T[0];
    private int count = 0;
    public int Capcity
    {
        get { return array.Length; }
    }
    public int Count
    {
        get { return count; }
    }
    public void Add(T item)
    {
        if (array.Length == 0)
            array = new T[4];
        if (array.Length == count) {
            T[] temp = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++) {
                temp[i] = array[i];
            }
            array = temp;
        }
        array[count] = item;
        count++;
    }
    public T this[int index]
    {
        get {
            if ((index < 0) || (index > count - 1)) {
                throw new ArgumentOutOfRangeException(nameof(index), "数组索引超出");
                //System.Environment.Exit(0);
            }
            return array[index];
        }
        set { array[index] = value; }
    }
    /// <summary>
    /// 插入元素，不能超出数组的Count
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Insert(int index, T item)
    {
        if ((index < 0) || (index > count - 1)) {
            throw new ArgumentOutOfRangeException(nameof(index), "数组索引超出");
            //System.Environment.Exit(0);
        }
        for (int i = count - 1; i > index - 1; i--) {
            array[i + 1] = array[i];
        }
        array[index] = item;
        count++;
    }
    public void RemoveAt(int index)
    {
        if ((index < 0) || (index > count - 1)) {
            throw new ArgumentOutOfRangeException(nameof(index), "数组索引超出");
            //System.Environment.Exit(0);
        }
        for (int i = index + 1; i < count; i++) {
            array[i - 1] = array[1];
        }
        count--;
    }
    /// <summary>
    /// 从前往后数
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int IndexOf(T item)
    {
        int index = -1;
        for (int i = 0; i < count; i++) {
            if (item.Equals(array[i])) {
                index = i;
                break;
            }
        }
        return index;
    }
    /// <summary>
    /// 从后往前数
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int LastIndexOf(T item)
    {
        int index = -1;
        for (int i = count - 1; i >= 0; i--) {
            if (item.Equals(array[i])) {
                index = i;
                break;
            }
        }
        return index;
    }
    //public T[] Sort()
    //{
    //    dynamic c;
    //    for (int i = 0; i < count; i++) {
    //        for (int j = i; j < count - i - 1; j++) {
    //            if (Convert.ToInt32(array[j]) > Convert.ToInt32(array[j + 1])) {
    //                c = array[j];
    //                array[j] = array[j + 1];
    //                array[j + 1] = c;
    //            }
    //        }
    //    }
    //    return array;
    //}
    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator<T>(array);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
public class MyEnumerator<T> : IEnumerator<T>
{
    private T[] array;
    int current=-1;
    public MyEnumerator(T[] list)
    {
        array= list;
    }
    public T Current {
        get { return array[current]; }
    }
    object IEnumerator.Current
    {
        get { return current; }
    }
    public void Dispose()
    {
    }
    public bool MoveNext()
    {
        if (++current >= array.Length)
            return false;
        return true;
    }
    public void Reset()
    {
        current = -1;
    }
}

