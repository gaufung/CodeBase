package main

import (
	"fmt"
	"time"
)


const LIM = 41
var fibs [LIM]uint64

func main(){
	//var result  uint64 = 0
	//var f =fib3()
	start := time.Now()
	for i:=0; i<LIM;i++{
		//result = fib2(i)
		//fmt.Printf("fibonacci(%d) is: %d\n", i, result)
		//fmt.Print(f(), "\n")
		fmt.Print(fib4(i), "\n")
	}
	end:=time.Now()
	delta := end.Sub(start)
	fmt.Printf("longcalculation took this amount of time: %s\n", delta)
}

func fib2(n int)(res uint64){
	if fibs[n]!=0{
		res = fibs[n]
		return
	}
	if n<=1{
		res = 1
	}else{
		res = fib2(n-1) + fib2(n-2)
	}
	fibs[n]=res
	return
}
func fib3() func() int{
	var a int = 0
	var b int = 1
	return func() int{
		b = a +b
		a = b - a
		return a
	}
}

func fib4(n int) uint64{
	if n<=1{
		return uint64(n)
	}else{
		return fib4(n-1) + fib4(n-2)
	}
}