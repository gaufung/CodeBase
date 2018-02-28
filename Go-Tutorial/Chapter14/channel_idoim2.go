package main

import (
	"fmt"
	"time"
)

func pp() chan int{
	ch := make(chan int)
	go func(){
		for i:=0; i<10; i++{
			ch<-i
		}
	}()
	return ch
}

func cc(ch chan int){
	go func(){
		for i:=range ch{
			fmt.Printf("%d", i)
		}
	}()
}

func main(){
	cc(pp())
	time.Sleep(1e9)
}