/**
 * Created by gaufung on 14/06/2017.
 */
import org.junit.Test;
import static org.junit.Assert.*;
public class TestAssert {
    @Test
    public void testAdd(){
        int num = 5;
        String temp = null;
        String str = "junit is working fine";
        assertEquals("junit is working fine", str);

        assertFalse(num > 6);

        assertNull(temp);

    }

}
