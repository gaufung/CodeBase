package main

import (
	"fmt"
	"time"
)

func pumper() chan int{
	ch := make(chan int)
	go func(){
		for i:=0; i<10; i++{
			ch<-i
		}
	}()
	return ch
}

func cons(in chan int){
	for{
		fmt.Printf("%d\n", <-in)
	}
}

func main(){
	ch := pumper()
	go cons(ch)
	time.Sleep(2e9)
}
