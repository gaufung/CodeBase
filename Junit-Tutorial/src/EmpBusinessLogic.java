/**
 * Created by gaufung on 14/06/2017.
 */
public class EmpBusinessLogic {
    public double calculateYearlySalary(EmpolyeeDetails employeeDetails){
        double yearlySalary = employeeDetails.getMonthlySalary() * 12;
        return yearlySalary;
    }

    public double calculateAppraisal(EmpolyeeDetails empolyeeDetails){
        double appraisal = 0.0;
        if(empolyeeDetails.getMonthlySalary() < 10000){
            appraisal = 500;
        }else{
            appraisal = 1000;
        }
        return appraisal;
    }
}
