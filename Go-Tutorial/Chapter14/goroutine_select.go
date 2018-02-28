package main

import (
	"fmt"
	"time"
)

func pump1(ch chan int){
	for i:=0;;i++{
		ch <- i*2
	}
}

func pump2(ch chan int){
	for i:=0;;i++{
		ch <- i+5
	}
}

func sucking(ch1, ch2 chan int){
	for{
		select {
		case v:= <- ch1:
			fmt.Printf("Receive data from channel1: %d\n", v)
		case v:= <- ch2:
			fmt.Printf("Receive data from channel2: %d\n", v)
		}
	}
}


func main(){
	ch1 := make(chan int)
	ch2 := make(chan int)
	go pump1(ch1)
	go pump2(ch2)
	go sucking(ch1, ch2)
	time.Sleep(1e9)
}