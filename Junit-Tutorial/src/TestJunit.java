import org.junit.Test;
import static org.junit.Assert.assertEquals;
/**
 * Created by gaufung on 14/06/2017.
 */
public class TestJunit {
    @Test
    public void testAdd() {
        String str = "Junit is working fine";
        assertEquals("Junit is working fine", str);
    }
}
