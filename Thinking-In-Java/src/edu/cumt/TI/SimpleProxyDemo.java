package edu.cumt.TI;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

/**
 * Created by gaufung on 11/06/2017.
 */

interface Interface{
    void doSomething();
    void somethingElse(String arg);
}
class RealObject implements  Interface{
    @Override
    public void doSomething() {
        System.out.println("Do Something");
    }

    @Override
    public void somethingElse(String arg) {
        System.out.println("Something Else " + arg);
    }
}
class SimpleProxy implements  Interface{
    private Interface proxied;
    public SimpleProxy(Interface proxid){
        this.proxied = proxid;
    }

    @Override
    public void doSomething() {
        System.out.println("Simple Proxy Do Something");
        this.proxied.doSomething();
    }

    @Override
    public void somethingElse(String arg) {
        System.out.println("SimpleProxy Something else "+arg);
        this.proxied.somethingElse(arg);
    }
}

class DynamicProxyHandle implements InvocationHandler{
    private Object proxid;
    public DynamicProxyHandle(Object proxid){
        this.proxid = proxid;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        if(args!=null)
            for(Object arg:args)
                System.out.println(arg);
        return method.invoke(proxid,args);
    }
}

public class SimpleProxyDemo {
    public static void consumer(Interface iface){
        iface.doSomething();
        iface.somethingElse("bonobo");
    }
    public static void main(String[] args){
//        consumer(new RealObject());
//        consumer(new SimpleProxy(new RealObject()));
        RealObject real = new RealObject();
        consumer(real);
        Interface proxy = (Interface) Proxy.newProxyInstance(
                Interface.class.getClassLoader(),
                new Class[]{ Interface.class },
                new DynamicProxyHandle(real));
        consumer(proxy);
    }
}
