namespace CodeWars.Cli.LinkedLists;

public class LinkedListUtils
{
    public static int Length(Node head)
    {
        var temp = head;
        var len = 0;
        while (temp != null)
        {
            len++;
            temp = temp.Next;
        }
        return len;
    }
  
    public static int Count(Node head, Predicate<int> func)
    {
        var temp = head;
        var count = 0;
        while (temp != null)
        {
            if (func(temp.Data)) count++;
            temp = temp.Next;
        }
        return count;
    }    
    
    public static Node Push(Node? head, int data)
    {
        var node = new Node(data);
        node.Next = head;
        head = node;
        return head;
    }
  
    public static Node BuildOneTwoThree()
    {
        Node? head = null;
        head = LinkedListUtils.Push(head, 3);
        head = LinkedListUtils.Push(head, 2);
        head = LinkedListUtils.Push(head, 1);
        return head;
    }    
    
    public static Node GetNth(Node node, int index)
    {
        if (node == null) throw new ArgumentException();
        var head = node;
        var curr = head;
        var pos = 0;
        while (curr != null)
        {
            if (pos == index) return curr;
            curr = curr.Next;
            pos += 1;
        }
        throw new ArgumentException();
    }    
}