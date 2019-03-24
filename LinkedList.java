import java.util.*;

public class LinkedList {
    public Node head;
    public Node tail;

    public LinkedList() {
        head = null;
        tail = null;
    }

    public void addInTail(Node item) {
        if (this.head == null) {
            this.head = item;
        } else {
            Node temp = this.head;
            while (temp.next != null) {
                temp = temp.next;
            }
            temp.next = new Node(item.value);
        }
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
        Node tmpNode = head;
        Node prevNode = null;
        boolean deletedResult = false;
        while (tmpNode != null) {
            if (tmpNode.value == _value) {
                if (tmpNode == this.head) {
                    this.head = this.head.next;
                } else {
                    prevNode.next = tmpNode.next;
                }
                deletedResult = true;
                break;
            } else {
                prevNode = tmpNode;
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
                } else {
                    prevNode.next = tmpNode.next;
                }
                deletedResult = true;
            } else {
                prevNode = tmpNode;
            }
            tmpNode = tmpNode.next;
        }
        return deletedResult;
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
        Node listNode = head;
        while (listNode != null) {
            count++;
            listNode = listNode.next;
        }
        return count;
    }

    public void insertAfter(Node _nodeAfter, Node _nodeToInsert) {
        Node newNode = new Node(_nodeToInsert.value);
        Node curr = head;
        while (curr != null) {
            if (curr.equals(_nodeAfter)) {
                newNode.next = curr.next;
                curr.next = newNode;
                break;
            } else {
                curr = curr.next;
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
