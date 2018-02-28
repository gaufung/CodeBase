package edu.cumt.Generic;

import java.lang.reflect.Method;
import java.util.*;

/**
 * Created by gaufung on 11/06/2017.
 */
public class ContainerMethodDifference {
    static <T> Set<T> difference(Set<T> superset, Set<T> subset){
        Set<T> result = new HashSet<T>(superset);
        result.removeAll(subset);
        return result;
    }
    static Set<String> methodsSet(Class<?> type){
        Set<String> result = new TreeSet<>();
        for(Method m:type.getMethods())
            result.add(m.getName());
        return result;
    }
    static void interfaces(Class<?> type){
        System.out.println(String.format("Interface in %s", type.getSimpleName()));
        List<String> result = new ArrayList<>();
        for(Class<?> cls:type.getInterfaces())
            result.add(cls.getSimpleName());
        System.out.println(result);
    }
    static Set<String> object = methodsSet(Object.class);
    static {object.add("clone");}
    static void difference(Class<?> superset, Class<?> subset){
        System.out.println(String.format("%s extends %s, adds: ",
                superset.getSimpleName(),subset.getSimpleName()));
        Set<String> comp = difference(methodsSet(superset), methodsSet(subset));
        comp.removeAll(object);
        System.out.println(comp);
        interfaces(superset);
    }
    public static void main(String[] args){
        System.out.println("Collection: " +
                methodsSet(Collection.class));
        interfaces(Collection.class);
        difference(Set.class, Collection.class);
        difference(HashSet.class, Set.class);
        difference(LinkedHashSet.class, HashSet.class);
        difference(TreeSet.class, Set.class);
        difference(List.class, Collection.class);
        difference(ArrayList.class, List.class);
        difference(LinkedList.class, List.class);
        difference(Queue.class, Collection.class);
        difference(PriorityQueue.class, Queue.class);
        System.out.println("Map: " + methodsSet(Map.class));
        difference(HashMap.class, Map.class);
    }
}
