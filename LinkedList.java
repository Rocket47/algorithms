import java.util.*;

public class LinkedList {
    public Node head;
    public Node tail;

    public LinkedList() {
        head = null;
        tail = null;
    }

    public void addInTail(Node item) {
        if (this.head == null)
            this.head = item;
        else
            this.tail.next = item;
        this.tail = item;
    }

    public Node find(int value) {
        Node node = this.head;
        while (node != null) {
            if (node.value == value)
                return node;
            node = node.next;
        }
        return null;
    }

    public ArrayList<Node> findAll(int _value) {
        ArrayList<Node> nodes = new ArrayList<>();
        Node node = this.head;
        while (node != null) {
            if (node.value == _value) {
                nodes.add(node);
            }
            node = node.next;
        }
        return nodes;
    }

    public boolean remove(int _value) {
        Node storeHead = head;
        Node prevNode = null;
        boolean deletedResult = false;
        while (storeHead != null) {
            if (storeHead.value == _value) {
                if (storeHead == head) {
                    storeHead = head.next;
                } else {
                    prevNode.next = storeHead.next;
                }
                deletedResult = true;
                break;
            } else {
                prevNode = storeHead;
            }
            storeHead = storeHead.next;
        }
        return deletedResult; // если узел был удалён
    }

    public void removeAll(int _value) {
        Node storeHead = head;
        Node prevNode = null;
        boolean deletedResult = false;
        while (storeHead != null) {
            if (storeHead.value == _value) {
                if (storeHead == head) {
                    storeHead = head.next;
                } else {
                    prevNode.next = storeHead.next;
                }
                deletedResult = true;
            } else {
                prevNode = storeHead;
            }
            storeHead = storeHead.next;
        }
    }

    public void clear() {
        Node backup = null;
        while (head != null) {
            backup = head.next;
            head = null;
            head = backup;
        }
    }

    public int count() {
        int count = 0;
        while (head != null) {
            count++;
            head = head.next;
        }
        return count;
    }

    public void insertAfter(Node _nodeAfter, Node _nodeToInsert) {
        Node current = find(_nodeAfter.value);
        if (current == null) {
            current = current.next;
        }

        Node newNode = new Node(_nodeToInsert.value);
        if (current.next == null) {
            tail = newNode;
        }
        newNode.next = current.next;
        current.next = newNode;

    }
}

class Node {
    public int value;
    public Node next;

    public Node(int _value) {
        value = _value;
        next = null;
    }
}


