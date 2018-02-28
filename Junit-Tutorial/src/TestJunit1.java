import org.junit.Test;

import static org.junit.Assert.assertEquals;
/**
 * Created by gaufung on 14/06/2017.
 */
public class TestJunit1 {
    String message = "Robert";

    @Test
    public void TestPrintMessage(){
        System.out.println(message);
        assertEquals(message,"Robert");
    }
}
