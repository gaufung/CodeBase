package main

import (
	"time"
	"fmt"
)

func dup3(in chan int)(chan int,chan int, chan int){
	a, b, c := make(chan int), make(chan int), make(chan int)
	go func(){
		for{
			x:=<-in
			a <- x
			b <- x
			c <- x
		}
	}()
	return a, b, c
}

func fib3() chan int{
	x:=make(chan int, 2)
	a, b, out := dup3(x)
	go func(){
		x<-0
		x<-1
		<-a
		for{
			x<- <-a + <-b
		}
	}()
	return out
}

func main(){
	start:=time.Now()
	x := fib3()
	for i:=0;i<10;i++{
		fmt.Println(<-x, " ")
	}
	end := time.Now()
	delta := end.Sub(start)
	fmt.Println("took time: ", delta)
}