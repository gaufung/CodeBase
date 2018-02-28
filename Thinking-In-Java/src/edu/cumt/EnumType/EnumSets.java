package edu.cumt.EnumType;

import java.util.EnumSet;

/**
 * Created by gaufung on 14/06/2017.
 */
enum AlarmPoints{
    STAIR1,
    STAIR2,
    LOBBY,
    OFFICE1,
    OFFICE2,
    OFFICE3,
    OFFICE4,
    BATHROOM,
    UTILITY,
    KITCHEN
}
public class EnumSets {
    public static void main(String[] args){
        EnumSet<AlarmPoints> points=
                EnumSet.noneOf(AlarmPoints.class);
        points.add(AlarmPoints.BATHROOM);
        System.out.println(points);
        points.addAll(EnumSet.of(AlarmPoints.STAIR1,AlarmPoints.STAIR2,AlarmPoints.KITCHEN));
        System.out.println(points);
        points  = EnumSet.allOf(AlarmPoints.class);
        points.removeAll(EnumSet.of(AlarmPoints.STAIR1,AlarmPoints.STAIR2,AlarmPoints.KITCHEN));
        System.out.println(points);
    }
}
