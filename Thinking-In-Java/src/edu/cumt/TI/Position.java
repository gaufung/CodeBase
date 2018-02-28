package edu.cumt.TI;

/**
 * Created by gaufung on 11/06/2017.
 */
public class Position {
    private String title;
    private Person person;
    public Position(String jobtitle, Person employee){
        this.title = jobtitle;
        this.person = employee == null?
                      Person.NULL:
                      employee;

    }
    public Position(String jobtitle){
            this.title = jobtitle;
    }
}
