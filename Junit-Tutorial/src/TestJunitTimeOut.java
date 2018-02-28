import org.junit.Test;

/**
 * Created by gaufung on 15/06/2017.
 */
public class TestJunitTimeOut {

    @Test(timeout = 2000)
    public void testTimeout1() throws InterruptedException{
        Thread.sleep(2000);
    }

    @Test(timeout = 5000)
    public void testTimeout2() throws InterruptedException{
        Thread.sleep(2000);
    }

    @Test(timeout = 500)
    public void testTimeout3() throws InterruptedException{
        Thread.sleep(2000);
    }
}
