import org.junit.Test;

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
    Node n5 = new Node(5);

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
}