# Double linked list
  Doubly linked list is a linked data structure that consists of a set of sequentially 
  linked records called nodes. Each node contains three fields: two link fields and one data field.

## Abstraction
  * ```csharp
    public interface INode<T> // node interface
    ```
    
  * ```csharp
    public interface ILinkedList<T> // linked list interface
    ```
## Concrete
  * ```csharp
    public class Node<T> : INode<T> // node
    ```
  * ```csharp
    public class LinkedList<T> : ILinkedList<T> // linked list
    ```

## Exceptions
  * ```csharp
    public class EmptyNodeException : Exception // throws if node.Next and node.Previous is null
    ```
  * ```csharp
    public class NotBelongToThisListException : Exception // throws if node is note belong to the linked list
    ```
    
### INode
  
  Properties:
  * ```csharp
    public T Data { get; set; } // data of node
    ```
  * ```csharp
    public INode<T> Previous { get; set; } // previous node
    ```
  * ```csharp 
    public INode<T> Next { get; set; } // next node
    ```
  
### ILinkedList
  
  Properties:
  * ```csharp
    public INode<T> Head { get; } // first node
    ```
  * ```csharp
    public INode<T> Tail { get; } // last node
    ```
  * ```chsarp
    public int Count { get; } // count of nodes
    ```
  * ```chsarp
    public bool IsEmpty { get; } // check is empty the linked list
    ```
   
  Methods: 
  * ```csharp 
    void AddAfter(INode<T> elem, T data); // add new element after an existing item
    ```
  * ```csharp
    INode<T> AddHead(T data); // add the elemnt before head
    ```
  * ```chsarp
    INode<T> AddTail(T data); // add the element after the Tail
    ```
  * ```csharp
    void RemoveAfter(INode<T> node); // remove element after existing item
    ```
  * ```csharp
    void RemoveHead(); // remove first node of list
    ```
  * ```csharp
    void RemoveTail(); // remove last node of  list
    ```
  * ```csharp
    void Reverse(); // reverse the list
    ```
  * ```csharp
    void Clear(); // clear all linked list
    ```
  * ```csharp
    INode<T> Find(T data); // find node by data
    ```
  * ```csharp
    bool Contains(T data); // search node which contains the data
    ```
  * ```csharp
    bool Contains(INode<T> elem); // search this node 
    ```
    
