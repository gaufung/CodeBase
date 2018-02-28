import org.junit.*;

/**
 * Created by gaufung on 15/06/2017.
 */
public class ExecutionProcedureJunit {
    @BeforeClass
    public static void beforeClass(){
        System.out.println("in before class");
    }

    @AfterClass
    public static void afterClass(){
        System.out.println("in after class");
    }

    @Before
    public void before(){
        System.out.println("in before");
    }

    @After
    public void after(){
        System.out.println("in after");
    }

    @Test
    public void test1(){
        System.out.println("in test case 1");
    }

    @Test
    public void test2(){
        System.out.println("in test case 2");
    }
}
