import org.junit.Test;

import java.io.IOException;

/**
 * Created by gaufung on 15/06/2017.
 */
public class TestJunitExpect {

    @Test(expected = IOException.class)
    public void testExpection() throws IOException{
        throw new IOException();
    }
}
