package edu.cumt.InnerClass;

/**
 * Created by gaufung on 09/06/2017.
 */

class MNA{
    private void f(){}
        class A {
            private void g(){}
            public class B{
                void h(){
                    g();
                    f();
                }
            }
        }
}
public class MultiNestingAccess {
    public static void main(String[] args){
        MNA mna = new MNA();
        MNA.A mnaa = mna.new A();
        MNA.A.B mnaab = mnaa.new B();
        mnaab.h();

    }
}
