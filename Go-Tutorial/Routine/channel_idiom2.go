package main

import (
	"fmt"
	"time"
)

func main(){
	suck(pump())
	time.Sleep(1*1e9)
}

func pump() chan int{
	ch := make(chan int)
	go func(){
		for i:=0; ;i++{
			ch <- i
		}
	}()
	return ch
}

func suck(ch chan int){
	go func(){
		for value := range ch{
			fmt.Printf("%d\n", value)
		}
	}()
}