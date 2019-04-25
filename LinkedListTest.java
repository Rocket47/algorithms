import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;

import static org.hamcrest.core.Is.is;
import static org.junit.Assert.assertThat;

public class LinkedListTest {

    LinkedList<Integer> list = new LinkedList<Integer>();
    list.LinkedList myList = new list.LinkedList();
    Node n1 = new Node(1);
    Node n2 = new Node(2);
    Node n3 = new Node(3);
    Node n4 = new Node(4);
    Node n5 = new Node(2);
    Node n6 = new Node(2);
    Node n7 = null;

    @Test
    public void whenListIsEmptyAddInTail() {
        list.addLast(1);
        myList.addInTail(n1);
        assertThat(list.getFirst(), is(myList.head.value));
        assertThat(list.getLast(), is(myList.tail.value));
    }

    @Test
    public void whenListHasOneElementAddInTail() {
        list.addLast(1);
        list.addLast(2);
        myList.addInTail(n1);
        myList.addInTail(n2);
        assertThat(list.getFirst(), is(myList.head.value));
        assertThat(list.getLast(), is(myList.tail.value));
    }

    @Test
    public void whenListHasSomeElementAddInTail() {
        list.addLast(1);
        list.addLast(2);
        list.addLast(3);
        list.addLast(4);
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        myList.addInTail(n4);
        assertThat(list.getFirst(), is(myList.head.value));
        assertThat(list.get(1), is(myList.head.next.value));
        assertThat(list.get(2), is(myList.head.next.next.value));
        assertThat(list.getLast(), is(myList.tail.value));
    }

    @Test
    public void whenListIsEmptyFind() {
        Node resultMyList = myList.find(1);
        Node nodeNull = null;
        assertThat(resultMyList, is(nodeNull));
    }

    @Test
    public void whenListHasOneElementFind() {
        list.addLast(1);
        myList.addInTail(n1);
        assertThat(list.get(0), is(myList.find(1).value));
    }

    @Test
    public void whenListHasSomeElementFind() {
        list.addLast(1);
        list.addLast(2);
        list.addLast(3);
        list.addLast(4);
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        myList.addInTail(n4);
        assertThat(list.get(0), is(myList.find(1).value));
        assertThat(list.get(1), is(myList.find(2).value));
        assertThat(list.get(2), is(myList.find(3).value));
        assertThat(list.get(3), is(myList.find(4).value));
    }

    @Test
    public void whenListIsEmptyFindAll() {
        ArrayList<Node> resultMyList = new ArrayList<>();
        ArrayList<Node> emptyArray = new ArrayList<>();
        resultMyList = myList.findAll(1);
        assertThat(resultMyList, is(emptyArray));
    }

    @Test
    public void whenListHasOneElementFindAll() {
        ArrayList<Node> resultMyList = new ArrayList<>();
        ArrayList<Node> testArray = new ArrayList<>();
        myList.addInTail(n1);
        testArray.add(n1);
        resultMyList = myList.findAll(1);
        assertThat(testArray, is(resultMyList));
    }

    @Test
    public void whenListHasSomeElementFindAll() {
        ArrayList<Node> resultMyList = new ArrayList<>();
        ArrayList<Node> testArray = new ArrayList<>();
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        myList.addInTail(n4);
        myList.addInTail(n5);
        myList.addInTail(n6);
        testArray.add(n2);
        testArray.add(n5);
        testArray.add(n6);
        resultMyList = myList.findAll(2);
        assertThat(testArray, is(resultMyList));
    }

    @Test
    public void whenListIsEmptyRemove() {
        boolean result;
        result = myList.remove(2);
        assertThat(result, is(false));
    }

    @Test
    public void whenListHasOneElement() {
        myList.addInTail(n1);
        myList.remove(1);
        list.addLast(1);
        list.remove(0);
        assertThat(myList.findAll(1), is(list));
    }

    @Test
    public void whenListHasSomeElement() {
        boolean result;
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        list.addLast(1);
        list.addLast(2);
        list.addLast(3);
        myList.remove(2);
        list.remove(1);
        assertThat(myList.head.value, is(list.getFirst()));
        assertThat(myList.tail.value, is(list.getLast()));
    }

    @Test
    public void whenListIsEmptyRemoveAll() {
        boolean result;
        result = myList.remove(2);
        assertThat(result, is(false));
    }

    @Test
    public void whenListHasOneElementRemoveAll() {
        myList.addInTail(n1);
        myList.removeAll(1);
        list.addLast(1);
        list.remove(0);
        assertThat(myList.findAll(1), is(list));
    }

    @Test
    public void whenListHasSomeElementRemoveAll() {
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        myList.addInTail(n5);
        myList.addInTail(n6);
        list.addLast(1);
        list.addLast(2);
        list.addLast(3);
        list.addLast(2);
        list.addLast(2);
        myList.removeAll(2);
        LinkedList<Integer> al = new LinkedList<>();
        al.add(2);
        list.removeAll(al);
        assertThat(myList.head.value, is(list.get(0)));
        assertThat(myList.head.next.value, is(list.get(1)));
    }

    @Test
    public void whenListIsEmptyClear() {
        myList.clear();
        assertThat(myList.head, is(n7));
        assertThat(myList.tail, is(n7));
        myList.addInTail(n1);
        assertThat(myList.head.value, is(1));
        assertThat(myList.tail.value, is(1));
        assertThat(myList.head.next, is(n7));
        assertThat(myList.tail.next, is(n7));
    }

    @Test
    public void whenListHasOneElementClear() {
        myList.addInTail(n1);
        myList.clear();
        assertThat(myList.head, is(n7));
        assertThat(myList.tail, is(n7));
        myList.addInTail(n1);
        assertThat(myList.head.value, is(1));
        assertThat(myList.tail.value, is(1));
    }

    @Test
    public void whenListHasSomeElementClear() {
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        myList.clear();
        assertThat(myList.head, is(n7));
        assertThat(myList.tail, is(n7));
        myList.addInTail(n1);
        assertThat(myList.head.value, is(1));
        assertThat(myList.tail.value, is(1));
    }

    @Test
    public void whenListIsEmptyCount() {
        int count = myList.count();
        assertThat(count, is(0));
    }

    @Test
    public void whenListHasOneElementCount() {
        myList.addInTail(n1);
        int count = myList.count();
        assertThat(count, is(1));
    }

    @Test
    public void whenListHasSomeElementCount() {
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        int count = myList.count();
        assertThat(count, is(3));
    }

    @Test
    public void whenListIsEmptyInsertAfter() {
        myList.insertAfter(n7, n2);
        assertThat(myList.head, is(n2));
        assertThat(myList.tail, is(n2));
    }

    @Test
    public void whenListHasOneElementInsertAfter() {
        myList.addInTail(n1);
        myList.insertAfter(n1, n2);
        assertThat(myList.head.value, is(n1.value));
        assertThat(myList.head.next.value, is(n2.value));
        assertThat(myList.tail.value, is(n2.value));
    }

    @Test
    public void whenListHasSomeElementInsertAfter() {
        myList.addInTail(n1);
        myList.addInTail(n2);
        myList.addInTail(n3);
        myList.insertAfter(n3, n4);
        assertThat(myList.head.value, is(n1.value));
        assertThat(myList.head.next.value, is(n2.value));
        assertThat(myList.head.next.next.value, is(n3.value));
        assertThat(myList.tail.value, is(n4.value));
    }


}
