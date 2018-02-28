package main

import (
	"time"
	"fmt"
)

func main(){
	ch := make(chan int)
	go func(){
		time.Sleep(5*1e9)
		x:= <- ch
		fmt.Println("received: ", x)
	}()
	fmt.Println("sending", 10)
	//blocking
	ch <- 10
	fmt.Println("sent")
}