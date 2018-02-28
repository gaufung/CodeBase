package main

import (
	"fmt"
	"time"
)


func main(){
	ch1 := pump1()
	ch2 := pump2()
	go suck(ch1, ch2)
	time.Sleep(1*1e9)
}

func pump1() chan int{
	ch := make(chan int)
	go func(){
		for i:=0; ; i++{
			ch <- i * 2
		}
	}()
	return ch
}

func pump2() chan int{
	ch := make(chan int)
	go func(){
		for i:=0; ; i++{
			ch <- i + 5
		}
	}()
	return ch
}

func suck(ch1, ch2 chan int){
	for {
		select {
		case v:=<-ch1:
			fmt.Printf("Received on channel 1: %d\n", v)
		case v:=<-ch2:
			fmt.Printf("Received on channel 2: %d\n", v)
		}
	}
}
