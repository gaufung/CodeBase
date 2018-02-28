package edu.cumt.Array;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by gaufung on 12/06/2017.
 */
class BerylliumSphere{
    private static long counter;
    private final long id  = counter++;

    @Override
    public String toString() {
        return String.format("Sphere %d", id);
    }
}
public class ContainerComparison {
    public static void main(String[] args){
        BerylliumSphere[] spheres = new BerylliumSphere[10];
        for (int i = 0; i < 5; i++) {
            spheres[i] = new BerylliumSphere();
        }
        System.out.println(Arrays.toString(spheres));
        System.out.println(spheres[4]);
        List<BerylliumSphere> sphereList = new ArrayList<>();
        for (int i = 0; i < 5; i++) {
            sphereList.add(new BerylliumSphere());
        }
        System.out.println(sphereList);
        System.out.println(sphereList.get(4));

    }
}
