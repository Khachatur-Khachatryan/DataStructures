# Linked list
    Linked list is a linear collection of data elements whose order 
    is not given by their physical placement in memory.

## Abstraction

    * IElement<T> - interface for nodes in linked list
    * ILinkedList<T>  - interface for linked lists

## Concrete  

    * LinkedList<T> - class implements ILinkedList<T>
    * Element<T> - class implements IElement
  
## ILinkedList<T>

### Properties
  * ```csharp 
    public IElement<T> Head { get; } // first node  
    ``` 
  * ```csharp
    public IElement<T> Tail { get; } // last node 
    ```
  * ```csharp
    public int Count { get; } // count of nodes
    ```
  * ```csharp
    public bool IsEmpty { get; } // check is empty the linked list
    ```
  
### Methods
  * ```csharp
    public void AddAfter(IElement<T> elem, T data); // add new element after an existing item
    ```
  * ```csharp
    public IElement<T> AddHead(T data); // add the elemnt before head
    ```
  * ```csharp
    public IElement<T> AddTail(T data); // add the element after the tail
    ```
  * ```csharp
    public void RemoveAfter(IElement<T> elem); // remove element after existing item
    ```
  * ```csharp
    public void RemoveHead(); // remove first element of list
    ```
  * ```csharp
    public void RemoveTail(); // remove last element of  list  
    