package main

import (
	"time"
	"fmt"
)

func main(){
	c := make(chan int, 10)
	go func(){
		time.Sleep(2*1e9)
		for{
			x:= <- c
			fmt.Println("received ", x)
		}

	}()
	for i:= 0; i< 15; i++{
		fmt.Printf("sending %d\n", i)
		c <- i
		fmt.Printf("sent %d\n", i)
	}
}
