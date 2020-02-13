import java.util.ArrayList;

public class SumLists {
    public LinkedList sumLists(LinkedList list1, LinkedList list2) {
        LinkedList result = new LinkedList();
        ArrayList<Integer> arrayList = new ArrayList<>();
        if (list1.count() != list2.count()) {
            return new LinkedList();
        } else {
            Node node1 = list1.head;
            Node node2 = list2.head;
            while (node1 != null && node2 != null) {
                arrayList.add(node1.value + node2.value);
                node1 = node1.next;
                node2 = node2.next;
            }
        }
        for (Integer j : arrayList) {
            result.addInTail(new Node(j));
        }
        return result;
    }
}