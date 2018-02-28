package main

import "fmt"
func fib() func() int{
	var a int = 0
	var b int = 1
	return func() int{
		b = a +b
		a = b - a
		return a
	}
}

func main(){
	var f = fib()
	for i:=1;i<10;i++{
		fmt.Print(f(), " ")
	}
}