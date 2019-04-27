import java.util.*;

public class LinkedList {
    public Node head;
    public Node tail;

    public LinkedList() {
        head = null;
        tail = null;
    }

    public void addInTail(Node item) {
        item.next = null;
        if (this.head == null) {
            this.head = item;
        } else {
            this.tail.next = item;
        }
        this.tail = item;
    }

    public Node find(int value) {
        Node tmp = this.head;
        while (tmp != null) {
            if (tmp.value == value) {
                return tmp;
            } else {
                tmp = tmp.next;
            }
        }
        return null;
    }

    public ArrayList<Node> findAll(int value) {
        ArrayList<Node> nodes = new ArrayList<>();
        Node node = this.head;
        while (node != null) {
            if (node.value == value) {
                nodes.add(node);
            }
            node = node.next;
        }
        return nodes;
    }

    public boolean remove(int _value) {
        Node tmpNode = this.head;
        Node prevNode = null;      
        boolean deletedResult = false;
        while (tmpNode != null) {
            if (tmpNode.value != _value) {
                prevNode = tmpNode;
            } else if (tmpNode.value == _value && prevNode != null) {
                if (tmpNode.next != null) {
                    prevNode.next = tmpNode.next;
                } else {
                    prevNode.next = null;
                    this.tail = prevNode;
                    this.tail.next = null;
                }
                deletedResult = true;
                break;
            } else if (tmpNode.value == _value && prevNode == null) {
                this.head = this.head.next;
                if (this.head == null) {
                    this.tail = null;
                }
                deletedResult = true;
                break;
            }
            tmpNode = tmpNode.next;
        }
        return deletedResult;
    }

    public boolean removeAll(int _value) {
        Node tmpNode = head;
        Node prevNode = null;
        boolean deletedResult = false;
        while (tmpNode != null) {
            if (tmpNode.value == _value) {
                if (tmpNode == this.head) {
                    this.head = this.head.next;
                    this.tail = this.head;
                } else {
                    prevNode.next = tmpNode.next;
                }
                deletedResult = true;
            } else {
                prevNode = tmpNode;
            }
            tmpNode = tmpNode.next;
            this.tail = prevNode;
        }
        return deletedResult;
    }

    public void clear() {
        this.head = null;
        this.tail = null;
    }

    public int count() {
        int count = 0;
        Node listNode = head;
        while (listNode != null) {
            count++;
            listNode = listNode.next;
        }
        return count;
    }

    public void insertAfter(Node _nodeAfter, Node _nodeToInsert) {
        Node node = this.head;
        Node newNode = new Node(_nodeToInsert.value);
        if (_nodeAfter == null && node == null) {
            this.head = _nodeToInsert;
            this.tail = _nodeToInsert;
        }
        while (node != null) {
            if (node.equals(_nodeAfter)) {
                newNode.next = node.next;
                node.next = newNode;
                this.tail = newNode;
                break;
            } else {
                node = node.next;
            }
        }
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