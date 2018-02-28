import junit.framework.*;

/**
 * Created by gaufung on 14/06/2017.
 */
public class JavaTest extends TestCase {
    protected int value1, value2;

    @Override
    protected void setUp() throws Exception {
        value1 = 3;
        value2 = 3;
    }

    public void testAdd(){
        double result = value1+value2;
        assertTrue(result==6);
    }

}
