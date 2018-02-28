import junit.framework.AssertionFailedError;
import junit.framework.TestResult;
import org.junit.Test;

/**
 * Created by gaufung on 14/06/2017.
 */
public class TestJunit3 extends TestResult {

    public synchronized void addError(Test test, Throwable t){
        super.addError((junit.framework.Test)test, t);
    }

    public synchronized void addFailure(Test test, AssertionFailedError t){
        super.addFailure((junit.framework.Test)test, t);
    }

    @Test
    public void testAdd()
    {

    }
    public synchronized void stop(){

    }
}
