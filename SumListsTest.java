import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;

import static org.hamcrest.core.Is.is;
import static org.junit.Assert.assertThat;

public class SumListsTest {

    @Test
    public void whenCreatedTwoLists() {
        SumLists sl = new SumLists();
        LinkedList result = new LinkedList();
        LinkedList n1 = new LinkedList();
        LinkedList n2 = new LinkedList();
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        n1.addInTail(node1);
        n1.addInTail(node2);
        n1.addInTail(node3);
        n2.addInTail(node1);
        n2.addInTail(node2);
        n2.addInTail(node3);
        result = sl.sumLists(n1, n2);
        assertThat(result.head.value, is(2));
        assertThat(result.head.next.value, is(4));
        assertThat(result.tail.value, is(6));
    }
}