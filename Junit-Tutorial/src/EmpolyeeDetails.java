/**
 * Created by gaufung on 14/06/2017.
 */
public class EmpolyeeDetails {
    private String name;
    private double monthlySalary;
    private int age;

    public String getName(){
        return name;
    }
    public void setName(String name){
        this.name = name;
    }
    public double getMonthlySalary(){
        return this.monthlySalary;
    }

    public void setMonthlySalary(double monthlySalary){
        this.monthlySalary = monthlySalary;
    }
    public int getAge(){
        return this.age;
    }
    public void setAge(int age){
        this.age = age;
    }

}
