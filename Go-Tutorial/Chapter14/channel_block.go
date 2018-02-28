package main

import (
	"fmt"
	"time"
)

func pump(ch chan int){
	for i:=0;;i++{
		ch <- i
	}
}

func suck(ch chan int){
	for {
		fmt.Printf("%d\n", <-ch)
	}
}

func main(){
	ch1 := make(chan int)
	go suck(ch1)
	go pump(ch1)

	time.Sleep(100e9)
}
