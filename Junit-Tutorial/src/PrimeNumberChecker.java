/**
 * Created by gaufung on 15/06/2017.
 */
public class PrimeNumberChecker {
   public Boolean validation(final Integer primeNumber){
       for (int i = 2; i < (primeNumber / 2); i++) {
           if(primeNumber % i ==0){
               return false;
           }
       }
       return true;
   }
}
