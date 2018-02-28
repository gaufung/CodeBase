import junit.framework.TestCase;
import org.junit.Before;

/**
 * Created by gaufung on 14/06/2017.
 */
public class TestTestCase extends TestCase{
    protected double fvalue1;
    protected double fvalue2;

    @Before
    public void setUp() {
        fvalue1 = 2.0;
        fvalue2 = 3.0;
    }

    public void testAdd() {
        System.out.println(String.format("No. of Test case = %d", this.countTestCases()));

        String name = this.getName();
        System.out.println(String.format("Test Case Name is:  %s", name));

        this.setName("testNewAdd");
        name = this.getName();
        System.out.println(String.format("Updated Test Case Name is: %s", name));

    }

    public void tearDown(){
        System.out.println("tear down");
    }


}
