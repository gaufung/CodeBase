import org.junit.Assert;
import org.junit.Test;

/**
 * Created by gaufung on 14/06/2017.
 */
public class TestEmployDetails {
    EmpBusinessLogic empBusinessLogic = new EmpBusinessLogic();
    EmpolyeeDetails employee = new EmpolyeeDetails();

    @Test
    public void testCalculateAppriasal()
    {
        employee.setName("Rajeev");
        employee.setAge(25);
        employee.setMonthlySalary(8000);
        double appraisal = empBusinessLogic.calculateAppraisal(employee);
        Assert.assertEquals(500,appraisal,0.0);
    }
    @Test
    public void testCalculateYearlySalary() {
        employee.setName("Rajeev");
        employee.setAge(25);
        employee.setMonthlySalary(8000);

        double salary = empBusinessLogic.calculateYearlySalary(employee);
        Assert.assertEquals(96000, salary, 0.0);
    }
}
